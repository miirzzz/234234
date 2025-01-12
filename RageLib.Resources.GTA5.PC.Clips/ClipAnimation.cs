using System;
using System.Collections.Generic;

namespace RageLib.Resources.GTA5.PC.Clips;

public class ClipAnimation : Clip
{
	public ulong AnimationPointer;

	public float Unknown_58h;

	public float Unknown_5Ch;

	public float Unknown_60h;

	public uint Unknown_64h;

	public uint Unknown_68h;

	public uint Unknown_6Ch;

	public Animation Animation;

	public override long Length => 112L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		base.Read(reader, parameters);
		AnimationPointer = reader.ReadUInt64();
		Unknown_58h = reader.ReadSingle();
		Unknown_5Ch = reader.ReadSingle();
		Unknown_60h = reader.ReadSingle();
		Unknown_64h = reader.ReadUInt32();
		Unknown_68h = reader.ReadUInt32();
		Unknown_6Ch = reader.ReadUInt32();
		Animation = reader.ReadBlockAt<Animation>(AnimationPointer, Array.Empty<object>());
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		base.Write(writer, parameters);
		AnimationPointer = (ulong)((Animation != null) ? Animation.Position : 0);
		writer.Write(AnimationPointer);
		writer.Write(Unknown_58h);
		writer.Write(Unknown_5Ch);
		writer.Write(Unknown_60h);
		writer.Write(Unknown_64h);
		writer.Write(Unknown_68h);
		writer.Write(Unknown_6Ch);
	}

	public override IResourceBlock[] GetReferences()
	{
		List<IResourceBlock> list = new List<IResourceBlock>();
		list.AddRange(base.GetReferences());
		if (Animation != null)
		{
			list.Add(Animation);
		}
		return list.ToArray();
	}
}
