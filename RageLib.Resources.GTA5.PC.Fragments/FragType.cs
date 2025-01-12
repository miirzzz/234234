using System;
using System.Collections.Generic;
using RageLib.Resources.Common;
using RageLib.Resources.GTA5.PC.Clothes;
using RageLib.Resources.GTA5.PC.Drawables;

namespace RageLib.Resources.GTA5.PC.Fragments;

public class FragType : FileBase64_GTA5_pc
{
	public uint Unknown_10h;

	public uint Unknown_14h;

	public uint Unknown_18h;

	public uint Unknown_1Ch;

	public uint Unknown_20h;

	public uint Unknown_24h;

	public uint Unknown_28h;

	public uint Unknown_2Ch;

	public ulong DrawablePointer;

	public ulong Unknown_28h_Pointer;

	public ulong Unknown_30h_Pointer;

	public uint Count0;

	public uint Unknown_4Ch;

	public uint Unknown_50h;

	public uint Unknown_54h;

	public ulong NamePointer;

	public ResourcePointerList64<EnvironmentCloth> Clothes;

	public uint Unknown_70h;

	public uint Unknown_74h;

	public uint Unknown_78h;

	public uint Unknown_7Ch;

	public uint Unknown_80h;

	public uint Unknown_84h;

	public uint Unknown_88h;

	public uint Unknown_8Ch;

	public uint Unknown_90h;

	public uint Unknown_94h;

	public uint Unknown_98h;

	public uint Unknown_9Ch;

	public uint Unknown_A0h;

	public uint Unknown_A4h;

	public ulong Unknown_A8h_Pointer;

	public uint Unknown_B0h;

	public uint Unknown_B4h;

	public uint Unknown_B8h;

	public uint Unknown_BCh;

	public uint Unknown_C0h;

	public uint Unknown_C4h;

	public uint Unknown_C8h;

	public uint Unknown_CCh;

	public uint Unknown_D0h;

	public uint Unknown_D4h;

	public byte Unknown_D8h;

	public byte Count3;

	public ushort Unknown_DAh;

	public uint Unknown_DCh;

	public ulong Unknown_E0h_Pointer;

	public uint Unknown_E8h;

	public uint Unknown_ECh;

	public ulong PhysicsLODGroupPointer;

	public ulong Unknown_F8h_Pointer;

	public uint Unknown_100h;

	public uint Unknown_104h;

	public uint Unknown_108h;

	public uint Unknown_10Ch;

	public ResourceSimpleList64<LightAttributes> LightAttributes;

	public ulong Unknown_120h_Pointer;

	public uint Unknown_128h;

	public uint Unknown_12Ch;

	public FragDrawable Drawable;

	public ResourcePointerArray64<FragDrawable> Unknown_28h_Data;

	public ResourcePointerArray64<string_r> Unknown_30h_Data;

	public string_r Name;

	public Unknown_F_003 Unknown_A8h_Data;

	public ResourcePointerArray64<Unknown_F_004> Unknown_E0h_Data;

	public FragPhysicsLODGroup PhysicsLODGroup;

	public FragDrawable Unknown_F8h_Data;

	public Unknown_F_002 Unknown_120h_Data;

