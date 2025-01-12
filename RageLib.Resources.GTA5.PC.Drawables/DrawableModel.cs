using System.Collections.Generic;
using RageLib.Resources.Common;

namespace RageLib.Resources.GTA5.PC.Drawables;

public class DrawableModel : ResourceSystemBlock
{
	public uint VFT;

	public uint Unknown_4h;

	public ulong GeometriesPointer;

	public ushort GeometriesCount1;

	public ushort GeometriesCount2;

	public uint Unknown_14h;

	public ulong Unknown_18h_Pointer;

	public ulong ShaderMappingPointer;

	public uint Unknown_28h;

	public uint Unknown_2Ch;

	public ResourcePointerArray64<DrawableGeometry> Geometries;

	public ResourceSimpleArray<RAGE_AABB> Unknown_18h_Data;

	public ResourceSimpleArray<ushort_r> ShaderMapping;

	public override long Length => 48L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		VFT = reader.ReadUInt32();
		Unknown_4h = reader.ReadUInt32();
		GeometriesPointer = reader.ReadUInt64();
		GeometriesCount1 = reader.ReadUInt16();
		GeometriesCount2 = reader.ReadUInt16();
		Unknown_14h = reader.ReadUInt32();
		Unknown_18h_Pointer = reader.ReadUInt64();
		ShaderMappingPointer = reader.ReadUInt64();
		Unknown_28h = reader.ReadUInt32();
		Unknown_2Ch = reader.ReadUInt32();
		Geometries = reader.ReadBlockAt<ResourcePointerArray64<DrawableGeometry>>(GeometriesPointer, new object[1] { GeometriesCount1 });
		Unknown_18h_Data = reader.ReadBlockAt<ResourceSimpleArray<RAGE_AABB>>(Unknown_18h_Pointer, new object[1] { (GeometriesCount1 > 1) ? (GeometriesCount1 + 1) : GeometriesCount1 });
		ShaderMapping = reader.ReadBlockAt<ResourceSimpleArray<ushort_r>>(ShaderMappingPointer, new object[1] { GeometriesCount1 });
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		GeometriesPointer = (ulong)((Geometries != null) ? Geometries.Position : 0);
		Unknown_18h_Pointer = (ulong)((Unknown_18h_Data != null) ? Unknown_18h_Data.Position : 0);
		ShaderMappingPointer = (ulong)((ShaderMapping != null) ? ShaderMapping.Position : 0);
		writer.Write(VFT);
		writer.Write(Unknown_4h);
		writer.Write(GeometriesPointer);
		writer.Write(GeometriesCount1);
		writer.Write(GeometriesCount2);
		writer.Write(Unknown_14h);
		writer.Write(Unknown_18h_Pointer);
		writer.Write(ShaderMappingPointer);
		writer.Write(Unknown_28h);
		writer.Write(Unknown_2Ch);
	}

	public override IResourceBlock[] GetReferences()
	{
		List<IResourceBlock> list = new List<IResourceBlock>();
		if (Geometries != null)
		{
			list.Add(Geometries);
		}
		if (Unknown_18h_Data != null)
		{
			list.Add(Unknown_18h_Data);
		}
		if (ShaderMapping != null)
		{
			list.Add(ShaderMapping);
		}
		return list.ToArray();
	}
}
