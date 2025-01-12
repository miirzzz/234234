namespace RageLib.Resources;

public abstract class ResourceGraphicsBlock : IResourceGraphicsBlock, IResourceBlock
{
	public virtual long Position { get; set; }

	public abstract long Length { get; }

	public abstract void Read(ResourceDataReader reader, params object[] parameters);

	public abstract void Write(ResourceDataWriter writer, params object[] parameters);
}
