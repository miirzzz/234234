using System.Collections.Generic;
using RageLib.Resources.Common;

namespace RageLib.Resources.GTA5.PC.Drawables;

public class SkeletonData : ResourceSystemBlock
{
	public uint VFT;

	public uint Unknown_4h;

	public uint Unknown_8h;

	public uint Unknown_Ch;

	public ulong Unknown_10h_Pointer;

	public ushort Count1;

	public ushort Count2;

	public uint Unknown_1Ch;

	public ulong BonesPointer;

	public ulong TransformationsInvertedPointer;

	public ulong TransformationsPointer;

	public ulong ParentIndicesPointer;

	public ulong Unknown_40h_Pointer;

	public uint Unknown_48h;

	public uint Unknown_4Ch;

	public uint Unknown_50h;

	public uint Unknown_54h;

	public uint Unknown_58h;

	public ushort Unknown_5Ch;

	public ushort BonesCount;

	public ushort Count4;

	public ushort Unknown_62h;

	public uint Unknown_64h;

	public uint Unknown_68h;

	public uint Unknown_6Ch;

	public ResourcePointerArray64<Unknown_D_001> Unknown_10h_Data;

	public ResourceSimpleArray<Bone> Bones;

	public ResourceSimpleArray<RAGE_Matrix4> TransformationsInverted;

	public ResourceSimpleArray<RAGE_Matrix4> Transformations;

	public ResourceSimpleArray<ushort_r> ParentIndices;

	public ResourceSimpleArray<ushort_r> Unknown_40h_Data;

	public override long Length => 112L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		VFT = reader.ReadUInt32();
		Unknown_4h = reader.ReadUInt32();
		Unknown_8h = reader.ReadUInt32();
		Unknown_Ch = reader.ReadUInt32();
		Unknown_10h_Pointer = reader.ReadUInt64();
		Count1 = reader.ReadUInt16();
		Count2 = reader.ReadUInt16();
		Unknown_1Ch = reader.ReadUInt32();
		BonesPointer = reader.ReadUInt64();
		TransformationsInvertedPointer = reader.ReadUInt64();
		TransformationsPointer = reader.ReadUInt64();
		ParentIndicesPointer = reader.ReadUInt64();
		Unknown_40h_Pointer = reader.ReadUInt64();
		Unknown_48h = reader.ReadUInt32();
		Unknown_4Ch = reader.ReadUInt32();
		Unknown_50h = reader.ReadUInt32();
		Unknown_54h = reader.ReadUInt32();
		Unknown_58h = reader.ReadUInt32();
		Unknown_5Ch = reader.ReadUInt16();
		BonesCount = reader.ReadUInt16();
		Count4 = reader.ReadUInt16();
		Unknown_62h = reader.ReadUInt16();
		Unknown_64h = reader.ReadUInt32();
		Unknown_68h = reader.ReadUInt32();
		Unknown_6Ch = reader.ReadUInt32();
		Unknown_10h_Data = reader.ReadBlockAt<ResourcePointerArray64<Unknown_D_001>>(Unknown_10h_Pointer, new object[1] { Count1 });
		Bones = reader.ReadBlockAt<ResourceSimpleArray<Bone>>(BonesPointer, new object[1] { BonesCount });
		TransformationsInverted = reader.ReadBlockAt<ResourceSimpleArray<RAGE_Matrix4>>(TransformationsInvertedPointer, new object[1] { BonesCount });
		Transformations = reader.ReadBlockAt<ResourceSimpleArray<RAGE_Matrix4>>(TransformationsPointer, new object[1] { BonesCount });
		ParentIndices = reader.ReadBlockAt<ResourceSimpleArray<ushort_r>>(ParentIndicesPointer, new object[1] { BonesCount });
		Unknown_40h_Data = reader.ReadBlockAt<ResourceSimpleArray<ushort_r>>(Unknown_40h_Pointer, new object[1] { Count4 });
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		Unknown_10h_Pointer = (ulong)((Unknown_10h_Data != null) ? Unknown_10h_Data.Position : 0);
		Count1 = (ushort)(Unknown_10h_Data?.Count ?? 0);
		if (Unknown_10h_Data != null)
		{
			int num = 0;
			foreach (Unknown_D_001 data_item in Unknown_10h_Data.data_items)
			{
				if (data_item == null)
				{
					continue;
				}
				Unknown_D_001 unknown_D_ = data_item;
				while (true)
				{
					num++;
					if (unknown_D_.Next == null)
					{
						break;
					}
					unknown_D_ = unknown_D_.Next;
				}
			}
			Count2 = (ushort)num;
		}
		else
		{
			Count2 = 0;
		}
		BonesPointer = (ulong)((Bones != null) ? Bones.Position : 0);
		TransformationsInvertedPointer = (ulong)((TransformationsInverted != null) ? TransformationsInverted.Position : 0);
		TransformationsPointer = (ulong)((Transformations != null) ? Transformations.Position : 0);
		ParentIndicesPointer = (ulong)((ParentIndices != null) ? ParentIndices.Position : 0);
		Unknown_40h_Pointer = (ulong)((Unknown_40h_Data != null) ? Unknown_40h_Data.Position : 0);
		BonesCount = (ushort)(Bones?.Count ?? 0);
		Count4 = (ushort)((Unknown_40h_Data != null) ? ((uint)Unknown_40h_Data.Count) : 0u);
		writer.Write(VFT);
		writer.Write(Unknown_4h);
		writer.Write(Unknown_8h);
		writer.Write(Unknown_Ch);
		writer.Write(Unknown_10h_Pointer);
		writer.Write(Count1);
		writer.Write(Count2);
		writer.Write(Unknown_1Ch);
		writer.Write(BonesPointer);
		writer.Write(TransformationsInvertedPointer);
		writer.Write(TransformationsPointer);
		writer.Write(ParentIndicesPointer);
		writer.Write(Unknown_40h_Pointer);
		writer.Write(Unknown_48h);
		writer.Write(Unknown_4Ch);
		writer.Write(Unknown_50h);
		writer.Write(Unknown_54h);
		writer.Write(Unknown_58h);
		writer.Write(Unknown_5Ch);
		writer.Write(BonesCount);
		writer.Write(Count4);
		writer.Write(Unknown_62h);
		writer.Write(Unknown_64h);
		writer.Write(Unknown_68h);
		writer.Write(Unknown_6Ch);
	}

	public override IResourceBlock[] GetReferences()
	{
		List<IResourceBlock> list = new List<IResourceBlock>();
		if (Unknown_10h_Data != null)
		{
			list.Add(Unknown_10h_Data);
		}
		if (Bones != null)
		{
			list.Add(Bones);
		}
		if (TransformationsInverted != null)
		{
			list.Add(TransformationsInverted);
		}
		if (Transformations != null)
		{
			list.Add(Transformations);
		}
		if (ParentIndices != null)
		{
			list.Add(ParentIndices);
		}
		if (Unknown_40h_Data != null)
		{
			list.Add(Unknown_40h_Data);
		}
		return list.ToArray();
	}
}
