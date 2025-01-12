using System;
using System.Collections.Generic;
using RageLib.Data;
using RageLib.GTA5.PSO;
using RageLib.GTA5.PSOWrappers.Data;

namespace RageLib.GTA5.PSOWrappers.Types;

public class PsoMap : IPsoValue
{
	public readonly PsoFile pso;

	public readonly PsoStructureInfo structureInfo;

	public readonly PsoStructureEntryInfo keyEntryInfo;

	public readonly PsoStructureEntryInfo valueEntryInfo;

	public List<PsoStructure> Entries { get; set; }

	public PsoMap(PsoFile pso, PsoStructureInfo structureInfo, PsoStructureEntryInfo keyEntryInfo, PsoStructureEntryInfo valueEntryInfo)
	{
		this.pso = pso;
		this.structureInfo = structureInfo;
		this.keyEntryInfo = keyEntryInfo;
		this.valueEntryInfo = valueEntryInfo;
	}

	public void Read(PsoDataReader reader)
	{
		reader.ReadInt32();
		reader.ReadInt32();
		int num = reader.ReadInt32();
		int num2 = (num >> 12) & 0xFFFFF;
		int num3 = num & 0xFFF;
		reader.ReadInt32();
		int num4 = reader.ReadInt32();
		int num5 = (num4 >> 16) & 0xFFFF;
		int num6 = num4 & 0xFFFF;
		if (num5 != num6)
		{
			throw new Exception("length does not match");
		}
		reader.ReadInt32();
		int currentSectionIndex = reader.CurrentSectionIndex;
		long position = reader.Position;
		reader.SetSectionIndex(num3 - 1);
		reader.Position = num2;
		int nameHash = pso.DataMappingSection.Entries[num3 - 1].NameHash;
		PsoStructureInfo psoStructureInfo = null;
		for (int i = 0; i < pso.DefinitionSection.EntriesIdx.Count; i++)
		{
			if (pso.DefinitionSection.EntriesIdx[i].NameHash == nameHash)
			{
				psoStructureInfo = (PsoStructureInfo)pso.DefinitionSection.Entries[i];
			}
		}
		Entries = new List<PsoStructure>();
		for (int j = 0; j < num5; j++)
		{
			PsoStructure psoStructure = new PsoStructure(pso, psoStructureInfo, null, null);
			psoStructure.Read(reader);
			Entries.Add(psoStructure);
		}
		reader.SetSectionIndex(currentSectionIndex);
		reader.Position = position;
	}

	public void Write(DataWriter writer)
	{
	}
}
