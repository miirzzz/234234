using RageLib.Data;

namespace RageLib.GTA5.PSO;

public abstract class PsoElementInfo
{
	public abstract void Read(DataReader reader);

	public abstract void Write(DataWriter writer);
}
