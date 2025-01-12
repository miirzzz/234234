using RageLib.Data;
using RageLib.GTA5.PSOWrappers.Data;

namespace RageLib.GTA5.PSOWrappers.Types;

public class PsoString8 : IPsoValue
{
	public int Value { get; set; }

	public PsoString8()
	{
	}

	public PsoString8(int value)
	{
		Value = value;
	}

	public void Read(PsoDataReader reader)
	{
		int value = reader.ReadInt32();
		reader.ReadInt32();
		Value = value;
	}

	public void Write(DataWriter writer)
	{
	}
}
