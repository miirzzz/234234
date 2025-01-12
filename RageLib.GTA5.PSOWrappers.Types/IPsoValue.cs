using RageLib.Data;
using RageLib.GTA5.PSOWrappers.Data;

namespace RageLib.GTA5.PSOWrappers.Types;

public interface IPsoValue
{
	void Read(PsoDataReader reader);

	void Write(DataWriter writer);
}
