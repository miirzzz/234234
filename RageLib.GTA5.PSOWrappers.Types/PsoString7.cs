using RageLib.Data;
using RageLib.GTA5.PSOWrappers.Data;

namespace RageLib.GTA5.PSOWrappers.Types;

public class PsoString7 : IPsoValue
{
	public int Value { get; set; }

	public PsoString7()
	{
	}

	public PsoString7(int value)
	{
		Value = value;
	}

	public void Read(PsoDataReader reader)
	{
		Value = reader.ReadInt32();
	}

	public void Write(DataWriter writer)
	{
	}
}
