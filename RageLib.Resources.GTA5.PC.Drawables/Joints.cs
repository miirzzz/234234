using System.Collections.Generic;
using RageLib.Resources.Common;

namespace RageLib.Resources.GTA5.PC.Drawables;

public class Joints : ResourceSystemBlock
{
	public uint VFT;

	public uint Unknown_4h;

	public uint Unknown_8h;

	public uint Unknown_Ch;

	public ulong RotationLimitsPointer;

	public ulong TranslationLimitsPointer;

	public uint Unknown_20h;

	public uint Unknown_24h;

	public uint Unknown_28h;

	public uint Unknown_2Ch;

	public ushort RotationLimitsCount;

	public ushort TranslationLimitsCount;

	public ushort Unknown_34h;

	public ushort Unknown_36h;

	public uint Unknown_38h;

	public uint Unknown_3Ch;

	public ResourceSimpleArray<JointRotationLimit> RotationLimits;

	public ResourceSimpleArray<JointTranslationLimit> TranslationLimits;

	public override long Length => 64L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		VFT = reader.ReadUInt32();
		Unknown_4h = reader.ReadUInt32();
		Unknown_8h = reader.ReadUInt32();
		Unknown_Ch = reader.ReadUInt32();
		RotationLimitsPointer = reader.ReadUInt64();
		TranslationLimitsPointer = reader.ReadUInt64();
		Unknown_20h = reader.ReadUInt32();
		Unknown_24h = reader.ReadUInt32();
		Unknown_28h = reader.ReadUInt32();
		Unknown_2Ch = reader.ReadUInt32();
		RotationLimitsCount = reader.ReadUInt16();
		TranslationLimitsCount = reader.ReadUInt16();
		Unknown_34h = reader.ReadUInt16();
		Unknown_36h = reader.ReadUInt16();
		Unknown_38h = reader.ReadUInt32();
		Unknown_3Ch = reader.ReadUInt32();
		RotationLimits = reader.ReadBlockAt<ResourceSimpleArray<JointRotationLimit>>(RotationLimitsPointer, new object[1] { RotationLimitsCount });
		TranslationLimits = reader.ReadBlockAt<ResourceSimpleArray<JointTranslationLimit>>(TranslationLimitsPointer, new object[1] { TranslationLimitsCount });
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		RotationLimitsPointer = (ulong)((RotationLimits != null) ? RotationLimits.Position : 0);
		TranslationLimitsPointer = (ulong)((TranslationLimits != null) ? TranslationLimits.Position : 0);
		RotationLimitsCount = (ushort)((RotationLimits != null) ? ((uint)RotationLimits.Count) : 0u);
		TranslationLimitsCount = (ushort)((TranslationLimits != null) ? ((uint)TranslationLimits.Count) : 0u);
		writer.Write(VFT);
		writer.Write(Unknown_4h);
		writer.Write(Unknown_8h);
		writer.Write(Unknown_Ch);
		writer.Write(RotationLimitsPointer);
		writer.Write(TranslationLimitsPointer);
		writer.Write(Unknown_20h);
		writer.Write(Unknown_24h);
		writer.Write(Unknown_28h);
		writer.Write(Unknown_2Ch);
		writer.Write(RotationLimitsCount);
		writer.Write(TranslationLimitsCount);
		writer.Write(Unknown_34h);
		writer.Write(Unknown_36h);
		writer.Write(Unknown_38h);
		writer.Write(Unknown_3Ch);
	}

	public override IResourceBlock[] GetReferences()
	{
		List<IResourceBlock> list = new List<IResourceBlock>();
		if (RotationLimits != null)
		{
			list.Add(RotationLimits);
		}
		if (TranslationLimits != null)
		{
			list.Add(TranslationLimits);
		}
		return list.ToArray();
	}
}
