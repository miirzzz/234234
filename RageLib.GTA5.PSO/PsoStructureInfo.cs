using System.Collections.Generic;
using RageLib.Data;

namespace RageLib.GTA5.PSO;

public class PsoStructureInfo : PsoElementInfo
{
	public byte Type { get; set; }

	public short EntriesCount { get; private set; }

	public byte Unk { get; set; }

	public int StructureLength { get; set; }

	public uint Unk_Ch { get; set; }

	public List<PsoStructureEntryInfo> Entries { get; set; } = new List<PsoStructureEntryInfo>();

	public override void Read(DataReader reader)
	{
		uint num = reader.ReadUInt32();
		Type = (byte)((num & 0xFF000000u) >> 24);
		EntriesCount = (short)(num & 0xFFFF);
		Unk = (byte)((num & 0xFF0000) >> 16);
		StructureLength = reader.ReadInt32();
		Unk_Ch = reader.ReadUInt32();
		Entries = new List<PsoStructureEntryInfo>();
		for (int i = 0; i < EntriesCount; i++)
		{
			PsoStructureEntryInfo psoStructureEntryInfo = new PsoStructureEntryInfo();
			psoStructureEntryInfo.Read(reader);
			Entries.Add(psoStructureEntryInfo);
		}
	}

	public override void Write(DataWriter writer)
	{
		Type = 0;
		EntriesCount = (short)Entries.Count;
		uint value = (uint)((Type << 24) | (Unk << 16) | (ushort)EntriesCount);
		writer.Write(value);
		writer.Write(StructureLength);
		writer.Write(Unk_Ch);
		foreach (PsoStructureEntryInfo entry in Entries)
		{
			entry.Write(writer);
		}
	}
}
