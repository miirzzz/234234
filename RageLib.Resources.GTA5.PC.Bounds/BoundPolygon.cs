namespace RageLib.Resources.GTA5.PC.Bounds;

public class BoundPolygon : ResourceSystemBlock
{
	public uint Unknown_0h;

	public ushort Unknown_4h;

	public ushort Unknown_6h;

	public ushort Unknown_8h;

	public ushort Unknown_Ah;

	public uint Unknown_Ch;

	public override long Length => 16L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		Unknown_0h = reader.ReadUInt32();
		Unknown_4h = reader.ReadUInt16();
		Unknown_6h = reader.ReadUInt16();
		Unknown_8h = reader.ReadUInt16();
		Unknown_Ah = reader.ReadUInt16();
		Unknown_Ch = reader.ReadUInt32();
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		writer.Write(Unknown_0h);
		writer.Write(Unknown_4h);
		writer.Write(Unknown_6h);
		writer.Write(Unknown_8h);
		writer.Write(Unknown_Ah);
		writer.Write(Unknown_Ch);
	}
}
