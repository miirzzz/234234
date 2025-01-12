using System;
using RageLib.Resources.Common;

namespace RageLib.Resources.GTA5.PC.Clothes;

public class Unknown_C_006 : ResourceSystemBlock
{
	public uint Unknown_0h;

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

	public ResourceSimpleList64<RAGE_Vector4> Unknown_50h;

	public ResourceSimpleList64<ushort_r> Unknown_60h;

	public ResourceSimpleList64<ushort_r> Unknown_70h;

	public ResourceSimpleList64<ushort_r> Unknown_80h;

	public ResourceSimpleList64<ushort_r> Unknown_90h;

	public ResourceSimpleList64<RAGE_Vector4> Unknown_A0h;

	public ResourceSimpleList64<ushort_r> Unknown_B0h;

	public ResourceSimpleList64<ushort_r> Unknown_C0h;

	public ResourceSimpleList64<ushort_r> Unknown_D0h;

	public ResourceSimpleList64<ushort_r> Unknown_E0h;

	public uint Unknown_F0h;

	public uint Unknown_F4h;

	public uint Unknown_F8h;

	public uint Unknown_FCh;

	public uint Unknown_100h;

	public uint Unknown_104h;

	public uint Unknown_108h;

	public uint Unknown_10Ch;

	public uint Unknown_110h;

	public uint Unknown_114h;

	public uint Unknown_118h;

	public uint Unknown_11Ch;

	public uint Unknown_120h;

	public uint Unknown_124h;

	public uint Unknown_128h;

	public uint Unknown_12Ch;

	public uint Unknown_130h;

	public uint Unknown_134h;

	public uint Unknown_138h;

	public uint Unknown_13Ch;

	public uint Unknown_140h;

	public uint Unknown_144h;

	public uint Unknown_148h;

	public uint Unknown_14Ch;

	public ResourceSimpleList64<ushort_r> Unknown_150h;

	public ResourceSimpleList64<ushort_r> Unknown_160h;

	public uint Unknown_170h;

	public uint Unknown_174h;

	public uint Unknown_178h;

	public uint Unknown_17Ch;

	public uint Unknown_180h;

	public uint Unknown_184h;

	public uint Unknown_188h;

	public uint Unknown_18Ch;

