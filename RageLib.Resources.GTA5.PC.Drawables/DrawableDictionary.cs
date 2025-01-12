using System;
using RageLib.Resources.Common;

namespace RageLib.Resources.GTA5.PC.Drawables;

public class DrawableDictionary : FileBase64_GTA5_pc
{
	public uint Unknown_10h;

	public uint Unknown_14h;

	public uint Unknown_18h;

	public uint Unknown_1Ch;

	public ResourceSimpleList64<uint_r> Hashes;

	public ResourcePointerList64<Drawable> Drawables;

	public override long Length => 64L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		base.Read(reader, parameters);
		Unknown_10h = reader.ReadUInt32();
		Unknown_14h = reader.ReadUInt32();
		Unknown_18h = reader.ReadUInt32();
		Unknown_1Ch = reader.ReadUInt32();
		Hashes = reader.ReadBlock<ResourceSimpleList64<uint_r>>(Array.Empty<object>());
		Drawables = reader.ReadBlock<ResourcePointerList64<Drawable>>(Array.Empty<object>());
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		base.Write(writer, parameters);
		writer.Write(Unknown_10h);
		writer.Write(Unknown_14h);
		writer.Write(Unknown_18h);
		writer.Write(Unknown_1Ch);
		writer.WriteBlock(Hashes);
		writer.WriteBlock(Drawables);
	}

	public override Tuple<long, IResourceBlock>[] GetParts()
	{
		return new Tuple<long, IResourceBlock>[2]
		{
			new Tuple<long, IResourceBlock>(32L, Hashes),
			new Tuple<long, IResourceBlock>(48L, Drawables)
		};
	}
}
