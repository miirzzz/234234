namespace RageLib.Archives;

public interface IArchiveDirectory
{
	string Name { get; set; }

	IArchiveDirectory[] GetDirectories();

	IArchiveDirectory GetDirectory(string name);

	IArchiveDirectory CreateDirectory();

	void DeleteDirectory(IArchiveDirectory directory);

	IArchiveFile[] GetFiles();

	IArchiveFile GetFile(string name);

	IArchiveBinaryFile CreateBinaryFile();

	IArchiveResourceFile CreateResourceFile();

	void DeleteFile(IArchiveFile file);
}
