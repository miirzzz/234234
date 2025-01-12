using System;
using System.Collections.Generic;
using RageLib.Resources.Common;
using RageLib.Resources.GTA5.PC.Bounds;

namespace RageLib.Resources.GTA5.PC.Fragments;

public class FragPhysicsLOD : ResourceSystemBlock
{
	public uint VFT;

	public uint Unknown_4h;

	public uint Unknown_8h;

	public uint Unknown_Ch;

	public uint Unknown_10h;

	public uint Unknown_14h;

	public uint Unknown_18h;

	public uint Unknown_1Ch;

	public ulong ArticulatedBodyTypePointer;

	public ulong Unknown_28h_Pointer;

	public RAGE_Vector4 Unknown_30h;

	public RAGE_Vector4 Unknown_40h;

	public RAGE_Vector4 Unknown_50h;

	public RAGE_Vector4 Unknown_60h;

	public RAGE_Vector4 Unknown_70h;

	public RAGE_Vector4 Unknown_80h;

	public RAGE_Vector4 Unknown_90h;

	public RAGE_Vector4 Unknown_A0h;

	public RAGE_Vector4 Unknown_B0h;

	public ulong GroupNamesPointer;

	public ulong GroupsPointer;

	public ulong ChildrenPointer;

	public ulong Archetype1Pointer;

	public ulong Archetype2Pointer;

	public ulong BoundPointer;

	public ulong Unknown_F0h_Pointer;

	public ulong Unknown_F8h_Pointer;

	public ulong Unknown_100h_Pointer;

	public ulong Unknown_108h_Pointer;

	public ulong Unknown_110h_Pointer;

	public byte Count1;

	public byte Count2;

	public byte GroupsCount;

	public byte Unknown_11Bh;

	public byte Unknown_11Ch;

	public byte ChildrenCount;

	public byte Count3;

	public byte Unknown_11Fh;

	public uint Unknown_120h;

	public uint Unknown_124h;

	public uint Unknown_128h;

	public uint Unknown_12Ch;

	public ArticulatedBodyType ArticulatedBodyType;

	public ResourceSimpleArray<uint_r> Unknown_28h_Data;

	public ResourcePointerArray64<fragNameStruct> GroupNames;

	public ResourcePointerArray64<FragTypeGroup> Groups;

	public ResourcePointerArray64<FragTypeChild> Children;

	public Archetype Archetype1;

	public Archetype Archetype2;

	public Bound Bound;

	public ResourceSimpleArray<RAGE_Vector4> Unknown_F0h_Data;

	public ResourceSimpleArray<RAGE_Vector4> Unknown_F8h_Data;

	public Unknown_F_001 Unknown_100h_Data;

	public ResourceSimpleArray<byte_r> Unknown_108h_Data;

	public ResourceSimpleArray<byte_r> Unknown_110h_Data;

