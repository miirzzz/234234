using System;
using System.Collections.Generic;

namespace RageLib.Resources.GTA5.PC.Fragments;

public class FragTypeChild : ResourceSystemBlock
{
	public uint VFT;

	public uint Unknown_4h;

	public uint Unknown_8h;

	public uint Unknown_Ch;

	public uint Unknown_10h;

	public uint Unknown_14h;

	public uint Unknown_18h;

	public uint Unknown_1Ch;

	public uint Unknown_20h;

	public uint Unknown_24h;

	public uint Unknown_28h;

	public uint Unknown_2Ch;

	public uint Unknown_30h;

	public uint Unknown_34h;

	public uint Unknown_38h;

	public uint Unknown_3Ch;

	public uint Unknown_40h;

	public uint Unknown_44h;

	public uint Unknown_48h;

	public uint Unknown_4Ch;

	public uint Unknown_50h;

	public uint Unknown_54h;

	public uint Unknown_58h;

	public uint Unknown_5Ch;

	public uint Unknown_60h;

	public uint Unknown_64h;

	public uint Unknown_68h;

	public uint Unknown_6Ch;

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

	public ulong Drawable1Pointer;

	public ulong Drawable2Pointer;

	public ulong EvtSetPointer;

	public uint Unknown_B8h;

	public uint Unknown_BCh;

	public uint Unknown_C0h;

	public uint Unknown_C4h;

	public uint Unknown_C8h;

	public uint Unknown_CCh;

	public uint Unknown_D0h;

	public uint Unknown_D4h;

	public uint Unknown_D8h;

	public uint Unknown_DCh;

	public uint Unknown_E0h;

	public uint Unknown_E4h;

	public uint Unknown_E8h;

	public uint Unknown_ECh;

	public uint Unknown_F0h;

	public uint Unknown_F4h;

	public uint Unknown_F8h;

	public uint Unknown_FCh;

	public FragDrawable Drawable1;

	public FragDrawable Drawable2;

	public EvtSet EvtSet;

	public override long Length => 256L;

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
		Unknown_20h = reader.ReadUInt32();
		Unknown_24h = reader.ReadUInt32();
		Unknown_28h = reader.ReadUInt32();
		Unknown_2Ch = reader.ReadUInt32();
		Unknown_30h = reader.ReadUInt32();
		Unknown_34h = reader.ReadUInt32();
		Unknown_38h = reader.ReadUInt32();
		Unknown_3Ch = reader.ReadUInt32();
		Unknown_40h = reader.ReadUInt32();
		Unknown_44h = reader.ReadUInt32();
		Unknown_48h = reader.ReadUInt32();
		Unknown_4Ch = reader.ReadUInt32();
		Unknown_50h = reader.ReadUInt32();
		Unknown_54h = reader.ReadUInt32();
		Unknown_58h = reader.ReadUInt32();
		Unknown_5Ch = reader.ReadUInt32();
		Unknown_60h = reader.ReadUInt32();
		Unknown_64h = reader.ReadUInt32();
		Unknown_68h = reader.ReadUInt32();
		Unknown_6Ch = reader.ReadUInt32();
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
		Drawable1Pointer = reader.ReadUInt64();
		Drawable2Pointer = reader.ReadUInt64();
		EvtSetPointer = reader.ReadUInt64();
		Unknown_B8h = reader.ReadUInt32();
		Unknown_BCh = reader.ReadUInt32();
		Unknown_C0h = reader.ReadUInt32();
		Unknown_C4h = reader.ReadUInt32();
		Unknown_C8h = reader.ReadUInt32();
		Unknown_CCh = reader.ReadUInt32();
		Unknown_D0h = reader.ReadUInt32();
		Unknown_D4h = reader.ReadUInt32();
		Unknown_D8h = reader.ReadUInt32();
		Unknown_DCh = reader.ReadUInt32();
		Unknown_E0h = reader.ReadUInt32();
		Unknown_E4h = reader.ReadUInt32();
		Unknown_E8h = reader.ReadUInt32();
		Unknown_ECh = reader.ReadUInt32();
		Unknown_F0h = reader.ReadUInt32();
		Unknown_F4h = reader.ReadUInt32();
		Unknown_F8h = reader.ReadUInt32();
		Unknown_FCh = reader.ReadUInt32();
		Drawable1 = reader.ReadBlockAt<FragDrawable>(Drawable1Pointer, Array.Empty<object>());
		Drawable2 = reader.ReadBlockAt<FragDrawable>(Drawable2Pointer, Array.Empty<object>());
		EvtSet = reader.ReadBlockAt<EvtSet>(EvtSetPointer, Array.Empty<object>());
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		Drawable1Pointer = (ulong)((Drawable1 != null) ? Drawable1.Position : 0);
		Drawable2Pointer = (ulong)((Drawable2 != null) ? Drawable2.Position : 0);
		EvtSetPointer = (ulong)((EvtSet != null) ? EvtSet.Position : 0);
		writer.Write(VFT);
		writer.Write(Unknown_4h);
		writer.Write(Unknown_8h);
		writer.Write(Unknown_Ch);
		writer.Write(Unknown_10h);
		writer.Write(Unknown_14h);
		writer.Write(Unknown_18h);
		writer.Write(Unknown_1Ch);
		writer.Write(Unknown_20h);
		writer.Write(Unknown_24h);
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
		writer.Write(Unknown_60h);
		writer.Write(Unknown_64h);
		writer.Write(Unknown_68h);
		writer.Write(Unknown_6Ch);
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
		writer.Write(Drawable1Pointer);
		writer.Write(Drawable2Pointer);
		writer.Write(EvtSetPointer);
		writer.Write(Unknown_B8h);
		writer.Write(Unknown_BCh);
		writer.Write(Unknown_C0h);
		writer.Write(Unknown_C4h);
		writer.Write(Unknown_C8h);
		writer.Write(Unknown_CCh);
		writer.Write(Unknown_D0h);
		writer.Write(Unknown_D4h);
		writer.Write(Unknown_D8h);
		writer.Write(Unknown_DCh);
		writer.Write(Unknown_E0h);
		writer.Write(Unknown_E4h);
		writer.Write(Unknown_E8h);
		writer.Write(Unknown_ECh);
		writer.Write(Unknown_F0h);
		writer.Write(Unknown_F4h);
		writer.Write(Unknown_F8h);
		writer.Write(Unknown_FCh);
	}

	public override IResourceBlock[] GetReferences()
	{
		List<IResourceBlock> list = new List<IResourceBlock>();
		if (Drawable1 != null)
		{
			list.Add(Drawable1);
		}
		if (Drawable2 != null)
		{
			list.Add(Drawable2);
		}
		if (EvtSet != null)
		{
			list.Add(EvtSet);
		}
		return list.ToArray();
	}
}
