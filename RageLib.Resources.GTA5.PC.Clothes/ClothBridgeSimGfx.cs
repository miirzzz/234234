using System;
using RageLib.Resources.Common;

namespace RageLib.Resources.GTA5.PC.Clothes;

public class ClothBridgeSimGfx : ResourceSystemBlock
{
	public uint VFT;

	public uint Unknown_4h;

	public uint Unknown_8h;

	public uint Unknown_Ch;

	public uint Unknown_10h;

	public uint Unknown_14h;

	public uint Unknown_18h;

	public uint Unknown_1Ch;

	public ResourceSimpleList64<float_r> Unknown_20h;

	public ResourceSimpleList64<float_r> Unknown_30h;

	public ResourceSimpleList64<float_r> Unknown_40h;

	public uint Unknown_50h;

	public uint Unknown_54h;

	public uint Unknown_58h;

	public uint Unknown_5Ch;

	public ResourceSimpleList64<float_r> Unknown_60h;

	public ResourceSimpleList64<uint_r> Unknown_70h;

	public ResourceSimpleList64<uint_r> Unknown_80h;

	public uint Unknown_90h;

	public uint Unknown_94h;

	public uint Unknown_98h;

	public uint Unknown_9Ch;

	public ResourceSimpleList64<float_r> Unknown_A0h;

	public ResourceSimpleList64<uint_r> Unknown_B0h;

	public ResourceSimpleList64<uint_r> Unknown_C0h;

	public uint Unknown_D0h;

	public uint Unknown_D4h;

	public uint Unknown_D8h;

	public uint Unknown_DCh;

	public ResourceSimpleList64<ushort_r> Unknown_E0h;

	public ResourceSimpleList64<ushort_r> Unknown_F0h;

	public ResourceSimpleList64<ushort_r> Unknown_100h;

	public uint Unknown_110h;

	public uint Unknown_114h;

	public uint Unknown_118h;

	public uint Unknown_11Ch;

	public uint Unknown_120h;

	public uint Unknown_124h;

	public ResourceSimpleList64<uint_r> Unknown_128h;

	public uint Unknown_138h;

	public uint Unknown_13Ch;

