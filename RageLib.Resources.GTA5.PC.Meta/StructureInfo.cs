using System.Collections.Generic;
using RageLib.Resources.Common;

namespace RageLib.Resources.GTA5.PC.Meta;

public class StructureInfo : ResourceSystemBlock
{
	public ResourceSimpleArray<StructureEntryInfo> Entries;

	public override long Length => 32L;

	public int StructureNameHash { get; set; }

	public int StructureKey { get; set; }

	public int Unknown_8h { get; set; }

	public int Unknown_Ch { get; set; }

	public long EntriesPointer { get; private set; }

	public int StructureLength { get; set; }

	public short Unknown_1Ch { get; set; }

	public short EntriesCount { get; private set; }

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		StructureNameHash = reader.ReadInt32();
		StructureKey = reader.ReadInt32();
		Unknown_8h = reader.ReadInt32();
		Unknown_Ch = reader.ReadInt32();
		EntriesPointer = reader.ReadInt64();
		StructureLength = reader.ReadInt32();
		Unknown_1Ch = reader.ReadInt16();
		EntriesCount = reader.ReadInt16();
		Entries = reader.ReadBlockAt<ResourceSimpleArray<StructureEntryInfo>>((uint)EntriesPointer, new object[1] { EntriesCount });
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		EntriesPointer = Entries?.Position ?? 0;
		EntriesCount = (short)(Entries?.Count ?? 0);
		writer.Write(StructureNameHash);
		writer.Write(StructureKey);
		writer.Write(Unknown_8h);
		writer.Write(Unknown_Ch);
		writer.Write(EntriesPointer);
		writer.Write(StructureLength);
		writer.Write(Unknown_1Ch);
		writer.Write(EntriesCount);
	}

	public override IResourceBlock[] GetReferences()
	{
		List<IResourceBlock> list = new List<IResourceBlock>();
		if (Entries != null)
		{
			list.Add(Entries);
		}
		return list.ToArray();
	}
}
