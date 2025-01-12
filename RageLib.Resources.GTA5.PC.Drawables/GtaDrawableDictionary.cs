using System.Collections.Generic;
using RageLib.Resources.Common;

namespace RageLib.Resources.GTA5.PC.Drawables;

public class GtaDrawableDictionary : FileBase64_GTA5_pc
{
	public uint Unknown_10h;

	public uint Unknown_14h;

	public uint Unknown_18h;

	public uint Unknown_1Ch;

	public ulong HashesPointer;

	public ushort HashesCount1;

	public ushort HashesCount2;

	public uint Unknown_2Ch;

	public ulong DrawablesPointer;

	public ushort DrawablesCount1;

	public ushort DrawablesCount2;

	public uint Unknown_3Ch;

	public ResourceSimpleArray<uint_r> Hashes;

	public ResourcePointerArray64<GtaDrawable> Drawables;

	public override long Length => 64L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		base.Read(reader, parameters);
		Unknown_10h = reader.ReadUInt32();
		Unknown_14h = reader.ReadUInt32();
		Unknown_18h = reader.ReadUInt32();
		Unknown_1Ch = reader.ReadUInt32();
		HashesPointer = reader.ReadUInt64();
		HashesCount1 = reader.ReadUInt16();
		HashesCount2 = reader.ReadUInt16();
		Unknown_2Ch = reader.ReadUInt32();
		DrawablesPointer = reader.ReadUInt64();
		DrawablesCount1 = reader.ReadUInt16();
		DrawablesCount2 = reader.ReadUInt16();
		Unknown_3Ch = reader.ReadUInt32();
		Hashes = reader.ReadBlockAt<ResourceSimpleArray<uint_r>>(HashesPointer, new object[1] { HashesCount1 });
		Drawables = reader.ReadBlockAt<ResourcePointerArray64<GtaDrawable>>(DrawablesPointer, new object[1] { DrawablesCount1 });
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		base.Write(writer, parameters);
		HashesPointer = (ulong)((Hashes != null) ? Hashes.Position : 0);
		DrawablesPointer = (ulong)((Drawables != null) ? Drawables.Position : 0);
		writer.Write(Unknown_10h);
		writer.Write(Unknown_14h);
		writer.Write(Unknown_18h);
		writer.Write(Unknown_1Ch);
		writer.Write(HashesPointer);
		writer.Write(HashesCount1);
		writer.Write(HashesCount2);
		writer.Write(Unknown_2Ch);
		writer.Write(DrawablesPointer);
		writer.Write(DrawablesCount1);
		writer.Write(DrawablesCount2);
		writer.Write(Unknown_3Ch);
	}

	public override IResourceBlock[] GetReferences()
	{
		List<IResourceBlock> list = new List<IResourceBlock>(base.GetReferences());
		if (Hashes != null)
		{
			list.Add(Hashes);
		}
		if (Drawables != null)
		{
			list.Add(Drawables);
		}
		return list.ToArray();
	}
}
