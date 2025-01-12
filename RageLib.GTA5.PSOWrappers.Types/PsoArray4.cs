using System.Collections.Generic;
using RageLib.Data;
using RageLib.GTA5.PSO;
using RageLib.GTA5.PSOWrappers.Data;

namespace RageLib.GTA5.PSOWrappers.Types;

public class PsoArray4 : IPsoValue
{
	public readonly PsoFile pso;

	public readonly PsoStructureInfo structureInfo;

	public readonly PsoStructureEntryInfo entryInfo;

	public readonly int numberOfEntries;

	public List<IPsoValue> Entries { get; set; }

	public PsoArray4(PsoFile pso, PsoStructureInfo structureInfo, PsoStructureEntryInfo entryInfo, int numberOfEntries)
	{
		this.pso = pso;
		this.structureInfo = structureInfo;
		this.entryInfo = entryInfo;
		this.numberOfEntries = numberOfEntries;
	}

	public void Read(PsoDataReader reader)
	{
		Entries = new List<IPsoValue>();
		for (int i = 0; i < numberOfEntries; i++)
		{
			IPsoValue psoValue = PsoTypeBuilder.Make(pso, structureInfo, entryInfo);
			psoValue.Read(reader);
			Entries.Add(psoValue);
		}
	}

	public void Write(DataWriter writer)
	{
	}
}
