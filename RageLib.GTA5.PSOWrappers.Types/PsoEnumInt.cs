using RageLib.Data;
using RageLib.GTA5.PSO;
using RageLib.GTA5.PSOWrappers.Data;

namespace RageLib.GTA5.PSOWrappers.Types;

public class PsoEnumInt : IPsoValue
{
	public PsoEnumInfo TypeInfo { get; set; }

	public int Value { get; set; }

	public PsoEnumInt()
	{
	}

	public PsoEnumInt(int value)
	{
		Value = value;
	}

	public PsoEnumInt(PsoEnumInfo typeInfo, int value)
	{
		TypeInfo = typeInfo;
		Value = value;
	}

	public void Read(PsoDataReader reader)
	{
		Value = reader.ReadInt32();
	}

	public void Write(DataWriter writer)
	{
		writer.Write(Value);
	}
}
