using System;
using System.Collections.Generic;
using RageLib.Resources.Common;
using RageLib.Resources.GTA5.PC.Bounds;

namespace RageLib.Resources.GTA5.PC.Clothes;

public class VerletCloth : ResourceSystemBlock
{
	public uint VFT;

	public uint Unknown_4h;

	public uint Unknown_8h;

	public uint Unknown_Ch;

	public uint Unknown_10h;

	public uint Unknown_14h;

	public ulong BoundPointer;

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

	public ResourceSimpleList64<RAGE_Vector4> Unknown_70h;

	public ResourceSimpleList64<RAGE_Vector4> Unknown_80h;

	public uint Unknown_90h;

	public uint Unknown_94h;

	public uint Unknown_98h;

	public uint Unknown_9Ch;

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

	public ResourceSimpleList64<Unknown_C_004> Unknown_100h;

	public ResourceSimpleList64<Unknown_C_004> Unknown_110h;

	public uint Unknown_120h;

	public uint Unknown_124h;

	public uint Unknown_128h;

	public uint Unknown_12Ch;

	public ulong BehaviorPointer;

	public uint Unknown_138h;

	public uint Unknown_13Ch;

	public ulong Unknown_140h_Pointer;

	public uint Unknown_148h;

	public uint Unknown_14Ch;

	public uint Unknown_150h;

	public uint Unknown_154h;

	public uint Unknown_158h;

	public uint Unknown_15Ch;

	public uint Unknown_160h;

	public uint Unknown_164h;

	public uint Unknown_168h;

	public uint Unknown_16Ch;

	public uint Unknown_170h;

	public uint Unknown_174h;

	public uint Unknown_178h;

	public uint Unknown_17Ch;

	public Bound Bound;

	public EnvClothVerletBehavior Behavior;

	public Unknown_C_007 Unknown_140h_Data;

	public override long Length => 384L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		VFT = reader.ReadUInt32();
		Unknown_4h = reader.ReadUInt32();
		Unknown_8h = reader.ReadUInt32();
		Unknown_Ch = reader.ReadUInt32();
		Unknown_10h = reader.ReadUInt32();
		Unknown_14h = reader.ReadUInt32();
		BoundPointer = reader.ReadUInt64();
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
		Unknown_70h = reader.ReadBlock<ResourceSimpleList64<RAGE_Vector4>>(Array.Empty<object>());
		Unknown_80h = reader.ReadBlock<ResourceSimpleList64<RAGE_Vector4>>(Array.Empty<object>());
		Unknown_90h = reader.ReadUInt32();
		Unknown_94h = reader.ReadUInt32();
		Unknown_98h = reader.ReadUInt32();
		Unknown_9Ch = reader.ReadUInt32();
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
		Unknown_100h = reader.ReadBlock<ResourceSimpleList64<Unknown_C_004>>(Array.Empty<object>());
		Unknown_110h = reader.ReadBlock<ResourceSimpleList64<Unknown_C_004>>(Array.Empty<object>());
		Unknown_120h = reader.ReadUInt32();
		Unknown_124h = reader.ReadUInt32();
		Unknown_128h = reader.ReadUInt32();
		Unknown_12Ch = reader.ReadUInt32();
		BehaviorPointer = reader.ReadUInt64();
		Unknown_138h = reader.ReadUInt32();
		Unknown_13Ch = reader.ReadUInt32();
		Unknown_140h_Pointer = reader.ReadUInt64();
		Unknown_148h = reader.ReadUInt32();
		Unknown_14Ch = reader.ReadUInt32();
		Unknown_150h = reader.ReadUInt32();
		Unknown_154h = reader.ReadUInt32();
		Unknown_158h = reader.ReadUInt32();
		Unknown_15Ch = reader.ReadUInt32();
		Unknown_160h = reader.ReadUInt32();
		Unknown_164h = reader.ReadUInt32();
		Unknown_168h = reader.ReadUInt32();
		Unknown_16Ch = reader.ReadUInt32();
		Unknown_170h = reader.ReadUInt32();
		Unknown_174h = reader.ReadUInt32();
		Unknown_178h = reader.ReadUInt32();
		Unknown_17Ch = reader.ReadUInt32();
		Bound = reader.ReadBlockAt<Bound>(BoundPointer, Array.Empty<object>());
		Behavior = reader.ReadBlockAt<EnvClothVerletBehavior>(BehaviorPointer, Array.Empty<object>());
		Unknown_140h_Data = reader.ReadBlockAt<Unknown_C_007>(Unknown_140h_Pointer, Array.Empty<object>());
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		BoundPointer = (ulong)((Bound != null) ? Bound.Position : 0);
		BehaviorPointer = (ulong)((Behavior != null) ? Behavior.Position : 0);
		Unknown_140h_Pointer = (ulong)((Unknown_140h_Data != null) ? Unknown_140h_Data.Position : 0);
		writer.Write(VFT);
		writer.Write(Unknown_4h);
		writer.Write(Unknown_8h);
		writer.Write(Unknown_Ch);
		writer.Write(Unknown_10h);
		writer.Write(Unknown_14h);
		writer.Write(BoundPointer);
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
		writer.WriteBlock(Unknown_70h);
		writer.WriteBlock(Unknown_80h);
		writer.Write(Unknown_90h);
		writer.Write(Unknown_94h);
		writer.Write(Unknown_98h);
		writer.Write(Unknown_9Ch);
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
		writer.WriteBlock(Unknown_100h);
		writer.WriteBlock(Unknown_110h);
		writer.Write(Unknown_120h);
		writer.Write(Unknown_124h);
		writer.Write(Unknown_128h);
		writer.Write(Unknown_12Ch);
		writer.Write(BehaviorPointer);
		writer.Write(Unknown_138h);
		writer.Write(Unknown_13Ch);
		writer.Write(Unknown_140h_Pointer);
		writer.Write(Unknown_148h);
		writer.Write(Unknown_14Ch);
		writer.Write(Unknown_150h);
		writer.Write(Unknown_154h);
		writer.Write(Unknown_158h);
		writer.Write(Unknown_15Ch);
		writer.Write(Unknown_160h);
		writer.Write(Unknown_164h);
		writer.Write(Unknown_168h);
		writer.Write(Unknown_16Ch);
		writer.Write(Unknown_170h);
		writer.Write(Unknown_174h);
		writer.Write(Unknown_178h);
		writer.Write(Unknown_17Ch);
	}

	public override IResourceBlock[] GetReferences()
	{
		List<IResourceBlock> list = new List<IResourceBlock>();
		if (Bound != null)
		{
			list.Add(Bound);
		}
		if (Behavior != null)
		{
			list.Add(Behavior);
		}
		if (Unknown_140h_Data != null)
		{
			list.Add(Unknown_140h_Data);
		}
		return list.ToArray();
	}

	public override Tuple<long, IResourceBlock>[] GetParts()
	{
		return new Tuple<long, IResourceBlock>[4]
		{
			new Tuple<long, IResourceBlock>(112L, Unknown_70h),
			new Tuple<long, IResourceBlock>(128L, Unknown_80h),
			new Tuple<long, IResourceBlock>(256L, Unknown_100h),
			new Tuple<long, IResourceBlock>(272L, Unknown_110h)
		};
	}
}
