using System.Collections.Generic;
using RageLib.Resources.Common;

namespace RageLib.Resources.GTA5.PC.Navigations;

public class AdjPolysListPart : ResourceSystemBlock
{
	public ulong AdjPolysPointer;

	public uint AdjPolysCount;

	public uint Unknown_Ch;

	public ResourceSimpleArray<AdjPoly> AdjPolys;

	public override long Length => 16L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		AdjPolysPointer = reader.ReadUInt64();
		AdjPolysCount = reader.ReadUInt32();
		Unknown_Ch = reader.ReadUInt32();
		AdjPolys = reader.ReadBlockAt<ResourceSimpleArray<AdjPoly>>(AdjPolysPointer, new object[1] { AdjPolysCount });
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		AdjPolysPointer = (ulong)((AdjPolys != null) ? AdjPolys.Position : 0);
		AdjPolysCount = ((AdjPolys != null) ? ((uint)AdjPolys.Count) : 0u);
		writer.Write(AdjPolysPointer);
		writer.Write(AdjPolysCount);
		writer.Write(Unknown_Ch);
	}

	public override IResourceBlock[] GetReferences()
	{
		List<IResourceBlock> list = new List<IResourceBlock>();
		if (AdjPolys != null)
		{
			list.Add(AdjPolys);
		}
		return list.ToArray();
	}
}
