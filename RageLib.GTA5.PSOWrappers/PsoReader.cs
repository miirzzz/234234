using System.Collections.Generic;
using System.IO;
using RageLib.GTA5.PSO;
using RageLib.GTA5.PSOWrappers.Data;
using RageLib.GTA5.PSOWrappers.Types;

namespace RageLib.GTA5.PSOWrappers;

public class PsoReader
{
	public IPsoValue Read(string fileName)
	{
		using FileStream fileStream = new FileStream(fileName, FileMode.Open);
		return Read(fileStream);
	}

	public IPsoValue Read(Stream fileStream)
	{
		PsoFile psoFile = new PsoFile();
		psoFile.Load(fileStream);
		return Parse(psoFile);
	}

	public IPsoValue Parse(PsoFile meta)
	{
		new List<int>();
		new List<List<IPsoValue>>();
		PsoStructureInfo structureInfo = null;
		PsoElementIndexInfo entryIndexInfo = null;
		int nameHash = meta.DataMappingSection.Entries[meta.DataMappingSection.RootIndex - 1].NameHash;
		for (int i = 0; i < meta.DefinitionSection.Count; i++)
		{
			if (meta.DefinitionSection.EntriesIdx[i].NameHash == nameHash)
			{
				structureInfo = (PsoStructureInfo)meta.DefinitionSection.Entries[i];
				entryIndexInfo = meta.DefinitionSection.EntriesIdx[i];
			}
		}
		PsoStructure psoStructure = new PsoStructure(meta, structureInfo, entryIndexInfo, null);
		PsoDataReader psoDataReader = new PsoDataReader(meta);
		psoDataReader.SetSectionIndex(meta.DataMappingSection.RootIndex - 1);
		psoDataReader.Position = 0L;
		psoStructure.Read(psoDataReader);
		return psoStructure;
	}
}
