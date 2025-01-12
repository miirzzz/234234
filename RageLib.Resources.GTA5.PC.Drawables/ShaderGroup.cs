using System;
using System.Collections.Generic;
using RageLib.Resources.Common;
using RageLib.Resources.GTA5.PC.Textures;

namespace RageLib.Resources.GTA5.PC.Drawables;

public class ShaderGroup : ResourceSystemBlock
{
	public uint VFT;

	public uint Unknown_4h;

	public ulong TextureDictionaryPointer;

	public ulong ShadersPointer;

	public ushort ShadersCount1;

	public ushort ShadersCount2;

	public uint Unknown_1Ch;

	public uint Unknown_20h;

	public uint Unknown_24h;

	public uint Unknown_28h;

	public uint Unknown_2Ch;

	public uint Unknown_30h;

	public uint Unknown_34h;

	public uint Unknown_38h;

	public uint Unknown_3Ch;

	public TextureDictionary TextureDictionary;

	public ResourcePointerArray64<ShaderFX> Shaders;

	public override long Length => 64L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		VFT = reader.ReadUInt32();
		Unknown_4h = reader.ReadUInt32();
		TextureDictionaryPointer = reader.ReadUInt64();
		ShadersPointer = reader.ReadUInt64();
		ShadersCount1 = reader.ReadUInt16();
		ShadersCount2 = reader.ReadUInt16();
		Unknown_1Ch = reader.ReadUInt32();
		Unknown_20h = reader.ReadUInt32();
		Unknown_24h = reader.ReadUInt32();
		Unknown_28h = reader.ReadUInt32();
		Unknown_2Ch = reader.ReadUInt32();
		Unknown_30h = reader.ReadUInt32();
		Unknown_34h = reader.ReadUInt32();
		Unknown_38h = reader.ReadUInt32();
		Unknown_3Ch = reader.ReadUInt32();
		TextureDictionary = reader.ReadBlockAt<TextureDictionary>(TextureDictionaryPointer, Array.Empty<object>());
		Shaders = reader.ReadBlockAt<ResourcePointerArray64<ShaderFX>>(ShadersPointer, new object[1] { ShadersCount1 });
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		TextureDictionaryPointer = (ulong)((TextureDictionary != null) ? TextureDictionary.Position : 0);
		ShadersPointer = (ulong)((Shaders != null) ? Shaders.Position : 0);
		writer.Write(VFT);
		writer.Write(Unknown_4h);
		writer.Write(TextureDictionaryPointer);
		writer.Write(ShadersPointer);
		writer.Write(ShadersCount1);
		writer.Write(ShadersCount2);
		writer.Write(Unknown_1Ch);
		writer.Write(Unknown_20h);
		writer.Write(Unknown_24h);
		writer.Write(Unknown_28h);
		writer.Write(Unknown_2Ch);
		writer.Write(Unknown_30h);
		writer.Write(Unknown_34h);
		writer.Write(Unknown_38h);
		writer.Write(Unknown_3Ch);
	}

	public override IResourceBlock[] GetReferences()
	{
		List<IResourceBlock> list = new List<IResourceBlock>();
		if (TextureDictionary != null)
		{
			list.Add(TextureDictionary);
		}
		if (Shaders != null)
		{
			list.Add(Shaders);
		}
		return list.ToArray();
	}
}
