namespace RageLib.Resources.GTA5.PC.WaypointRecords;

public class WaypointRecordEntry : ResourceSystemBlock
{
	public float PositionX;

	public float PositionY;

	public float PositionZ;

	public ushort Unknown_Ch;

	public ushort Unknown_Eh;

	public ushort Unknown_10h;

	public ushort Unknown_12h;

	public override long Length => 20L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		PositionX = reader.ReadSingle();
		PositionY = reader.ReadSingle();
		PositionZ = reader.ReadSingle();
		Unknown_Ch = reader.ReadUInt16();
		Unknown_Eh = reader.ReadUInt16();
		Unknown_10h = reader.ReadUInt16();
		Unknown_12h = reader.ReadUInt16();
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		writer.Write(PositionX);
		writer.Write(PositionY);
		writer.Write(PositionZ);
		writer.Write(Unknown_Ch);
		writer.Write(Unknown_Eh);
		writer.Write(Unknown_10h);
		writer.Write(Unknown_12h);
	}
}
