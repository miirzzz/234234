using System;
using System.Collections.Generic;
using RageLib.Resources.Common;

namespace RageLib.Resources.GTA5.PC.Navigations;

public class Navigation : FileBase64_GTA5_pc
{
	public uint Unknown_10h;

	public uint Unknown_14h;

	public uint Unknown_18h;

	public uint Unknown_1Ch;

	public uint Unknown_20h;

	public uint Unknown_24h;

	public uint Unknown_28h;

	public uint Unknown_2Ch;

	public uint Unknown_30h;

	public uint Unknown_34h;

	public uint Unknown_38h;

	public uint Unknown_3Ch;

	public uint Unknown_40h;

	public uint Unknown_44h;

	public uint Unknown_48h;

	public uint Unknown_4Ch;

	public uint Unknown_50h;

	public uint Unknown_54h;

	public uint Unknown_58h;

	public uint Unknown_5Ch;

	public uint Unknown_60h;

	public uint Unknown_64h;

	public uint Unknown_68h;

	public uint Unknown_6Ch;

	public ulong VerticesPointer;

	public uint Unknown_78h;

	public uint Unknown_7Ch;

	public ulong IndicesPointer;

	public ulong p4;

	public uint Unknown_90h;

	public uint Unknown_94h;

	public uint Unknown_98h;

	public uint Unknown_9Ch;

	public uint Unknown_A0h;

	public uint Unknown_A4h;

	public uint Unknown_A8h;

	public uint Unknown_ACh;

	public uint Unknown_B0h;

	public uint Unknown_B4h;

	public uint Unknown_B8h;

	public uint Unknown_BCh;

	public uint Unknown_C0h;

	public uint Unknown_C4h;

	public uint Unknown_C8h;

	public uint Unknown_CCh;

	public uint Unknown_D0h;

	public uint Unknown_D4h;

	public uint Unknown_D8h;

	public uint Unknown_DCh;

	public uint Unknown_E0h;

	public uint Unknown_E4h;

	public uint Unknown_E8h;

	public uint Unknown_ECh;

	public uint Unknown_F0h;

	public uint Unknown_F4h;

	public uint Unknown_F8h;

	public uint Unknown_FCh;

	public uint Unknown_100h;

	public uint Unknown_104h;

	public uint Unknown_108h;

	public uint Unknown_10Ch;

	public uint Unknown_110h;

	public uint Unknown_114h;

	public ulong p5;

	public ulong SectorTreePointer;

	public ulong PortalsPointer;

	public ulong p8;

	public uint Unknown_138h;

	public uint Unknown_13Ch;

	public uint Unknown_140h;

	public uint Unknown_144h;

	public uint Unknown_148h;

	public uint PortalsCount;

	public uint c1;

	public uint Unknown_154h;

	public uint Unknown_158h;

	public uint Unknown_15Ch;

	public uint Unknown_160h;

	public uint Unknown_164h;

	public uint Unknown_168h;

	public uint Unknown_16Ch;

	public VerticesList Vertices;

	public IndicesList Indices;

	public AdjPolysList AdjPolys;

	public PolysList Polys;

	public Sector SectorTree;

	public ResourceSimpleArray<Portal> Portals;

	public ResourceSimpleArray<ushort_r> p8data;

