using System;
using System.Collections.Generic;
using RageLib.Resources.Common;
using RageLib.Resources.GTA5.PC.Textures;

namespace RageLib.Resources.GTA5.PC.Particles;

public class ShaderVarTexture : ShaderVar
{
	public uint Unknown_18h;

	public uint Unknown_1Ch;

	public uint Unknown_20h;

	public uint Unknown_24h;

	public ulong TexturePointer;

	public ulong NamePointer;

	public uint NameHash;

	public uint Unknown_3Ch;

	public TextureDX11 Texture;

	public string_r Name;

	public override long Length => 64L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		base.Read(reader, parameters);
		Unknown_18h = reader.ReadUInt32();
		Unknown_1Ch = reader.ReadUInt32();
		Unknown_20h = reader.ReadUInt32();
		Unknown_24h = reader.ReadUInt32();
		TexturePointer = reader.ReadUInt64();
		NamePointer = reader.ReadUInt64();
		NameHash = reader.ReadUInt32();
		Unknown_3Ch = reader.ReadUInt32();
		Texture = reader.ReadBlockAt<TextureDX11>(TexturePointer, Array.Empty<object>());
		Name = reader.ReadBlockAt<string_r>(NamePointer, Array.Empty<object>());
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		base.Write(writer, parameters);
		TexturePointer = (ulong)((Texture != null) ? Texture.Position : 0);
		NamePointer = (ulong)((Name != null) ? Name.Position : 0);
		writer.Write(Unknown_18h);
		writer.Write(Unknown_1Ch);
		writer.Write(Unknown_20h);
		writer.Write(Unknown_24h);
		writer.Write(TexturePointer);
		writer.Write(NamePointer);
		writer.Write(NameHash);
		writer.Write(Unknown_3Ch);
	}

	public override IResourceBlock[] GetReferences()
	{
		List<IResourceBlock> list = new List<IResourceBlock>(base.GetReferences());
		if (Texture != null)
		{
			list.Add(Texture);
		}
		if (Name != null)
		{
			list.Add(Name);
		}
		return list.ToArray();
	}
}
