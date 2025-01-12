using System.Collections.Generic;

namespace RageLib.Resources.GTA5.PC.Drawables;

public class ShaderParameter : ResourceSystemBlock
{
	public byte DataType;

	public byte Unknown_1h;

	public ushort Unknown_2h;

	public uint Unknown_4h;

	public ulong DataPointer;

	public IResourceBlock Data;

	public override long Length => 16L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		DataType = reader.ReadByte();
		Unknown_1h = reader.ReadByte();
		Unknown_2h = reader.ReadUInt16();
		Unknown_4h = reader.ReadUInt32();
		DataPointer = reader.ReadUInt64();
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		writer.Write(DataType);
		writer.Write(Unknown_1h);
		writer.Write(Unknown_2h);
		writer.Write(Unknown_4h);
		writer.Write(DataPointer);
	}

	public override IResourceBlock[] GetReferences()
	{
		List<IResourceBlock> list = new List<IResourceBlock>(base.GetReferences());
		if (Data != null)
		{
			list.Add(Data);
		}
		return list.ToArray();
	}
}
