namespace RageLib.Resources.GTA5.PC.Expressions;

public class Unknown_E_001 : ResourceSystemBlock
{
	public uint Unknown_0h;

	public uint len1;

	public uint len2;

	public ushort len3;

	public ushort Unknown_Eh;

	public byte[] Data1;

	public byte[] Data2;

	public byte[] Data3;

	public override long Length => 16 + Data1.Length + Data2.Length + Data3.Length;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		Unknown_0h = reader.ReadUInt32();
		len1 = reader.ReadUInt32();
		len2 = reader.ReadUInt32();
		len3 = reader.ReadUInt16();
		Unknown_Eh = reader.ReadUInt16();
		Data1 = reader.ReadBytes((int)len1);
		Data2 = reader.ReadBytes((int)len2);
		Data3 = reader.ReadBytes(len3);
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		writer.Write(Unknown_0h);
		writer.Write(len1);
		writer.Write(len2);
		writer.Write(len3);
		writer.Write(Unknown_Eh);
		writer.Write(Data1);
		writer.Write(Data2);
		writer.Write(Data3);
	}
}
