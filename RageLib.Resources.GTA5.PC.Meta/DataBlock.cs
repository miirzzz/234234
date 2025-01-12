using System.Collections.Generic;
using RageLib.Resources.Common;

namespace RageLib.Resources.GTA5.PC.Meta;

public class DataBlock : ResourceSystemBlock
{
	public override long Length => 16L;

	public int StructureNameHash { get; set; }

	public int DataLength { get; private set; }

	public long DataPointer { get; private set; }

	public ResourceSimpleArray<byte_r> Data { get; set; }

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		StructureNameHash = reader.ReadInt32();
		DataLength = reader.ReadInt32();
		DataPointer = reader.ReadInt64();
		Data = reader.ReadBlockAt<ResourceSimpleArray<byte_r>>((ulong)DataPointer, new object[1] { DataLength });
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		DataLength = Data?.Count ?? 0;
		DataPointer = Data?.Position ?? 0;
		writer.Write(StructureNameHash);
		writer.Write(DataLength);
		writer.Write(DataPointer);
	}

	public override IResourceBlock[] GetReferences()
	{
		List<IResourceBlock> list = new List<IResourceBlock>();
		if (Data != null)
		{
			list.Add(Data);
		}
		return list.ToArray();
	}
}
