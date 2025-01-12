using System;

namespace RageLib.Resources.GTA5.PC.Particles;

public class Behaviour : ResourceSystemBlock, IResourceXXSystemBlock, IResourceSystemBlock, IResourceBlock
{
	public uint VFT;

	public uint Unknown_4h;

	public uint Type;

	public uint Unknown_Ch;

	public override long Length => 16L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		VFT = reader.ReadUInt32();
		Unknown_4h = reader.ReadUInt32();
		Type = reader.ReadUInt32();
		Unknown_Ch = reader.ReadUInt32();
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		writer.Write(VFT);
		writer.Write(Unknown_4h);
		writer.Write(Type);
		writer.Write(Unknown_Ch);
	}

	public IResourceSystemBlock GetType(ResourceDataReader reader, params object[] parameters)
	{
		reader.Position += 8L;
		BehaviourType behaviourType = (BehaviourType)reader.ReadUInt32();
		reader.Position -= 12L;
		return behaviourType switch
		{
			BehaviourType.Age => new BehaviourAge(), 
			BehaviourType.Acceleration => new BehaviourAcceleration(), 
			BehaviourType.Velocity => new BehaviourVelocity(), 
			BehaviourType.Rotation => new BehaviourRotation(), 
			BehaviourType.Size => new BehaviourSize(), 
			BehaviourType.Dampening => new BehaviourDampening(), 
			BehaviourType.MatrixWeight => new BehaviourMatrixWeight(), 
			BehaviourType.Collision => new BehaviourCollision(), 
			BehaviourType.AnimateTexture => new BehaviourAnimateTexture(), 
			BehaviourType.Colour => new BehaviourColour(), 
			BehaviourType.Sprite => new BehaviourSprite(), 
			BehaviourType.Wind => new BehaviourWind(), 
			BehaviourType.Light => new BehaviourLight(), 
			BehaviourType.Model => new BehaviourModel(), 
			BehaviourType.Decal => new BehaviourDecal(), 
			BehaviourType.ZCull => new BehaviourZCull(), 
			BehaviourType.Noise => new BehaviourNoise(), 
			BehaviourType.Attractor => new BehaviourAttractor(), 
			BehaviourType.Trail => new BehaviourTrail(), 
			BehaviourType.FogVolume => new BehaviourFogVolume(), 
			BehaviourType.River => new BehaviourRiver(), 
			BehaviourType.DecalPool => new BehaviourDecalPool(), 
			BehaviourType.Liquid => new BehaviourLiquid(), 
			_ => throw new Exception("Unknown behaviour type"), 
		};
	}
}
