namespace RageLib.Resources;

public abstract class ResourecTypedSystemBlock : ResourceSystemBlock, IResourceXXSystemBlock, IResourceSystemBlock, IResourceBlock
{
	public abstract IResourceSystemBlock GetType(ResourceDataReader reader, params object[] parameters);
}
