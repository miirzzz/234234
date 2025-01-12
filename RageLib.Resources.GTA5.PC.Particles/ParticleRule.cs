using System;
using System.Collections.Generic;
using RageLib.Resources.Common;

namespace RageLib.Resources.GTA5.PC.Particles;

public class ParticleRule : ResourceSystemBlock
{
	public uint VFT;

	public uint Unknown_4h;

	public uint Unknown_8h;

	public uint Unknown_Ch;

	public uint Unknown_10h;

	public uint Unknown_14h;

	public uint Unknown_18h;

	public uint Unknown_1Ch;

	public EffectSpawner emb1;

	public EffectSpawner emb2;

	public uint Unknown_100h;

	public uint Unknown_104h;

	public uint Unknown_108h;

	public uint Unknown_10Ch;

	public uint Unknown_110h;

	public uint Unknown_114h;

	public uint Unknown_118h;

	public uint Unknown_11Ch;

	public ulong NamePointer;

	public ResourcePointerList64<Behaviour> Unknown_128h;

	public ResourcePointerList64<Behaviour> Unknown_138h;

	public ResourcePointerList64<Behaviour> Unknown_148h;

	public ResourcePointerList64<Behaviour> Unknown_158h;

	public ResourcePointerList64<Behaviour> Unknown_168h;

	public uint Unknown_178h;

	public uint Unknown_17Ch;

	public uint Unknown_180h;

	public uint Unknown_184h;

	public ResourceSimpleList64<Unknown_P_013> Unknown_188h;

	public uint Unknown_198h;

	public uint Unknown_19Ch;

	public uint Unknown_1A0h;

	public uint Unknown_1A4h;

	public uint Unknown_1A8h;

	public uint Unknown_1ACh;

	public uint VFTx3;

	public uint Unknown_1B4h;

	public ulong p9;

	public ulong p10;

	public uint Unknown_1C8h;

	public uint Unknown_1CCh;

	public uint Unknown_1D0h;

	public uint Unknown_1D4h;

	public uint VFTx4;

	public uint Unknown_1DCh;

	public uint Unknown_1E0h;

	public uint Unknown_1E4h;

	public uint Unknown_1E8h;

	public uint Unknown_1ECh;

	public ResourcePointerList64<ShaderVar> ShaderVars;

	public uint Unknown_200h;

	public uint Unknown_204h;

	public uint Unknown_208h;

	public uint Unknown_20Ch;

	public ResourceSimpleList64<Unknown_P_012> Unknown_210h;

	public uint Unknown_220h;

	public uint Unknown_224h;

	public uint Unknown_228h;

	public uint Unknown_22Ch;

	public uint Unknown_230h;

	public uint Unknown_234h;

	public uint Unknown_238h;

	public uint Unknown_23Ch;

	public string_r Name;

	public string_r p9data;

	public string_r p10data;

