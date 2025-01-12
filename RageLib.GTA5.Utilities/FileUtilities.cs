using System.Collections.Generic;
using System.IO;
using RageLib.Archives;
using RageLib.GTA5.Archives;

namespace RageLib.GTA5.Utilities;

public class FileUtilities
{
	public static HashSet<string> GetAllFileNamesWithoutExtension(string gameDirectoryName)
	{
		HashSet<string> hashSet = new HashSet<string>();
		foreach (string allFileName in GetAllFileNames(gameDirectoryName))
		{
			hashSet.Add(RemoveExtension(allFileName));
		}
		return hashSet;
	}

	public static string RemoveExtension(string fileName)
	{
		return Path.ChangeExtension(fileName, null);
	}

	public static HashSet<string> GetAllFileNames(string gameDirectoryName)
	{
		HashSet<string> fileNames = new HashSet<string>();
		string[] files = Directory.GetFiles(gameDirectoryName, "*.*", SearchOption.AllDirectories);
		for (int i = 0; i < files.Length; i++)
		{
			FileInfo fileInfo = new FileInfo(files[i]);
			fileNames.Add(fileInfo.Name);
		}
		ArchiveUtilities.ForEachFile(gameDirectoryName, delegate(string fullFileName, IArchiveFile file, RageArchiveEncryption7 encryption)
		{
			fileNames.Add(file.Name);
		});
		return fileNames;
	}
}
