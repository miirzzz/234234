namespace RageLib.Resources.GTA5.PC.Particles;

public class BehaviourVelocity : Behaviour
{
	public uint Unknown_10h;

	public uint Unknown_14h;

	public uint Unknown_18h;

	public uint Unknown_1Ch;

	public uint Unknown_20h;

	public uint Unknown_24h;

	public uint Unknown_28h;

	public uint Unknown_2Ch;

	public override long Length => 48L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		base.Read(reader, parameters);
		Unknown_10h = reader.ReadUInt32();
		Unknown_14h = reader.ReadUInt32();
		Unknown_18h = reader.ReadUInt32();
		Unknown_1Ch = reader.ReadUInt32();
		Unknown_20h = reader.ReadUInt32();
		Unknown_24h = reader.ReadUInt32();
		Unknown_28h = reader.ReadUInt32();
		Unknown_2Ch = reader.ReadUInt32();
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		base.Write(writer, parameters);
		writer.Write(Unknown_10h);
		writer.Write(Unknown_14h);
		writer.Write(Unknown_18h);
		writer.Write(Unknown_1Ch);
		writer.Write(Unknown_20h);
		writer.Write(Unknown_24h);
		writer.Write(Unknown_28h);
		writer.Write(Unknown_2Ch);
	}
}
