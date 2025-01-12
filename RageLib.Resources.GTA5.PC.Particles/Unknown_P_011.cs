namespace RageLib.Resources.GTA5.PC.Particles;

public class Unknown_P_011 : ResourceSystemBlock
{
	public float Unknown_0h;

	public float Unknown_4h;

	public uint Unknown_8h;

	public uint Unknown_Ch;

	public float Unknown_10h;

	public float Unknown_14h;

	public float Unknown_18h;

	public float Unknown_1Ch;

	public override long Length => 32L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		Unknown_0h = reader.ReadSingle();
		Unknown_4h = reader.ReadSingle();
		Unknown_8h = reader.ReadUInt32();
		Unknown_Ch = reader.ReadUInt32();
		Unknown_10h = reader.ReadSingle();
		Unknown_14h = reader.ReadSingle();
		Unknown_18h = reader.ReadSingle();
		Unknown_1Ch = reader.ReadSingle();
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		writer.Write(Unknown_0h);
		writer.Write(Unknown_4h);
		writer.Write(Unknown_8h);
		writer.Write(Unknown_Ch);
		writer.Write(Unknown_10h);
		writer.Write(Unknown_14h);
		writer.Write(Unknown_18h);
		writer.Write(Unknown_1Ch);
	}
}
