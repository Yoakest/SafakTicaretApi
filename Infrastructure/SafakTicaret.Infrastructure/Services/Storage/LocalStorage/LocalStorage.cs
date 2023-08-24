using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using SafakTicaret.Application.Storage.Local;
using SafakTicaret.Infrastructure.Services.Storage.Storage;

namespace SafakTicaret.Infrastructure.Services.Storage.LocalStorage
{
	public class LocalStorage : BaseStorage, ILocalStorage
	{

		readonly IWebHostEnvironment _webHostEnvironment;

		public LocalStorage(IWebHostEnvironment webHostEnvironment)
		{
			_webHostEnvironment = webHostEnvironment;
		}



		public async Task<List<(string fileName, string path)>> UploadAsync(string path, IFormFileCollection files)
		{
			string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, path);
			if (!Directory.Exists(uploadPath))
				Directory.CreateDirectory(uploadPath);


			List<(string fileName, string path)> datas = new();
			List<bool> results = new();
			foreach (IFormFile file in files)
			{
				string fileSaveName = await FileRenameAsync(path, file.Name, HasFile);


				//string fileNewName = await FileRenameAsync(uploadPath, file.FileName);
				//string fileNewName = file.FileName;

				bool result = await CopyFileAsync($"{uploadPath}\\{fileSaveName}", file);
				results.Add(result);
				datas.Add((fileSaveName, $"{path}\\{fileSaveName}"));
			}


			if (results.TrueForAll(r => r.Equals(true)))
				return datas;

			return null;
		}

		public async Task<bool> CopyFileAsync(string path, IFormFile file)
		{
			try
			{
				await using FileStream fileStream = new(path, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, useAsync: false);

				await file.CopyToAsync(fileStream);
				await fileStream.FlushAsync();
				return true;
			}
			catch (Exception ex)
			{
				//todo log
				throw ex;
			}
		}






		public async Task DeleteAsync(string path, string fileName)
			=> File.Delete($"{path}\\{fileName}");


		public List<string> GetFiles(string path)
		{
			DirectoryInfo directory = new DirectoryInfo(path);
			return directory.GetFiles().Select(f => f.Name).ToList();
		}

		public bool HasFile(string path, string fileName)
			=> File.Exists($"{path}\\{fileName}");

	}
}
