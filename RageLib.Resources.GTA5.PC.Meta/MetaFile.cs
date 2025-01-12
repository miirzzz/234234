using System;
using System.Collections.Generic;
using RageLib.Resources.Common;

namespace RageLib.Resources.GTA5.PC.Meta;

public class MetaFile : FileBase64_GTA5_pc
{
	public ResourceSimpleArray<StructureInfo> StructureInfos;

	public ResourceSimpleArray<EnumInfo> EnumInfos;

	public ResourceSimpleArray<DataBlock> DataBlocks;

	public string_r Name;

	public override long Length => 112L;

	public int Unknown_10h { get; set; } = 1347568688;

	public short Unknown_14h { get; set; } = 121;

	public byte HasUselessData { get; set; }

	public byte Unknown_17h { get; set; }

	public int Unknown_18h { get; set; }

	public int RootBlockIndex { get; set; }

	public long StructureInfosPointer { get; private set; }

	public long EnumInfosPointer { get; private set; }

	public long DataBlocksPointer { get; private set; }

	public long NamePointer { get; private set; }

	public long UselessPointer { get; private set; }

	public short StructureInfosCount { get; private set; }

	public short EnumInfosCount { get; private set; }

	public short DataBlocksCount { get; private set; }

	public short Unknown_4Eh { get; set; }

	public int Unknown_50h { get; set; }

	public int Unknown_54h { get; set; }

	public int Unknown_58h { get; set; }

	public int Unknown_5Ch { get; set; }

	public int Unknown_60h { get; set; }

	public int Unknown_64h { get; set; }

	public int Unknown_68h { get; set; }

	public int Unknown_6Ch { get; set; }

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		base.Read(reader, parameters);
		Unknown_10h = reader.ReadInt32();
		Unknown_14h = reader.ReadInt16();
		HasUselessData = reader.ReadByte();
		Unknown_17h = reader.ReadByte();
		Unknown_18h = reader.ReadInt32();
		RootBlockIndex = reader.ReadInt32();
		StructureInfosPointer = reader.ReadInt64();
		EnumInfosPointer = reader.ReadInt64();
		DataBlocksPointer = reader.ReadInt64();
		NamePointer = reader.ReadInt64();
		UselessPointer = reader.ReadInt64();
		StructureInfosCount = reader.ReadInt16();
		EnumInfosCount = reader.ReadInt16();
		DataBlocksCount = reader.ReadInt16();
		Unknown_4Eh = reader.ReadInt16();
		Unknown_50h = reader.ReadInt32();
		Unknown_54h = reader.ReadInt32();
		Unknown_58h = reader.ReadInt32();
		Unknown_5Ch = reader.ReadInt32();
		Unknown_60h = reader.ReadInt32();
		Unknown_64h = reader.ReadInt32();
		Unknown_68h = reader.ReadInt32();
		Unknown_6Ch = reader.ReadInt32();
		StructureInfos = reader.ReadBlockAt<ResourceSimpleArray<StructureInfo>>((ulong)StructureInfosPointer, new object[1] { StructureInfosCount });
		EnumInfos = reader.ReadBlockAt<ResourceSimpleArray<EnumInfo>>((ulong)EnumInfosPointer, new object[1] { EnumInfosCount });
		DataBlocks = reader.ReadBlockAt<ResourceSimpleArray<DataBlock>>((ulong)DataBlocksPointer, new object[1] { DataBlocksCount });
		Name = reader.ReadBlockAt<string_r>((ulong)NamePointer, Array.Empty<object>());
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		base.Write(writer, parameters);
		StructureInfosPointer = StructureInfos?.Position ?? 0;
		EnumInfosPointer = EnumInfos?.Position ?? 0;
		DataBlocksPointer = DataBlocks?.Position ?? 0;
		NamePointer = Name?.Position ?? 0;
		UselessPointer = 0L;
		StructureInfosCount = (short)(StructureInfos?.Count ?? 0);
		EnumInfosCount = (short)(EnumInfos?.Count ?? 0);
		DataBlocksCount = (short)(DataBlocks?.Count ?? 0);
		writer.Write(Unknown_10h);
		writer.Write(Unknown_14h);
		writer.Write(HasUselessData);
		writer.Write(Unknown_17h);
		writer.Write(Unknown_18h);
		writer.Write(RootBlockIndex);
		writer.Write(StructureInfosPointer);
		writer.Write(EnumInfosPointer);
		writer.Write(DataBlocksPointer);
		writer.Write(NamePointer);
		writer.Write(UselessPointer);
		writer.Write(StructureInfosCount);
		writer.Write(EnumInfosCount);
		writer.Write(DataBlocksCount);
		writer.Write(Unknown_4Eh);
		writer.Write(Unknown_50h);
		writer.Write(Unknown_54h);
		writer.Write(Unknown_58h);
		writer.Write(Unknown_5Ch);
		writer.Write(Unknown_60h);
		writer.Write(Unknown_64h);
		writer.Write(Unknown_68h);
		writer.Write(Unknown_6Ch);
	}

	public override IResourceBlock[] GetReferences()
	{
		List<IResourceBlock> list = new List<IResourceBlock>(base.GetReferences());
		if (StructureInfos != null)
		{
			list.Add(StructureInfos);
		}
		if (EnumInfos != null)
		{
			list.Add(EnumInfos);
		}
		if (DataBlocks != null)
		{
			list.Add(DataBlocks);
		}
		if (Name != null)
		{
			list.Add(Name);
		}
		return list.ToArray();
	}
}
