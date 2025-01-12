namespace RageLib.Resources;

public interface IResourceBlock
{
	long Position { get; set; }

	long Length { get; }

	void Read(ResourceDataReader reader, params object[] parameters);

	void Write(ResourceDataWriter writer, params object[] parameters);
}
