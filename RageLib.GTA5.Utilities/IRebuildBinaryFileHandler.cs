using RageLib.Archives;
using RageLib.GTA5.Archives;

namespace RageLib.GTA5.Utilities;

public interface IRebuildBinaryFileHandler
{
	bool CanRebuild(IArchiveBinaryFile sourceFile);

	void Rebuild(IArchiveBinaryFile sourceFile, IArchiveDirectory targetDirectory, RageArchiveEncryption7 encryption);
}
