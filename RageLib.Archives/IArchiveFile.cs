using System.IO;

namespace RageLib.Archives;

public interface IArchiveFile
{
	string Name { get; set; }

	long Size { get; }

	void Import(string fileName);

	void Import(Stream stream);

	void Export(string fileName);

	void Export(Stream stream);
}
