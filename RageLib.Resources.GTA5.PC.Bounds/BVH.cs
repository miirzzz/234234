using System;
using System.Collections.Generic;
using RageLib.Resources.Common;

namespace RageLib.Resources.GTA5.PC.Bounds;

public class BVH : ResourceSystemBlock
{
	public ulong NodesPointer;

	public uint NodesCount;

	public uint NodesCapacity;

	public uint Unknown_10h;

	public uint Unknown_14h;

	public uint Unknown_18h;

	public uint Unknown_1Ch;

	public RAGE_Vector4 BoundingBoxMin;

	public RAGE_Vector4 BoundingBoxMax;

	public RAGE_Vector4 BoundingBoxCenter;

	public RAGE_Vector4 QuantumInverse;

	public RAGE_Vector4 Quantum;

	public ulong TreesPointer;

	public ushort TreesCount1;

	public ushort TreesCount2;

	public uint Unknown_7Ch;

	public ResourceSimpleArray<BVHNode> Nodes;

	public ResourceSimpleArray<BVHTreeInfo> Trees;

	public override long Length => 128L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		NodesPointer = reader.ReadUInt64();
		NodesCount = reader.ReadUInt32();
		NodesCapacity = reader.ReadUInt32();
		Unknown_10h = reader.ReadUInt32();
		Unknown_14h = reader.ReadUInt32();
		Unknown_18h = reader.ReadUInt32();
		Unknown_1Ch = reader.ReadUInt32();
		BoundingBoxMin = reader.ReadBlock<RAGE_Vector4>(Array.Empty<object>());
		BoundingBoxMax = reader.ReadBlock<RAGE_Vector4>(Array.Empty<object>());
		BoundingBoxCenter = reader.ReadBlock<RAGE_Vector4>(Array.Empty<object>());
		QuantumInverse = reader.ReadBlock<RAGE_Vector4>(Array.Empty<object>());
		Quantum = reader.ReadBlock<RAGE_Vector4>(Array.Empty<object>());
		TreesPointer = reader.ReadUInt64();
		TreesCount1 = reader.ReadUInt16();
		TreesCount2 = reader.ReadUInt16();
		Unknown_7Ch = reader.ReadUInt32();
		Nodes = reader.ReadBlockAt<ResourceSimpleArray<BVHNode>>(NodesPointer, new object[1] { NodesCount });
		Trees = reader.ReadBlockAt<ResourceSimpleArray<BVHTreeInfo>>(TreesPointer, new object[1] { TreesCount1 });
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		NodesPointer = (ulong)((Nodes != null) ? Nodes.Position : 0);
		NodesCount = ((Nodes != null) ? ((uint)Nodes.Count) : 0u);
		NodesCapacity = ((Nodes != null) ? ((uint)Nodes.Count) : 0u);
		TreesPointer = (ulong)((Trees != null) ? Trees.Position : 0);
		TreesCount1 = (ushort)((Trees != null) ? ((uint)Trees.Count) : 0u);
		TreesCount2 = (ushort)((Trees != null) ? ((uint)Trees.Count) : 0u);
		writer.Write(NodesPointer);
		writer.Write(NodesCount);
		writer.Write(NodesCapacity);
		writer.Write(Unknown_10h);
		writer.Write(Unknown_14h);
		writer.Write(Unknown_18h);
		writer.Write(Unknown_1Ch);
		writer.WriteBlock(BoundingBoxMin);
		writer.WriteBlock(BoundingBoxMax);
		writer.WriteBlock(BoundingBoxCenter);
		writer.WriteBlock(QuantumInverse);
		writer.WriteBlock(Quantum);
		writer.Write(TreesPointer);
		writer.Write(TreesCount1);
		writer.Write(TreesCount2);
		writer.Write(Unknown_7Ch);
	}

	public override IResourceBlock[] GetReferences()
	{
		List<IResourceBlock> list = new List<IResourceBlock>();
		if (Nodes != null)
		{
			list.Add(Nodes);
		}
		if (Trees != null)
		{
			list.Add(Trees);
		}
		return list.ToArray();
	}

	public override Tuple<long, IResourceBlock>[] GetParts()
	{
		return new Tuple<long, IResourceBlock>[5]
		{
			new Tuple<long, IResourceBlock>(32L, BoundingBoxMin),
			new Tuple<long, IResourceBlock>(48L, BoundingBoxMax),
			new Tuple<long, IResourceBlock>(64L, BoundingBoxCenter),
			new Tuple<long, IResourceBlock>(80L, QuantumInverse),
			new Tuple<long, IResourceBlock>(96L, Quantum)
		};
	}
}
