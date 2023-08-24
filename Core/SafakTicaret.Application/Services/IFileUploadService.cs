using Microsoft.AspNetCore.Http;

namespace SafakTicaret.Application.Services
{
	public interface IFileUploadService
	{
		Task<List<(string fileName, string path)>> UploadFileAsync(string path, IFormFileCollection files);
		Task<bool> CopyFileAsync(string path, IFormFile file);

	}
}
