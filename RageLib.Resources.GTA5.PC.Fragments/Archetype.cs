using System;
using System.Collections.Generic;
using RageLib.Resources.Common;
using RageLib.Resources.GTA5.PC.Bounds;

namespace RageLib.Resources.GTA5.PC.Fragments;

public class Archetype : ResourceSystemBlock
{
	public float Unknown_0h;

	public uint Unknown_4h;

	public uint Unknown_8h;

	public uint Unknown_Ch;

	public uint Unknown_10h;

	public uint Unknown_14h;

	public ulong NamePointer;

	public ulong BoundPointer;

	public uint Unknown_28h;

	public uint Unknown_2Ch;

	public uint Unknown_30h;

	public uint Unknown_34h;

	public uint Unknown_38h;

	public uint Unknown_3Ch;

	public float Unknown_40h;

	public float Unknown_44h;

	public float Unknown_48h;

	public float Unknown_4Ch;

	public float Unknown_50h;

	public float Unknown_54h;

	public uint Unknown_58h;

	public uint Unknown_5Ch;

	public RAGE_Vector4 Unknown_60h;

	public RAGE_Vector4 Unknown_70h;

	public RAGE_Vector4 Unknown_80h;

	public RAGE_Vector4 Unknown_90h;

	public RAGE_Vector4 Unknown_A0h;

	public RAGE_Vector4 Unknown_B0h;

	public RAGE_Vector4 Unknown_C0h;

	public RAGE_Vector4 Unknown_D0h;

	public string_r Name;

	public Bound Bound;

	public override long Length => 224L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		Unknown_0h = reader.ReadSingle();
		Unknown_4h = reader.ReadUInt32();
		Unknown_8h = reader.ReadUInt32();
		Unknown_Ch = reader.ReadUInt32();
		Unknown_10h = reader.ReadUInt32();
		Unknown_14h = reader.ReadUInt32();
		NamePointer = reader.ReadUInt64();
		BoundPointer = reader.ReadUInt64();
		Unknown_28h = reader.ReadUInt32();
		Unknown_2Ch = reader.ReadUInt32();
		Unknown_30h = reader.ReadUInt32();
		Unknown_34h = reader.ReadUInt32();
		Unknown_38h = reader.ReadUInt32();
		Unknown_3Ch = reader.ReadUInt32();
		Unknown_40h = reader.ReadSingle();
		Unknown_44h = reader.ReadSingle();
		Unknown_48h = reader.ReadSingle();
		Unknown_4Ch = reader.ReadSingle();
		Unknown_50h = reader.ReadSingle();
		Unknown_54h = reader.ReadSingle();
		Unknown_58h = reader.ReadUInt32();
		Unknown_5Ch = reader.ReadUInt32();
		Unknown_60h = reader.ReadBlock<RAGE_Vector4>(Array.Empty<object>());
		Unknown_70h = reader.ReadBlock<RAGE_Vector4>(Array.Empty<object>());
		Unknown_80h = reader.ReadBlock<RAGE_Vector4>(Array.Empty<object>());
		Unknown_90h = reader.ReadBlock<RAGE_Vector4>(Array.Empty<object>());
		Unknown_A0h = reader.ReadBlock<RAGE_Vector4>(Array.Empty<object>());
		Unknown_B0h = reader.ReadBlock<RAGE_Vector4>(Array.Empty<object>());
		Unknown_C0h = reader.ReadBlock<RAGE_Vector4>(Array.Empty<object>());
		Unknown_D0h = reader.ReadBlock<RAGE_Vector4>(Array.Empty<object>());
		Name = reader.ReadBlockAt<string_r>(NamePointer, Array.Empty<object>());
		Bound = reader.ReadBlockAt<Bound>(BoundPointer, Array.Empty<object>());
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		NamePointer = (ulong)((Name != null) ? Name.Position : 0);
		BoundPointer = (ulong)((Bound != null) ? Bound.Position : 0);
		writer.Write(Unknown_0h);
		writer.Write(Unknown_4h);
		writer.Write(Unknown_8h);
		writer.Write(Unknown_Ch);
		writer.Write(Unknown_10h);
		writer.Write(Unknown_14h);
		writer.Write(NamePointer);
		writer.Write(BoundPointer);
		writer.Write(Unknown_28h);
		writer.Write(Unknown_2Ch);
		writer.Write(Unknown_30h);
		writer.Write(Unknown_34h);
		writer.Write(Unknown_38h);
		writer.Write(Unknown_3Ch);
		writer.Write(Unknown_40h);
		writer.Write(Unknown_44h);
		writer.Write(Unknown_48h);
		writer.Write(Unknown_4Ch);
		writer.Write(Unknown_50h);
		writer.Write(Unknown_54h);
		writer.Write(Unknown_58h);
		writer.Write(Unknown_5Ch);
		writer.WriteBlock(Unknown_60h);
		writer.WriteBlock(Unknown_70h);
		writer.WriteBlock(Unknown_80h);
		writer.WriteBlock(Unknown_90h);
		writer.WriteBlock(Unknown_A0h);
		writer.WriteBlock(Unknown_B0h);
		writer.WriteBlock(Unknown_C0h);
		writer.WriteBlock(Unknown_D0h);
	}

	public override IResourceBlock[] GetReferences()
	{
		List<IResourceBlock> list = new List<IResourceBlock>();
		if (Name != null)
		{
			list.Add(Name);
		}
		if (Bound != null)
		{
			list.Add(Bound);
		}
		return list.ToArray();
	}
}
