using RageLib.Data;

namespace RageLib.GTA5.Archives;

public class RageArchiveResourceFile7 : IRageArchiveFileEntry7, IRageArchiveEntry7
{
	public uint NameOffset { get; set; }

	public uint FileSize { get; set; }

	public uint FileOffset { get; set; }

	public uint SystemFlags { get; set; }

	public uint GraphicsFlags { get; set; }

	public string Name { get; set; }

	public void Read(DataReader reader)
	{
		NameOffset = reader.ReadUInt16();
		byte[] array = reader.ReadBytes(3);
		FileSize = (uint)(array[0] + (array[1] << 8) + (array[2] << 16));
		byte[] array2 = reader.ReadBytes(3);
		FileOffset = (uint)((array2[0] + (array2[1] << 8) + (array2[2] << 16)) & 0x7FFFFF);
		SystemFlags = reader.ReadUInt32();
		GraphicsFlags = reader.ReadUInt32();
	}

	public void Write(DataWriter writer)
	{
		writer.Write((ushort)NameOffset);
		byte[] value = new byte[3]
		{
			(byte)(FileSize & 0xFF),
			(byte)((FileSize >> 8) & 0xFF),
			(byte)((FileSize >> 16) & 0xFF)
		};
		writer.Write(value);
		byte[] value2 = new byte[3]
		{
			(byte)(FileOffset & 0xFF),
			(byte)((FileOffset >> 8) & 0xFF),
			(byte)(((FileOffset >> 16) & 0xFF) | 0x80)
		};
		writer.Write(value2);
		writer.Write(SystemFlags);
		writer.Write(GraphicsFlags);
	}
}
