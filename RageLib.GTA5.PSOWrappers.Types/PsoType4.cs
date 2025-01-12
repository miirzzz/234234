using RageLib.Data;
using RageLib.GTA5.PSOWrappers.Data;

namespace RageLib.GTA5.PSOWrappers.Types;

public class PsoType4 : IPsoValue
{
	public short Value { get; set; }

	public void Read(PsoDataReader reader)
	{
		Value = reader.ReadInt16();
	}

	public void Write(DataWriter writer)
	{
	}
}
