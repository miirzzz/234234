using System;
using System.Collections.Generic;
using RageLib.Archives;
using RageLib.GTA5.Archives;

namespace RageLib.GTA5.ArchiveWrappers;

public class RageArchiveDirectoryWrapper7 : IArchiveDirectory, IDisposable
{
	private RageArchiveWrapper7 archiveWrapper;

	internal RageArchiveDirectory7 directory;

	public string Name
	{
		get
		{
			return directory.Name;
		}
		set
		{
			directory.Name = value;
		}
	}

	internal RageArchiveDirectoryWrapper7(RageArchiveWrapper7 archiveWrapper, RageArchiveDirectory7 directory)
	{
		this.archiveWrapper = archiveWrapper;
		this.directory = directory;
	}

	public IArchiveDirectory[] GetDirectories()
	{
		List<IArchiveDirectory> list = new List<IArchiveDirectory>();
		foreach (RageArchiveDirectory7 directory in directory.Directories)
		{
			RageArchiveDirectoryWrapper7 item = new RageArchiveDirectoryWrapper7(archiveWrapper, directory);
			list.Add(item);
		}
		return list.ToArray();
	}

	public IArchiveDirectory GetDirectory(string name)
	{
		foreach (RageArchiveDirectory7 directory in directory.Directories)
		{
			if (directory.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
			{
				return new RageArchiveDirectoryWrapper7(archiveWrapper, directory);
			}
		}
		return null;
	}

	public IArchiveDirectory CreateDirectory()
	{
		RageArchiveDirectory7 item = new RageArchiveDirectory7();
		RageArchiveDirectoryWrapper7 result = new RageArchiveDirectoryWrapper7(archiveWrapper, item);
		directory.Directories.Add(item);
		return result;
	}

	public void DeleteDirectory(IArchiveDirectory directory)
	{
		this.directory.Directories.Remove(((RageArchiveDirectoryWrapper7)directory).directory);
	}

	public IArchiveFile[] GetFiles()
	{
		List<IArchiveFile> list = new List<IArchiveFile>();
		foreach (IRageArchiveEntry7 file in directory.Files)
		{
			if (file is RageArchiveBinaryFile7)
			{
				list.Add(new RageArchiveBinaryFileWrapper7(archiveWrapper, (RageArchiveBinaryFile7)file));
			}
			if (file is RageArchiveResourceFile7)
			{
				list.Add(new RageArchiveResourceFileWrapper7(archiveWrapper, (RageArchiveResourceFile7)file));
			}
		}
		return list.ToArray();
	}

	public IArchiveFile GetFile(string name)
	{
		foreach (IRageArchiveEntry7 file in directory.Files)
		{
			if (file.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
			{
				if (file is RageArchiveResourceFile7)
				{
					return new RageArchiveResourceFileWrapper7(archiveWrapper, (RageArchiveResourceFile7)file);
				}
				return new RageArchiveBinaryFileWrapper7(archiveWrapper, (RageArchiveBinaryFile7)file);
			}
		}
		return null;
	}

	public IArchiveBinaryFile CreateBinaryFile()
	{
		RageArchiveBinaryFile7 rageArchiveBinaryFile = new RageArchiveBinaryFile7();
		RageArchiveBinaryFileWrapper7 result = new RageArchiveBinaryFileWrapper7(archiveWrapper, rageArchiveBinaryFile);
		rageArchiveBinaryFile.Name = "";
		long num = archiveWrapper.FindSpace(64L);
		rageArchiveBinaryFile.FileOffset = (uint)(num / 512);
		directory.Files.Add(rageArchiveBinaryFile);
		return result;
	}

	public IArchiveResourceFile CreateResourceFile()
	{
		RageArchiveResourceFile7 rageArchiveResourceFile = new RageArchiveResourceFile7();
		RageArchiveResourceFileWrapper7 result = new RageArchiveResourceFileWrapper7(archiveWrapper, rageArchiveResourceFile);
		rageArchiveResourceFile.Name = "";
		long num = archiveWrapper.FindSpace(64L);
		rageArchiveResourceFile.FileOffset = (uint)(num / 512);
		directory.Files.Add(rageArchiveResourceFile);
		return result;
	}

	public void DeleteFile(IArchiveFile file)
	{
		throw new NotImplementedException();
	}

	public void Dispose()
	{
		archiveWrapper = null;
		directory = null;
	}
}
