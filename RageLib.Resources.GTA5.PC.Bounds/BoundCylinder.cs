namespace RageLib.Resources.GTA5.PC.Bounds;

public class BoundCylinder : Bound
{
	public uint Unknown_70h;

	public uint Unknown_74h;

	public uint Unknown_78h;

	public uint Unknown_7Ch;

	public override long Length => 128L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		base.Read(reader, parameters);
		Unknown_70h = reader.ReadUInt32();
		Unknown_74h = reader.ReadUInt32();
		Unknown_78h = reader.ReadUInt32();
		Unknown_7Ch = reader.ReadUInt32();
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		base.Write(writer, parameters);
		writer.Write(Unknown_70h);
		writer.Write(Unknown_74h);
		writer.Write(Unknown_78h);
		writer.Write(Unknown_7Ch);
	}
}
