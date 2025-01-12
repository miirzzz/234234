using System;
using System.IO;
using RageLib.Archives;
using RageLib.GTA5.Archives;
using RageLib.GTA5.ArchiveWrappers;

namespace RageLib.GTA5.Utilities;

public static class ArchiveUtilities
{
	public static void ForEachBinaryFile(string gameDirectoryName, ProcessBinaryFileDelegate processDelegate)
	{
		ForEachFile(gameDirectoryName, delegate(string fullFileName, IArchiveFile file, RageArchiveEncryption7 encryption)
		{
			if (file is IArchiveBinaryFile)
			{
				processDelegate(fullFileName, (IArchiveBinaryFile)file, encryption);
			}
		});
	}

	public static void ForEachResourceFile(string gameDirectoryName, ProcessResourceFileDelegate processDelegate)
	{
		ForEachFile(gameDirectoryName, delegate(string fullFileName, IArchiveFile file, RageArchiveEncryption7 encryption)
		{
			if (file is IArchiveResourceFile)
			{
				processDelegate(fullFileName, (IArchiveResourceFile)file, encryption);
			}
		});
	}

	public static void ForEachFile(string gameDirectoryName, ProcessFileDelegate processDelegate)
	{
		string[] files = Directory.GetFiles(gameDirectoryName, "*.rpf", SearchOption.AllDirectories);
		foreach (string obj in files)
		{
			RageArchiveWrapper7 rageArchiveWrapper = RageArchiveWrapper7.Open(fileName: new FileInfo(obj).Name, stream: new FileStream(obj, FileMode.Open));
			ForEachFile(obj.Replace(gameDirectoryName, ""), rageArchiveWrapper.Root, rageArchiveWrapper.archive_.Encryption, processDelegate);
			rageArchiveWrapper.Dispose();
		}
	}

	private static void ForEachFile(string fullPathName, IArchiveDirectory directory, RageArchiveEncryption7 encryption, ProcessFileDelegate processDelegate)
	{
		IArchiveFile[] files = directory.GetFiles();
		foreach (IArchiveFile archiveFile in files)
		{
			processDelegate(fullPathName + "\\" + archiveFile.Name, archiveFile, encryption);
			if (archiveFile is IArchiveBinaryFile && archiveFile.Name.EndsWith(".rpf", StringComparison.OrdinalIgnoreCase))
			{
				RageArchiveWrapper7 rageArchiveWrapper = RageArchiveWrapper7.Open(((IArchiveBinaryFile)archiveFile).GetStream(), archiveFile.Name);
				ForEachFile(fullPathName + "\\" + archiveFile.Name, rageArchiveWrapper.Root, rageArchiveWrapper.archive_.Encryption, processDelegate);
			}
		}
		IArchiveDirectory[] directories = directory.GetDirectories();
		foreach (IArchiveDirectory archiveDirectory in directories)
		{
			ForEachFile(fullPathName + "\\" + archiveDirectory.Name, archiveDirectory, encryption, processDelegate);
		}
	}
}
