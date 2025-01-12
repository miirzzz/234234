using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace RageLib.GTA5.PSOWrappers.Xml;

[Serializable]
public class PsoStructureXml
{
	[XmlIgnore]
	public int NameHash { get; set; }

	[XmlAttribute("NameHash")]
	public string NameHashAsHex
	{
		get
		{
			return HexConverter.ToHex(NameHash);
		}
		set
		{
			NameHash = HexConverter.ToUInt32(value);
		}
	}

	[XmlIgnore]
	public int Unknown { get; set; }

	[XmlAttribute("Unknown")]
	public string UnknownAsHex
	{
		get
		{
			return HexConverter.ToHex(Unknown);
		}
		set
		{
			Unknown = HexConverter.ToUInt32(value);
		}
	}

	[XmlAttribute("Length")]
	public int Length { get; set; }

	[XmlElement("StructureEntry")]
	public List<PsoStructureEntryXml> Entries { get; set; }
}
