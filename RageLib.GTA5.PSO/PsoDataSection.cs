using RageLib.Data;

namespace RageLib.GTA5.PSO;

public class PsoDataSection
{
	public byte[] Data { get; set; }

	public void Read(DataReader reader)
	{
		reader.ReadUInt32();
		int count = reader.ReadInt32();
		reader.Position -= 8L;
		Data = reader.ReadBytes(count);
	}

	public void Write(DataWriter writer)
	{
		writer.Write(Data);
		writer.Position -= Data.Length;
		writer.Write(1347635534u);
		writer.Write((uint)Data.Length);
		writer.Position += Data.Length - 8;
	}
}