	public override long Length => 304L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		VFT = reader.ReadUInt32();
		Unknown_4h = reader.ReadUInt32();
		Unknown_8h = reader.ReadUInt32();
		Unknown_Ch = reader.ReadUInt32();
		Unknown_10h = reader.ReadUInt32();
		Unknown_14h = reader.ReadUInt32();
		Unknown_18h = reader.ReadUInt32();
		Unknown_1Ch = reader.ReadUInt32();
		ArticulatedBodyTypePointer = reader.ReadUInt64();
		Unknown_28h_Pointer = reader.ReadUInt64();
		Unknown_30h = reader.ReadBlock<RAGE_Vector4>(Array.Empty<object>());
		Unknown_40h = reader.ReadBlock<RAGE_Vector4>(Array.Empty<object>());
		Unknown_50h = reader.ReadBlock<RAGE_Vector4>(Array.Empty<object>());
		Unknown_60h = reader.ReadBlock<RAGE_Vector4>(Array.Empty<object>());
		Unknown_70h = reader.ReadBlock<RAGE_Vector4>(Array.Empty<object>());
		Unknown_80h = reader.ReadBlock<RAGE_Vector4>(Array.Empty<object>());
		Unknown_90h = reader.ReadBlock<RAGE_Vector4>(Array.Empty<object>());
		Unknown_A0h = reader.ReadBlock<RAGE_Vector4>(Array.Empty<object>());
		Unknown_B0h = reader.ReadBlock<RAGE_Vector4>(Array.Empty<object>());
		GroupNamesPointer = reader.ReadUInt64();
		GroupsPointer = reader.ReadUInt64();
		ChildrenPointer = reader.ReadUInt64();
		Archetype1Pointer = reader.ReadUInt64();
		Archetype2Pointer = reader.ReadUInt64();
		BoundPointer = reader.ReadUInt64();
		Unknown_F0h_Pointer = reader.ReadUInt64();
		Unknown_F8h_Pointer = reader.ReadUInt64();
		Unknown_100h_Pointer = reader.ReadUInt64();
		Unknown_108h_Pointer = reader.ReadUInt64();
		Unknown_110h_Pointer = reader.ReadUInt64();
		Count1 = reader.ReadByte();
		Count2 = reader.ReadByte();
		GroupsCount = reader.ReadByte();
		Unknown_11Bh = reader.ReadByte();
		Unknown_11Ch = reader.ReadByte();
		ChildrenCount = reader.ReadByte();
		Count3 = reader.ReadByte();
		Unknown_11Fh = reader.ReadByte();
		Unknown_120h = reader.ReadUInt32();
		Unknown_124h = reader.ReadUInt32();
		Unknown_128h = reader.ReadUInt32();
		Unknown_12Ch = reader.ReadUInt32();
		ArticulatedBodyType = reader.ReadBlockAt<ArticulatedBodyType>(ArticulatedBodyTypePointer, Array.Empty<object>());
		Unknown_28h_Data = reader.ReadBlockAt<ResourceSimpleArray<uint_r>>(Unknown_28h_Pointer, new object[1] { ChildrenCount });
		GroupNames = reader.ReadBlockAt<ResourcePointerArray64<fragNameStruct>>(GroupNamesPointer, new object[1] { GroupsCount });
		Groups = reader.ReadBlockAt<ResourcePointerArray64<FragTypeGroup>>(GroupsPointer, new object[1] { GroupsCount });
		Children = reader.ReadBlockAt<ResourcePointerArray64<FragTypeChild>>(ChildrenPointer, new object[1] { ChildrenCount });
		Archetype1 = reader.ReadBlockAt<Archetype>(Archetype1Pointer, Array.Empty<object>());
		Archetype2 = reader.ReadBlockAt<Archetype>(Archetype2Pointer, Array.Empty<object>());
		Bound = reader.ReadBlockAt<Bound>(BoundPointer, Array.Empty<object>());
		Unknown_F0h_Data = reader.ReadBlockAt<ResourceSimpleArray<RAGE_Vector4>>(Unknown_F0h_Pointer, new object[1] { ChildrenCount });
		Unknown_F8h_Data = reader.ReadBlockAt<ResourceSimpleArray<RAGE_Vector4>>(Unknown_F8h_Pointer, new object[1] { ChildrenCount });
		Unknown_100h_Data = reader.ReadBlockAt<Unknown_F_001>(Unknown_100h_Pointer, Array.Empty<object>());
		Unknown_108h_Data = reader.ReadBlockAt<ResourceSimpleArray<byte_r>>(Unknown_108h_Pointer, new object[1] { Count1 });
		Unknown_110h_Data = reader.ReadBlockAt<ResourceSimpleArray<byte_r>>(Unknown_110h_Pointer, new object[1] { Count2 });
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		ArticulatedBodyTypePointer = (ulong)((ArticulatedBodyType != null) ? ArticulatedBodyType.Position : 0);
		Unknown_28h_Pointer = (ulong)((Unknown_28h_Data != null) ? Unknown_28h_Data.Position : 0);
		GroupNamesPointer = (ulong)((GroupNames != null) ? GroupNames.Position : 0);
		GroupsPointer = (ulong)((Groups != null) ? Groups.Position : 0);
		ChildrenPointer = (ulong)((Children != null) ? Children.Position : 0);
		Archetype1Pointer = (ulong)((Archetype1 != null) ? Archetype1.Position : 0);
		Archetype2Pointer = (ulong)((Archetype2 != null) ? Archetype2.Position : 0);
		BoundPointer = (ulong)((Bound != null) ? Bound.Position : 0);
		Unknown_F0h_Pointer = (ulong)((Unknown_F0h_Data != null) ? Unknown_F0h_Data.Position : 0);
		Unknown_F8h_Pointer = (ulong)((Unknown_F8h_Data != null) ? Unknown_F8h_Data.Position : 0);
		Unknown_100h_Pointer = (ulong)((Unknown_100h_Data != null) ? Unknown_100h_Data.Position : 0);
		Unknown_108h_Pointer = (ulong)((Unknown_108h_Data != null) ? Unknown_108h_Data.Position : 0);
		Unknown_110h_Pointer = (ulong)((Unknown_110h_Data != null) ? Unknown_110h_Data.Position : 0);
		writer.Write(VFT);
		writer.Write(Unknown_4h);
		writer.Write(Unknown_8h);
		writer.Write(Unknown_Ch);
		writer.Write(Unknown_10h);
		writer.Write(Unknown_14h);
		writer.Write(Unknown_18h);
		writer.Write(Unknown_1Ch);
		writer.Write(ArticulatedBodyTypePointer);
		writer.Write(Unknown_28h_Pointer);
		writer.WriteBlock(Unknown_30h);
		writer.WriteBlock(Unknown_40h);
		writer.WriteBlock(Unknown_50h);
		writer.WriteBlock(Unknown_60h);
		writer.WriteBlock(Unknown_70h);
		writer.WriteBlock(Unknown_80h);
		writer.WriteBlock(Unknown_90h);
		writer.WriteBlock(Unknown_A0h);
		writer.WriteBlock(Unknown_B0h);
		writer.Write(GroupNamesPointer);
		writer.Write(GroupsPointer);
		writer.Write(ChildrenPointer);
		writer.Write(Archetype1Pointer);
		writer.Write(Archetype2Pointer);
		writer.Write(BoundPointer);
		writer.Write(Unknown_F0h_Pointer);
		writer.Write(Unknown_F8h_Pointer);
		writer.Write(Unknown_100h_Pointer);
		writer.Write(Unknown_108h_Pointer);
		writer.Write(Unknown_110h_Pointer);
		writer.Write(Count1);
		writer.Write(Count2);
		writer.Write(GroupsCount);
		writer.Write(Unknown_11Bh);
		writer.Write(Unknown_11Ch);
		writer.Write(ChildrenCount);
		writer.Write(Count3);
		writer.Write(Unknown_11Fh);
		writer.Write(Unknown_120h);
		writer.Write(Unknown_124h);
		writer.Write(Unknown_128h);
		writer.Write(Unknown_12Ch);
	}

	public override IResourceBlock[] GetReferences()
	{
		List<IResourceBlock> list = new List<IResourceBlock>();
		if (ArticulatedBodyType != null)
		{
			list.Add(ArticulatedBodyType);
		}
		if (Unknown_28h_Data != null)
		{
			list.Add(Unknown_28h_Data);
		}
		if (Groups != null)
		{
			list.Add(Groups);
		}
		if (Children != null)
		{
			list.Add(Children);
		}
		if (Archetype1 != null)
		{
			list.Add(Archetype1);
		}
		if (Archetype2 != null)
		{
			list.Add(Archetype2);
		}
		if (Bound != null)
		{
			list.Add(Bound);
		}
		if (Unknown_F0h_Data != null)
		{
			list.Add(Unknown_F0h_Data);
		}
		if (Unknown_F8h_Data != null)
		{
			list.Add(Unknown_F8h_Data);
		}
		if (Unknown_100h_Data != null)
		{
			list.Add(Unknown_100h_Data);
		}
		if (Unknown_108h_Data != null)
		{
			list.Add(Unknown_108h_Data);
		}
		if (Unknown_110h_Data != null)
		{
			list.Add(Unknown_110h_Data);
		}
		if (GroupNames != null)
		{
			list.Add(GroupNames);
		}
		return list.ToArray();
	}
}
