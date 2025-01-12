using System;
using System.Collections.Generic;

namespace RageLib.Resources.GTA5.PC.Drawables;

public class Unknown_D_001 : ResourceSystemBlock
{
	public uint Key;

	public uint Value;

	public ulong NextPointer;

	public Unknown_D_001 Next;

	public override long Length => 16L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		Key = reader.ReadUInt32();
		Value = reader.ReadUInt32();
		NextPointer = reader.ReadUInt64();
		Next = reader.ReadBlockAt<Unknown_D_001>(NextPointer, Array.Empty<object>());
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		NextPointer = (ulong)((Next != null) ? Next.Position : 0);
		writer.Write(Key);
		writer.Write(Value);
		writer.Write(NextPointer);
	}

	public override IResourceBlock[] GetReferences()
	{
		List<IResourceBlock> list = new List<IResourceBlock>();
		if (Next != null)
		{
			list.Add(Next);
		}
		return list.ToArray();
	}
}
