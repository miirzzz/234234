namespace RageLib.Resources.GTA5.PC.VehicleRecords;

public class VehicleRecordsEntry : ResourceSystemBlock
{
	public uint Time;

	public ushort VelocityX;

	public ushort VelocityY;

	public ushort VelocityZ;

	public byte RightX;

	public byte RightY;

	public byte RightZ;

	public byte TopX;

	public byte TopY;

	public byte TopZ;

	public byte SteeringAngle;

	public byte GasPedalPower;

	public byte BrakePedalPower;

	public byte HandbrakeUsed;

	public float PositionX;

	public float PositionY;

	public float PositionZ;

	public override long Length => 32L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		Time = reader.ReadUInt32();
		VelocityX = reader.ReadUInt16();
		VelocityY = reader.ReadUInt16();
		VelocityZ = reader.ReadUInt16();
		RightX = reader.ReadByte();
		RightY = reader.ReadByte();
		RightZ = reader.ReadByte();
		TopX = reader.ReadByte();
		TopY = reader.ReadByte();
		TopZ = reader.ReadByte();
		SteeringAngle = reader.ReadByte();
		GasPedalPower = reader.ReadByte();
		BrakePedalPower = reader.ReadByte();
		HandbrakeUsed = reader.ReadByte();
		PositionX = reader.ReadSingle();
		PositionY = reader.ReadSingle();
		PositionZ = reader.ReadSingle();
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		writer.Write(Time);
		writer.Write(VelocityX);
		writer.Write(VelocityY);
		writer.Write(VelocityZ);
		writer.Write(RightX);
		writer.Write(RightY);
		writer.Write(RightZ);
		writer.Write(TopX);
		writer.Write(TopY);
		writer.Write(TopZ);
		writer.Write(SteeringAngle);
		writer.Write(GasPedalPower);
		writer.Write(BrakePedalPower);
		writer.Write(HandbrakeUsed);
		writer.Write(PositionX);
		writer.Write(PositionY);
		writer.Write(PositionZ);
	}
}
