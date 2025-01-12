using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml;
using RageLib.GTA5.PSO;
using RageLib.GTA5.PSOWrappers.Types;

namespace RageLib.GTA5.PSOWrappers;

public class PsoXmlExporter
{
	public Dictionary<int, string> HashMapping { get; set; }

	public PsoXmlExporter()
	{
		HashMapping = new Dictionary<int, string>();
	}

	public void Export(IPsoValue value, string xmlFileName)
	{
		using FileStream xmlFileStream = new FileStream(xmlFileName, FileMode.Create);
		Export(value, xmlFileStream);
	}

	public void Export(IPsoValue value, Stream xmlFileStream)
	{
		PsoStructure psoStructure = (PsoStructure)value;
		XmlTextWriter xmlTextWriter = new XmlTextWriter(xmlFileStream, Encoding.UTF8);
		xmlTextWriter.Formatting = Formatting.Indented;
		xmlTextWriter.WriteStartDocument();
		xmlTextWriter.WriteStartElement(GetNameForHash(psoStructure.entryIndexInfo.NameHash));
		WriteStructureContentXml(psoStructure, xmlTextWriter);
		xmlTextWriter.WriteEndElement();
		xmlTextWriter.WriteEndDocument();
		xmlTextWriter.Flush();
	}

	private void WriteStructureContentXml(PsoStructure value, XmlTextWriter writer)
	{
		foreach (KeyValuePair<int, IPsoValue> value3 in value.Values)
		{
			int key = value3.Key;
			IPsoValue value2 = value3.Value;
			string nameForHash = GetNameForHash(key);
			writer.WriteStartElement(nameForHash);
			WriteStructureElementContentXml(value2, writer);
			writer.WriteEndElement();
		}
	}

	private void WriteStructureContentXml(PsoStructure3 value, XmlTextWriter writer)
	{
		if (value.Value == null)
		{
			return;
		}
		writer.WriteAttributeString("type", GetNameForHash(value.Value.entryIndexInfo.NameHash));
		foreach (KeyValuePair<int, IPsoValue> value3 in value.Value.Values)
		{
			int key = value3.Key;
			IPsoValue value2 = value3.Value;
			string nameForHash = GetNameForHash(key);
			writer.WriteStartElement(nameForHash);
			WriteStructureElementContentXml(value2, writer);
			writer.WriteEndElement();
		}
	}

	private void WriteStructureElementContentXml(IPsoValue value, XmlTextWriter writer)
	{
		if (value is PsoArray0)
		{
			WriteArrayContent(writer, (PsoArray0)value);
			return;
		}
		if (value is PsoArray1)
		{
			WriteArrayContent(writer, (PsoArray1)value);
			return;
		}
		if (value is PsoArray4)
		{
			WriteArrayContent(writer, (PsoArray4)value);
			return;
		}
		if (value is PsoBoolean)
		{
			WriteBooleanContent(writer, (PsoBoolean)value);
			return;
		}
		if (value is PsoByte)
		{
			WriteByteContent(writer, (PsoByte)value);
			return;
		}
		if (value is PsoEnumByte)
		{
			WriteEnumContent(writer, (PsoEnumByte)value);
			return;
		}
		if (value is PsoEnumInt)
		{
			WriteEnumContent(writer, (PsoEnumInt)value);
			return;
		}
		if (value is PsoFlagsByte)
		{
			WriteFlagsContent(writer, (PsoFlagsByte)value);
			return;
		}
		if (value is PsoFlagsShort)
		{
			WriteFlagsContent(writer, (PsoFlagsShort)value);
			return;
		}
		if (value is PsoFlagsInt)
		{
			WriteFlagsContent(writer, (PsoFlagsInt)value);
			return;
		}
		if (value is PsoFloat)
		{
			WriteFloatContent(writer, (PsoFloat)value);
			return;
		}
		if (value is PsoFloat2)
		{
			WriteFloatContent(writer, (PsoFloat2)value);
			return;
		}
		if (value is PsoFloat3)
		{
			WriteFloatContent(writer, (PsoFloat3)value);
			return;
		}
		if (value is PsoFloat4A)
		{
			WriteFloatContent(writer, (PsoFloat4A)value);
			return;
		}
		if (value is PsoFloat4B)
		{
			WriteFloatContent(writer, (PsoFloat4B)value);
			return;
		}
		if (value is PsoIntSigned)
		{
			WriteIntegerContent(writer, (PsoIntSigned)value);
			return;
		}
		if (value is PsoIntUnsigned)
		{
			WriteIntegerContent(writer, (PsoIntUnsigned)value);
			return;
		}
		if (value is PsoMap)
		{
			WriteMapContent(writer, (PsoMap)value);
			return;
		}
		if (value is PsoString0)
		{
			WriteStringContent(writer, (PsoString0)value);
			return;
		}
		if (value is PsoString1)
		{
			WriteStringContent(writer, (PsoString1)value);
			return;
		}
		if (value is PsoString2)
		{
			WriteStringContent(writer, (PsoString2)value);
			return;
		}
		if (value is PsoString3)
		{
			WriteStringContent(writer, (PsoString3)value);
			return;
		}
		if (value is PsoString7)
		{
			WriteStringContent(writer, (PsoString7)value);
			return;
		}
		if (value is PsoString8)
		{
			WriteStringContent(writer, (PsoString8)value);
			return;
		}
		if (value is PsoType5)
		{
			PsoType5 value2 = value as PsoType5;
			Write5Content(writer, value2);
			return;
		}
		if (value is PsoStructure)
		{
			PsoStructure value3 = value as PsoStructure;
			WriteStructureContentXml(value3, writer);
			return;
		}
		if (value is PsoStructure3)
		{
			PsoStructure3 value4 = value as PsoStructure3;
			WriteStructureContentXml(value4, writer);
			return;
		}
		if (value is PsoXXHalf)
		{
			throw new NotImplementedException();
		}
		if (value is PsoType4)
		{
			throw new NotImplementedException();
		}
		if (value is PsoType9)
		{
			throw new NotImplementedException();
		}
		if (value is PsoType32)
		{
			throw new NotImplementedException();
		}
		if (value is PsoType3)
		{
			throw new NotImplementedException();
		}
		if (value is PsoXXByte)
		{
			throw new NotImplementedException();
		}
		throw new Exception("Unknown type");
	}

