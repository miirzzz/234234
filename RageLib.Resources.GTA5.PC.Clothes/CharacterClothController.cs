using System;
using RageLib.Resources.Common;

namespace RageLib.Resources.GTA5.PC.Clothes;

public class CharacterClothController : ClothController
{
	public ResourceSimpleList64<ushort_r> Unknown_80h;

	public ResourceSimpleList64<Unknown_C_002> Unknown_90h;

	public uint Unknown_A0h;

	public uint Unknown_A4h;

	public uint Unknown_A8h;

	public uint Unknown_ACh;

	public ResourceSimpleList64<uint_r> Unknown_B0h;

	public ResourceSimpleList64<Unknown_C_003> Unknown_C0h;

	public uint Unknown_D0h;

	public uint Unknown_D4h;

	public uint Unknown_D8h;

	public uint Unknown_DCh;

	public ResourceSimpleList64<uint_r> Unknown_E0h;

	public override long Length => 240L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		base.Read(reader, parameters);
		Unknown_80h = reader.ReadBlock<ResourceSimpleList64<ushort_r>>(Array.Empty<object>());
		Unknown_90h = reader.ReadBlock<ResourceSimpleList64<Unknown_C_002>>(Array.Empty<object>());
		Unknown_A0h = reader.ReadUInt32();
		Unknown_A4h = reader.ReadUInt32();
		Unknown_A8h = reader.ReadUInt32();
		Unknown_ACh = reader.ReadUInt32();
		Unknown_B0h = reader.ReadBlock<ResourceSimpleList64<uint_r>>(Array.Empty<object>());
		Unknown_C0h = reader.ReadBlock<ResourceSimpleList64<Unknown_C_003>>(Array.Empty<object>());
		Unknown_D0h = reader.ReadUInt32();
		Unknown_D4h = reader.ReadUInt32();
		Unknown_D8h = reader.ReadUInt32();
		Unknown_DCh = reader.ReadUInt32();
		Unknown_E0h = reader.ReadBlock<ResourceSimpleList64<uint_r>>(Array.Empty<object>());
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		base.Write(writer, parameters);
		writer.WriteBlock(Unknown_80h);
		writer.WriteBlock(Unknown_90h);
		writer.Write(Unknown_A0h);
		writer.Write(Unknown_A4h);
		writer.Write(Unknown_A8h);
		writer.Write(Unknown_ACh);
		writer.WriteBlock(Unknown_B0h);
		writer.WriteBlock(Unknown_C0h);
		writer.Write(Unknown_D0h);
		writer.Write(Unknown_D4h);
		writer.Write(Unknown_D8h);
		writer.Write(Unknown_DCh);
		writer.WriteBlock(Unknown_E0h);
	}

	public override Tuple<long, IResourceBlock>[] GetParts()
	{
		return new Tuple<long, IResourceBlock>[5]
		{
			new Tuple<long, IResourceBlock>(128L, Unknown_80h),
			new Tuple<long, IResourceBlock>(144L, Unknown_90h),
			new Tuple<long, IResourceBlock>(176L, Unknown_B0h),
			new Tuple<long, IResourceBlock>(192L, Unknown_C0h),
			new Tuple<long, IResourceBlock>(224L, Unknown_E0h)
		};
	}
}
