using System;
using RageLib.Resources.Common;

namespace RageLib.Resources.GTA5.PC.Particles;

public class ShaderVarKeyframe : ShaderVar
{
	public uint Unknown_18h;

	public uint Unknown_1Ch;

	public uint Unknown_20h;

	public uint Unknown_24h;

	public ResourceSimpleList64<Unknown_P_001> Unknown_28h;

	public uint Unknown_38h;

	public uint Unknown_3Ch;

	public uint Unknown_40h;

	public uint Unknown_44h;

	public uint Unknown_48h;

	public uint Unknown_4Ch;

	public override long Length => 80L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		base.Read(reader, parameters);
		Unknown_18h = reader.ReadUInt32();
		Unknown_1Ch = reader.ReadUInt32();
		Unknown_20h = reader.ReadUInt32();
		Unknown_24h = reader.ReadUInt32();
		Unknown_28h = reader.ReadBlock<ResourceSimpleList64<Unknown_P_001>>(Array.Empty<object>());
		Unknown_38h = reader.ReadUInt32();
		Unknown_3Ch = reader.ReadUInt32();
		Unknown_40h = reader.ReadUInt32();
		Unknown_44h = reader.ReadUInt32();
		Unknown_48h = reader.ReadUInt32();
		Unknown_4Ch = reader.ReadUInt32();
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		base.Write(writer, parameters);
		writer.Write(Unknown_18h);
		writer.Write(Unknown_1Ch);
		writer.Write(Unknown_20h);
		writer.Write(Unknown_24h);
		writer.WriteBlock(Unknown_28h);
		writer.Write(Unknown_38h);
		writer.Write(Unknown_3Ch);
		writer.Write(Unknown_40h);
		writer.Write(Unknown_44h);
		writer.Write(Unknown_48h);
		writer.Write(Unknown_4Ch);
	}

	public override Tuple<long, IResourceBlock>[] GetParts()
	{
		return new Tuple<long, IResourceBlock>[1]
		{
			new Tuple<long, IResourceBlock>(40L, Unknown_28h)
		};
	}
}
