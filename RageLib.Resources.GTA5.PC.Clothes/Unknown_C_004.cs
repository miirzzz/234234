namespace RageLib.Resources.GTA5.PC.Clothes;

public class Unknown_C_004 : ResourceSystemBlock
{
	public ushort Unknown_0h;

	public ushort Unknown_2h;

	public float Unknown_4h;

	public float Unknown_8h;

	public float Unknown_Ch;

	public override long Length => 16L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		Unknown_0h = reader.ReadUInt16();
		Unknown_2h = reader.ReadUInt16();
		Unknown_4h = reader.ReadSingle();
		Unknown_8h = reader.ReadSingle();
		Unknown_Ch = reader.ReadSingle();
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		writer.Write(Unknown_0h);
		writer.Write(Unknown_2h);
		writer.Write(Unknown_4h);
		writer.Write(Unknown_8h);
		writer.Write(Unknown_Ch);
	}
}
