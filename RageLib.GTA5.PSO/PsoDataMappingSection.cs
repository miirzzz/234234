using System.Collections.Generic;
using RageLib.Data;

namespace RageLib.GTA5.PSO;

public class PsoDataMappingSection
{
	public int Ident { get; set; } = 1347240272;

	public int Length { get; private set; }

	public int RootIndex { get; set; }

	public short EntriesCount { get; private set; }

	public short Unknown_Eh { get; set; } = 28784;

	public List<PsoDataMappingEntry> Entries { get; set; }

	public void Read(DataReader reader)
	{
		Ident = reader.ReadInt32();
		Length = reader.ReadInt32();
		RootIndex = reader.ReadInt32();
		EntriesCount = reader.ReadInt16();
		Unknown_Eh = reader.ReadInt16();
		Entries = new List<PsoDataMappingEntry>();
		for (int i = 0; i < EntriesCount; i++)
		{
			PsoDataMappingEntry psoDataMappingEntry = new PsoDataMappingEntry();
			psoDataMappingEntry.Read(reader);
			Entries.Add(psoDataMappingEntry);
		}
	}

	public void Write(DataWriter writer)
	{
		EntriesCount = (short)Entries.Count;
		Length = 16 + EntriesCount * 16;
		writer.Write(Ident);
		writer.Write(Length);
		writer.Write(RootIndex);
		writer.Write(EntriesCount);
		writer.Write(Unknown_Eh);
		foreach (PsoDataMappingEntry entry in Entries)
		{
			entry.Write(writer);
		}
	}
}
