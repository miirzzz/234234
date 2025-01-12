using System.IO;

namespace RageLib.Resources;

public interface IResourceFile
{
	byte[] SystemData { get; set; }

	byte[] GraphicsData { get; set; }

	int Version { get; set; }

	void Load(Stream stream);

	void Load(string fileName);

	void Save(Stream stream);

	void Save(string fileName);
}
public interface IResourceFile<T> : IResourceFile where T : IResourceBlock, new()
{
	T ResourceData { get; set; }
}
