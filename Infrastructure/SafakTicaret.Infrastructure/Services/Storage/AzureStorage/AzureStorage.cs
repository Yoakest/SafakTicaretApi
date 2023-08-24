using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using SafakTicaret.Application.Storage.Azure;
using SafakTicaret.Infrastructure.Services.Storage.Storage;

namespace SafakTicaret.Infrastructure.Services.Storage.AzureStorage
{
	public class AzureStorage : BaseStorage, IAzureService
	{

		readonly BlobServiceClient _blobServiceClient;
		BlobContainerClient _blobContainerClient;

		public AzureStorage(IConfiguration configuration)
		{
			_blobServiceClient = new(configuration["Storage:Azure:Key"]);

		}

		public async Task DeleteAsync(string container, string fileName)
		{
			_blobContainerClient = _blobServiceClient.GetBlobContainerClient(container);
			await _blobContainerClient.GetBlobClient(fileName).DeleteAsync();
		}

		public List<string> GetFiles(string container)
		{
			_blobContainerClient = _blobServiceClient.GetBlobContainerClient(container);
			return _blobContainerClient.GetBlobs().Select(b => b.Name).ToList();

		}

		public bool HasFile(string container, string fileName)
		{
			_blobContainerClient = _blobServiceClient.GetBlobContainerClient(container);
			return _blobContainerClient.GetBlobs().Any(b => b.Name == fileName);
		}

		public async Task<List<(string fileName, string path)>> UploadAsync(string container, IFormFileCollection files)
		{
			_blobContainerClient = _blobServiceClient.GetBlobContainerClient(container);

			await _blobContainerClient.CreateIfNotExistsAsync();
			await _blobContainerClient.SetAccessPolicyAsync(Azure.Storage.Blobs.Models.PublicAccessType.BlobContainer);

			List<(string fileName, string path)> datas = new();
			foreach (var file in files)
			{
				string fileSaveName = await FileRenameAsync(container, file.Name, HasFile);

				BlobClient blobClient = _blobContainerClient.GetBlobClient(fileSaveName);
				await blobClient.UploadAsync(file.OpenReadStream());
				datas.Add((fileSaveName, $"{container}/{fileSaveName}"));
			}
			return datas;
		}
	}
}
