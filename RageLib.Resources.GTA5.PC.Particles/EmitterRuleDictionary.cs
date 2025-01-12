using System.Collections.Generic;
using RageLib.Resources.Common;

namespace RageLib.Resources.GTA5.PC.Particles;

public class EmitterRuleDictionary : ResourceSystemBlock
{
	public uint VFT;

	public uint Unknown_4h;

	public uint Unknown_8h;

	public uint Unknown_Ch;

	public uint Unknown_10h;

	public uint Unknown_14h;

	public uint Unknown_18h;

	public uint Unknown_1Ch;

	public ulong HashesPointer;

	public ushort HashesCount1;

	public ushort HashesCount2;

	public uint Unknown_2Ch;

	public ulong EffectRulesPointer;

	public ushort EffectRulesCount1;

	public ushort EffectRulesCount2;

	public uint Unknown_3Ch;

	public ResourceSimpleArray<uint_r> Hashes;

	public ResourcePointerArray64<EmitterRule> EmitterRules;

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
		HashesPointer = reader.ReadUInt64();
		HashesCount1 = reader.ReadUInt16();
		HashesCount2 = reader.ReadUInt16();
		Unknown_2Ch = reader.ReadUInt32();
		EffectRulesPointer = reader.ReadUInt64();
		EffectRulesCount1 = reader.ReadUInt16();
		EffectRulesCount2 = reader.ReadUInt16();
		Unknown_3Ch = reader.ReadUInt32();
		Hashes = reader.ReadBlockAt<ResourceSimpleArray<uint_r>>(HashesPointer, new object[1] { HashesCount1 });
		EmitterRules = reader.ReadBlockAt<ResourcePointerArray64<EmitterRule>>(EffectRulesPointer, new object[1] { EffectRulesCount1 });
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		HashesPointer = (ulong)((Hashes != null) ? Hashes.Position : 0);
		EffectRulesPointer = (ulong)((EmitterRules != null) ? EmitterRules.Position : 0);
		writer.Write(VFT);
		writer.Write(Unknown_4h);
		writer.Write(Unknown_8h);
		writer.Write(Unknown_Ch);
		writer.Write(Unknown_10h);
		writer.Write(Unknown_14h);
		writer.Write(Unknown_18h);
		writer.Write(Unknown_1Ch);
		writer.Write(HashesPointer);
		writer.Write(HashesCount1);
		writer.Write(HashesCount2);
		writer.Write(Unknown_2Ch);
		writer.Write(EffectRulesPointer);
		writer.Write(EffectRulesCount1);
		writer.Write(EffectRulesCount2);
		writer.Write(Unknown_3Ch);
	}

	public override IResourceBlock[] GetReferences()
	{
		List<IResourceBlock> list = new List<IResourceBlock>();
		if (Hashes != null)
		{
			list.Add(Hashes);
		}
		if (EmitterRules != null)
		{
			list.Add(EmitterRules);
		}
		return list.ToArray();
	}
}
