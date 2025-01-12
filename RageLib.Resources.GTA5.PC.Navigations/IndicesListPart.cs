using System.Collections.Generic;
using RageLib.Resources.Common;

namespace RageLib.Resources.GTA5.PC.Navigations;

public class IndicesListPart : ResourceSystemBlock
{
	public ulong IndicesPointer;

	public uint IndicesCount;

	public uint Unknown_Ch;

	public ResourceSimpleArray<ushort_r> Indices;

	public override long Length => 16L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		IndicesPointer = reader.ReadUInt64();
		IndicesCount = reader.ReadUInt32();
		Unknown_Ch = reader.ReadUInt32();
		Indices = reader.ReadBlockAt<ResourceSimpleArray<ushort_r>>(IndicesPointer, new object[1] { IndicesCount });
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		IndicesPointer = (ulong)((Indices != null) ? Indices.Position : 0);
		IndicesCount = ((Indices != null) ? ((uint)Indices.Count) : 0u);
		writer.Write(IndicesPointer);
		writer.Write(IndicesCount);
		writer.Write(Unknown_Ch);
	}

	public override IResourceBlock[] GetReferences()
	{
		List<IResourceBlock> list = new List<IResourceBlock>();
		if (Indices != null)
		{
			list.Add(Indices);
		}
		return list.ToArray();
	}
}
