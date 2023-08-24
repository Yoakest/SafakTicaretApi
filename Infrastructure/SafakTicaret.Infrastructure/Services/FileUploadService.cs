using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using SafakTicaret.Application.Services;
using SafakTicaret.Infrastructure.StaticServices;

namespace SafakTicaret.Infrastructure.Services
{
	public class FileUploadService : IFileUploadService
	{

		readonly IWebHostEnvironment _webHostEnvironment;

		public FileUploadService(IWebHostEnvironment webHostEnvironment)
		{
			_webHostEnvironment = webHostEnvironment;
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



		async Task<string> FileRenameAsync(string path, string fileName)
		{
			string extension = Path.GetExtension(fileName);
			string oldName = Path.GetFileNameWithoutExtension(fileName);
			string newName = $"{NameOperations.CharacterRegulatory(oldName)}{extension}";

			if (File.Exists($"{path}\\{newName}"))
			{
				string newNameNoExtension = Path.GetFileNameWithoutExtension(newName);
				newName = $"{newNameNoExtension}-2{extension}";
				if (File.Exists($"{path}\\{newName}"))
				{
					int fileCount = 3;
					while (File.Exists($"{path}\\{newNameNoExtension}-{fileCount}{extension}"))
						fileCount += 1;

					newName = $"{newNameNoExtension}-{fileCount}{extension}";
				}
			}
			return newName;
		}




		public async Task<List<(string fileName, string path)>> UploadFileAsync(string path, IFormFileCollection Files)
		{
			string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, path);
			if (!Directory.Exists(uploadPath))
				Directory.CreateDirectory(uploadPath);


			List<(string fileName, string path)> datas = new();
			List<bool> results = new();
			foreach (IFormFile file in Files)
			{
				string fileNewName = await FileRenameAsync(uploadPath, file.FileName);

				bool result = await CopyFileAsync($"{uploadPath}\\{fileNewName}", file);
				results.Add(result);
				datas.Add((fileNewName, $"{path}\\{fileNewName}"));
			}


			if (results.TrueForAll(r => r.Equals(true)))
				return datas;

			return null;

			//todo Eğer ki yukarıdaki 'if' geçerkli değilse burada dostaların dunucuda yğklenirken hata alındığına dair uyarıcı bir exception oluşturulup fırlatılması gerekiyor!


			//string uploadPath = Path.Combine(_webHostEnviroment.WebRootPath, "resource/productImages");
			//if (!Directory.Exists(uploadPath))
			//	Directory.CreateDirectory(uploadPath);

			//foreach (IFormFile file in Request.Form.Files)
			//{
			//	string fullPath = Path.Combine(uploadPath, $"{file.Name}");
			//	using FileStream fileStream = new FileStream(fullPath, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, useAsync: false);
			//	await file.CopyToAsync(fileStream);
			//	await fileStream.FlushAsync();
			//}

			//return Ok();
		}
	}
}
