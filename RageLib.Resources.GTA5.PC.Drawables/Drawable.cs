using System;
using System.Collections.Generic;
using RageLib.Resources.Common;

namespace RageLib.Resources.GTA5.PC.Drawables;

public class Drawable : FileBase64_GTA5_pc
{
	public ulong ShaderGroupPointer;

	public ulong SkeletonPointer;

	public RAGE_Vector3 BoundingCenter;

	public float BoundingSphereRadius;

	public RAGE_Vector4 BoundingBoxMin;

	public RAGE_Vector4 BoundingBoxMax;

	public ulong DrawableModelsHighPointer;

	public ulong DrawableModelsMediumPointer;

	public ulong DrawableModelsLowPointer;

	public ulong DrawableModelsVeryLowPointer;

	public float Unknown_70h;

	public float Unknown_74h;

	public float Unknown_78h;

	public float Unknown_7Ch;

	public uint Unknown_80h;

	public uint Unknown_84h;

	public uint Unknown_88h;

	public uint Unknown_8Ch;

	public ulong JointsPointer;

	public uint Unknown_98h;

	public uint Unknown_9Ch;

	public ulong DrawableModelsXPointer;

	public ShaderGroup ShaderGroup;

	public SkeletonData Skeleton;

	public ResourcePointerList64<DrawableModel> DrawableModelsHigh;

	public ResourcePointerList64<DrawableModel> DrawableModelsMedium;

	public ResourcePointerList64<DrawableModel> DrawableModelsLow;

	public ResourcePointerList64<DrawableModel> DrawableModelsVeryLow;

	public Joints Joints;

	public ResourcePointerList64<DrawableModel> DrawableModelsX;

	public override long Length => 168L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		base.Read(reader, parameters);
		ShaderGroupPointer = reader.ReadUInt64();
		SkeletonPointer = reader.ReadUInt64();
		BoundingCenter = reader.ReadBlock<RAGE_Vector3>(Array.Empty<object>());
		BoundingSphereRadius = reader.ReadSingle();
		BoundingBoxMin = reader.ReadBlock<RAGE_Vector4>(Array.Empty<object>());
		BoundingBoxMax = reader.ReadBlock<RAGE_Vector4>(Array.Empty<object>());
		DrawableModelsHighPointer = reader.ReadUInt64();
		DrawableModelsMediumPointer = reader.ReadUInt64();
		DrawableModelsLowPointer = reader.ReadUInt64();
		DrawableModelsVeryLowPointer = reader.ReadUInt64();
		Unknown_70h = reader.ReadSingle();
		Unknown_74h = reader.ReadSingle();
		Unknown_78h = reader.ReadSingle();
		Unknown_7Ch = reader.ReadSingle();
		Unknown_80h = reader.ReadUInt32();
		Unknown_84h = reader.ReadUInt32();
		Unknown_88h = reader.ReadUInt32();
		Unknown_8Ch = reader.ReadUInt32();
		JointsPointer = reader.ReadUInt64();
		Unknown_98h = reader.ReadUInt32();
		Unknown_9Ch = reader.ReadUInt32();
		DrawableModelsXPointer = reader.ReadUInt64();
		ShaderGroup = reader.ReadBlockAt<ShaderGroup>(ShaderGroupPointer, Array.Empty<object>());
		Skeleton = reader.ReadBlockAt<SkeletonData>(SkeletonPointer, Array.Empty<object>());
		DrawableModelsHigh = reader.ReadBlockAt<ResourcePointerList64<DrawableModel>>(DrawableModelsHighPointer, Array.Empty<object>());
		DrawableModelsMedium = reader.ReadBlockAt<ResourcePointerList64<DrawableModel>>(DrawableModelsMediumPointer, Array.Empty<object>());
		DrawableModelsLow = reader.ReadBlockAt<ResourcePointerList64<DrawableModel>>(DrawableModelsLowPointer, Array.Empty<object>());
		DrawableModelsVeryLow = reader.ReadBlockAt<ResourcePointerList64<DrawableModel>>(DrawableModelsVeryLowPointer, Array.Empty<object>());
		Joints = reader.ReadBlockAt<Joints>(JointsPointer, Array.Empty<object>());
		DrawableModelsX = reader.ReadBlockAt<ResourcePointerList64<DrawableModel>>(DrawableModelsXPointer, Array.Empty<object>());
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		base.Write(writer, parameters);
		ShaderGroupPointer = (ulong)((ShaderGroup != null) ? ShaderGroup.Position : 0);
		SkeletonPointer = (ulong)((Skeleton != null) ? Skeleton.Position : 0);
		DrawableModelsHighPointer = (ulong)((DrawableModelsHigh != null) ? DrawableModelsHigh.Position : 0);
		DrawableModelsMediumPointer = (ulong)((DrawableModelsMedium != null) ? DrawableModelsMedium.Position : 0);
		DrawableModelsLowPointer = (ulong)((DrawableModelsLow != null) ? DrawableModelsLow.Position : 0);
		DrawableModelsVeryLowPointer = (ulong)((DrawableModelsVeryLow != null) ? DrawableModelsVeryLow.Position : 0);
		JointsPointer = (ulong)((Joints != null) ? Joints.Position : 0);
		DrawableModelsXPointer = (ulong)((DrawableModelsX != null) ? DrawableModelsX.Position : 0);
		writer.Write(ShaderGroupPointer);
		writer.Write(SkeletonPointer);
		writer.WriteBlock(BoundingCenter);
		writer.Write(BoundingSphereRadius);
		writer.WriteBlock(BoundingBoxMin);
		writer.WriteBlock(BoundingBoxMax);
		writer.Write(DrawableModelsHighPointer);
		writer.Write(DrawableModelsMediumPointer);
		writer.Write(DrawableModelsLowPointer);
		writer.Write(DrawableModelsVeryLowPointer);
		writer.Write(Unknown_70h);
		writer.Write(Unknown_74h);
		writer.Write(Unknown_78h);
		writer.Write(Unknown_7Ch);
		writer.Write(Unknown_80h);
		writer.Write(Unknown_84h);
		writer.Write(Unknown_88h);
		writer.Write(Unknown_8Ch);
		writer.Write(JointsPointer);
		writer.Write(Unknown_98h);
		writer.Write(Unknown_9Ch);
		writer.Write(DrawableModelsXPointer);
	}

	public override IResourceBlock[] GetReferences()
	{
		List<IResourceBlock> list = new List<IResourceBlock>(base.GetReferences());
		if (ShaderGroup != null)
		{
			list.Add(ShaderGroup);
		}
		if (Skeleton != null)
		{
			list.Add(Skeleton);
		}
		if (DrawableModelsHigh != null)
		{
			list.Add(DrawableModelsHigh);
		}
		if (DrawableModelsMedium != null)
		{
			list.Add(DrawableModelsMedium);
		}
		if (DrawableModelsLow != null)
		{
			list.Add(DrawableModelsLow);
		}
		if (DrawableModelsVeryLow != null)
		{
			list.Add(DrawableModelsVeryLow);
		}
		if (Joints != null)
		{
			list.Add(Joints);
		}
		if (DrawableModelsX != null)
		{
			list.Add(DrawableModelsX);
		}
		return list.ToArray();
	}
}
