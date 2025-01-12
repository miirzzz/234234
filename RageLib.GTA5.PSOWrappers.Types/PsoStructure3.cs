using System;
using RageLib.Data;
using RageLib.GTA5.PSO;
using RageLib.GTA5.PSOWrappers.Data;

namespace RageLib.GTA5.PSOWrappers.Types;

public class PsoStructure3 : IPsoValue
{
	public readonly PsoFile pso;

	public readonly PsoStructureInfo structureInfo;

	public readonly PsoStructureEntryInfo entryInfo;

	public PsoStructure Value { get; set; }

	public PsoStructure3(PsoFile pso, PsoStructureInfo structureInfo, PsoStructureEntryInfo entryInfo)
	{
		this.pso = pso;
		this.structureInfo = structureInfo;
		this.entryInfo = entryInfo;
	}

	public void Read(PsoDataReader reader)
	{
		int num = reader.ReadInt32();
		if (reader.ReadInt32() != 0)
		{
			throw new Exception("z2 should be zero");
		}
		int num2 = (num >> 12) & 0xFFFFF;
		int num3 = num & 0xFFF;
		if (num3 > 0)
		{
			int nameHash = pso.DataMappingSection.Entries[num3 - 1].NameHash;
			PsoStructureInfo psoStructureInfo = null;
			PsoElementIndexInfo entryIndexInfo = null;
			for (int i = 0; i < pso.DefinitionSection.Entries.Count; i++)
			{
				if (pso.DefinitionSection.EntriesIdx[i].NameHash == nameHash)
				{
					psoStructureInfo = (PsoStructureInfo)pso.DefinitionSection.Entries[i];
					entryIndexInfo = pso.DefinitionSection.EntriesIdx[i];
				}
			}
			int currentSectionIndex = reader.CurrentSectionIndex;
			long position = reader.Position;
			reader.SetSectionIndex(num3 - 1);
			reader.Position = num2;
			Value = new PsoStructure(pso, psoStructureInfo, entryIndexInfo, null);
			Value.Read(reader);
			reader.SetSectionIndex(currentSectionIndex);
			reader.Position = position;
		}
		else
		{
			Value = null;
		}
	}

	public void Write(DataWriter writer)
	{
	}
}
