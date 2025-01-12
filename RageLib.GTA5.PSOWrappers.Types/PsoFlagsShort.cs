using RageLib.Data;
using RageLib.GTA5.PSO;
using RageLib.GTA5.PSOWrappers.Data;

namespace RageLib.GTA5.PSOWrappers.Types;

public class PsoFlagsShort : IPsoValue
{
	public PsoEnumInfo TypeInfo;

	public short Value { get; set; }

	public PsoFlagsShort()
	{
	}

	public PsoFlagsShort(byte value)
	{
		Value = value;
	}

	public PsoFlagsShort(PsoEnumInfo typeInfo, byte value)
	{
		TypeInfo = typeInfo;
		Value = value;
	}

	public void Read(PsoDataReader reader)
	{
		Value = reader.ReadInt16();
	}

	public void Write(DataWriter writer)
	{
		writer.Write(Value);
	}
}
