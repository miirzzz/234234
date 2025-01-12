using System;

namespace RageLib.Resources;

public interface IResourceSystemBlock : IResourceBlock
{
	Tuple<long, IResourceBlock>[] GetParts();

	IResourceBlock[] GetReferences();
}