	public override long Length => 304L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		base.Read(reader, parameters);
		Unknown_10h = reader.ReadUInt32();
		Unknown_14h = reader.ReadUInt32();
		Unknown_18h = reader.ReadUInt32();
		Unknown_1Ch = reader.ReadUInt32();
		Unknown_20h = reader.ReadUInt32();
		Unknown_24h = reader.ReadUInt32();
		Unknown_28h = reader.ReadUInt32();
		Unknown_2Ch = reader.ReadUInt32();
		DrawablePointer = reader.ReadUInt64();
		Unknown_28h_Pointer = reader.ReadUInt64();
		Unknown_30h_Pointer = reader.ReadUInt64();
		Count0 = reader.ReadUInt32();
		Unknown_4Ch = reader.ReadUInt32();
		Unknown_50h = reader.ReadUInt32();
		Unknown_54h = reader.ReadUInt32();
		NamePointer = reader.ReadUInt64();
		Clothes = reader.ReadBlock<ResourcePointerList64<EnvironmentCloth>>(Array.Empty<object>());
		Unknown_70h = reader.ReadUInt32();
		Unknown_74h = reader.ReadUInt32();
		Unknown_78h = reader.ReadUInt32();
		Unknown_7Ch = reader.ReadUInt32();
		Unknown_80h = reader.ReadUInt32();
		Unknown_84h = reader.ReadUInt32();
		Unknown_88h = reader.ReadUInt32();
		Unknown_8Ch = reader.ReadUInt32();
		Unknown_90h = reader.ReadUInt32();
		Unknown_94h = reader.ReadUInt32();
		Unknown_98h = reader.ReadUInt32();
		Unknown_9Ch = reader.ReadUInt32();
		Unknown_A0h = reader.ReadUInt32();
		Unknown_A4h = reader.ReadUInt32();
		Unknown_A8h_Pointer = reader.ReadUInt64();
		Unknown_B0h = reader.ReadUInt32();
		Unknown_B4h = reader.ReadUInt32();
		Unknown_B8h = reader.ReadUInt32();
		Unknown_BCh = reader.ReadUInt32();
		Unknown_C0h = reader.ReadUInt32();
		Unknown_C4h = reader.ReadUInt32();
		Unknown_C8h = reader.ReadUInt32();
		Unknown_CCh = reader.ReadUInt32();
		Unknown_D0h = reader.ReadUInt32();
		Unknown_D4h = reader.ReadUInt32();
		Unknown_D8h = reader.ReadByte();
		Count3 = reader.ReadByte();
		Unknown_DAh = reader.ReadUInt16();
		Unknown_DCh = reader.ReadUInt32();
		Unknown_E0h_Pointer = reader.ReadUInt64();
		Unknown_E8h = reader.ReadUInt32();
		Unknown_ECh = reader.ReadUInt32();
		PhysicsLODGroupPointer = reader.ReadUInt64();
		Unknown_F8h_Pointer = reader.ReadUInt64();
		Unknown_100h = reader.ReadUInt32();
		Unknown_104h = reader.ReadUInt32();
		Unknown_108h = reader.ReadUInt32();
		Unknown_10Ch = reader.ReadUInt32();
		LightAttributes = reader.ReadBlock<ResourceSimpleList64<LightAttributes>>(Array.Empty<object>());
		Unknown_120h_Pointer = reader.ReadUInt64();
		Unknown_128h = reader.ReadUInt32();
		Unknown_12Ch = reader.ReadUInt32();
		Drawable = reader.ReadBlockAt<FragDrawable>(DrawablePointer, Array.Empty<object>());
		Unknown_28h_Data = reader.ReadBlockAt<ResourcePointerArray64<FragDrawable>>(Unknown_28h_Pointer, new object[1] { Count0 });
		Unknown_30h_Data = reader.ReadBlockAt<ResourcePointerArray64<string_r>>(Unknown_30h_Pointer, new object[1] { Count0 });
		Name = reader.ReadBlockAt<string_r>(NamePointer, Array.Empty<object>());
		Unknown_A8h_Data = reader.ReadBlockAt<Unknown_F_003>(Unknown_A8h_Pointer, Array.Empty<object>());
		Unknown_E0h_Data = reader.ReadBlockAt<ResourcePointerArray64<Unknown_F_004>>(Unknown_E0h_Pointer, new object[1] { Count3 });
		PhysicsLODGroup = reader.ReadBlockAt<FragPhysicsLODGroup>(PhysicsLODGroupPointer, Array.Empty<object>());
		Unknown_F8h_Data = reader.ReadBlockAt<FragDrawable>(Unknown_F8h_Pointer, Array.Empty<object>());
		Unknown_120h_Data = reader.ReadBlockAt<Unknown_F_002>(Unknown_120h_Pointer, Array.Empty<object>());
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		base.Write(writer, parameters);
		DrawablePointer = (ulong)((Drawable != null) ? Drawable.Position : 0);
		Unknown_28h_Pointer = (ulong)((Unknown_28h_Data != null) ? Unknown_28h_Data.Position : 0);
		Unknown_30h_Pointer = (ulong)((Unknown_30h_Data != null) ? Unknown_30h_Data.Position : 0);
		NamePointer = (ulong)((Name != null) ? Name.Position : 0);
		Unknown_A8h_Pointer = (ulong)((Unknown_A8h_Data != null) ? Unknown_A8h_Data.Position : 0);
		Unknown_E0h_Pointer = (ulong)((Unknown_E0h_Data != null) ? Unknown_E0h_Data.Position : 0);
		PhysicsLODGroupPointer = (ulong)((PhysicsLODGroup != null) ? PhysicsLODGroup.Position : 0);
		Unknown_F8h_Pointer = (ulong)((Unknown_F8h_Data != null) ? Unknown_F8h_Data.Position : 0);
		Unknown_120h_Pointer = (ulong)((Unknown_120h_Data != null) ? Unknown_120h_Data.Position : 0);
		writer.Write(Unknown_10h);
		writer.Write(Unknown_14h);
		writer.Write(Unknown_18h);
		writer.Write(Unknown_1Ch);
		writer.Write(Unknown_20h);
		writer.Write(Unknown_24h);
		writer.Write(Unknown_28h);
		writer.Write(Unknown_2Ch);
		writer.Write(DrawablePointer);
		writer.Write(Unknown_28h_Pointer);
		writer.Write(Unknown_30h_Pointer);
		writer.Write(Count0);
		writer.Write(Unknown_4Ch);
		writer.Write(Unknown_50h);
		writer.Write(Unknown_54h);
		writer.Write(NamePointer);
		writer.WriteBlock(Clothes);
		writer.Write(Unknown_70h);
		writer.Write(Unknown_74h);
		writer.Write(Unknown_78h);
		writer.Write(Unknown_7Ch);
		writer.Write(Unknown_80h);
		writer.Write(Unknown_84h);
		writer.Write(Unknown_88h);
		writer.Write(Unknown_8Ch);
		writer.Write(Unknown_90h);
		writer.Write(Unknown_94h);
		writer.Write(Unknown_98h);
		writer.Write(Unknown_9Ch);
		writer.Write(Unknown_A0h);
		writer.Write(Unknown_A4h);
		writer.Write(Unknown_A8h_Pointer);
		writer.Write(Unknown_B0h);
		writer.Write(Unknown_B4h);
		writer.Write(Unknown_B8h);
		writer.Write(Unknown_BCh);
		writer.Write(Unknown_C0h);
		writer.Write(Unknown_C4h);
		writer.Write(Unknown_C8h);
		writer.Write(Unknown_CCh);
		writer.Write(Unknown_D0h);
		writer.Write(Unknown_D4h);
		writer.Write(Unknown_D8h);
		writer.Write(Count3);
		writer.Write(Unknown_DAh);
		writer.Write(Unknown_DCh);
		writer.Write(Unknown_E0h_Pointer);
		writer.Write(Unknown_E8h);
		writer.Write(Unknown_ECh);
		writer.Write(PhysicsLODGroupPointer);
		writer.Write(Unknown_F8h_Pointer);
		writer.Write(Unknown_100h);
		writer.Write(Unknown_104h);
		writer.Write(Unknown_108h);
		writer.Write(Unknown_10Ch);
		writer.WriteBlock(LightAttributes);
		writer.Write(Unknown_120h_Pointer);
		writer.Write(Unknown_128h);
		writer.Write(Unknown_12Ch);
	}

	public override IResourceBlock[] GetReferences()
	{
		List<IResourceBlock> list = new List<IResourceBlock>(base.GetReferences());
		if (Drawable != null)
		{
			list.Add(Drawable);
		}
		if (Unknown_28h_Data != null)
		{
			list.Add(Unknown_28h_Data);
		}
		if (Unknown_30h_Data != null)
		{
			list.Add(Unknown_30h_Data);
		}
		if (Name != null)
		{
			list.Add(Name);
		}
		if (Unknown_A8h_Data != null)
		{
			list.Add(Unknown_A8h_Data);
		}
		if (Unknown_E0h_Data != null)
		{
			list.Add(Unknown_E0h_Data);
		}
		if (PhysicsLODGroup != null)
		{
			list.Add(PhysicsLODGroup);
		}
		if (Unknown_F8h_Data != null)
		{
			list.Add(Unknown_F8h_Data);
		}
		if (Unknown_120h_Data != null)
		{
			list.Add(Unknown_120h_Data);
		}
		return list.ToArray();
	}

	public override Tuple<long, IResourceBlock>[] GetParts()
	{
		return new Tuple<long, IResourceBlock>[2]
		{
			new Tuple<long, IResourceBlock>(96L, Clothes),
			new Tuple<long, IResourceBlock>(272L, LightAttributes)
		};
	}
}
