using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace RageLib.GTA5.PSOWrappers.Xml;

[Serializable]
public class PsoEnumXml
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

	[XmlElement("EnumEntry")]
	public List<PsoEnumEntryXml> Entries { get; set; }
}