	public override long Length => 368L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		base.Read(reader, parameters);
		Unknown_10h = reader.ReadUInt32();
		Unknown_14h = reader.ReadUInt32();
		Unknown_18h = reader.ReadUInt32();
		Unknown_1Ch = reader.ReadUInt32();
		Unknown_20h = reader.ReadUInt32();
		Unknown_24h = reader.ReadUInt32();
		Unknown_28h = reader.ReadUInt32();
		Unknown_2Ch = reader.ReadUInt32();
		Unknown_30h = reader.ReadUInt32();
		Unknown_34h = reader.ReadUInt32();
		Unknown_38h = reader.ReadUInt32();
		Unknown_3Ch = reader.ReadUInt32();
		Unknown_40h = reader.ReadUInt32();
		Unknown_44h = reader.ReadUInt32();
		Unknown_48h = reader.ReadUInt32();
		Unknown_4Ch = reader.ReadUInt32();
		Unknown_50h = reader.ReadUInt32();
		Unknown_54h = reader.ReadUInt32();
		Unknown_58h = reader.ReadUInt32();
		Unknown_5Ch = reader.ReadUInt32();
		Unknown_60h = reader.ReadUInt32();
		Unknown_64h = reader.ReadUInt32();
		Unknown_68h = reader.ReadUInt32();
		Unknown_6Ch = reader.ReadUInt32();
		VerticesPointer = reader.ReadUInt64();
		Unknown_78h = reader.ReadUInt32();
		Unknown_7Ch = reader.ReadUInt32();
		IndicesPointer = reader.ReadUInt64();
		p4 = reader.ReadUInt64();
		Unknown_90h = reader.ReadUInt32();
		Unknown_94h = reader.ReadUInt32();
		Unknown_98h = reader.ReadUInt32();
		Unknown_9Ch = reader.ReadUInt32();
		Unknown_A0h = reader.ReadUInt32();
		Unknown_A4h = reader.ReadUInt32();
		Unknown_A8h = reader.ReadUInt32();
		Unknown_ACh = reader.ReadUInt32();
		Unknown_B0h = reader.ReadUInt32();
		Unknown_B4h = reader.ReadUInt32();
		Unknown_B8h = reader.ReadUInt32();
		Unknown_BCh = reader.ReadUInt32();
		Unknown_C0h = reader.ReadUInt32();
		Unknown_C4h = reader.ReadUInt32();
		Unknown_C8h = reader.ReadUInt32();
		Unknown_CCh = reader.ReadUInt32();
		Unknown_D0h = reader.ReadUInt32();
		Unknown_D4h = reader.ReadUInt32();
		Unknown_D8h = reader.ReadUInt32();
		Unknown_DCh = reader.ReadUInt32();
		Unknown_E0h = reader.ReadUInt32();
		Unknown_E4h = reader.ReadUInt32();
		Unknown_E8h = reader.ReadUInt32();
		Unknown_ECh = reader.ReadUInt32();
		Unknown_F0h = reader.ReadUInt32();
		Unknown_F4h = reader.ReadUInt32();
		Unknown_F8h = reader.ReadUInt32();
		Unknown_FCh = reader.ReadUInt32();
		Unknown_100h = reader.ReadUInt32();
		Unknown_104h = reader.ReadUInt32();
		Unknown_108h = reader.ReadUInt32();
		Unknown_10Ch = reader.ReadUInt32();
		Unknown_110h = reader.ReadUInt32();
		Unknown_114h = reader.ReadUInt32();
		p5 = reader.ReadUInt64();
		SectorTreePointer = reader.ReadUInt64();
		PortalsPointer = reader.ReadUInt64();
		p8 = reader.ReadUInt64();
		Unknown_138h = reader.ReadUInt32();
		Unknown_13Ch = reader.ReadUInt32();
		Unknown_140h = reader.ReadUInt32();
		Unknown_144h = reader.ReadUInt32();
		Unknown_148h = reader.ReadUInt32();
		PortalsCount = reader.ReadUInt32();
		c1 = reader.ReadUInt32();
		Unknown_154h = reader.ReadUInt32();
		Unknown_158h = reader.ReadUInt32();
		Unknown_15Ch = reader.ReadUInt32();
		Unknown_160h = reader.ReadUInt32();
		Unknown_164h = reader.ReadUInt32();
		Unknown_168h = reader.ReadUInt32();
		Unknown_16Ch = reader.ReadUInt32();
		Vertices = reader.ReadBlockAt<VerticesList>(VerticesPointer, Array.Empty<object>());
		Indices = reader.ReadBlockAt<IndicesList>(IndicesPointer, Array.Empty<object>());
		AdjPolys = reader.ReadBlockAt<AdjPolysList>(p4, Array.Empty<object>());
		Polys = reader.ReadBlockAt<PolysList>(p5, Array.Empty<object>());
		SectorTree = reader.ReadBlockAt<Sector>(SectorTreePointer, Array.Empty<object>());
		Portals = reader.ReadBlockAt<ResourceSimpleArray<Portal>>(PortalsPointer, new object[1] { PortalsCount });
		p8data = reader.ReadBlockAt<ResourceSimpleArray<ushort_r>>(p8, new object[1] { c1 });
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		base.Write(writer, parameters);
		VerticesPointer = (ulong)((Vertices != null) ? Vertices.Position : 0);
		IndicesPointer = (ulong)((Indices != null) ? Indices.Position : 0);
		p4 = (ulong)((AdjPolys != null) ? AdjPolys.Position : 0);
		p5 = (ulong)((Polys != null) ? Polys.Position : 0);
		SectorTreePointer = (ulong)((SectorTree != null) ? SectorTree.Position : 0);
		PortalsPointer = (ulong)((Portals != null) ? Portals.Position : 0);
		p8 = (ulong)((p8data != null) ? p8data.Position : 0);
		writer.Write(Unknown_10h);
		writer.Write(Unknown_14h);
		writer.Write(Unknown_18h);
		writer.Write(Unknown_1Ch);
		writer.Write(Unknown_20h);
		writer.Write(Unknown_24h);
		writer.Write(Unknown_28h);
		writer.Write(Unknown_2Ch);
		writer.Write(Unknown_30h);
		writer.Write(Unknown_34h);
		writer.Write(Unknown_38h);
		writer.Write(Unknown_3Ch);
		writer.Write(Unknown_40h);
		writer.Write(Unknown_44h);
		writer.Write(Unknown_48h);
		writer.Write(Unknown_4Ch);
		writer.Write(Unknown_50h);
		writer.Write(Unknown_54h);
		writer.Write(Unknown_58h);
		writer.Write(Unknown_5Ch);
		writer.Write(Unknown_60h);
		writer.Write(Unknown_64h);
		writer.Write(Unknown_68h);
		writer.Write(Unknown_6Ch);
		writer.Write(VerticesPointer);
		writer.Write(Unknown_78h);
		writer.Write(Unknown_7Ch);
		writer.Write(IndicesPointer);
		writer.Write(p4);
		writer.Write(Unknown_90h);
		writer.Write(Unknown_94h);
		writer.Write(Unknown_98h);
		writer.Write(Unknown_9Ch);
		writer.Write(Unknown_A0h);
		writer.Write(Unknown_A4h);
		writer.Write(Unknown_A8h);
		writer.Write(Unknown_ACh);
		writer.Write(Unknown_B0h);
		writer.Write(Unknown_B4h);
		writer.Write(Unknown_B8h);
		writer.Write(Unknown_BCh);
		writer.Write(Unknown_C0h);
		writer.Write(Unknown_C4h);
		writer.Write(Unknown_C8h);
		writer.Write(Unknown_CCh);
		writer.Write(Unknown_D0h);
		writer.Write(Unknown_D4h);
		writer.Write(Unknown_D8h);
		writer.Write(Unknown_DCh);
		writer.Write(Unknown_E0h);
		writer.Write(Unknown_E4h);
		writer.Write(Unknown_E8h);
		writer.Write(Unknown_ECh);
		writer.Write(Unknown_F0h);
		writer.Write(Unknown_F4h);
		writer.Write(Unknown_F8h);
		writer.Write(Unknown_FCh);
		writer.Write(Unknown_100h);
		writer.Write(Unknown_104h);
		writer.Write(Unknown_108h);
		writer.Write(Unknown_10Ch);
		writer.Write(Unknown_110h);
		writer.Write(Unknown_114h);
		writer.Write(p5);
		writer.Write(SectorTreePointer);
		writer.Write(PortalsPointer);
		writer.Write(p8);
		writer.Write(Unknown_138h);
		writer.Write(Unknown_13Ch);
		writer.Write(Unknown_140h);
		writer.Write(Unknown_144h);
		writer.Write(Unknown_148h);
		writer.Write(PortalsCount);
		writer.Write(c1);
		writer.Write(Unknown_154h);
		writer.Write(Unknown_158h);
		writer.Write(Unknown_15Ch);
		writer.Write(Unknown_160h);
		writer.Write(Unknown_164h);
		writer.Write(Unknown_168h);
		writer.Write(Unknown_16Ch);
	}

	public override IResourceBlock[] GetReferences()
	{
		List<IResourceBlock> list = new List<IResourceBlock>(base.GetReferences());
		if (Vertices != null)
		{
			list.Add(Vertices);
		}
		if (Indices != null)
		{
			list.Add(Indices);
		}
		if (AdjPolys != null)
		{
			list.Add(AdjPolys);
		}
		if (Polys != null)
		{
			list.Add(Polys);
		}
		if (SectorTree != null)
		{
			list.Add(SectorTree);
		}
		if (Portals != null)
		{
			list.Add(Portals);
		}
		if (p8data != null)
		{
			list.Add(p8data);
		}
		return list.ToArray();
	}
}
