namespace RageLib.Resources;

public class PagesInfo_GTA5_pc : ResourceSystemBlock
{
	public uint Unknown_0h;

	public uint Unknown_4h;

	public byte SystemPagesCount;

	public byte GraphicsPagesCount;

	public ushort Unknown_Ah;

	public uint Unknown_Ch;

	public uint Unknown_10h;

	public override long Length => 20L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		Unknown_0h = reader.ReadUInt32();
		Unknown_4h = reader.ReadUInt32();
		SystemPagesCount = reader.ReadByte();
		GraphicsPagesCount = reader.ReadByte();
		Unknown_Ah = reader.ReadUInt16();
		Unknown_Ch = reader.ReadUInt32();
		Unknown_10h = reader.ReadUInt32();
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		writer.Write(Unknown_0h);
		writer.Write(Unknown_4h);
		writer.Write(SystemPagesCount);
		writer.Write(GraphicsPagesCount);
		writer.Write(Unknown_Ah);
		writer.Write(Unknown_Ch);
		writer.Write(Unknown_10h);
	}
}
