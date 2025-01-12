using System.Collections.Generic;
using RageLib.Resources.Common;

namespace RageLib.Resources.GTA5.PC.Nodes;

public class NodesFile : FileBase64_GTA5_pc
{
	public ulong NodesPointer;

	public uint NodesCount;

	public uint Unknown_1Ch;

	public uint Unknown_20h;

	public uint Unknown_24h;

	public ulong Unknown_28h_Pointer;

	public uint DataPointer1Length;

	public uint Unknown_34h;

	public ulong Unknown_38h_Pointer;

	public ulong Unknown_40h_Pointer;

	public uint Unknown_48h;

	public uint Unknown_4Ch;

	public ulong Unknown_50h_Pointer;

	public ushort cnt5a;

	public ushort cnt5b;

	public uint Unknown_5Ch;

	public uint len4;

	public uint len5;

	public uint Unknown_68h;

	public uint Unknown_6Ch;

	public ResourceSimpleArray<Node> Nodes;

	public ResourceSimpleArray<Unknown_ND_002> Unknown_28h_Data;

	public ResourceSimpleArray<Unknown_ND_003> Unknown_38h_Data;

	public ResourceSimpleArray<byte_r> Unknown_40h_Data;

	public ResourceSimpleArray<Unknown_ND_004> Unknown_50h_Data;

	public override long Length => 112L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		base.Read(reader, parameters);
		NodesPointer = reader.ReadUInt64();
		NodesCount = reader.ReadUInt32();
		Unknown_1Ch = reader.ReadUInt32();
		Unknown_20h = reader.ReadUInt32();
		Unknown_24h = reader.ReadUInt32();
		Unknown_28h_Pointer = reader.ReadUInt64();
		DataPointer1Length = reader.ReadUInt32();
		Unknown_34h = reader.ReadUInt32();
		Unknown_38h_Pointer = reader.ReadUInt64();
		Unknown_40h_Pointer = reader.ReadUInt64();
		Unknown_48h = reader.ReadUInt32();
		Unknown_4Ch = reader.ReadUInt32();
		Unknown_50h_Pointer = reader.ReadUInt64();
		cnt5a = reader.ReadUInt16();
		cnt5b = reader.ReadUInt16();
		Unknown_5Ch = reader.ReadUInt32();
		len4 = reader.ReadUInt32();
		len5 = reader.ReadUInt32();
		Unknown_68h = reader.ReadUInt32();
		Unknown_6Ch = reader.ReadUInt32();
		Nodes = reader.ReadBlockAt<ResourceSimpleArray<Node>>(NodesPointer, new object[1] { NodesCount });
		Unknown_28h_Data = reader.ReadBlockAt<ResourceSimpleArray<Unknown_ND_002>>(Unknown_28h_Pointer, new object[1] { DataPointer1Length });
		Unknown_38h_Data = reader.ReadBlockAt<ResourceSimpleArray<Unknown_ND_003>>(Unknown_38h_Pointer, new object[1] { len4 });
		Unknown_40h_Data = reader.ReadBlockAt<ResourceSimpleArray<byte_r>>(Unknown_40h_Pointer, new object[1] { len5 });
		Unknown_50h_Data = reader.ReadBlockAt<ResourceSimpleArray<Unknown_ND_004>>(Unknown_50h_Pointer, new object[1] { cnt5b });
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		base.Write(writer, parameters);
		NodesPointer = (ulong)((Nodes != null) ? Nodes.Position : 0);
		NodesCount = ((Nodes != null) ? ((uint)Nodes.Count) : 0u);
		Unknown_28h_Pointer = (ulong)((Unknown_28h_Data != null) ? Unknown_28h_Data.Position : 0);
		DataPointer1Length = ((Unknown_28h_Data != null) ? ((uint)Unknown_28h_Data.Count) : 0u);
		Unknown_38h_Pointer = (ulong)((Unknown_38h_Data != null) ? Unknown_38h_Data.Position : 0);
		Unknown_40h_Pointer = (ulong)((Unknown_40h_Data != null) ? Unknown_40h_Data.Position : 0);
		Unknown_50h_Pointer = (ulong)((Unknown_50h_Data != null) ? Unknown_50h_Data.Position : 0);
		cnt5a = (ushort)((Unknown_50h_Data != null) ? ((uint)Unknown_50h_Data.Count) : 0u);
		cnt5b = (ushort)((Unknown_50h_Data != null) ? ((uint)Unknown_50h_Data.Count) : 0u);
		len4 = ((Unknown_38h_Data != null) ? ((uint)Unknown_38h_Data.Count) : 0u);
		len5 = ((Unknown_40h_Data != null) ? ((uint)Unknown_40h_Data.Count) : 0u);
		writer.Write(NodesPointer);
		writer.Write(NodesCount);
		writer.Write(Unknown_1Ch);
		writer.Write(Unknown_20h);
		writer.Write(Unknown_24h);
		writer.Write(Unknown_28h_Pointer);
		writer.Write(DataPointer1Length);
		writer.Write(Unknown_34h);
		writer.Write(Unknown_38h_Pointer);
		writer.Write(Unknown_40h_Pointer);
		writer.Write(Unknown_48h);
		writer.Write(Unknown_4Ch);
		writer.Write(Unknown_50h_Pointer);
		writer.Write(cnt5a);
		writer.Write(cnt5b);
		writer.Write(Unknown_5Ch);
		writer.Write(len4);
		writer.Write(len5);
		writer.Write(Unknown_68h);
		writer.Write(Unknown_6Ch);
	}

	public override IResourceBlock[] GetReferences()
	{
		List<IResourceBlock> list = new List<IResourceBlock>(base.GetReferences());
		if (Nodes != null)
		{
			list.Add(Nodes);
		}
		if (Unknown_28h_Data != null)
		{
			list.Add(Unknown_28h_Data);
		}
		if (Unknown_38h_Data != null)
		{
			list.Add(Unknown_38h_Data);
		}
		if (Unknown_40h_Data != null)
		{
			list.Add(Unknown_40h_Data);
		}
		if (Unknown_50h_Data != null)
		{
			list.Add(Unknown_50h_Data);
		}
		return list.ToArray();
	}
}
