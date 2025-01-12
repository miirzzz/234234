using RageLib.Data;

namespace RageLib.GTA5.PSO;

public class PsoEnumEntryInfo
{
	public int EntryNameHash { get; set; }

	public int EntryKey { get; set; }

	public PsoEnumEntryInfo()
	{
	}

	public PsoEnumEntryInfo(int nameHash, int key)
	{
		EntryNameHash = nameHash;
		EntryKey = key;
	}

	public void Read(DataReader reader)
	{
		EntryNameHash = reader.ReadInt32();
		EntryKey = reader.ReadInt32();
	}

	public void Write(DataWriter writer)
	{
		writer.Write(EntryNameHash);
		writer.Write(EntryKey);
	}
}
