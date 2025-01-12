using System;
using RageLib.Resources.Common;

namespace RageLib.Resources.GTA5.PC.Particles;

public class EffectRuleDictionary : ResourceSystemBlock
{
	public uint VFT;

	public uint Unknown_4h;

	public uint Unknown_8h;

	public uint Unknown_Ch;

	public uint Unknown_10h;

	public uint Unknown_14h;

	public uint Unknown_18h;

	public uint Unknown_1Ch;

	public ResourceSimpleList64<uint_r> EffectRuleNameHashes;

	public ResourcePointerList64<EffectRule> EffectRules;

	public override long Length => 64L;

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
		EffectRuleNameHashes = reader.ReadBlock<ResourceSimpleList64<uint_r>>(Array.Empty<object>());
		EffectRules = reader.ReadBlock<ResourcePointerList64<EffectRule>>(Array.Empty<object>());
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
		writer.WriteBlock(EffectRuleNameHashes);
		writer.WriteBlock(EffectRules);
	}

	public override Tuple<long, IResourceBlock>[] GetParts()
	{
		return new Tuple<long, IResourceBlock>[2]
		{
			new Tuple<long, IResourceBlock>(32L, EffectRuleNameHashes),
			new Tuple<long, IResourceBlock>(48L, EffectRules)
		};
	}
}
