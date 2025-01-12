using RageLib.Data;
using RageLib.GTA5.PSOWrappers.Data;

namespace RageLib.GTA5.PSOWrappers.Types;

public class PsoFloat2 : IPsoValue
{
	public float X { get; set; }

	public float Y { get; set; }

	public void Read(PsoDataReader reader)
	{
		X = reader.ReadSingle();
		Y = reader.ReadSingle();
	}

	public void Write(DataWriter writer)
	{
	}
}
