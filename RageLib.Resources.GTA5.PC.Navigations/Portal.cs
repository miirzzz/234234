namespace RageLib.Resources.GTA5.PC.Navigations;

public class Portal : ResourceSystemBlock
{
	public uint Unknown_0h;

	public uint Unknown_4h;

	public uint Unknown_8h;

	public uint Unknown_Ch;

	public ushort Unknown_10h;

	public ushort Unknown_12h;

	public ushort Unknown_14h;

	public ushort Unknown_16h;

	public uint Unknown_18h;

	public override long Length => 28L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		Unknown_0h = reader.ReadUInt32();
		Unknown_4h = reader.ReadUInt32();
		Unknown_8h = reader.ReadUInt32();
		Unknown_Ch = reader.ReadUInt32();
		Unknown_10h = reader.ReadUInt16();
		Unknown_12h = reader.ReadUInt16();
		Unknown_14h = reader.ReadUInt16();
		Unknown_16h = reader.ReadUInt16();
		Unknown_18h = reader.ReadUInt32();
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		writer.Write(Unknown_0h);
		writer.Write(Unknown_4h);
		writer.Write(Unknown_8h);
		writer.Write(Unknown_Ch);
		writer.Write(Unknown_10h);
		writer.Write(Unknown_12h);
		writer.Write(Unknown_14h);
		writer.Write(Unknown_16h);
		writer.Write(Unknown_18h);
	}
}
