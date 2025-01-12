using System;
using System.Collections.Generic;
using RageLib.Resources.Common;
using RageLib.Resources.GTA5.PC.Drawables;
using RageLib.Resources.GTA5.PC.Textures;

namespace RageLib.Resources.GTA5.PC.Particles;

public class ParticleEffectsList : FileBase64_GTA5_pc
{
	public ulong NamePointer;

	public uint Unknown_18h;

	public uint Unknown_1Ch;

	public ulong TextureDictionaryPointer;

	public uint Unknown_28h;

	public uint Unknown_2Ch;

	public ulong DrawableDictionaryPointer;

	public ulong ParticleRuleDictionaryPointer;

	public uint Unknown_40h;

	public uint Unknown_44h;

	public ulong EmitterRuleDictionaryPointer;

	public ulong EffectRuleDictionaryPointer;

	public uint Unknown_58h;

	public uint Unknown_5Ch;

	public string_r Name;

	public TextureDictionary TextureDictionary;

	public DrawableDictionary DrawableDictionary;

	public ParticleRuleDictionary ParticleRuleDictionary;

	public EffectRuleDictionary EffectRuleDictionary;

	public EmitterRuleDictionary EmitterRuleDictionary;

	public override long Length => 96L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		base.Read(reader, parameters);
		NamePointer = reader.ReadUInt64();
		Unknown_18h = reader.ReadUInt32();
		Unknown_1Ch = reader.ReadUInt32();
		TextureDictionaryPointer = reader.ReadUInt64();
		Unknown_28h = reader.ReadUInt32();
		Unknown_2Ch = reader.ReadUInt32();
		DrawableDictionaryPointer = reader.ReadUInt64();
		ParticleRuleDictionaryPointer = reader.ReadUInt64();
		Unknown_40h = reader.ReadUInt32();
		Unknown_44h = reader.ReadUInt32();
		EmitterRuleDictionaryPointer = reader.ReadUInt64();
		EffectRuleDictionaryPointer = reader.ReadUInt64();
		Unknown_58h = reader.ReadUInt32();
		Unknown_5Ch = reader.ReadUInt32();
		Name = reader.ReadBlockAt<string_r>(NamePointer, Array.Empty<object>());
		TextureDictionary = reader.ReadBlockAt<TextureDictionary>(TextureDictionaryPointer, Array.Empty<object>());
		DrawableDictionary = reader.ReadBlockAt<DrawableDictionary>(DrawableDictionaryPointer, Array.Empty<object>());
		ParticleRuleDictionary = reader.ReadBlockAt<ParticleRuleDictionary>(ParticleRuleDictionaryPointer, Array.Empty<object>());
		EffectRuleDictionary = reader.ReadBlockAt<EffectRuleDictionary>(EmitterRuleDictionaryPointer, Array.Empty<object>());
		EmitterRuleDictionary = reader.ReadBlockAt<EmitterRuleDictionary>(EffectRuleDictionaryPointer, Array.Empty<object>());
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		base.Write(writer, parameters);
		NamePointer = (ulong)((Name != null) ? Name.Position : 0);
		TextureDictionaryPointer = (ulong)((TextureDictionary != null) ? TextureDictionary.Position : 0);
		DrawableDictionaryPointer = (ulong)((DrawableDictionary != null) ? DrawableDictionary.Position : 0);
		ParticleRuleDictionaryPointer = (ulong)((ParticleRuleDictionary != null) ? ParticleRuleDictionary.Position : 0);
		EmitterRuleDictionaryPointer = (ulong)((EffectRuleDictionary != null) ? EffectRuleDictionary.Position : 0);
		EffectRuleDictionaryPointer = (ulong)((EmitterRuleDictionary != null) ? EmitterRuleDictionary.Position : 0);
		writer.Write(NamePointer);
		writer.Write(Unknown_18h);
		writer.Write(Unknown_1Ch);
		writer.Write(TextureDictionaryPointer);
		writer.Write(Unknown_28h);
		writer.Write(Unknown_2Ch);
		writer.Write(DrawableDictionaryPointer);
		writer.Write(ParticleRuleDictionaryPointer);
		writer.Write(Unknown_40h);
		writer.Write(Unknown_44h);
		writer.Write(EmitterRuleDictionaryPointer);
		writer.Write(EffectRuleDictionaryPointer);
		writer.Write(Unknown_58h);
		writer.Write(Unknown_5Ch);
	}

	public override IResourceBlock[] GetReferences()
	{
		List<IResourceBlock> list = new List<IResourceBlock>(base.GetReferences());
		if (Name != null)
		{
			list.Add(Name);
		}
		if (TextureDictionary != null)
		{
			list.Add(TextureDictionary);
		}
		if (DrawableDictionary != null)
		{
			list.Add(DrawableDictionary);
		}
		if (ParticleRuleDictionary != null)
		{
			list.Add(ParticleRuleDictionary);
		}
		if (EffectRuleDictionary != null)
		{
			list.Add(EffectRuleDictionary);
		}
		if (EmitterRuleDictionary != null)
		{
			list.Add(EmitterRuleDictionary);
		}
		return list.ToArray();
	}
}
