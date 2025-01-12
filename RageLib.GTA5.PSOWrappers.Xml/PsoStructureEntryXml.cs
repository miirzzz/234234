using System;
using System.Xml.Serialization;

namespace RageLib.GTA5.PSOWrappers.Xml;

[Serializable]
public class PsoStructureEntryXml
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

	[XmlAttribute("Offset")]
	public int Offset { get; set; }

	[XmlAttribute("Type")]
	public int Type { get; set; }

	[XmlIgnore]
	public int TypeHash { get; set; }

	[XmlAttribute("TypeHash")]
	public string TypeHashAsHex
	{
		get
		{
			return HexConverter.ToHex(TypeHash);
		}
		set
		{
			TypeHash = HexConverter.ToUInt32(value);
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

	[XmlElement("ArrayType")]
	public PsoStructureEntryXml ArrayType { get; set; }
}
