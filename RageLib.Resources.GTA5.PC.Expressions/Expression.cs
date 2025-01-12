using System;
using System.Collections.Generic;
using RageLib.Resources.Common;

namespace RageLib.Resources.GTA5.PC.Expressions;

public class Expression : ResourceSystemBlock
{
	public uint VFT;

	public uint Unknown_4h;

	public uint Unknown_8h;

	public uint Unknown_Ch;

	public uint Unknown_10h;

	public uint Unknown_14h;

	public uint Unknown_18h;

	public uint Unknown_1Ch;

	public ResourcePointerList64<Unknown_E_001> Unknown_20h;

	public ResourceSimpleList64<uint_r> Unknown_30h;

	public ResourceSimpleList64<Unknown_E_002> Unknown_40h;

	public ResourceSimpleList64<uint_r> Unknown_50h;

	public ulong NamePointer;

	public uint Unknown_68h;

	public uint Unknown_6Ch;

	public uint Unknown_70h;

	public uint Unknown_74h;

	public ushort len;

	public ushort Unknown_7Ah;

	public uint Unknown_7Ch;

	public uint Unknown_80h;

	public uint Unknown_84h;

	public uint Unknown_88h;

	public uint Unknown_8Ch;

	public string_r Name;

	public override long Length => 144L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		VFT = reader.ReadUInt32();
		Unknown_4h = reader.ReadUInt32();
		Unknown_8h = reader.ReadUInt32();
		Unknown_Ch = reader.ReadUInt32();
		Unknown_10h = reader.ReadUInt32();
		Unknown_14h = reader.ReadUInt32();
		Unknown_18h = reader.ReadUInt32();
		Unknown_1Ch = reader.ReadUInt32();
		Unknown_20h = reader.ReadBlock<ResourcePointerList64<Unknown_E_001>>(Array.Empty<object>());
		Unknown_30h = reader.ReadBlock<ResourceSimpleList64<uint_r>>(Array.Empty<object>());
		Unknown_40h = reader.ReadBlock<ResourceSimpleList64<Unknown_E_002>>(Array.Empty<object>());
		Unknown_50h = reader.ReadBlock<ResourceSimpleList64<uint_r>>(Array.Empty<object>());
		NamePointer = reader.ReadUInt64();
		Unknown_68h = reader.ReadUInt32();
		Unknown_6Ch = reader.ReadUInt32();
		Unknown_70h = reader.ReadUInt32();
		Unknown_74h = reader.ReadUInt32();
		len = reader.ReadUInt16();
		Unknown_7Ah = reader.ReadUInt16();
		Unknown_7Ch = reader.ReadUInt32();
		Unknown_80h = reader.ReadUInt32();
		Unknown_84h = reader.ReadUInt32();
		Unknown_88h = reader.ReadUInt32();
		Unknown_8Ch = reader.ReadUInt32();
		Name = reader.ReadBlockAt<string_r>(NamePointer, Array.Empty<object>());
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		NamePointer = (ulong)((Name != null) ? Name.Position : 0);
		writer.Write(VFT);
		writer.Write(Unknown_4h);
		writer.Write(Unknown_8h);
		writer.Write(Unknown_Ch);
		writer.Write(Unknown_10h);
		writer.Write(Unknown_14h);
		writer.Write(Unknown_18h);
		writer.Write(Unknown_1Ch);
		writer.WriteBlock(Unknown_20h);
		writer.WriteBlock(Unknown_30h);
		writer.WriteBlock(Unknown_40h);
		writer.WriteBlock(Unknown_50h);
		writer.Write(NamePointer);
		writer.Write(Unknown_68h);
		writer.Write(Unknown_6Ch);
		writer.Write(Unknown_70h);
		writer.Write(Unknown_74h);
		writer.Write(len);
		writer.Write(Unknown_7Ah);
		writer.Write(Unknown_7Ch);
		writer.Write(Unknown_80h);
		writer.Write(Unknown_84h);
		writer.Write(Unknown_88h);
		writer.Write(Unknown_8Ch);
	}

	public override IResourceBlock[] GetReferences()
	{
		List<IResourceBlock> list = new List<IResourceBlock>();
		if (Name != null)
		{
			list.Add(Name);
		}
		return list.ToArray();
	}

	public override Tuple<long, IResourceBlock>[] GetParts()
	{
		return new Tuple<long, IResourceBlock>[4]
		{
			new Tuple<long, IResourceBlock>(32L, Unknown_20h),
			new Tuple<long, IResourceBlock>(48L, Unknown_30h),
			new Tuple<long, IResourceBlock>(64L, Unknown_40h),
			new Tuple<long, IResourceBlock>(80L, Unknown_50h)
		};
	}
}
