using System.Collections.Generic;
using RageLib.GTA5.RBF.Types;

namespace RageLib.GTA5.RBF;

public class RbfStructure : IRbfType
{
	public List<IRbfType> Children = new List<IRbfType>();

	public string Name { get; set; }
}
