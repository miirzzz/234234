using System;
using System.Collections.Generic;

namespace RageLib.Resources.GTA5.PC.Clips;

public class ClipMapEntry : ResourceSystemBlock
{
	public uint Hash;

	public uint Unknown_4h;

	public ulong ClipPointer;

	public ulong NextPointer;

	public uint Unknown_18h;

	public uint Unknown_1Ch;

	public Clip Clip;

	public ClipMapEntry Next;

	public override long Length => 32L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		Hash = reader.ReadUInt32();
		Unknown_4h = reader.ReadUInt32();
		ClipPointer = reader.ReadUInt64();
		NextPointer = reader.ReadUInt64();
		Unknown_18h = reader.ReadUInt32();
		Unknown_1Ch = reader.ReadUInt32();
		Clip = reader.ReadBlockAt<Clip>(ClipPointer, Array.Empty<object>());
		Next = reader.ReadBlockAt<ClipMapEntry>(NextPointer, Array.Empty<object>());
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		ClipPointer = (ulong)((Clip != null) ? Clip.Position : 0);
		NextPointer = (ulong)((Next != null) ? Next.Position : 0);
		writer.Write(Hash);
		writer.Write(Unknown_4h);
		writer.Write(ClipPointer);
		writer.Write(NextPointer);
		writer.Write(Unknown_18h);
		writer.Write(Unknown_1Ch);
	}

	public override IResourceBlock[] GetReferences()
	{
		List<IResourceBlock> list = new List<IResourceBlock>();
		if (Clip != null)
		{
			list.Add(Clip);
		}
		if (Next != null)
		{
			list.Add(Next);
		}
		return list.ToArray();
	}
}
