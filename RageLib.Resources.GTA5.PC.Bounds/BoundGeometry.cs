using System.Collections.Generic;
using RageLib.Resources.Common;

namespace RageLib.Resources.GTA5.PC.Bounds;

public class BoundGeometry : Bound
{
	public uint Unknown_70h;

	public uint Unknown_74h;

	public ulong Unknown_78h_Pointer;

	public uint Unknown_80h;

	public uint VerticesCount1;

	public ulong PolygonsPointer;

	public uint Unknown_90h;

	public uint Unknown_94h;

	public uint Unknown_98h;

	public uint Unknown_9Ch;

	public float Unknown_A0h;

	public float Unknown_A4h;

	public float Unknown_A8h;

	public float Unknown_ACh;

	public ulong VerticesPointer;

	public ulong Unknown_B8h_Pointer;

	public ulong Unknown_C0h_Pointer;

	public ulong Unknown_C8h_Pointer;

	public uint VerticesCount2;

	public uint PolygonsCount;

	public uint Unknown_D8h;

	public uint Unknown_DCh;

	public uint Unknown_E0h;

	public uint Unknown_E4h;

	public uint Unknown_E8h;

	public uint Unknown_ECh;

	public ulong MaterialsPointer;

	public ulong MaterialColoursPointer;

	public uint Unknown_100h;

	public uint Unknown_104h;

	public uint Unknown_108h;

	public uint Unknown_10Ch;

	public uint Unknown_110h;

	public uint Unknown_114h;

	public ulong PolygonMaterialIndicesPointer;

	public byte MaterialsCount;

	public byte MaterialColoursCount;

	public ushort Unknown_122h;

	public uint Unknown_124h;

	public uint Unknown_128h;

	public uint Unknown_12Ch;

	public ResourceSimpleArray<BoundVertex> Unknown_78h_Data;

	public ResourceSimpleArray<BoundPolygon> Polygons;

	public ResourceSimpleArray<BoundVertex> Vertices;

	public ResourceSimpleArray<uint_r> Unknown_B8h_Data;

	public ResourceSimpleArray<uint_r> Unknown_C0h_Data;

	public ResourceSimpleArrayArray64<uint_r> Unknown_C8h_Data;

	public ResourceSimpleArray<BoundMaterial> Materials;

	public ResourceSimpleArray<uint_r> MaterialColours;

	public ResourceSimpleArray<byte_r> PolygonMaterialIndices;

