namespace RageLib.Resources.GTA5.PC.Bounds;

public class BVHNode : ResourceSystemBlock
{
	public ushort MinX;

	public ushort MinY;

	public ushort MinZ;

	public ushort MaxX;

	public ushort MaxY;

	public ushort MaxZ;

	public ushort Unknown_Ch;

	public ushort Unknown_Eh;

	public override long Length => 16L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		MinX = reader.ReadUInt16();
		MinY = reader.ReadUInt16();
		MinZ = reader.ReadUInt16();
		MaxX = reader.ReadUInt16();
		MaxY = reader.ReadUInt16();
		MaxZ = reader.ReadUInt16();
		Unknown_Ch = reader.ReadUInt16();
		Unknown_Eh = reader.ReadUInt16();
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		writer.Write(MinX);
		writer.Write(MinY);
		writer.Write(MinZ);
		writer.Write(MaxX);
		writer.Write(MaxY);
		writer.Write(MaxZ);
		writer.Write(Unknown_Ch);
		writer.Write(Unknown_Eh);
	}
}
