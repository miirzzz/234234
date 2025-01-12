namespace RageLib.Resources.GTA5.PC.Navigations;

public class Vertex : ResourceSystemBlock
{
	public ushort Unknown_0h;

	public ushort Unknown_2h;

	public ushort Unknown_4h;

	public override long Length => 6L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		Unknown_0h = reader.ReadUInt16();
		Unknown_2h = reader.ReadUInt16();
		Unknown_4h = reader.ReadUInt16();
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		writer.Write(Unknown_0h);
		writer.Write(Unknown_2h);
		writer.Write(Unknown_4h);
	}
}
