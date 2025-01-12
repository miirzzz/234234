using System;
using System.Collections.Generic;

namespace RageLib.Resources.GTA5.PC.Clips;

public class AnimationMapEntry : ResourceSystemBlock
{
	public uint Hash;

	public uint Unknown_4h;

	public ulong AnimationPointer;

	public ulong NextEntryPointer;

	public uint Unknown_18h;

	public uint Unknown_1Ch;

	public Animation Animation;

	public AnimationMapEntry NextEntry;

	public override long Length => 32L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		Hash = reader.ReadUInt32();
		Unknown_4h = reader.ReadUInt32();
		AnimationPointer = reader.ReadUInt64();
		NextEntryPointer = reader.ReadUInt64();
		Unknown_18h = reader.ReadUInt32();
		Unknown_1Ch = reader.ReadUInt32();
		Animation = reader.ReadBlockAt<Animation>(AnimationPointer, Array.Empty<object>());
		NextEntry = reader.ReadBlockAt<AnimationMapEntry>(NextEntryPointer, Array.Empty<object>());
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		AnimationPointer = (ulong)((Animation != null) ? Animation.Position : 0);
		NextEntryPointer = (ulong)((NextEntry != null) ? NextEntry.Position : 0);
		writer.Write(Hash);
		writer.Write(Unknown_4h);
		writer.Write(AnimationPointer);
		writer.Write(NextEntryPointer);
		writer.Write(Unknown_18h);
		writer.Write(Unknown_1Ch);
	}

	public override IResourceBlock[] GetReferences()
	{
		List<IResourceBlock> list = new List<IResourceBlock>();
		if (Animation != null)
		{
			list.Add(Animation);
		}
		if (NextEntry != null)
		{
			list.Add(NextEntry);
		}
		return list.ToArray();
	}
}
