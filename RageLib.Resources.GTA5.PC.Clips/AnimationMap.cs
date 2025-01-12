using System.Collections.Generic;
using RageLib.Resources.Common;

namespace RageLib.Resources.GTA5.PC.Clips;

public class AnimationMap : ResourceSystemBlock
{
	public uint VFT;

	public uint Unknown_4h;

	public uint Unknown_8h;

	public uint Unknown_Ch;

	public uint Unknown_10h;

	public uint Unknown_14h;

	public ulong AnimationsPointer;

	public ushort AnimationEntriesCount;

	public ushort AnimationEntriesTotalCount;

	public uint Unknown_24h;

	public uint Unknown_28h;

	public uint Unknown_2Ch;

	public ResourcePointerArray64<AnimationMapEntry> Animations;

	public override long Length => 48L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		VFT = reader.ReadUInt32();
		Unknown_4h = reader.ReadUInt32();
		Unknown_8h = reader.ReadUInt32();
		Unknown_Ch = reader.ReadUInt32();
		Unknown_10h = reader.ReadUInt32();
		Unknown_14h = reader.ReadUInt32();
		AnimationsPointer = reader.ReadUInt64();
		AnimationEntriesCount = reader.ReadUInt16();
		AnimationEntriesTotalCount = reader.ReadUInt16();
		Unknown_24h = reader.ReadUInt32();
		Unknown_28h = reader.ReadUInt32();
		Unknown_2Ch = reader.ReadUInt32();
		Animations = reader.ReadBlockAt<ResourcePointerArray64<AnimationMapEntry>>(AnimationsPointer, new object[1] { AnimationEntriesCount });
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		AnimationsPointer = (ulong)((Animations != null) ? Animations.Position : 0);
		AnimationEntriesCount = (ushort)((Animations != null) ? ((uint)Animations.Count) : 0u);
		if (Animations != null)
		{
			int num = 0;
			foreach (AnimationMapEntry data_item in Animations.data_items)
			{
				if (data_item == null)
				{
					continue;
				}
				AnimationMapEntry animationMapEntry = data_item;
				while (true)
				{
					if (animationMapEntry.Animation != null)
					{
						num++;
					}
					if (animationMapEntry.NextEntry == null)
					{
						break;
					}
					animationMapEntry = animationMapEntry.NextEntry;
				}
			}
			AnimationEntriesTotalCount = (ushort)num;
		}
		else
		{
			AnimationEntriesTotalCount = 0;
		}
		writer.Write(VFT);
		writer.Write(Unknown_4h);
		writer.Write(Unknown_8h);
		writer.Write(Unknown_Ch);
		writer.Write(Unknown_10h);
		writer.Write(Unknown_14h);
		writer.Write(AnimationsPointer);
		writer.Write(AnimationEntriesCount);
		writer.Write(AnimationEntriesTotalCount);
		writer.Write(Unknown_24h);
		writer.Write(Unknown_28h);
		writer.Write(Unknown_2Ch);
	}

	public override IResourceBlock[] GetReferences()
	{
		List<IResourceBlock> list = new List<IResourceBlock>();
		if (Animations != null)
		{
			list.Add(Animations);
		}
		return list.ToArray();
	}
}