	private void WriteArrayContent(XmlTextWriter writer, PsoArray0 arrayValue)
	{
		if (arrayValue.Entries == null)
		{
			return;
		}
		foreach (IPsoValue entry in arrayValue.Entries)
		{
			writer.WriteStartElement("Item");
			if (entry is PsoStructure)
			{
				WriteStructureContentXml((PsoStructure)entry, writer);
			}
			else if (entry is PsoStructure3)
			{
				WriteStructureContentXml((PsoStructure3)entry, writer);
			}
			else
			{
				WriteStructureElementContentXml(entry, writer);
			}
			writer.WriteEndElement();
		}
	}

	private void WriteArrayContent(XmlTextWriter writer, PsoArray1 arrayValue)
	{
		foreach (IPsoValue entry in arrayValue.Entries)
		{
			writer.WriteStartElement("Item");
			if (entry is PsoStructure)
			{
				WriteStructureContentXml((PsoStructure)entry, writer);
			}
			else if (entry is PsoStructure3)
			{
				WriteStructureContentXml((PsoStructure3)entry, writer);
			}
			else
			{
				WriteStructureElementContentXml(entry, writer);
			}
			writer.WriteEndElement();
		}
	}

	private void WriteArrayContent(XmlTextWriter writer, PsoArray4 arrayValue)
	{
		foreach (IPsoValue entry in arrayValue.Entries)
		{
			writer.WriteStartElement("Item");
			if (entry is PsoStructure)
			{
				WriteStructureContentXml((PsoStructure)entry, writer);
			}
			else if (entry is PsoStructure3)
			{
				WriteStructureContentXml((PsoStructure3)entry, writer);
			}
			else
			{
				WriteStructureElementContentXml(entry, writer);
			}
			writer.WriteEndElement();
		}
	}

	private void WriteBooleanContent(XmlTextWriter writer, PsoBoolean value)
	{
		if (value.Value)
		{
			writer.WriteAttributeString("value", "true");
		}
		else
		{
			writer.WriteAttributeString("value", "false");
		}
	}

	private void WriteByteContent(XmlTextWriter writer, PsoByte value)
	{
		writer.WriteAttributeString("value", value.Value.ToString());
	}

