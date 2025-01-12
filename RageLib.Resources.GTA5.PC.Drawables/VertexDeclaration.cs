namespace RageLib.Resources.GTA5.PC.Drawables;

public class VertexDeclaration : ResourceSystemBlock
{
	public uint Flags;

	public ushort Stride;

	public byte Unknown_6h;

	public byte Count;

	public ulong Types;

	public override long Length => 16L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		Flags = reader.ReadUInt32();
		Stride = reader.ReadUInt16();
		Unknown_6h = reader.ReadByte();
		Count = reader.ReadByte();
		Types = reader.ReadUInt64();
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		writer.Write(Flags);
		writer.Write(Stride);
		writer.Write(Unknown_6h);
		writer.Write(Count);
		writer.Write(Types);
	}
}
