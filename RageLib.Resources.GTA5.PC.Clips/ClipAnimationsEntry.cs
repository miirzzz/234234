using System;
using System.Collections.Generic;

namespace RageLib.Resources.GTA5.PC.Clips;

public class ClipAnimationsEntry : ResourceSystemBlock
{
	public float Unknown_0h;

	public float Unknown_4h;

	public float Unknown_8h;

	public uint Unknown_Ch;

	public ulong AnimationPointer;

	public Animation Animation;

	public override long Length => 24L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		Unknown_0h = reader.ReadSingle();
		Unknown_4h = reader.ReadSingle();
		Unknown_8h = reader.ReadSingle();
		Unknown_Ch = reader.ReadUInt32();
		AnimationPointer = reader.ReadUInt64();
		Animation = reader.ReadBlockAt<Animation>(AnimationPointer, Array.Empty<object>());
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		AnimationPointer = (ulong)((Animation != null) ? Animation.Position : 0);
		writer.Write(Unknown_0h);
		writer.Write(Unknown_4h);
		writer.Write(Unknown_8h);
		writer.Write(Unknown_Ch);
		writer.Write(AnimationPointer);
	}

	public override IResourceBlock[] GetReferences()
	{
		List<IResourceBlock> list = new List<IResourceBlock>();
		if (Animation != null)
		{
			list.Add(Animation);
		}
		return list.ToArray();
	}
}
