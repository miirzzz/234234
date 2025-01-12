using System;

namespace RageLib.Resources;

public abstract class ResourceSystemBlock : IResourceSystemBlock, IResourceBlock
{
	private long position;

	public virtual long Position
	{
		get
		{
			return position;
		}
		set
		{
			position = value;
			Tuple<long, IResourceBlock>[] parts = GetParts();
			foreach (Tuple<long, IResourceBlock> tuple in parts)
			{
				tuple.Item2.Position = value + tuple.Item1;
			}
		}
	}

	public abstract long Length { get; }

	public abstract void Read(ResourceDataReader reader, params object[] parameters);

	public abstract void Write(ResourceDataWriter writer, params object[] parameters);

	public virtual Tuple<long, IResourceBlock>[] GetParts()
	{
		return new Tuple<long, IResourceBlock>[0];
	}

	public virtual IResourceBlock[] GetReferences()
	{
		return new IResourceBlock[0];
	}
}
