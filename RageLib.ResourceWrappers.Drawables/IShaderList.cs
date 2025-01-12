using System.Collections;
using System.Collections.Generic;

namespace RageLib.ResourceWrappers.Drawables;

public interface IShaderList : IList<IShader>, ICollection<IShader>, IEnumerable<IShader>, IEnumerable
{
}
