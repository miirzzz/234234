namespace RageLib.Resources.GTA5.PC.Bounds;

public class BoundVertex : ResourceSystemBlock
{
	public ushort X;

	public ushort Y;

	public ushort Z;

	public override long Length => 6L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		X = reader.ReadUInt16();
		Y = reader.ReadUInt16();
		Z = reader.ReadUInt16();
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		writer.Write(X);
		writer.Write(Y);
		writer.Write(Z);
	}
}
