namespace RageLib.Resources.GTA5.PC.Clips;

public class Sequence : ResourceSystemBlock
{
	public uint Unknown_0h;

	public uint DataLength;

	public uint Unknown_8h;

	public uint Unknown_Ch;

	public uint Unknown_10h;

	public uint Unknown_14h;

	public uint Unknown_18h;

	public ushort Unknown_1Ch;

	public ushort Unknown_1Eh;

	public byte[] Data;

	public override long Length => 32 + Data.Length;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		Unknown_0h = reader.ReadUInt32();
		DataLength = reader.ReadUInt32();
		Unknown_8h = reader.ReadUInt32();
		Unknown_Ch = reader.ReadUInt32();
		Unknown_10h = reader.ReadUInt32();
		Unknown_14h = reader.ReadUInt32();
		Unknown_18h = reader.ReadUInt32();
		Unknown_1Ch = reader.ReadUInt16();
		Unknown_1Eh = reader.ReadUInt16();
		Data = reader.ReadBytes((int)DataLength);
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		writer.Write(Unknown_0h);
		writer.Write(DataLength);
		writer.Write(Unknown_8h);
		writer.Write(Unknown_Ch);
		writer.Write(Unknown_10h);
		writer.Write(Unknown_14h);
		writer.Write(Unknown_18h);
		writer.Write(Unknown_1Ch);
		writer.Write(Unknown_1Eh);
		writer.Write(Data);
	}
}
