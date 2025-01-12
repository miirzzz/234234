using System.Collections.Generic;
using RageLib.Data;

namespace RageLib.GTA5.PSO;

public class PsoEnumInfo : PsoElementInfo
{
	public byte Type { get; private set; } = 1;

	public int EntriesCount { get; private set; }

	public List<PsoEnumEntryInfo> Entries { get; set; }

	public override void Read(DataReader reader)
	{
		uint num = reader.ReadUInt32();
		Type = (byte)((num & 0xFF000000u) >> 24);
		EntriesCount = (int)(num & 0xFFFFFF);
		Entries = new List<PsoEnumEntryInfo>();
		for (int i = 0; i < EntriesCount; i++)
		{
			PsoEnumEntryInfo psoEnumEntryInfo = new PsoEnumEntryInfo();
			psoEnumEntryInfo.Read(reader);
			Entries.Add(psoEnumEntryInfo);
		}
	}

	public override void Write(DataWriter writer)
	{
		Type = 1;
		EntriesCount = Entries.Count;
		uint value = (uint)((Type << 24) | EntriesCount);
		writer.Write(value);
		foreach (PsoEnumEntryInfo entry in Entries)
		{
			entry.Write(writer);
		}
	}
}
