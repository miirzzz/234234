using System.Collections.Generic;
using RageLib.Resources.Common;

namespace RageLib.Resources.GTA5.PC.Navigations;

public class PolysListPart : ResourceSystemBlock
{
	public ulong PolysPointer;

	public uint PolysCount;

	public uint Unknown_Ch;

	public ResourceSimpleArray<Poly> Polys;

	public override long Length => 16L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		PolysPointer = reader.ReadUInt64();
		PolysCount = reader.ReadUInt32();
		Unknown_Ch = reader.ReadUInt32();
		Polys = reader.ReadBlockAt<ResourceSimpleArray<Poly>>(PolysPointer, new object[1] { PolysCount });
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		PolysPointer = (ulong)((Polys != null) ? Polys.Position : 0);
		PolysCount = ((Polys != null) ? ((uint)Polys.Count) : 0u);
		writer.Write(PolysPointer);
		writer.Write(PolysCount);
		writer.Write(Unknown_Ch);
	}

	public override IResourceBlock[] GetReferences()
	{
		List<IResourceBlock> list = new List<IResourceBlock>();
		if (Polys != null)
		{
			list.Add(Polys);
		}
		return list.ToArray();
	}
}