	public override long Length => 400L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		Unknown_0h = reader.ReadUInt32();
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
		Unknown_50h = reader.ReadBlock<ResourceSimpleList64<RAGE_Vector4>>(Array.Empty<object>());
		Unknown_60h = reader.ReadBlock<ResourceSimpleList64<ushort_r>>(Array.Empty<object>());
		Unknown_70h = reader.ReadBlock<ResourceSimpleList64<ushort_r>>(Array.Empty<object>());
		Unknown_80h = reader.ReadBlock<ResourceSimpleList64<ushort_r>>(Array.Empty<object>());
		Unknown_90h = reader.ReadBlock<ResourceSimpleList64<ushort_r>>(Array.Empty<object>());
		Unknown_A0h = reader.ReadBlock<ResourceSimpleList64<RAGE_Vector4>>(Array.Empty<object>());
		Unknown_B0h = reader.ReadBlock<ResourceSimpleList64<ushort_r>>(Array.Empty<object>());
		Unknown_C0h = reader.ReadBlock<ResourceSimpleList64<ushort_r>>(Array.Empty<object>());
		Unknown_D0h = reader.ReadBlock<ResourceSimpleList64<ushort_r>>(Array.Empty<object>());
		Unknown_E0h = reader.ReadBlock<ResourceSimpleList64<ushort_r>>(Array.Empty<object>());
		Unknown_F0h = reader.ReadUInt32();
		Unknown_F4h = reader.ReadUInt32();
		Unknown_F8h = reader.ReadUInt32();
		Unknown_FCh = reader.ReadUInt32();
		Unknown_100h = reader.ReadUInt32();
		Unknown_104h = reader.ReadUInt32();
		Unknown_108h = reader.ReadUInt32();
		Unknown_10Ch = reader.ReadUInt32();
		Unknown_110h = reader.ReadUInt32();
		Unknown_114h = reader.ReadUInt32();
		Unknown_118h = reader.ReadUInt32();
		Unknown_11Ch = reader.ReadUInt32();
		Unknown_120h = reader.ReadUInt32();
		Unknown_124h = reader.ReadUInt32();
		Unknown_128h = reader.ReadUInt32();
		Unknown_12Ch = reader.ReadUInt32();
		Unknown_130h = reader.ReadUInt32();
		Unknown_134h = reader.ReadUInt32();
		Unknown_138h = reader.ReadUInt32();
		Unknown_13Ch = reader.ReadUInt32();
		Unknown_140h = reader.ReadUInt32();
		Unknown_144h = reader.ReadUInt32();
		Unknown_148h = reader.ReadUInt32();
		Unknown_14Ch = reader.ReadUInt32();
		Unknown_150h = reader.ReadBlock<ResourceSimpleList64<ushort_r>>(Array.Empty<object>());
		Unknown_160h = reader.ReadBlock<ResourceSimpleList64<ushort_r>>(Array.Empty<object>());
		Unknown_170h = reader.ReadUInt32();
		Unknown_174h = reader.ReadUInt32();
		Unknown_178h = reader.ReadUInt32();
		Unknown_17Ch = reader.ReadUInt32();
		Unknown_180h = reader.ReadUInt32();
		Unknown_184h = reader.ReadUInt32();
		Unknown_188h = reader.ReadUInt32();
		Unknown_18Ch = reader.ReadUInt32();
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		writer.Write(Unknown_0h);
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
		writer.WriteBlock(Unknown_50h);
		writer.WriteBlock(Unknown_60h);
		writer.WriteBlock(Unknown_70h);
		writer.WriteBlock(Unknown_80h);
		writer.WriteBlock(Unknown_90h);
		writer.WriteBlock(Unknown_A0h);
		writer.WriteBlock(Unknown_B0h);
		writer.WriteBlock(Unknown_C0h);
		writer.WriteBlock(Unknown_D0h);
		writer.WriteBlock(Unknown_E0h);
		writer.Write(Unknown_F0h);
		writer.Write(Unknown_F4h);
		writer.Write(Unknown_F8h);
		writer.Write(Unknown_FCh);
		writer.Write(Unknown_100h);
		writer.Write(Unknown_104h);
		writer.Write(Unknown_108h);
		writer.Write(Unknown_10Ch);
		writer.Write(Unknown_110h);
		writer.Write(Unknown_114h);
		writer.Write(Unknown_118h);
		writer.Write(Unknown_11Ch);
		writer.Write(Unknown_120h);
		writer.Write(Unknown_124h);
		writer.Write(Unknown_128h);
		writer.Write(Unknown_12Ch);
		writer.Write(Unknown_130h);
		writer.Write(Unknown_134h);
		writer.Write(Unknown_138h);
		writer.Write(Unknown_13Ch);
		writer.Write(Unknown_140h);
		writer.Write(Unknown_144h);
		writer.Write(Unknown_148h);
		writer.Write(Unknown_14Ch);
		writer.WriteBlock(Unknown_150h);
		writer.WriteBlock(Unknown_160h);
		writer.Write(Unknown_170h);
		writer.Write(Unknown_174h);
		writer.Write(Unknown_178h);
		writer.Write(Unknown_17Ch);
		writer.Write(Unknown_180h);
		writer.Write(Unknown_184h);
		writer.Write(Unknown_188h);
		writer.Write(Unknown_18Ch);
	}

	public override Tuple<long, IResourceBlock>[] GetParts()
	{
		return new Tuple<long, IResourceBlock>[12]
		{
			new Tuple<long, IResourceBlock>(80L, Unknown_50h),
			new Tuple<long, IResourceBlock>(96L, Unknown_60h),
			new Tuple<long, IResourceBlock>(112L, Unknown_70h),
			new Tuple<long, IResourceBlock>(128L, Unknown_80h),
			new Tuple<long, IResourceBlock>(144L, Unknown_90h),
			new Tuple<long, IResourceBlock>(160L, Unknown_A0h),
			new Tuple<long, IResourceBlock>(176L, Unknown_B0h),
			new Tuple<long, IResourceBlock>(192L, Unknown_C0h),
			new Tuple<long, IResourceBlock>(208L, Unknown_D0h),
			new Tuple<long, IResourceBlock>(224L, Unknown_E0h),
			new Tuple<long, IResourceBlock>(336L, Unknown_150h),
			new Tuple<long, IResourceBlock>(352L, Unknown_160h)
		};
	}
}
