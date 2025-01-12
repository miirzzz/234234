namespace RageLib.Resources.GTA5.PC.Meta;

public class StructureEntryInfo : ResourceSystemBlock
{
	public override long Length => 16L;

	public int EntryNameHash { get; set; }

	public int DataOffset { get; set; }

	public StructureEntryDataType DataType { get; set; }

	public byte Unknown_9h { get; set; }

	public short ReferenceTypeIndex { get; set; }

	public int ReferenceKey { get; set; }

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		EntryNameHash = reader.ReadInt32();
		DataOffset = reader.ReadInt32();
		DataType = (StructureEntryDataType)reader.ReadByte();
		Unknown_9h = reader.ReadByte();
		ReferenceTypeIndex = reader.ReadInt16();
		ReferenceKey = reader.ReadInt32();
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		writer.Write(EntryNameHash);
		writer.Write(DataOffset);
		writer.Write((byte)DataType);
		writer.Write(Unknown_9h);
		writer.Write(ReferenceTypeIndex);
		writer.Write(ReferenceKey);
	}
}
