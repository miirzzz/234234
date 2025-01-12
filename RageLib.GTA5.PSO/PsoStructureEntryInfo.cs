using RageLib.Data;

namespace RageLib.GTA5.PSO;

public class PsoStructureEntryInfo
{
	public int EntryNameHash;

	public DataType Type;

	public byte Unk_5h;

	public short DataOffset;

	public int ReferenceKey;

	public PsoStructureEntryInfo()
	{
	}

	public PsoStructureEntryInfo(int nameHash, DataType type, byte unk5, short dataOffset, int referenceKey)
	{
		EntryNameHash = nameHash;
		Type = type;
		Unk_5h = unk5;
		DataOffset = dataOffset;
		ReferenceKey = referenceKey;
	}

	public void Read(DataReader reader)
	{
		EntryNameHash = reader.ReadInt32();
		Type = (DataType)reader.ReadByte();
		Unk_5h = reader.ReadByte();
		DataOffset = reader.ReadInt16();
		ReferenceKey = reader.ReadInt32();
	}

	public void Write(DataWriter writer)
	{
		writer.Write(EntryNameHash);
		writer.Write((byte)Type);
		writer.Write(Unk_5h);
		writer.Write(DataOffset);
		writer.Write(ReferenceKey);
	}
}
