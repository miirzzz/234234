namespace RageLib.Resources.GTA5.PC.Bounds;

public class BVHTreeInfo : ResourceSystemBlock
{
	public ushort MinX;

	public ushort MinY;

	public ushort MinZ;

	public ushort MaxX;

	public ushort MaxY;

	public ushort MaxZ;

	public ushort NodeIndex1;

	public ushort NodeIndex2;

	public override long Length => 16L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		MinX = reader.ReadUInt16();
		MinY = reader.ReadUInt16();
		MinZ = reader.ReadUInt16();
		MaxX = reader.ReadUInt16();
		MaxY = reader.ReadUInt16();
		MaxZ = reader.ReadUInt16();
		NodeIndex1 = reader.ReadUInt16();
		NodeIndex2 = reader.ReadUInt16();
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		writer.Write(MinX);
		writer.Write(MinY);
		writer.Write(MinZ);
		writer.Write(MaxX);
		writer.Write(MaxY);
		writer.Write(MaxZ);
		writer.Write(NodeIndex1);
		writer.Write(NodeIndex2);
	}
}