	public override long Length => 304L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		base.Read(reader, parameters);
		Unknown_70h = reader.ReadUInt32();
		Unknown_74h = reader.ReadUInt32();
		Unknown_78h_Pointer = reader.ReadUInt64();
		Unknown_80h = reader.ReadUInt32();
		VerticesCount1 = reader.ReadUInt32();
		PolygonsPointer = reader.ReadUInt64();
		Unknown_90h = reader.ReadUInt32();
		Unknown_94h = reader.ReadUInt32();
		Unknown_98h = reader.ReadUInt32();
		Unknown_9Ch = reader.ReadUInt32();
		Unknown_A0h = reader.ReadSingle();
		Unknown_A4h = reader.ReadSingle();
		Unknown_A8h = reader.ReadSingle();
		Unknown_ACh = reader.ReadSingle();
		VerticesPointer = reader.ReadUInt64();
		Unknown_B8h_Pointer = reader.ReadUInt64();
		Unknown_C0h_Pointer = reader.ReadUInt64();
		Unknown_C8h_Pointer = reader.ReadUInt64();
		VerticesCount2 = reader.ReadUInt32();
		PolygonsCount = reader.ReadUInt32();
		Unknown_D8h = reader.ReadUInt32();
		Unknown_DCh = reader.ReadUInt32();
		Unknown_E0h = reader.ReadUInt32();
		Unknown_E4h = reader.ReadUInt32();
		Unknown_E8h = reader.ReadUInt32();
		Unknown_ECh = reader.ReadUInt32();
		MaterialsPointer = reader.ReadUInt64();
		MaterialColoursPointer = reader.ReadUInt64();
		Unknown_100h = reader.ReadUInt32();
		Unknown_104h = reader.ReadUInt32();
		Unknown_108h = reader.ReadUInt32();
		Unknown_10Ch = reader.ReadUInt32();
		Unknown_110h = reader.ReadUInt32();
		Unknown_114h = reader.ReadUInt32();
		PolygonMaterialIndicesPointer = reader.ReadUInt64();
		MaterialsCount = reader.ReadByte();
		MaterialColoursCount = reader.ReadByte();
		Unknown_122h = reader.ReadUInt16();
		Unknown_124h = reader.ReadUInt32();
		Unknown_128h = reader.ReadUInt32();
		Unknown_12Ch = reader.ReadUInt32();
		Unknown_78h_Data = reader.ReadBlockAt<ResourceSimpleArray<BoundVertex>>(Unknown_78h_Pointer, new object[1] { VerticesCount2 });
		Polygons = reader.ReadBlockAt<ResourceSimpleArray<BoundPolygon>>(PolygonsPointer, new object[1] { PolygonsCount });
		Vertices = reader.ReadBlockAt<ResourceSimpleArray<BoundVertex>>(VerticesPointer, new object[1] { VerticesCount2 });
		Unknown_B8h_Data = reader.ReadBlockAt<ResourceSimpleArray<uint_r>>(Unknown_B8h_Pointer, new object[1] { VerticesCount2 });
		Unknown_C0h_Data = reader.ReadBlockAt<ResourceSimpleArray<uint_r>>(Unknown_C0h_Pointer, new object[1] { 8 });
		Unknown_C8h_Data = reader.ReadBlockAt<ResourceSimpleArrayArray64<uint_r>>(Unknown_C8h_Pointer, new object[2] { 8, Unknown_C0h_Data });
		Materials = reader.ReadBlockAt<ResourceSimpleArray<BoundMaterial>>(MaterialsPointer, new object[1] { MaterialsCount });
		MaterialColours = reader.ReadBlockAt<ResourceSimpleArray<uint_r>>(MaterialColoursPointer, new object[1] { MaterialColoursCount });
		PolygonMaterialIndices = reader.ReadBlockAt<ResourceSimpleArray<byte_r>>(PolygonMaterialIndicesPointer, new object[1] { PolygonsCount });
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		base.Write(writer, parameters);
		Unknown_78h_Pointer = (ulong)((Unknown_78h_Data != null) ? Unknown_78h_Data.Position : 0);
		VerticesCount1 = ((Vertices != null) ? ((uint)Vertices.Count) : 0u);
		PolygonsPointer = (ulong)((Polygons != null) ? Polygons.Position : 0);
		VerticesPointer = (ulong)((Vertices != null) ? Vertices.Position : 0);
		Unknown_B8h_Pointer = (ulong)((Unknown_B8h_Data != null) ? Unknown_B8h_Data.Position : 0);
		Unknown_C0h_Pointer = (ulong)((Unknown_C0h_Data != null) ? Unknown_C0h_Data.Position : 0);
		Unknown_C8h_Pointer = (ulong)((Unknown_C8h_Data != null) ? Unknown_C8h_Data.Position : 0);
		VerticesCount2 = ((Vertices != null) ? ((uint)Vertices.Count) : 0u);
		PolygonsCount = ((Polygons != null) ? ((uint)Polygons.Count) : 0u);
		MaterialsPointer = (ulong)((Materials != null) ? Materials.Position : 0);
		MaterialColoursPointer = (ulong)((MaterialColours != null) ? MaterialColours.Position : 0);
		PolygonMaterialIndicesPointer = (ulong)((PolygonMaterialIndices != null) ? PolygonMaterialIndices.Position : 0);
		MaterialsCount = (byte)((Materials != null) ? ((uint)Materials.Count) : 0u);
		MaterialColoursCount = (byte)((MaterialColours != null) ? ((uint)MaterialColours.Count) : 0u);
		writer.Write(Unknown_70h);
		writer.Write(Unknown_74h);
		writer.Write(Unknown_78h_Pointer);
		writer.Write(Unknown_80h);
		writer.Write(VerticesCount1);
		writer.Write(PolygonsPointer);
		writer.Write(Unknown_90h);
		writer.Write(Unknown_94h);
		writer.Write(Unknown_98h);
		writer.Write(Unknown_9Ch);
		writer.Write(Unknown_A0h);
		writer.Write(Unknown_A4h);
		writer.Write(Unknown_A8h);
		writer.Write(Unknown_ACh);
		writer.Write(VerticesPointer);
		writer.Write(Unknown_B8h_Pointer);
		writer.Write(Unknown_C0h_Pointer);
		writer.Write(Unknown_C8h_Pointer);
		writer.Write(VerticesCount2);
		writer.Write(PolygonsCount);
		writer.Write(Unknown_D8h);
		writer.Write(Unknown_DCh);
		writer.Write(Unknown_E0h);
		writer.Write(Unknown_E4h);
		writer.Write(Unknown_E8h);
		writer.Write(Unknown_ECh);
		writer.Write(MaterialsPointer);
		writer.Write(MaterialColoursPointer);
		writer.Write(Unknown_100h);
		writer.Write(Unknown_104h);
		writer.Write(Unknown_108h);
		writer.Write(Unknown_10Ch);
		writer.Write(Unknown_110h);
		writer.Write(Unknown_114h);
		writer.Write(PolygonMaterialIndicesPointer);
		writer.Write(MaterialsCount);
		writer.Write(MaterialColoursCount);
		writer.Write(Unknown_122h);
		writer.Write(Unknown_124h);
		writer.Write(Unknown_128h);
		writer.Write(Unknown_12Ch);
	}

	public override IResourceBlock[] GetReferences()
	{
		List<IResourceBlock> list = new List<IResourceBlock>(base.GetReferences());
		if (Unknown_78h_Data != null)
		{
			list.Add(Unknown_78h_Data);
		}
		if (Polygons != null)
		{
			list.Add(Polygons);
		}
		if (Vertices != null)
		{
			list.Add(Vertices);
		}
		if (Unknown_B8h_Data != null)
		{
			list.Add(Unknown_B8h_Data);
		}
		if (Unknown_C0h_Data != null)
		{
			list.Add(Unknown_C0h_Data);
		}
		if (Unknown_C8h_Data != null)
		{
			list.Add(Unknown_C8h_Data);
		}
		if (Materials != null)
		{
			list.Add(Materials);
		}
		if (MaterialColours != null)
		{
			list.Add(MaterialColours);
		}
		if (PolygonMaterialIndices != null)
		{
			list.Add(PolygonMaterialIndices);
		}
		return list.ToArray();
	}
}
