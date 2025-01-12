namespace RageLib.Resources.GTA5.PC.Clips;

public class PropertyAttributeQuaternion : PropertyAttribute
{
	public float X;

	public float Y;

	public float Z;

	public float W;

	public override long Length => 48L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		base.Read(reader, parameters);
		X = reader.ReadSingle();
		Y = reader.ReadSingle();
		Z = reader.ReadSingle();
		W = reader.ReadSingle();
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		base.Write(writer, parameters);
		writer.Write(X);
		writer.Write(Y);
		writer.Write(Z);
		writer.Write(W);
	}
}
