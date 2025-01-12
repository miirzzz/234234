namespace RageLib.GTA5.Archives;

public interface IRageArchiveFileEntry7 : IRageArchiveEntry7
{
	uint FileOffset { get; set; }

	uint FileSize { get; set; }
}
