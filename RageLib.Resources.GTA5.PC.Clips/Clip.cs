using System;
using System.Collections.Generic;
using RageLib.Resources.Common;

namespace RageLib.Resources.GTA5.PC.Clips;

public class Clip : ResourceSystemBlock, IResourceXXSystemBlock, IResourceSystemBlock, IResourceBlock
{
	public uint VFT;

	public uint Unknown_4h;

	public uint Unknown_8h;

	public uint Unknown_Ch;

	public uint Unknown_10h;

	public uint Unknown_14h;

	public ulong NamePointer;

	public ushort NameLength1;

	public ushort NameLength2;

	public uint Unknown_24h;

	public uint Unknown_28h;

	public uint Unknown_2Ch;

	public uint Unknown_30h;

	public uint Unknown_34h;

	public ulong TagsPointer;

	public ulong PropertiesPointer;

	public uint Unknown_48h;

	public uint Unknown_4Ch;

	public string_r Name;

	public Tags Tags;

	public PropertyMap Properties;

	public override long Length => 112L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		VFT = reader.ReadUInt32();
		Unknown_4h = reader.ReadUInt32();
		Unknown_8h = reader.ReadUInt32();
		Unknown_Ch = reader.ReadUInt32();
		Unknown_10h = reader.ReadUInt32();
		Unknown_14h = reader.ReadUInt32();
		NamePointer = reader.ReadUInt64();
		NameLength1 = reader.ReadUInt16();
		NameLength2 = reader.ReadUInt16();
		Unknown_24h = reader.ReadUInt32();
		Unknown_28h = reader.ReadUInt32();
		Unknown_2Ch = reader.ReadUInt32();
		Unknown_30h = reader.ReadUInt32();
		Unknown_34h = reader.ReadUInt32();
		TagsPointer = reader.ReadUInt64();
		PropertiesPointer = reader.ReadUInt64();
		Unknown_48h = reader.ReadUInt32();
		Unknown_4Ch = reader.ReadUInt32();
		Name = reader.ReadBlockAt<string_r>(NamePointer, Array.Empty<object>());
		Tags = reader.ReadBlockAt<Tags>(TagsPointer, Array.Empty<object>());
		Properties = reader.ReadBlockAt<PropertyMap>(PropertiesPointer, Array.Empty<object>());
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		NamePointer = (ulong)((Name != null) ? Name.Position : 0);
		NameLength1 = (ushort)((Name != null) ? ((uint)Name.Value.Length) : 0u);
		NameLength2 = (ushort)((Name != null) ? ((uint)(Name.Value.Length + 1)) : 0u);
		TagsPointer = (ulong)((Tags != null) ? Tags.Position : 0);
		PropertiesPointer = (ulong)((Properties != null) ? Properties.Position : 0);
		writer.Write(VFT);
		writer.Write(Unknown_4h);
		writer.Write(Unknown_8h);
		writer.Write(Unknown_Ch);
		writer.Write(Unknown_10h);
		writer.Write(Unknown_14h);
		writer.Write(NamePointer);
		writer.Write(NameLength1);
		writer.Write(NameLength2);
		writer.Write(Unknown_24h);
		writer.Write(Unknown_28h);
		writer.Write(Unknown_2Ch);
		writer.Write(Unknown_30h);
		writer.Write(Unknown_34h);
		writer.Write(TagsPointer);
		writer.Write(PropertiesPointer);
		writer.Write(Unknown_48h);
		writer.Write(Unknown_4Ch);
	}

	public override IResourceBlock[] GetReferences()
	{
		List<IResourceBlock> list = new List<IResourceBlock>();
		if (Name != null)
		{
			list.Add(Name);
		}
		if (Tags != null)
		{
			list.Add(Tags);
		}
		if (Properties != null)
		{
			list.Add(Properties);
		}
		return list.ToArray();
	}

	public IResourceSystemBlock GetType(ResourceDataReader reader, params object[] parameters)
	{
		reader.Position += 16L;
		byte b = reader.ReadByte();
		reader.Position -= 17L;
		return b switch
		{
			1 => new ClipAnimation(), 
			2 => new ClipAnimations(), 
			_ => throw new Exception("Unknown clip type"), 
		};
	}
}
