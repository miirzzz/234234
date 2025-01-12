namespace RageLib.Resources.GTA5.PC.Bounds;

public class BoundMaterial : ResourceSystemBlock
{
	public uint Unknown_0h;

	public uint Unknown_4h;

	public override long Length => 8L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		Unknown_0h = reader.ReadUInt32();
		Unknown_4h = reader.ReadUInt32();
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		writer.Write(Unknown_0h);
		writer.Write(Unknown_4h);
	}
}
