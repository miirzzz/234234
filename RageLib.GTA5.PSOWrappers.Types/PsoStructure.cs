using System.Collections.Generic;
using RageLib.Data;
using RageLib.GTA5.PSO;
using RageLib.GTA5.PSOWrappers.Data;

namespace RageLib.GTA5.PSOWrappers.Types;

public class PsoStructure : IPsoValue
{
	public readonly PsoFile pso;

	public readonly PsoStructureInfo structureInfo;

	public readonly PsoElementIndexInfo entryIndexInfo;

	public readonly PsoStructureEntryInfo entryInfo;

	public Dictionary<int, IPsoValue> Values { get; set; }

	public PsoStructure(PsoFile pso, PsoStructureInfo structureInfo, PsoElementIndexInfo entryIndexInfo, PsoStructureEntryInfo entryInfo)
	{
		this.pso = pso;
		this.structureInfo = structureInfo;
		this.entryIndexInfo = entryIndexInfo;
		this.entryInfo = entryInfo;
		Values = new Dictionary<int, IPsoValue>();
	}

	public void Read(PsoDataReader reader)
	{
		long position = reader.Position;
		Values = new Dictionary<int, IPsoValue>();
		for (int i = 0; i < structureInfo.Entries.Count; i++)
		{
			PsoStructureEntryInfo psoStructureEntryInfo = structureInfo.Entries[i];
			if (psoStructureEntryInfo.EntryNameHash != 256)
			{
				reader.Position = position + psoStructureEntryInfo.DataOffset;
				IPsoValue psoValue = PsoTypeBuilder.Make(pso, structureInfo, psoStructureEntryInfo);
				psoValue.Read(reader);
				Values.Add(psoStructureEntryInfo.EntryNameHash, psoValue);
			}
		}
		reader.Position = position + structureInfo.StructureLength;
	}

	public void Write(DataWriter writer)
	{
	}
}
