using System.IO;

namespace RageLib.Archives;

public interface IArchiveBinaryFile : IArchiveFile
{
	bool IsEncrypted { get; set; }

	bool IsCompressed { get; set; }

	long UncompressedSize { get; set; }

	long CompressedSize { get; }

	Stream GetStream();
}
