using System.IO;

namespace RageLib.ResourceWrappers;

public interface IResourceFile
{
	void Load(string fileName);

	void Load(Stream stream);

	void Save(string fileName);

	void Save(Stream stream);
}
