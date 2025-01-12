using System.Collections.Generic;
using RageLib.Resources.Common;

namespace RageLib.Resources.GTA5.PC.Clips;

public class ClipAnimations : Clip
{
	public ulong AnimationsPointer;

	public ushort AnimationsCount1;

	public ushort AnimationsCount2;

	public uint Unknown_5Ch;

	public uint Unknown_60h;

	public uint Unknown_64h;

	public uint Unknown_68h;

	public uint Unknown_6Ch;

	public ResourceSimpleArray<ClipAnimationsEntry> Animations;

	public override long Length => 112L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		base.Read(reader, parameters);
		AnimationsPointer = reader.ReadUInt64();
		AnimationsCount1 = reader.ReadUInt16();
		AnimationsCount2 = reader.ReadUInt16();
		Unknown_5Ch = reader.ReadUInt32();
		Unknown_60h = reader.ReadUInt32();
		Unknown_64h = reader.ReadUInt32();
		Unknown_68h = reader.ReadUInt32();
		Unknown_6Ch = reader.ReadUInt32();
		Animations = reader.ReadBlockAt<ResourceSimpleArray<ClipAnimationsEntry>>(AnimationsPointer, new object[1] { AnimationsCount1 });
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		base.Write(writer, parameters);
		AnimationsPointer = (ulong)((Animations != null) ? Animations.Position : 0);
		AnimationsCount1 = (ushort)((Animations != null) ? ((uint)Animations.Count) : 0u);
		AnimationsCount2 = (ushort)((Animations != null) ? ((uint)Animations.Count) : 0u);
		writer.Write(AnimationsPointer);
		writer.Write(AnimationsCount1);
		writer.Write(AnimationsCount2);
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
		if (Animations != null)
		{
			list.Add(Animations);
		}
		return list.ToArray();
	}
}
