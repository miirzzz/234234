using System;
using System.Collections.Generic;
using RageLib.Resources.Common;
using RageLib.Resources.GTA5.PC.Fragments;

namespace RageLib.Resources.GTA5.PC.Clothes;

public class EnvironmentCloth : ResourceSystemBlock
{
	public uint VFT;

	public uint Unknown_4h;

	public uint Unknown_8h;

	public uint Unknown_Ch;

	public ulong InstanceTuningPointer;

	public ulong DrawablePointer;

	public uint Unknown_20h;

	public uint Unknown_24h;

	public ulong ControllerPointer;

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

	public ulong pxxxxx_2;

	public ushort cntxx51a;

	public ushort cntxx51b;

	public uint Unknown_6Ch;

	public uint Unknown_70h;

	public uint Unknown_74h;

	public uint Unknown_78h;

	public uint Unknown_7Ch;

	public ClothInstanceTuning InstanceTuning;

	public FragDrawable Drawable;

	public ClothController Controller;

	public ResourceSimpleArray<uint_r> pxxxxx_2data;

	public override long Length => 128L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		VFT = reader.ReadUInt32();
		Unknown_4h = reader.ReadUInt32();
		Unknown_8h = reader.ReadUInt32();
		Unknown_Ch = reader.ReadUInt32();
		InstanceTuningPointer = reader.ReadUInt64();
		DrawablePointer = reader.ReadUInt64();
		Unknown_20h = reader.ReadUInt32();
		Unknown_24h = reader.ReadUInt32();
		ControllerPointer = reader.ReadUInt64();
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
		pxxxxx_2 = reader.ReadUInt64();
		cntxx51a = reader.ReadUInt16();
		cntxx51b = reader.ReadUInt16();
		Unknown_6Ch = reader.ReadUInt32();
		Unknown_70h = reader.ReadUInt32();
		Unknown_74h = reader.ReadUInt32();
		Unknown_78h = reader.ReadUInt32();
		Unknown_7Ch = reader.ReadUInt32();
		InstanceTuning = reader.ReadBlockAt<ClothInstanceTuning>(InstanceTuningPointer, Array.Empty<object>());
		Drawable = reader.ReadBlockAt<FragDrawable>(DrawablePointer, Array.Empty<object>());
		Controller = reader.ReadBlockAt<ClothController>(ControllerPointer, Array.Empty<object>());
		pxxxxx_2data = reader.ReadBlockAt<ResourceSimpleArray<uint_r>>(pxxxxx_2, new object[1] { cntxx51a });
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		InstanceTuningPointer = (ulong)((InstanceTuning != null) ? InstanceTuning.Position : 0);
		DrawablePointer = (ulong)((Drawable != null) ? Drawable.Position : 0);
		ControllerPointer = (ulong)((Controller != null) ? Controller.Position : 0);
		pxxxxx_2 = (ulong)((pxxxxx_2data != null) ? pxxxxx_2data.Position : 0);
		cntxx51a = (ushort)((pxxxxx_2data != null) ? ((uint)pxxxxx_2data.Count) : 0u);
		cntxx51b = (ushort)((pxxxxx_2data != null) ? ((uint)pxxxxx_2data.Count) : 0u);
		writer.Write(VFT);
		writer.Write(Unknown_4h);
		writer.Write(Unknown_8h);
		writer.Write(Unknown_Ch);
		writer.Write(InstanceTuningPointer);
		writer.Write(DrawablePointer);
		writer.Write(Unknown_20h);
		writer.Write(Unknown_24h);
		writer.Write(ControllerPointer);
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
		writer.Write(pxxxxx_2);
		writer.Write(cntxx51a);
		writer.Write(cntxx51b);
		writer.Write(Unknown_6Ch);
		writer.Write(Unknown_70h);
		writer.Write(Unknown_74h);
		writer.Write(Unknown_78h);
		writer.Write(Unknown_7Ch);
	}

	public override IResourceBlock[] GetReferences()
	{
		List<IResourceBlock> list = new List<IResourceBlock>();
		if (InstanceTuning != null)
		{
			list.Add(InstanceTuning);
		}
		if (Drawable != null)
		{
			list.Add(Drawable);
		}
		if (Controller != null)
		{
			list.Add(Controller);
		}
		if (pxxxxx_2data != null)
		{
			list.Add(pxxxxx_2data);
		}
		return list.ToArray();
	}
}
