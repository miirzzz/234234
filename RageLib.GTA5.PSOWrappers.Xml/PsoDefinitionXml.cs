using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace RageLib.GTA5.PSOWrappers.Xml;

[Serializable]
public class PsoDefinitionXml
{
	[XmlElement("Structure")]
	public List<PsoStructureXml> Structures { get; set; }

	[XmlElement("Enum")]
	public List<PsoEnumXml> Enums { get; set; }
}
