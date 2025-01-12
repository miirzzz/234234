using System;
using System.Collections.Generic;

namespace RageLib.Resources.GTA5.PC.Clothes;

public class ClothController : ResourceSystemBlock
{
	public uint VFT;

	public uint Unknown_4h;

	public uint Unknown_8h;

	public uint Unknown_Ch;

	public ulong BridgeSimGfxPointer;

	public ulong MorphControllerPointer;

	public ulong VerletCloth1Pointer;

	public ulong VerletCloth2Pointer;

	public ulong VerletCloth3Pointer;

	public uint Unknown_38h;

	public uint Unknown_3Ch;

	public uint Unknown_40h;

	public uint Unknown_44h;

	public uint Unknown_48h;

	public uint Unknown_4Ch;

	public uint Type;

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

	public ClothBridgeSimGfx BridgeSimGfx;

	public MorphController MorphController;

	public VerletCloth VerletCloth1;

	public VerletCloth VerletCloth2;

	public VerletCloth VerletCloth3;

	public override long Length => 128L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		VFT = reader.ReadUInt32();
		Unknown_4h = reader.ReadUInt32();
		Unknown_8h = reader.ReadUInt32();
		Unknown_Ch = reader.ReadUInt32();
		BridgeSimGfxPointer = reader.ReadUInt64();
		MorphControllerPointer = reader.ReadUInt64();
		VerletCloth1Pointer = reader.ReadUInt64();
		VerletCloth2Pointer = reader.ReadUInt64();
		VerletCloth3Pointer = reader.ReadUInt64();
		Unknown_38h = reader.ReadUInt32();
		Unknown_3Ch = reader.ReadUInt32();
		Unknown_40h = reader.ReadUInt32();
		Unknown_44h = reader.ReadUInt32();
		Unknown_48h = reader.ReadUInt32();
		Unknown_4Ch = reader.ReadUInt32();
		Type = reader.ReadUInt32();
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
		BridgeSimGfx = reader.ReadBlockAt<ClothBridgeSimGfx>(BridgeSimGfxPointer, Array.Empty<object>());
		MorphController = reader.ReadBlockAt<MorphController>(MorphControllerPointer, Array.Empty<object>());
		VerletCloth1 = reader.ReadBlockAt<VerletCloth>(VerletCloth1Pointer, Array.Empty<object>());
		VerletCloth2 = reader.ReadBlockAt<VerletCloth>(VerletCloth2Pointer, Array.Empty<object>());
		VerletCloth3 = reader.ReadBlockAt<VerletCloth>(VerletCloth3Pointer, Array.Empty<object>());
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		BridgeSimGfxPointer = (ulong)((BridgeSimGfx != null) ? BridgeSimGfx.Position : 0);
		MorphControllerPointer = (ulong)((MorphController != null) ? MorphController.Position : 0);
		VerletCloth1Pointer = (ulong)((VerletCloth1 != null) ? VerletCloth1.Position : 0);
		VerletCloth2Pointer = (ulong)((VerletCloth2 != null) ? VerletCloth2.Position : 0);
		VerletCloth3Pointer = (ulong)((VerletCloth3 != null) ? VerletCloth3.Position : 0);
		writer.Write(VFT);
		writer.Write(Unknown_4h);
		writer.Write(Unknown_8h);
		writer.Write(Unknown_Ch);
		writer.Write(BridgeSimGfxPointer);
		writer.Write(MorphControllerPointer);
		writer.Write(VerletCloth1Pointer);
		writer.Write(VerletCloth2Pointer);
		writer.Write(VerletCloth3Pointer);
		writer.Write(Unknown_38h);
		writer.Write(Unknown_3Ch);
		writer.Write(Unknown_40h);
		writer.Write(Unknown_44h);
		writer.Write(Unknown_48h);
		writer.Write(Unknown_4Ch);
		writer.Write(Type);
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
	}

	public override IResourceBlock[] GetReferences()
	{
		List<IResourceBlock> list = new List<IResourceBlock>();
		if (BridgeSimGfx != null)
		{
			list.Add(BridgeSimGfx);
		}
		if (MorphController != null)
		{
			list.Add(MorphController);
		}
		if (VerletCloth1 != null)
		{
			list.Add(VerletCloth1);
		}
		if (VerletCloth2 != null)
		{
			list.Add(VerletCloth2);
		}
		if (VerletCloth3 != null)
		{
			list.Add(VerletCloth3);
		}
		return list.ToArray();
	}
}
