using System;
using System.IO;
using RageLib.Archives;
using RageLib.GTA5.Archives;
using RageLib.GTA5.Resources.PC;
using RageLib.Resources;
using RageLib.Resources.GTA5;

namespace RageLib.GTA5.Utilities;

public class RebuildResourceFileHandler<T> : IRebuildResourceFileHandler where T : IResourceBlock, new()
{
	private ResourceFileType fileType;

	public RebuildResourceFileHandler(ResourceFileType fileType)
	{
		this.fileType = fileType;
	}

	public bool CanRebuild(IArchiveResourceFile sourceFile)
	{
		return sourceFile.Name.EndsWith("." + fileType.Extension, StringComparison.OrdinalIgnoreCase);
	}

	public void Rebuild(IArchiveResourceFile sourceFile, IArchiveDirectory targetDirectory, RageArchiveEncryption7 encryption)
	{
		try
		{
			MemoryStream memoryStream = new MemoryStream();
			sourceFile.Export(memoryStream);
			byte[] buffer = new byte[memoryStream.Length];
			memoryStream.Position = 0L;
			memoryStream.Read(buffer, 0, (int)memoryStream.Length);
			memoryStream = new MemoryStream(buffer);
			ResourceFile_GTA5_pc<T> resourceFile_GTA5_pc = new ResourceFile_GTA5_pc<T>();
			memoryStream.Position = 0L;
			resourceFile_GTA5_pc.Load(memoryStream);
			if (resourceFile_GTA5_pc.Version != fileType.Version)
			{
				throw new Exception("Wrong version");
			}
			MemoryStream memoryStream2 = new MemoryStream();
			resourceFile_GTA5_pc.Save(memoryStream2);
			buffer = new byte[memoryStream2.Length];
			memoryStream2.Position = 0L;
			memoryStream2.Read(buffer, 0, (int)memoryStream2.Length);
			memoryStream2 = new MemoryStream(buffer);
			IArchiveResourceFile archiveResourceFile = targetDirectory.CreateResourceFile();
			archiveResourceFile.Name = sourceFile.Name;
			memoryStream2.Position = 0L;
			archiveResourceFile.Import(memoryStream2);
			Console.WriteLine("Rebuilt " + sourceFile.Name);
		}
		catch (Exception ex)
		{
			Console.WriteLine("ERROR in " + sourceFile.Name + ": " + ex.Message);
		}
	}
}
