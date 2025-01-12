namespace RageLib.Resources.GTA5.PC.Clips;

public class PropertyAttributeVector3 : PropertyAttribute
{
	public float X;

	public float Y;

	public float Z;

	public float Unknown_2Ch;

	public override long Length => 48L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		base.Read(reader, parameters);
		X = reader.ReadSingle();
		Y = reader.ReadSingle();
		Z = reader.ReadSingle();
		Unknown_2Ch = reader.ReadSingle();
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		base.Write(writer, parameters);
		writer.Write(X);
		writer.Write(Y);
		writer.Write(Z);
		writer.Write(Unknown_2Ch);
	}
}
