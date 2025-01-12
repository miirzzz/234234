using System;
using System.Xml.Serialization;

namespace RageLib.GTA5.PSOWrappers.Xml;

[Serializable]
public class PsoEnumEntryXml
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

	[XmlAttribute("Value")]
	public int Value { get; set; }
}