	public override long Length => 576L;

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
		emb1 = reader.ReadBlock<EffectSpawner>(Array.Empty<object>());
		emb2 = reader.ReadBlock<EffectSpawner>(Array.Empty<object>());
		Unknown_100h = reader.ReadUInt32();
		Unknown_104h = reader.ReadUInt32();
		Unknown_108h = reader.ReadUInt32();
		Unknown_10Ch = reader.ReadUInt32();
		Unknown_110h = reader.ReadUInt32();
		Unknown_114h = reader.ReadUInt32();
		Unknown_118h = reader.ReadUInt32();
		Unknown_11Ch = reader.ReadUInt32();
		NamePointer = reader.ReadUInt64();
		Unknown_128h = reader.ReadBlock<ResourcePointerList64<Behaviour>>(Array.Empty<object>());
		Unknown_138h = reader.ReadBlock<ResourcePointerList64<Behaviour>>(Array.Empty<object>());
		Unknown_148h = reader.ReadBlock<ResourcePointerList64<Behaviour>>(Array.Empty<object>());
		Unknown_158h = reader.ReadBlock<ResourcePointerList64<Behaviour>>(Array.Empty<object>());
		Unknown_168h = reader.ReadBlock<ResourcePointerList64<Behaviour>>(Array.Empty<object>());
		Unknown_178h = reader.ReadUInt32();
		Unknown_17Ch = reader.ReadUInt32();
		Unknown_180h = reader.ReadUInt32();
		Unknown_184h = reader.ReadUInt32();
		Unknown_188h = reader.ReadBlock<ResourceSimpleList64<Unknown_P_013>>(Array.Empty<object>());
		Unknown_198h = reader.ReadUInt32();
		Unknown_19Ch = reader.ReadUInt32();
		Unknown_1A0h = reader.ReadUInt32();
		Unknown_1A4h = reader.ReadUInt32();
		Unknown_1A8h = reader.ReadUInt32();
		Unknown_1ACh = reader.ReadUInt32();
		VFTx3 = reader.ReadUInt32();
		Unknown_1B4h = reader.ReadUInt32();
		p9 = reader.ReadUInt64();
		p10 = reader.ReadUInt64();
		Unknown_1C8h = reader.ReadUInt32();
		Unknown_1CCh = reader.ReadUInt32();
		Unknown_1D0h = reader.ReadUInt32();
		Unknown_1D4h = reader.ReadUInt32();
		VFTx4 = reader.ReadUInt32();
		Unknown_1DCh = reader.ReadUInt32();
		Unknown_1E0h = reader.ReadUInt32();
		Unknown_1E4h = reader.ReadUInt32();
		Unknown_1E8h = reader.ReadUInt32();
		Unknown_1ECh = reader.ReadUInt32();
		ShaderVars = reader.ReadBlock<ResourcePointerList64<ShaderVar>>(Array.Empty<object>());
		Unknown_200h = reader.ReadUInt32();
		Unknown_204h = reader.ReadUInt32();
		Unknown_208h = reader.ReadUInt32();
		Unknown_20Ch = reader.ReadUInt32();
		Unknown_210h = reader.ReadBlock<ResourceSimpleList64<Unknown_P_012>>(Array.Empty<object>());
		Unknown_220h = reader.ReadUInt32();
		Unknown_224h = reader.ReadUInt32();
		Unknown_228h = reader.ReadUInt32();
		Unknown_22Ch = reader.ReadUInt32();
		Unknown_230h = reader.ReadUInt32();
		Unknown_234h = reader.ReadUInt32();
		Unknown_238h = reader.ReadUInt32();
		Unknown_23Ch = reader.ReadUInt32();
		Name = reader.ReadBlockAt<string_r>(NamePointer, Array.Empty<object>());
		p9data = reader.ReadBlockAt<string_r>(p9, Array.Empty<object>());
		p10data = reader.ReadBlockAt<string_r>(p10, Array.Empty<object>());
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		NamePointer = (ulong)((Name != null) ? Name.Position : 0);
		p9 = (ulong)((p9data != null) ? p9data.Position : 0);
		p10 = (ulong)((p10data != null) ? p10data.Position : 0);
		writer.Write(VFT);
		writer.Write(Unknown_4h);
		writer.Write(Unknown_8h);
		writer.Write(Unknown_Ch);
		writer.Write(Unknown_10h);
		writer.Write(Unknown_14h);
		writer.Write(Unknown_18h);
		writer.Write(Unknown_1Ch);
		writer.WriteBlock(emb1);
		writer.WriteBlock(emb2);
		writer.Write(Unknown_100h);
		writer.Write(Unknown_104h);
		writer.Write(Unknown_108h);
		writer.Write(Unknown_10Ch);
		writer.Write(Unknown_110h);
		writer.Write(Unknown_114h);
		writer.Write(Unknown_118h);
		writer.Write(Unknown_11Ch);
		writer.Write(NamePointer);
		writer.WriteBlock(Unknown_128h);
		writer.WriteBlock(Unknown_138h);
		writer.WriteBlock(Unknown_148h);
		writer.WriteBlock(Unknown_158h);
		writer.WriteBlock(Unknown_168h);
		writer.Write(Unknown_178h);
		writer.Write(Unknown_17Ch);
		writer.Write(Unknown_180h);
		writer.Write(Unknown_184h);
		writer.WriteBlock(Unknown_188h);
		writer.Write(Unknown_198h);
		writer.Write(Unknown_19Ch);
		writer.Write(Unknown_1A0h);
		writer.Write(Unknown_1A4h);
		writer.Write(Unknown_1A8h);
		writer.Write(Unknown_1ACh);
		writer.Write(VFTx3);
		writer.Write(Unknown_1B4h);
		writer.Write(p9);
		writer.Write(p10);
		writer.Write(Unknown_1C8h);
		writer.Write(Unknown_1CCh);
		writer.Write(Unknown_1D0h);
		writer.Write(Unknown_1D4h);
		writer.Write(VFTx4);
		writer.Write(Unknown_1DCh);
		writer.Write(Unknown_1E0h);
		writer.Write(Unknown_1E4h);
		writer.Write(Unknown_1E8h);
		writer.Write(Unknown_1ECh);
		writer.WriteBlock(ShaderVars);
		writer.Write(Unknown_200h);
		writer.Write(Unknown_204h);
		writer.Write(Unknown_208h);
		writer.Write(Unknown_20Ch);
		writer.WriteBlock(Unknown_210h);
		writer.Write(Unknown_220h);
		writer.Write(Unknown_224h);
		writer.Write(Unknown_228h);
		writer.Write(Unknown_22Ch);
		writer.Write(Unknown_230h);
		writer.Write(Unknown_234h);
		writer.Write(Unknown_238h);
		writer.Write(Unknown_23Ch);
	}

	public override IResourceBlock[] GetReferences()
	{
		List<IResourceBlock> list = new List<IResourceBlock>();
		if (Name != null)
		{
			list.Add(Name);
		}
		if (p9data != null)
		{
			list.Add(p9data);
		}
		if (p10data != null)
		{
			list.Add(p10data);
		}
		return list.ToArray();
	}

	public override Tuple<long, IResourceBlock>[] GetParts()
	{
		return new Tuple<long, IResourceBlock>[10]
		{
			new Tuple<long, IResourceBlock>(88L, emb1),
			new Tuple<long, IResourceBlock>(96L, emb2),
			new Tuple<long, IResourceBlock>(296L, Unknown_128h),
			new Tuple<long, IResourceBlock>(312L, Unknown_138h),
			new Tuple<long, IResourceBlock>(328L, Unknown_148h),
			new Tuple<long, IResourceBlock>(344L, Unknown_158h),
			new Tuple<long, IResourceBlock>(360L, Unknown_168h),
			new Tuple<long, IResourceBlock>(392L, Unknown_188h),
			new Tuple<long, IResourceBlock>(496L, ShaderVars),
			new Tuple<long, IResourceBlock>(528L, Unknown_210h)
		};
	}
}
