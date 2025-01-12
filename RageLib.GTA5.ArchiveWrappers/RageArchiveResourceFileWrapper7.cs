using System.IO;
using RageLib.Archives;
using RageLib.Data;
using RageLib.GTA5.Archives;

namespace RageLib.GTA5.ArchiveWrappers;

public class RageArchiveResourceFileWrapper7 : IArchiveResourceFile, IArchiveFile
{
	private RageArchiveWrapper7 archiveWrapper;

	private RageArchiveResourceFile7 file;

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

	public long Size => file.FileSize;

	internal RageArchiveResourceFileWrapper7(RageArchiveWrapper7 archiveWrapper, RageArchiveResourceFile7 file)
	{
		this.archiveWrapper = archiveWrapper;
		this.file = file;
	}

	public void Import(string fileName)
	{
		using FileStream stream = new FileStream(fileName, FileMode.Open);
		Import(stream);
	}

	public void Import(Stream stream)
	{
		PartialStream partialStream = new PartialStream(archiveWrapper.archive_.BaseStream, () => file.FileOffset * RageArchiveWrapper7.BLOCK_SIZE, () => file.FileSize, delegate(long length)
		{
			archiveWrapper.RequestBytesRES(file, length);
		});
		partialStream.SetLength(stream.Length);
		DataReader dataReader = new DataReader(stream);
		dataReader.Position = 0L;
		dataReader.ReadUInt32();
		dataReader.ReadUInt32();
		uint systemFlags = dataReader.ReadUInt32();
		uint graphicsFlags = dataReader.ReadUInt32();
		dataReader.Position = 0L;
		byte[] array = dataReader.ReadBytes((int)stream.Length);
		file.SystemFlags = systemFlags;
		file.GraphicsFlags = graphicsFlags;
		partialStream.Write(array, 0, array.Length);
	}

	public void Export(string fileName)
	{
		using FileStream stream = new FileStream(fileName, FileMode.Create);
		Export(stream);
	}

	public void Export(Stream stream)
	{
		uint value = ((file.GraphicsFlags & 0xF0000000u) >> 28) | ((file.SystemFlags & 0xF0000000u) >> 24);
		DataWriter dataWriter = new DataWriter(stream);
		dataWriter.Write(121852754u);
		dataWriter.Write(value);
		dataWriter.Write(file.SystemFlags);
		dataWriter.Write(file.GraphicsFlags);
		DataReader obj = new DataReader(new PartialStream(archiveWrapper.archive_.BaseStream, () => file.FileOffset * RageArchiveWrapper7.BLOCK_SIZE, () => file.FileSize))
		{
			Position = 16L
		};
		byte[] value2 = obj.ReadBytes((int)obj.Length - 16);
		dataWriter.Write(value2);
	}
}
