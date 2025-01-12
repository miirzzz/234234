using System;
using System.Collections.Generic;
using RageLib.Resources.Common;

namespace RageLib.Resources.GTA5.PC.Clips;

public class ClipDictionary : FileBase64_GTA5_pc
{
	public uint Unknown_10h;

	public uint Unknown_14h;

	public ulong AnimationsPointer;

	public uint Unknown_20h;

	public uint Unknown_24h;

	public ulong ClipsPointer;

	public ushort ClipEntriesCount;

	public ushort ClipEntriesTotalCount;

	public uint Unknown_34h;

	public uint Unknown_38h;

	public uint Unknown_3Ch;

	public AnimationMap Animations;

	public ResourcePointerArray64<ClipMapEntry> Clips;

	public override long Length => 64L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		base.Read(reader, parameters);
		Unknown_10h = reader.ReadUInt32();
		Unknown_14h = reader.ReadUInt32();
		AnimationsPointer = reader.ReadUInt64();
		Unknown_20h = reader.ReadUInt32();
		Unknown_24h = reader.ReadUInt32();
		ClipsPointer = reader.ReadUInt64();
		ClipEntriesCount = reader.ReadUInt16();
		ClipEntriesTotalCount = reader.ReadUInt16();
		Unknown_34h = reader.ReadUInt32();
		Unknown_38h = reader.ReadUInt32();
		Unknown_3Ch = reader.ReadUInt32();
		Animations = reader.ReadBlockAt<AnimationMap>(AnimationsPointer, Array.Empty<object>());
		Clips = reader.ReadBlockAt<ResourcePointerArray64<ClipMapEntry>>(ClipsPointer, new object[1] { ClipEntriesCount });
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		base.Write(writer, parameters);
		AnimationsPointer = (ulong)((Animations != null) ? Animations.Position : 0);
		ClipsPointer = (ulong)((Clips != null) ? Clips.Position : 0);
		ClipEntriesCount = (ushort)((Clips != null) ? ((uint)Clips.Count) : 0u);
		if (Clips != null)
		{
			int num = 0;
			foreach (ClipMapEntry data_item in Clips.data_items)
			{
				if (data_item == null)
				{
					continue;
				}
				ClipMapEntry clipMapEntry = data_item;
				while (true)
				{
					if (clipMapEntry.Clip != null)
					{
						num++;
					}
					if (clipMapEntry.Next == null)
					{
						break;
					}
					clipMapEntry = clipMapEntry.Next;
				}
			}
			ClipEntriesTotalCount = (ushort)num;
		}
		else
		{
			ClipEntriesTotalCount = 0;
		}
		writer.Write(Unknown_10h);
		writer.Write(Unknown_14h);
		writer.Write(AnimationsPointer);
		writer.Write(Unknown_20h);
		writer.Write(Unknown_24h);
		writer.Write(ClipsPointer);
		writer.Write(ClipEntriesCount);
		writer.Write(ClipEntriesTotalCount);
		writer.Write(Unknown_34h);
		writer.Write(Unknown_38h);
		writer.Write(Unknown_3Ch);
	}

	public override IResourceBlock[] GetReferences()
	{
		List<IResourceBlock> list = new List<IResourceBlock>(base.GetReferences());
		if (Animations != null)
		{
			list.Add(Animations);
		}
		if (Clips != null)
		{
			list.Add(Clips);
		}
		return list.ToArray();
	}
}
