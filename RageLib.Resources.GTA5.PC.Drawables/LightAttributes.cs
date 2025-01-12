namespace RageLib.Resources.GTA5.PC.Drawables;

public class LightAttributes : ResourceSystemBlock
{
	public uint Unknown_0h;

	public uint Unknown_4h;

	public float PositionX;

	public float PositionY;

	public float PositionZ;

	public uint Unknown_14h;

	public byte ColorR;

	public byte ColorG;

	public byte ColorB;

	public byte Unknown_1Bh;

	public float Intensity;

	public uint Unknown_20h;

	public ushort BoneId;

	public ushort Type;

	public uint Unknown_28h;

	public float Falloff;

	public float FalloffExponent;

	public float CullingPlaneNormalX;

	public float CullingPlaneNormalY;

	public float CullingPlaneNormalZ;

	public float CullingPlaneOffset;

	public byte ShadowBlur;

	public byte Unknown_45h;

	public ushort Unknown_46h;

	public uint Unknown_48h;

	public float VolumeIntensity;

	public float VolumeSizeScale;

	public byte VolumeOuterColorR;

	public byte VolumeOuterColorG;

	public byte VolumeOuterColorB;

	public byte LightHash;

	public float VolumeOuterIntensity;

	public float CoronaSize;

	public float VolumeOuterExponent;

	public byte LightFadeDistance;

	public byte ShadowFadeDistance;

	public byte SpecularFadeDistance;

	public byte VolumetricFadeDistance;

	public float ShadowNearClip;

	public float CoronaIntensity;

	public float CoronaZBias;

	public float DirectionX;

	public float DirectionY;

	public float DirectionZ;

	public float TangentX;

	public float TangentY;

	public float TangentZ;

	public float ConeInnerAngle;

	public float ConeOuterAngle;

	public float ExtentX;

	public float ExtentY;

	public float ExtentZ;

	public uint ProjectedTextureHash;

	public uint Unknown_A4h;

	public override long Length => 168L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		Unknown_0h = reader.ReadUInt32();
		Unknown_4h = reader.ReadUInt32();
		PositionX = reader.ReadSingle();
		PositionY = reader.ReadSingle();
		PositionZ = reader.ReadSingle();
		Unknown_14h = reader.ReadUInt32();
		ColorR = reader.ReadByte();
		ColorG = reader.ReadByte();
		ColorB = reader.ReadByte();
		Unknown_1Bh = reader.ReadByte();
		Intensity = reader.ReadSingle();
		Unknown_20h = reader.ReadUInt32();
		BoneId = reader.ReadUInt16();
		Type = reader.ReadUInt16();
		Unknown_28h = reader.ReadUInt32();
		Falloff = reader.ReadSingle();
		FalloffExponent = reader.ReadSingle();
		CullingPlaneNormalX = reader.ReadSingle();
		CullingPlaneNormalY = reader.ReadSingle();
		CullingPlaneNormalZ = reader.ReadSingle();
		CullingPlaneOffset = reader.ReadSingle();
		ShadowBlur = reader.ReadByte();
		Unknown_45h = reader.ReadByte();
		Unknown_46h = reader.ReadUInt16();
		Unknown_48h = reader.ReadUInt32();
		VolumeIntensity = reader.ReadSingle();
		VolumeSizeScale = reader.ReadSingle();
		VolumeOuterColorR = reader.ReadByte();
		VolumeOuterColorG = reader.ReadByte();
		VolumeOuterColorB = reader.ReadByte();
		LightHash = reader.ReadByte();
		VolumeOuterIntensity = reader.ReadSingle();
		CoronaSize = reader.ReadSingle();
		VolumeOuterExponent = reader.ReadSingle();
		LightFadeDistance = reader.ReadByte();
		ShadowFadeDistance = reader.ReadByte();
		SpecularFadeDistance = reader.ReadByte();
		VolumetricFadeDistance = reader.ReadByte();
		ShadowNearClip = reader.ReadSingle();
		CoronaIntensity = reader.ReadSingle();
		CoronaZBias = reader.ReadSingle();
		DirectionX = reader.ReadSingle();
		DirectionY = reader.ReadSingle();
		DirectionZ = reader.ReadSingle();
		TangentX = reader.ReadSingle();
		TangentY = reader.ReadSingle();
		TangentZ = reader.ReadSingle();
		ConeInnerAngle = reader.ReadSingle();
		ConeOuterAngle = reader.ReadSingle();
		ExtentX = reader.ReadSingle();
		ExtentY = reader.ReadSingle();
		ExtentZ = reader.ReadSingle();
		ProjectedTextureHash = reader.ReadUInt32();
		Unknown_A4h = reader.ReadUInt32();
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		writer.Write(Unknown_0h);
		writer.Write(Unknown_4h);
		writer.Write(PositionX);
		writer.Write(PositionY);
		writer.Write(PositionZ);
		writer.Write(Unknown_14h);
		writer.Write(ColorR);
		writer.Write(ColorG);
		writer.Write(ColorB);
		writer.Write(Unknown_1Bh);
		writer.Write(Intensity);
		writer.Write(Unknown_20h);
		writer.Write(BoneId);
		writer.Write(Type);
		writer.Write(Unknown_28h);
		writer.Write(Falloff);
		writer.Write(FalloffExponent);
		writer.Write(CullingPlaneNormalX);
		writer.Write(CullingPlaneNormalY);
		writer.Write(CullingPlaneNormalZ);
		writer.Write(CullingPlaneOffset);
		writer.Write(ShadowBlur);
		writer.Write(Unknown_45h);
		writer.Write(Unknown_46h);
		writer.Write(Unknown_48h);
		writer.Write(VolumeIntensity);
		writer.Write(VolumeSizeScale);
		writer.Write(VolumeOuterColorR);
		writer.Write(VolumeOuterColorG);
		writer.Write(VolumeOuterColorB);
		writer.Write(LightHash);
		writer.Write(VolumeOuterIntensity);
		writer.Write(CoronaSize);
		writer.Write(VolumeOuterExponent);
		writer.Write(LightFadeDistance);
		writer.Write(ShadowFadeDistance);
		writer.Write(SpecularFadeDistance);
		writer.Write(VolumetricFadeDistance);
		writer.Write(ShadowNearClip);
		writer.Write(CoronaIntensity);
		writer.Write(CoronaZBias);
		writer.Write(DirectionX);
		writer.Write(DirectionY);
		writer.Write(DirectionZ);
		writer.Write(TangentX);
		writer.Write(TangentY);
		writer.Write(TangentZ);
		writer.Write(ConeInnerAngle);
		writer.Write(ConeOuterAngle);
		writer.Write(ExtentX);
		writer.Write(ExtentY);
		writer.Write(ExtentZ);
		writer.Write(ProjectedTextureHash);
		writer.Write(Unknown_A4h);
	}
}
