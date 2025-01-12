using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using RageLib.Archives;
using RageLib.GTA5.Archives;
using RageLib.GTA5.ArchiveWrappers;

namespace RageLib.GTA5.Utilities;

public class GameRebuilder
{
	public List<IRebuildBinaryFileHandler> BinaryFileHandlers = new List<IRebuildBinaryFileHandler>();

	public List<IRebuildResourceFileHandler> ResourceFileHandlers = new List<IRebuildResourceFileHandler>();

	public void Rebuild(string sourceGameDirectoryName, string destinationGameDirectoryName)
	{
		string[] files = Directory.GetFiles(sourceGameDirectoryName, "*.rpf", SearchOption.AllDirectories);
		foreach (string text in files)
		{
			RebuildArchive(text, text.Replace(sourceGameDirectoryName, destinationGameDirectoryName));
		}
	}

	public void RebuildParallel(string sourceGameDirectoryName, string destinationGameDirectoryName)
	{
		Parallel.ForEach((IEnumerable<string>)Directory.GetFiles(sourceGameDirectoryName, "*.rpf", SearchOption.AllDirectories), (Action<string>)delegate(string archiveFileName)
		{
			RebuildArchive(archiveFileName, archiveFileName.Replace(sourceGameDirectoryName, destinationGameDirectoryName));
		});
	}

	private void RebuildArchive(string sourceArchiveFileName, string destinationArchiveFileName)
	{
		FileInfo fileInfo = new FileInfo(sourceArchiveFileName);
		RageArchiveWrapper7 rageArchiveWrapper = RageArchiveWrapper7.Open(new FileStream(sourceArchiveFileName, FileMode.Open), fileInfo.Name);
		RageArchiveWrapper7 rageArchiveWrapper2 = RageArchiveWrapper7.Create(destinationArchiveFileName);
		RebuildDictionary(rageArchiveWrapper.Root, rageArchiveWrapper2.Root, rageArchiveWrapper.archive_.Encryption);
		rageArchiveWrapper2.FileName = fileInfo.Name;
		rageArchiveWrapper2.archive_.Encryption = rageArchiveWrapper.archive_.Encryption;
		rageArchiveWrapper2.Flush();
	}

	private void RebuildDictionary(IArchiveDirectory sourceDirectory, IArchiveDirectory destinationDirectory, RageArchiveEncryption7 archiveEncryption)
	{
		IArchiveFile[] files = sourceDirectory.GetFiles();
		foreach (IArchiveFile sourceFile in files)
		{
			RebuildFile(sourceFile, destinationDirectory, archiveEncryption);
		}
		IArchiveDirectory[] directories = sourceDirectory.GetDirectories();
		foreach (IArchiveDirectory archiveDirectory in directories)
		{
			IArchiveDirectory archiveDirectory2 = destinationDirectory.CreateDirectory();
			archiveDirectory2.Name = archiveDirectory.Name;
			RebuildDictionary(archiveDirectory, archiveDirectory2, archiveEncryption);
		}
	}

	private void RebuildFile(IArchiveFile sourceFile, IArchiveDirectory destinationDirectory, RageArchiveEncryption7 archiveEncryption)
	{
		if (sourceFile is IArchiveBinaryFile)
		{
			IArchiveBinaryFile archiveBinaryFile = (IArchiveBinaryFile)sourceFile;
			if (archiveBinaryFile.Name.EndsWith(".rpf", StringComparison.OrdinalIgnoreCase))
			{
				RebuildArchiveFile(archiveBinaryFile, destinationDirectory);
			}
			else
			{
				RebuildBinaryFile(archiveBinaryFile, destinationDirectory, archiveEncryption);
			}
		}
		else
		{
			IArchiveResourceFile sourceFile2 = (IArchiveResourceFile)sourceFile;
			RebuildResourceFile(sourceFile2, destinationDirectory, archiveEncryption);
		}
	}

	private void RebuildArchiveFile(IArchiveBinaryFile sourceFile, IArchiveDirectory destinationDirectory)
	{
		RageArchiveWrapper7 rageArchiveWrapper = RageArchiveWrapper7.Open(sourceFile.GetStream(), sourceFile.Name);
		IArchiveBinaryFile archiveBinaryFile = destinationDirectory.CreateBinaryFile();
		archiveBinaryFile.Name = sourceFile.Name;
		RageArchiveWrapper7 rageArchiveWrapper2 = RageArchiveWrapper7.Create(archiveBinaryFile.GetStream(), sourceFile.Name);
		RebuildDictionary(rageArchiveWrapper.Root, rageArchiveWrapper2.Root, rageArchiveWrapper.archive_.Encryption);
		rageArchiveWrapper2.FileName = sourceFile.Name;
		rageArchiveWrapper2.archive_.Encryption = rageArchiveWrapper.archive_.Encryption;
		rageArchiveWrapper2.Flush();
	}

	private void RebuildBinaryFile(IArchiveBinaryFile sourceFile, IArchiveDirectory destinationDirectory, RageArchiveEncryption7 archiveEncryption)
	{
		foreach (IRebuildBinaryFileHandler binaryFileHandler in BinaryFileHandlers)
		{
			if (binaryFileHandler.CanRebuild(sourceFile))
			{
				binaryFileHandler.Rebuild(sourceFile, destinationDirectory, archiveEncryption);
				return;
			}
		}
		MemoryStream memoryStream = new MemoryStream();
		sourceFile.Export(memoryStream);
		memoryStream.Position = 0L;
		byte[] array = new byte[memoryStream.Length];
		memoryStream.Position = 0L;
		memoryStream.Read(array, 0, array.Length);
		IArchiveBinaryFile archiveBinaryFile = destinationDirectory.CreateBinaryFile();
		archiveBinaryFile.Name = sourceFile.Name;
		archiveBinaryFile.Import(new MemoryStream(array));
		archiveBinaryFile.IsEncrypted = sourceFile.IsEncrypted;
		if (sourceFile.IsCompressed)
		{
			archiveBinaryFile.IsCompressed = sourceFile.IsCompressed;
			archiveBinaryFile.UncompressedSize = sourceFile.UncompressedSize;
		}
	}

	private void RebuildResourceFile(IArchiveResourceFile sourceFile, IArchiveDirectory destinationDirectory, RageArchiveEncryption7 archiveEncryption)
	{
		foreach (IRebuildResourceFileHandler resourceFileHandler in ResourceFileHandlers)
		{
			if (resourceFileHandler.CanRebuild(sourceFile))
			{
				resourceFileHandler.Rebuild(sourceFile, destinationDirectory, archiveEncryption);
				return;
			}
		}
		CopyResource(sourceFile, destinationDirectory);
	}

	private static void CopyResource(IArchiveResourceFile sourceResource, IArchiveDirectory targetDirectory)
	{
		MemoryStream memoryStream = new MemoryStream();
		sourceResource.Export(memoryStream);
		IArchiveResourceFile archiveResourceFile = targetDirectory.CreateResourceFile();
		archiveResourceFile.Name = sourceResource.Name;
		memoryStream.Position = 0L;
		archiveResourceFile.Import(memoryStream);
	}
}
