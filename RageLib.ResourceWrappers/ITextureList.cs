using System.Collections;
using System.Collections.Generic;

namespace RageLib.ResourceWrappers;

public interface ITextureList : IList<ITexture>, ICollection<ITexture>, IEnumerable<ITexture>, IEnumerable
{
}
