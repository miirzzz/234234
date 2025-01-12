using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using RageLib.Data;
using RageLib.GTA5.RBF.Types;

namespace RageLib.GTA5.RBF;

public class RbfFile
{
	private const int RBF_IDENT = 809910866;

	private RbfStructure current;

	private Stack<RbfStructure> stack;

	private List<RbfEntryDescription> descriptors;

	public RbfStructure Load(string fileName)
	{
		using FileStream stream = new FileStream(fileName, FileMode.Open);
		return Load(stream);
	}

	public RbfStructure Load(Stream stream)
	{
		stack = new Stack<RbfStructure>();
		descriptors = new List<RbfEntryDescription>();
		DataReader dataReader = new DataReader(stream);
		if (dataReader.ReadInt32() != 809910866)
		{
			throw new Exception("The file identifier does not match.");
		}
		while (dataReader.Position < dataReader.Length)
		{
			byte b = dataReader.ReadByte();
			switch (b)
			{
			case byte.MaxValue:
			{
				byte b3 = dataReader.ReadByte();
				if (b3 != byte.MaxValue)
				{
					throw new Exception("Expected 0xFF but was " + b3.ToString("X2"));
				}
				if (stack.Count > 0)
				{
					current = stack.Pop();
					continue;
				}
				if (dataReader.Position != dataReader.Length)
				{
					throw new Exception("Expected end of stream but was not.");
				}
				return current;
			}
			case 253:
			{
				byte b2 = dataReader.ReadByte();
				if (b2 != byte.MaxValue)
				{
					throw new Exception("Expected 0xFF but was " + b2.ToString("X2"));
				}
				int count = dataReader.ReadInt32();
				byte[] value = dataReader.ReadBytes(count);
				RbfBytes rbfBytes = new RbfBytes();
				rbfBytes.Value = value;
				current.Children.Add(rbfBytes);
				continue;
			}
			}
			byte b4 = dataReader.ReadByte();
			if (b == descriptors.Count)
			{
				short count2 = dataReader.ReadInt16();
				byte[] bytes = dataReader.ReadBytes(count2);
				string @string = Encoding.ASCII.GetString(bytes);
				RbfEntryDescription rbfEntryDescription = new RbfEntryDescription();
				rbfEntryDescription.Name = @string;
				rbfEntryDescription.Type = b4;
				descriptors.Add(rbfEntryDescription);
				ParseElement(dataReader, descriptors.Count - 1);
			}
			else
			{
				if (b4 != descriptors[b].Type)
				{
					throw new Exception("Data type does not match.");
				}
				ParseElement(dataReader, b);
			}
		}
		throw new Exception("Unexpected end of stream.");
	}

	private void ParseElement(DataReader reader, int descriptorIndex)
	{
		RbfEntryDescription rbfEntryDescription = descriptors[descriptorIndex];
		switch (rbfEntryDescription.Type)
		{
		case 0:
		{
			RbfStructure rbfStructure = new RbfStructure();
			rbfStructure.Name = rbfEntryDescription.Name;
			if (current != null)
			{
				current.Children.Add(rbfStructure);
				stack.Push(current);
			}
			current = rbfStructure;
			reader.ReadInt16();
			reader.ReadInt16();
			reader.ReadInt16();
			break;
		}
		case 16:
		{
			RbfUint32 rbfUint = new RbfUint32();
			rbfUint.Name = rbfEntryDescription.Name;
			rbfUint.Value = reader.ReadUInt32();
			current.Children.Add(rbfUint);
			break;
		}
		case 32:
		{
			RbfBoolean rbfBoolean2 = new RbfBoolean();
			rbfBoolean2.Name = rbfEntryDescription.Name;
			rbfBoolean2.Value = true;
			current.Children.Add(rbfBoolean2);
			break;
		}
		case 48:
		{
			RbfBoolean rbfBoolean = new RbfBoolean();
			rbfBoolean.Name = rbfEntryDescription.Name;
			rbfBoolean.Value = false;
			current.Children.Add(rbfBoolean);
			break;
		}
		case 64:
		{
			RbfFloat rbfFloat2 = new RbfFloat();
			rbfFloat2.Name = rbfEntryDescription.Name;
			rbfFloat2.Value = reader.ReadSingle();
			current.Children.Add(rbfFloat2);
			break;
		}
		case 80:
		{
			RbfFloat3 rbfFloat = new RbfFloat3();
			rbfFloat.Name = rbfEntryDescription.Name;
			rbfFloat.X = reader.ReadSingle();
			rbfFloat.Y = reader.ReadSingle();
			rbfFloat.Z = reader.ReadSingle();
			current.Children.Add(rbfFloat);
			break;
		}
		case 96:
		{
			short count = reader.ReadInt16();
			byte[] bytes = reader.ReadBytes(count);
			string @string = Encoding.ASCII.GetString(bytes);
			RbfString rbfString = new RbfString();
			rbfString.Name = rbfEntryDescription.Name;
			rbfString.Value = @string;
			current.Children.Add(rbfString);
			break;
		}
		default:
			throw new Exception("Unsupported data type.");
		}
	}
}
