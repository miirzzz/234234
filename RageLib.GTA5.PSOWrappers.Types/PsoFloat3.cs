using RageLib.Data;
using RageLib.GTA5.PSOWrappers.Data;

namespace RageLib.GTA5.PSOWrappers.Types;

public class PsoFloat3 : IPsoValue
{
	public float X { get; set; }

	public float Y { get; set; }

	public float Z { get; set; }

	public void Read(PsoDataReader reader)
	{
		X = reader.ReadSingle();
		Y = reader.ReadSingle();
		Z = reader.ReadSingle();
	}

	public void Write(DataWriter writer)
	{
	}
}
