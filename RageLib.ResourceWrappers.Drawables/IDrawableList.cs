using System.Collections;
using System.Collections.Generic;

namespace RageLib.ResourceWrappers.Drawables;

public interface IDrawableList : IList<IDrawable>, ICollection<IDrawable>, IEnumerable<IDrawable>, IEnumerable
{
}
