using System;
using System.Collections.Generic;
using RageLib.Resources.Common;

namespace RageLib.Resources.GTA5.PC.Bounds;

public class BoundComposite : Bound
{
	public ulong ChildrenPointer;

	public ulong ChildTransformations1Pointer;

	public ulong ChildTransformations2Pointer;

	public ulong ChildBoundingBoxesPointer;

	public ulong ChildFlags1Pointer;

	public ulong ChildFlags2Pointer;

	public ushort ChildrenCount1;

	public ushort ChildrenCount2;

	public uint Unknown_A4h;

	public ulong BVHPointer;

	public ResourcePointerArray64<Bound> Children;

	public ResourceSimpleArray<RAGE_Matrix4> ChildTransformations1;

	public ResourceSimpleArray<RAGE_Matrix4> ChildTransformations2;

	public ResourceSimpleArray<RAGE_AABB> ChildBoundingBoxes;

	public ResourceSimpleArray<ulong_r> ChildFlags1;

	public ResourceSimpleArray<ulong_r> ChildFlags2;

	public BVH BVH;

	public override long Length => 176L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		base.Read(reader, parameters);
		ChildrenPointer = reader.ReadUInt64();
		ChildTransformations1Pointer = reader.ReadUInt64();
		ChildTransformations2Pointer = reader.ReadUInt64();
		ChildBoundingBoxesPointer = reader.ReadUInt64();
		ChildFlags1Pointer = reader.ReadUInt64();
		ChildFlags2Pointer = reader.ReadUInt64();
		ChildrenCount1 = reader.ReadUInt16();
		ChildrenCount2 = reader.ReadUInt16();
		Unknown_A4h = reader.ReadUInt32();
		BVHPointer = reader.ReadUInt64();
		Children = reader.ReadBlockAt<ResourcePointerArray64<Bound>>(ChildrenPointer, new object[1] { ChildrenCount1 });
		ChildTransformations1 = reader.ReadBlockAt<ResourceSimpleArray<RAGE_Matrix4>>(ChildTransformations1Pointer, new object[1] { ChildrenCount1 });
		ChildTransformations2 = reader.ReadBlockAt<ResourceSimpleArray<RAGE_Matrix4>>(ChildTransformations2Pointer, new object[1] { ChildrenCount1 });
		ChildBoundingBoxes = reader.ReadBlockAt<ResourceSimpleArray<RAGE_AABB>>(ChildBoundingBoxesPointer, new object[1] { ChildrenCount1 });
		ChildFlags1 = reader.ReadBlockAt<ResourceSimpleArray<ulong_r>>(ChildFlags1Pointer, new object[1] { ChildrenCount1 });
		ChildFlags2 = reader.ReadBlockAt<ResourceSimpleArray<ulong_r>>(ChildFlags2Pointer, new object[1] { ChildrenCount1 });
		BVH = reader.ReadBlockAt<BVH>(BVHPointer, Array.Empty<object>());
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		base.Write(writer, parameters);
		ChildrenPointer = (ulong)((Children != null) ? Children.Position : 0);
		ChildTransformations1Pointer = (ulong)((ChildTransformations1 != null) ? ChildTransformations1.Position : 0);
		ChildTransformations2Pointer = (ulong)((ChildTransformations2 != null) ? ChildTransformations2.Position : 0);
		ChildBoundingBoxesPointer = (ulong)((ChildBoundingBoxes != null) ? ChildBoundingBoxes.Position : 0);
		ChildFlags1Pointer = (ulong)((ChildFlags1 != null) ? ChildFlags1.Position : 0);
		ChildFlags2Pointer = (ulong)((ChildFlags2 != null) ? ChildFlags2.Position : 0);
		ChildrenCount1 = (ushort)((Children != null) ? ((uint)Children.Count) : 0u);
		ChildrenCount2 = (ushort)((Children != null) ? ((uint)Children.Count) : 0u);
		BVHPointer = (ulong)((BVH != null) ? BVH.Position : 0);
		writer.Write(ChildrenPointer);
		writer.Write(ChildTransformations1Pointer);
		writer.Write(ChildTransformations2Pointer);
		writer.Write(ChildBoundingBoxesPointer);
		writer.Write(ChildFlags1Pointer);
		writer.Write(ChildFlags2Pointer);
		writer.Write(ChildrenCount1);
		writer.Write(ChildrenCount2);
		writer.Write(Unknown_A4h);
		writer.Write(BVHPointer);
	}

	public override IResourceBlock[] GetReferences()
	{
		List<IResourceBlock> list = new List<IResourceBlock>(base.GetReferences());
		if (Children != null)
		{
			list.Add(Children);
		}
		if (ChildTransformations1 != null)
		{
			list.Add(ChildTransformations1);
		}
		if (ChildTransformations2 != null)
		{
			list.Add(ChildTransformations2);
		}
		if (ChildBoundingBoxes != null)
		{
			list.Add(ChildBoundingBoxes);
		}
		if (ChildFlags1 != null)
		{
			list.Add(ChildFlags1);
		}
		if (ChildFlags2 != null)
		{
			list.Add(ChildFlags2);
		}
		if (BVH != null)
		{
			list.Add(BVH);
		}
		return list.ToArray();
	}
}