	public override long Length => 320L;

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
		Unknown_20h = reader.ReadBlock<ResourceSimpleList64<float_r>>(Array.Empty<object>());
		Unknown_30h = reader.ReadBlock<ResourceSimpleList64<float_r>>(Array.Empty<object>());
		Unknown_40h = reader.ReadBlock<ResourceSimpleList64<float_r>>(Array.Empty<object>());
		Unknown_50h = reader.ReadUInt32();
		Unknown_54h = reader.ReadUInt32();
		Unknown_58h = reader.ReadUInt32();
		Unknown_5Ch = reader.ReadUInt32();
		Unknown_60h = reader.ReadBlock<ResourceSimpleList64<float_r>>(Array.Empty<object>());
		Unknown_70h = reader.ReadBlock<ResourceSimpleList64<uint_r>>(Array.Empty<object>());
		Unknown_80h = reader.ReadBlock<ResourceSimpleList64<uint_r>>(Array.Empty<object>());
		Unknown_90h = reader.ReadUInt32();
		Unknown_94h = reader.ReadUInt32();
		Unknown_98h = reader.ReadUInt32();
		Unknown_9Ch = reader.ReadUInt32();
		Unknown_A0h = reader.ReadBlock<ResourceSimpleList64<float_r>>(Array.Empty<object>());
		Unknown_B0h = reader.ReadBlock<ResourceSimpleList64<uint_r>>(Array.Empty<object>());
		Unknown_C0h = reader.ReadBlock<ResourceSimpleList64<uint_r>>(Array.Empty<object>());
		Unknown_D0h = reader.ReadUInt32();
		Unknown_D4h = reader.ReadUInt32();
		Unknown_D8h = reader.ReadUInt32();
		Unknown_DCh = reader.ReadUInt32();
		Unknown_E0h = reader.ReadBlock<ResourceSimpleList64<ushort_r>>(Array.Empty<object>());
		Unknown_F0h = reader.ReadBlock<ResourceSimpleList64<ushort_r>>(Array.Empty<object>());
		Unknown_100h = reader.ReadBlock<ResourceSimpleList64<ushort_r>>(Array.Empty<object>());
		Unknown_110h = reader.ReadUInt32();
		Unknown_114h = reader.ReadUInt32();
		Unknown_118h = reader.ReadUInt32();
		Unknown_11Ch = reader.ReadUInt32();
		Unknown_120h = reader.ReadUInt32();
		Unknown_124h = reader.ReadUInt32();
		Unknown_128h = reader.ReadBlock<ResourceSimpleList64<uint_r>>(Array.Empty<object>());
		Unknown_138h = reader.ReadUInt32();
		Unknown_13Ch = reader.ReadUInt32();
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		writer.Write(VFT);
		writer.Write(Unknown_4h);
		writer.Write(Unknown_8h);
		writer.Write(Unknown_Ch);
		writer.Write(Unknown_10h);
		writer.Write(Unknown_14h);
		writer.Write(Unknown_18h);
		writer.Write(Unknown_1Ch);
		writer.WriteBlock(Unknown_20h);
		writer.WriteBlock(Unknown_30h);
		writer.WriteBlock(Unknown_40h);
		writer.Write(Unknown_50h);
		writer.Write(Unknown_54h);
		writer.Write(Unknown_58h);
		writer.Write(Unknown_5Ch);
		writer.WriteBlock(Unknown_60h);
		writer.WriteBlock(Unknown_70h);
		writer.WriteBlock(Unknown_80h);
		writer.Write(Unknown_90h);
		writer.Write(Unknown_94h);
		writer.Write(Unknown_98h);
		writer.Write(Unknown_9Ch);
		writer.WriteBlock(Unknown_A0h);
		writer.WriteBlock(Unknown_B0h);
		writer.WriteBlock(Unknown_C0h);
		writer.Write(Unknown_D0h);
		writer.Write(Unknown_D4h);
		writer.Write(Unknown_D8h);
		writer.Write(Unknown_DCh);
		writer.WriteBlock(Unknown_E0h);
		writer.WriteBlock(Unknown_F0h);
		writer.WriteBlock(Unknown_100h);
		writer.Write(Unknown_110h);
		writer.Write(Unknown_114h);
		writer.Write(Unknown_118h);
		writer.Write(Unknown_11Ch);
		writer.Write(Unknown_120h);
		writer.Write(Unknown_124h);
		writer.WriteBlock(Unknown_128h);
		writer.Write(Unknown_138h);
		writer.Write(Unknown_13Ch);
	}

	public override Tuple<long, IResourceBlock>[] GetParts()
	{
		return new Tuple<long, IResourceBlock>[13]
		{
			new Tuple<long, IResourceBlock>(32L, Unknown_20h),
			new Tuple<long, IResourceBlock>(48L, Unknown_30h),
			new Tuple<long, IResourceBlock>(64L, Unknown_40h),
			new Tuple<long, IResourceBlock>(96L, Unknown_60h),
			new Tuple<long, IResourceBlock>(112L, Unknown_70h),
			new Tuple<long, IResourceBlock>(128L, Unknown_80h),
			new Tuple<long, IResourceBlock>(160L, Unknown_A0h),
			new Tuple<long, IResourceBlock>(176L, Unknown_B0h),
			new Tuple<long, IResourceBlock>(192L, Unknown_C0h),
			new Tuple<long, IResourceBlock>(224L, Unknown_E0h),
			new Tuple<long, IResourceBlock>(240L, Unknown_F0h),
			new Tuple<long, IResourceBlock>(256L, Unknown_100h),
			new Tuple<long, IResourceBlock>(296L, Unknown_128h)
		};
	}
}
