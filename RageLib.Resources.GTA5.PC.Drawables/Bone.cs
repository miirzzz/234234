using System;
using System.Collections.Generic;
using RageLib.Resources.Common;

namespace RageLib.Resources.GTA5.PC.Drawables;

public class Bone : ResourceSystemBlock
{
	public float RotationX;

	public float RotationY;

	public float RotationZ;

	public float RotationW;

	public float TranslationX;

	public float TranslationY;

	public float TranslationZ;

	public uint Unknown_1Ch;

	public float Unknown_20h;

	public float Unknown_24h;

	public float Unknown_28h;

	public float Unknown_2Ch;

	public uint Unknown_30h;

	public uint Unknown_34h;

	public ulong NamePointer;

	public ushort Unknown_40h;

	public ushort Unknown_42h;

	public ushort Id;

	public ushort Unknown_46h;

	public uint Unknown_48h;

	public uint Unknown_4Ch;

	public string_r Name;

	public override long Length => 80L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		RotationX = reader.ReadSingle();
		RotationY = reader.ReadSingle();
		RotationZ = reader.ReadSingle();
		RotationW = reader.ReadSingle();
		TranslationX = reader.ReadSingle();
		TranslationY = reader.ReadSingle();
		TranslationZ = reader.ReadSingle();
		Unknown_1Ch = reader.ReadUInt32();
		Unknown_20h = reader.ReadSingle();
		Unknown_24h = reader.ReadSingle();
		Unknown_28h = reader.ReadSingle();
		Unknown_2Ch = reader.ReadSingle();
		Unknown_30h = reader.ReadUInt32();
		Unknown_34h = reader.ReadUInt32();
		NamePointer = reader.ReadUInt64();
		Unknown_40h = reader.ReadUInt16();
		Unknown_42h = reader.ReadUInt16();
		Id = reader.ReadUInt16();
		Unknown_46h = reader.ReadUInt16();
		Unknown_48h = reader.ReadUInt32();
		Unknown_4Ch = reader.ReadUInt32();
		Name = reader.ReadBlockAt<string_r>(NamePointer, Array.Empty<object>());
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		NamePointer = (ulong)((Name != null) ? Name.Position : 0);
		writer.Write(RotationX);
		writer.Write(RotationY);
		writer.Write(RotationZ);
		writer.Write(RotationW);
		writer.Write(TranslationX);
		writer.Write(TranslationY);
		writer.Write(TranslationZ);
		writer.Write(Unknown_1Ch);
		writer.Write(Unknown_20h);
		writer.Write(Unknown_24h);
		writer.Write(Unknown_28h);
		writer.Write(Unknown_2Ch);
		writer.Write(Unknown_30h);
		writer.Write(Unknown_34h);
		writer.Write(NamePointer);
		writer.Write(Unknown_40h);
		writer.Write(Unknown_42h);
		writer.Write(Id);
		writer.Write(Unknown_46h);
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
		return list.ToArray();
	}
}
