using RageLib.Data;
using RageLib.GTA5.PSO;
using RageLib.GTA5.PSOWrappers.Data;

namespace RageLib.GTA5.PSOWrappers.Types;

public class PsoFlagsInt : IPsoValue
{
	public PsoEnumInfo TypeInfo;

	public int Value { get; set; }

	public PsoFlagsInt()
	{
	}

	public PsoFlagsInt(byte value)
	{
		Value = value;
	}

	public PsoFlagsInt(PsoEnumInfo typeInfo, byte value)
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
