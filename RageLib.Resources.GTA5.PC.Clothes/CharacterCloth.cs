using System;
using System.Collections.Generic;
using RageLib.Resources.Common;
using RageLib.Resources.GTA5.PC.Bounds;

namespace RageLib.Resources.GTA5.PC.Clothes;

public class CharacterCloth : ResourceSystemBlock
{
	public uint VFT;

	public uint Unknown_4h;

	public uint Unknown_8h;

	public uint Unknown_Ch;

	public ResourceSimpleList64<Unknown_C_001> Unknown_10h;

	public ulong ControllerPointer;

	public ulong BoundPointer;

	public ResourceSimpleList64<uint_r> Unknown_30h;

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

	public ResourceSimpleList64<uint_r> Unknown_90h;

	public uint Unknown_A0h;

	public uint Unknown_A4h;

	public uint Unknown_A8h;

	public uint Unknown_ACh;

	public uint Unknown_B0h;

	public uint Unknown_B4h;

	public uint Unknown_B8h;

	public uint Unknown_BCh;

	public uint Unknown_C0h;

	public uint Unknown_C4h;

	public uint Unknown_C8h;

	public uint Unknown_CCh;

	public CharacterClothController Controller;

	public Bound Bound;

	public override long Length => 208L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		VFT = reader.ReadUInt32();
		Unknown_4h = reader.ReadUInt32();
		Unknown_8h = reader.ReadUInt32();
		Unknown_Ch = reader.ReadUInt32();
		Unknown_10h = reader.ReadBlock<ResourceSimpleList64<Unknown_C_001>>(Array.Empty<object>());
		ControllerPointer = reader.ReadUInt64();
		BoundPointer = reader.ReadUInt64();
		Unknown_30h = reader.ReadBlock<ResourceSimpleList64<uint_r>>(Array.Empty<object>());
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
		Unknown_90h = reader.ReadBlock<ResourceSimpleList64<uint_r>>(Array.Empty<object>());
		Unknown_A0h = reader.ReadUInt32();
		Unknown_A4h = reader.ReadUInt32();
		Unknown_A8h = reader.ReadUInt32();
		Unknown_ACh = reader.ReadUInt32();
		Unknown_B0h = reader.ReadUInt32();
		Unknown_B4h = reader.ReadUInt32();
		Unknown_B8h = reader.ReadUInt32();
		Unknown_BCh = reader.ReadUInt32();
		Unknown_C0h = reader.ReadUInt32();
		Unknown_C4h = reader.ReadUInt32();
		Unknown_C8h = reader.ReadUInt32();
		Unknown_CCh = reader.ReadUInt32();
		Controller = reader.ReadBlockAt<CharacterClothController>(ControllerPointer, Array.Empty<object>());
		Bound = reader.ReadBlockAt<Bound>(BoundPointer, Array.Empty<object>());
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		ControllerPointer = (ulong)((Controller != null) ? Controller.Position : 0);
		BoundPointer = (ulong)((Bound != null) ? Bound.Position : 0);
		writer.Write(VFT);
		writer.Write(Unknown_4h);
		writer.Write(Unknown_8h);
		writer.Write(Unknown_Ch);
		writer.WriteBlock(Unknown_10h);
		writer.Write(ControllerPointer);
		writer.Write(BoundPointer);
		writer.WriteBlock(Unknown_30h);
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
		writer.WriteBlock(Unknown_90h);
		writer.Write(Unknown_A0h);
		writer.Write(Unknown_A4h);
		writer.Write(Unknown_A8h);
		writer.Write(Unknown_ACh);
		writer.Write(Unknown_B0h);
		writer.Write(Unknown_B4h);
		writer.Write(Unknown_B8h);
		writer.Write(Unknown_BCh);
		writer.Write(Unknown_C0h);
		writer.Write(Unknown_C4h);
		writer.Write(Unknown_C8h);
		writer.Write(Unknown_CCh);
	}

	public override IResourceBlock[] GetReferences()
	{
		List<IResourceBlock> list = new List<IResourceBlock>();
		if (Controller != null)
		{
			list.Add(Controller);
		}
		if (Bound != null)
		{
			list.Add(Bound);
		}
		return list.ToArray();
	}

	public override Tuple<long, IResourceBlock>[] GetParts()
	{
		return new Tuple<long, IResourceBlock>[3]
		{
			new Tuple<long, IResourceBlock>(16L, Unknown_10h),
			new Tuple<long, IResourceBlock>(48L, Unknown_30h),
			new Tuple<long, IResourceBlock>(144L, Unknown_90h)
		};
	}
}
