using RageLib.Data;

namespace RageLib.GTA5.Archives;

public interface IRageArchiveEntry7
{
	uint NameOffset { get; set; }

	string Name { get; set; }

	void Read(DataReader reader);

	void Write(DataWriter writer);
}
