using System;
using System.Collections.Generic;

namespace RageLib.Resources;

public class FileBase64_GTA5_pc : ResourceSystemBlock
{
	public uint VFT;

	public uint Unknown_4h;

	public ulong PagesInfoPointer;

	public PagesInfo_GTA5_pc PagesInfo;

	public override long Length => 16L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		VFT = reader.ReadUInt32();
		Unknown_4h = reader.ReadUInt32();
		PagesInfoPointer = reader.ReadUInt64();
		PagesInfo = reader.ReadBlockAt<PagesInfo_GTA5_pc>(PagesInfoPointer, Array.Empty<object>());
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		PagesInfoPointer = (ulong)((PagesInfo != null) ? PagesInfo.Position : 0);
		writer.Write(VFT);
		writer.Write(Unknown_4h);
		writer.Write(PagesInfoPointer);
	}

	public override IResourceBlock[] GetReferences()
	{
		List<IResourceBlock> list = new List<IResourceBlock>();
		if (PagesInfo != null)
		{
			list.Add(PagesInfo);
		}
		return list.ToArray();
	}
}
