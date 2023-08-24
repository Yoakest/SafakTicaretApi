using SafakTicaret.Infrastructure.StaticServices;

namespace SafakTicaret.Infrastructure.Services.Storage.Storage
{
	public class BaseStorage
	{
		protected delegate bool HasFile(string path, string fileName);

		protected async Task<string> FileRenameAsync(string path, string fileName, HasFile hasFile)
		{
			string extension = Path.GetExtension(fileName);
			string oldName = Path.GetFileNameWithoutExtension(fileName);
			string newName = $"{NameOperations.CharacterRegulatory(oldName)}{extension}";

			if (hasFile(path, newName))
			{
				string newNameNoExtension = Path.GetFileNameWithoutExtension(newName);
				newName = $"{newNameNoExtension}-2{extension}";
				if (hasFile(path, newName))
				{
					int fileCount = 2;
					string newFileName = $"{newNameNoExtension}-{fileCount}{extension}";
					//while (File.Exists($"{path}\\{newNameNoExtension}-{fileCount}{extension}"))
					while (hasFile(path, newName))
					{
						fileCount += 1;
						newName = $"{newNameNoExtension}-{fileCount}{extension}";
					}

				}
			}
			return newName;
		}
	}
}
