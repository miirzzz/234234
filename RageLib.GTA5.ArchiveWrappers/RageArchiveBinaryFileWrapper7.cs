using System.IO;
using RageLib.Archives;
using RageLib.GTA5.Archives;

namespace RageLib.GTA5.ArchiveWrappers;

public class RageArchiveBinaryFileWrapper7 : IArchiveBinaryFile, IArchiveFile
{
	internal RageArchiveWrapper7 archiveWrapper;

	internal RageArchiveBinaryFile7 file;

	public string Name
	{
		get
		{
			return file.Name;
		}
		set
		{
			file.Name = value;
		}
	}

	public bool IsEncrypted
	{
		get
		{
			return file.IsEncrypted;
		}
		set
		{
			file.IsEncrypted = value;
		}
	}

	public bool IsCompressed
	{
		get
		{
			return file.FileSize != 0;
		}
		set
		{
			if (value)
			{
				file.FileSize = file.FileUncompressedSize;
				return;
			}
			file.FileUncompressedSize = file.FileSize;
			file.FileSize = 0u;
		}
	}

	public long UncompressedSize
	{
		get
		{
			return file.FileUncompressedSize;
		}
		set
		{
			file.FileUncompressedSize = (uint)value;
		}
	}

	public long CompressedSize => file.FileSize;

	public long Size
	{
		get
		{
			if (file.FileSize != 0)
			{
				return file.FileSize;
			}
			return file.FileUncompressedSize;
		}
	}

	internal RageArchiveBinaryFileWrapper7(RageArchiveWrapper7 archiveWrapper, RageArchiveBinaryFile7 file)
	{
		this.archiveWrapper = archiveWrapper;
		this.file = file;
	}

	public Stream GetStream()
	{
		return archiveWrapper.GetStream(file);
	}

	public void Import(string fileName)
	{
		using FileStream stream = new FileStream(fileName, FileMode.Open);
		Import(stream);
	}

	public void Import(Stream stream)
	{
		Stream stream2 = GetStream();
		stream2.SetLength(stream.Length);
		byte[] array = new byte[stream.Length];
		stream.Position = 0L;
		stream.Read(array, 0, array.Length);
		stream2.Write(array, 0, array.Length);
	}

	public void Export(string fileName)
	{
		using FileStream stream = new FileStream(fileName, FileMode.Create);
		Export(stream);
	}

	public void Export(Stream stream)
	{
		Stream stream2 = GetStream();
		byte[] array = new byte[stream2.Length];
		stream2.Read(array, 0, array.Length);
		stream.Write(array, 0, array.Length);
	}
}
