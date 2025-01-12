using RageLib.Archives;
using RageLib.GTA5.Archives;

namespace RageLib.GTA5.Utilities;

public interface IRebuildResourceFileHandler
{
	bool CanRebuild(IArchiveResourceFile sourceFile);

	void Rebuild(IArchiveResourceFile sourceFile, IArchiveDirectory targetDirectory, RageArchiveEncryption7 encryption);
}
