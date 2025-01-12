namespace RageLib.Resources.GTA5.PC.Meta;

public class EnumEntryInfo : ResourceSystemBlock
{
	public override long Length => 8L;

	public int EntryNameHash { get; set; }

	public int EntryValue { get; set; }

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		EntryNameHash = reader.ReadInt32();
		EntryValue = reader.ReadInt32();
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		writer.Write(EntryNameHash);
		writer.Write(EntryValue);
	}
}