	private void WriteEnumContent(XmlTextWriter writer, PsoEnumByte value)
	{
		PsoEnumEntryInfo psoEnumEntryInfo = null;
		foreach (PsoEnumEntryInfo entry in value.TypeInfo.Entries)
		{
			if (entry.EntryKey == value.Value)
			{
				psoEnumEntryInfo = entry;
			}
		}
		if (psoEnumEntryInfo != null)
		{
			string nameForHash = GetNameForHash(psoEnumEntryInfo.EntryNameHash);
			writer.WriteString(nameForHash);
		}
	}

	private void WriteEnumContent(XmlTextWriter writer, PsoEnumInt value)
	{
		PsoEnumEntryInfo psoEnumEntryInfo = null;
		foreach (PsoEnumEntryInfo entry in value.TypeInfo.Entries)
		{
			if (entry.EntryKey == value.Value)
			{
				psoEnumEntryInfo = entry;
			}
		}
		if (psoEnumEntryInfo != null)
		{
			string nameForHash = GetNameForHash(psoEnumEntryInfo.EntryNameHash);
			writer.WriteString(nameForHash);
		}
	}

	private void WriteFlagsContent(XmlTextWriter writer, PsoFlagsByte value)
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < 8; i++)
		{
			if ((value.Value & (1 << i)) == 0)
			{
				continue;
			}
			PsoEnumEntryInfo psoEnumEntryInfo = null;
			foreach (PsoEnumEntryInfo entry in value.TypeInfo.Entries)
			{
				if (entry.EntryKey == i)
				{
					psoEnumEntryInfo = entry;
				}
			}
			string nameForHash = GetNameForHash(psoEnumEntryInfo.EntryNameHash);
			stringBuilder.Append(nameForHash + " ");
		}
		string text = stringBuilder.ToString().Trim();
		writer.WriteString(text);
	}

	private void WriteFlagsContent(XmlTextWriter writer, PsoFlagsShort value)
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < 16; i++)
		{
			if ((value.Value & (1 << i)) == 0)
			{
				continue;
			}
			PsoEnumEntryInfo psoEnumEntryInfo = null;
			foreach (PsoEnumEntryInfo entry in value.TypeInfo.Entries)
			{
				if (entry.EntryKey == i)
				{
					psoEnumEntryInfo = entry;
				}
			}
			string nameForHash = GetNameForHash(psoEnumEntryInfo.EntryNameHash);
			stringBuilder.Append(nameForHash + " ");
		}
		string text = stringBuilder.ToString().Trim();
		writer.WriteString(text);
	}

	private void WriteFlagsContent(XmlTextWriter writer, PsoFlagsInt value)
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < 32; i++)
		{
			if ((value.Value & (1 << i)) == 0)
			{
				continue;
			}
			PsoEnumEntryInfo psoEnumEntryInfo = null;
			foreach (PsoEnumEntryInfo entry in value.TypeInfo.Entries)
			{
				if (entry.EntryKey == i)
				{
					psoEnumEntryInfo = entry;
				}
			}
			string nameForHash = GetNameForHash(psoEnumEntryInfo.EntryNameHash);
			stringBuilder.Append(nameForHash + " ");
		}
		string text = stringBuilder.ToString().Trim();
		writer.WriteString(text);
	}

	private void WriteFloatContent(XmlTextWriter writer, PsoFloat value)
	{
		string value2 = string.Format(CultureInfo.InvariantCulture, "{0:0.0###########}", value.Value);
		writer.WriteAttributeString("value", value2);
	}

	private void WriteFloatContent(XmlTextWriter writer, PsoFloat2 value)
	{
		string value2 = string.Format(CultureInfo.InvariantCulture, "{0:0.0###########}", value.X);
		string value3 = string.Format(CultureInfo.InvariantCulture, "{0:0.0###########}", value.Y);
		writer.WriteAttributeString("x", value2);
		writer.WriteAttributeString("y", value3);
	}

	private void WriteFloatContent(XmlTextWriter writer, PsoFloat3 value)
	{
		string value2 = string.Format(CultureInfo.InvariantCulture, "{0:0.0###########}", value.X);
		string value3 = string.Format(CultureInfo.InvariantCulture, "{0:0.0###########}", value.Y);
		string value4 = string.Format(CultureInfo.InvariantCulture, "{0:0.0###########}", value.Z);
		writer.WriteAttributeString("x", value2);
		writer.WriteAttributeString("y", value3);
		writer.WriteAttributeString("z", value4);
	}

	private void WriteFloatContent(XmlTextWriter writer, PsoFloat4A value)
	{
		string value2 = string.Format(CultureInfo.InvariantCulture, "{0:0.0###########}", value.X);
		string value3 = string.Format(CultureInfo.InvariantCulture, "{0:0.0###########}", value.Y);
		string value4 = string.Format(CultureInfo.InvariantCulture, "{0:0.0###########}", value.Z);
		string value5 = string.Format(CultureInfo.InvariantCulture, "{0:0.0###########}", value.W);
		writer.WriteAttributeString("x", value2);
		writer.WriteAttributeString("y", value3);
		writer.WriteAttributeString("z", value4);
		writer.WriteAttributeString("w", value5);
	}

	private void WriteFloatContent(XmlTextWriter writer, PsoFloat4B value)
	{
		string value2 = string.Format(CultureInfo.InvariantCulture, "{0:0.0###########}", value.X);
		string value3 = string.Format(CultureInfo.InvariantCulture, "{0:0.0###########}", value.Y);
		string value4 = string.Format(CultureInfo.InvariantCulture, "{0:0.0###########}", value.Z);
		string value5 = string.Format(CultureInfo.InvariantCulture, "{0:0.0###########}", value.W);
		writer.WriteAttributeString("x", value2);
		writer.WriteAttributeString("y", value3);
		writer.WriteAttributeString("z", value4);
		writer.WriteAttributeString("w", value5);
	}

	private void WriteIntegerContent(XmlTextWriter writer, PsoIntSigned value)
	{
		writer.WriteAttributeString("value", value.Value.ToString());
	}

	private void WriteIntegerContent(XmlTextWriter writer, PsoIntUnsigned value)
	{
		writer.WriteAttributeString("value", value.Value.ToString("X8"));
	}

	private void WriteMapContent(XmlTextWriter writer, PsoMap value)
	{
		if (value.Entries == null)
		{
			return;
		}
		foreach (PsoStructure entry in value.Entries)
		{
			writer.WriteStartElement("Item");
			PsoString7 psoString = (PsoString7)entry.Values[1620616462];
			writer.WriteAttributeString("key", GetNameForHash(psoString.Value));
			IPsoValue psoValue = entry.Values[104834034];
			if (psoValue is PsoStructure)
			{
				WriteStructureContentXml((PsoStructure)psoValue, writer);
			}
			else if (psoValue is PsoStructure3)
			{
				WriteStructureContentXml((PsoStructure3)psoValue, writer);
			}
			else
			{
				WriteStructureElementContentXml(psoValue, writer);
			}
			writer.WriteEndElement();
		}
	}

	private void WriteStringContent(XmlTextWriter writer, PsoString0 value)
	{
		if (value.Value != null)
		{
			writer.WriteString(value.Value.Replace("\0", ""));
		}
	}

	private void WriteStringContent(XmlTextWriter writer, PsoString1 value)
	{
		if (value.Value != null)
		{
			writer.WriteString(value.Value.Replace("\0", ""));
		}
	}

	private void WriteStringContent(XmlTextWriter writer, PsoString2 value)
	{
		if (value.Value != null)
		{
			writer.WriteString(value.Value.Replace("\0", ""));
		}
	}

	private void WriteStringContent(XmlTextWriter writer, PsoString3 value)
	{
		if (value.Value != null)
		{
			writer.WriteString(value.Value.Replace("\0", ""));
		}
	}

	private void WriteStringContent(XmlTextWriter writer, PsoString7 value)
	{
		if (value.Value != 0)
		{
			writer.WriteString(GetNameForHash(value.Value));
		}
	}

	private void WriteStringContent(XmlTextWriter writer, PsoString8 value)
	{
		if (value.Value != 0)
		{
			writer.WriteString(GetNameForHash(value.Value));
		}
	}

	private void Write5Content(XmlTextWriter writer, PsoType5 value)
	{
		writer.WriteAttributeString("value", value.Value.ToString());
	}

	private string GetNameForHash(int hash)
	{
		if (HashMapping.ContainsKey(hash))
		{
			return HashMapping[hash];
		}
		throw new Exception("Hash 0x" + hash.ToString("X8") + "could not be replaced by a string.");
	}

	public string ByteArrayToString(byte[] b)
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < b.Length; i++)
		{
			stringBuilder.Append(b[i].ToString());
			if (i != b.Length - 1)
			{
				stringBuilder.Append(" ");
			}
		}
		return stringBuilder.ToString();
	}
}
