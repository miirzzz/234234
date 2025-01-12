using System;
using RageLib.GTA5.PSO;
using RageLib.GTA5.PSOWrappers.Types;

namespace RageLib.GTA5.PSOWrappers;

public static class PsoTypeBuilder
{
	public static IPsoValue Make(PsoFile pso, PsoStructureInfo structureInfo, PsoStructureEntryInfo entryInfo)
	{
		switch (entryInfo.Type)
		{
		case DataType.Array:
			switch (entryInfo.Unk_5h)
			{
			case 0:
			{
				PsoStructureEntryInfo entryInfo4 = structureInfo.Entries[entryInfo.ReferenceKey & 0xFFFF];
				return new PsoArray0(pso, structureInfo, entryInfo4);
			}
			case 1:
			{
				int index2 = entryInfo.ReferenceKey & 0xFFFF;
				int numberOfEntries2 = (entryInfo.ReferenceKey >> 16) & 0xFFFF;
				PsoStructureEntryInfo entryInfo3 = structureInfo.Entries[index2];
				return new PsoArray1(pso, structureInfo, entryInfo3, numberOfEntries2);
			}
			case 4:
			{
				int index = entryInfo.ReferenceKey & 0xFFFF;
				int numberOfEntries = (entryInfo.ReferenceKey >> 16) & 0xFFFF;
				PsoStructureEntryInfo entryInfo2 = structureInfo.Entries[index];
				return new PsoArray4(pso, structureInfo, entryInfo2, numberOfEntries);
			}
			default:
				throw new Exception("Unsupported array type.");
			}
		case DataType.String:
			return entryInfo.Unk_5h switch
			{
				0 => new PsoString0((entryInfo.ReferenceKey >> 16) & 0xFFFF), 
				1 => new PsoString1(), 
				2 => new PsoString2(), 
				3 => new PsoString3(), 
				7 => new PsoString7(), 
				8 => new PsoString8(), 
				_ => throw new Exception("Unsupported string type."), 
			};
		case DataType.Enum:
			return entryInfo.Unk_5h switch
			{
				0 => new PsoEnumInt
				{
					TypeInfo = GetEnumInfo(pso, entryInfo.ReferenceKey)
				}, 
				2 => new PsoEnumByte
				{
					TypeInfo = GetEnumInfo(pso, entryInfo.ReferenceKey)
				}, 
				_ => throw new Exception("Unsupported enum type."), 
			};
		case DataType.Flags:
			switch (entryInfo.Unk_5h)
			{
			case 0:
			{
				PsoFlagsInt psoFlagsInt = new PsoFlagsInt();
				int num = entryInfo.ReferenceKey & 0xFFFF;
				if (num != 4095)
				{
					PsoStructureEntryInfo psoStructureEntryInfo3 = structureInfo.Entries[num];
					psoFlagsInt.TypeInfo = GetEnumInfo(pso, psoStructureEntryInfo3.ReferenceKey);
				}
				return psoFlagsInt;
			}
			case 1:
			{
				PsoFlagsShort psoFlagsShort = new PsoFlagsShort();
				int index4 = entryInfo.ReferenceKey & 0xFFFF;
				PsoStructureEntryInfo psoStructureEntryInfo2 = structureInfo.Entries[index4];
				psoFlagsShort.TypeInfo = GetEnumInfo(pso, psoStructureEntryInfo2.ReferenceKey);
				return psoFlagsShort;
			}
			case 2:
			{
				PsoFlagsByte psoFlagsByte = new PsoFlagsByte();
				int index3 = entryInfo.ReferenceKey & 0xFFFF;
				PsoStructureEntryInfo psoStructureEntryInfo = structureInfo.Entries[index3];
				psoFlagsByte.TypeInfo = GetEnumInfo(pso, psoStructureEntryInfo.ReferenceKey);
				return psoFlagsByte;
			}
			default:
				throw new Exception("Unsupported flags type.");
			}
		case DataType.Integer:
			return entryInfo.Unk_5h switch
			{
				0 => new PsoIntSigned(), 
				1 => new PsoIntUnsigned(), 
				_ => throw new Exception("Unsupported integer type."), 
			};
		case DataType.Structure:
			switch (entryInfo.Unk_5h)
			{
			case 0:
			{
				PsoStructureInfo structureInfo2 = GetStructureInfo(pso, entryInfo.ReferenceKey);
				PsoElementIndexInfo structureIndexInfo = GetStructureIndexInfo(pso, entryInfo.ReferenceKey);
				return new PsoStructure(pso, structureInfo2, structureIndexInfo, entryInfo);
			}
			case 3:
				return new PsoStructure3(pso, structureInfo, entryInfo);
			default:
				throw new Exception("Unsupported structure type.");
			}
		case DataType.Map:
		{
			byte unk_5h = entryInfo.Unk_5h;
			if (unk_5h == 1)
			{
				int index5 = entryInfo.ReferenceKey & 0xFFFF;
				int index6 = (entryInfo.ReferenceKey >> 16) & 0xFFFF;
				PsoStructureEntryInfo keyEntryInfo = structureInfo.Entries[index6];
				PsoStructureEntryInfo valueEntryInfo = structureInfo.Entries[index5];
				return new PsoMap(pso, structureInfo, keyEntryInfo, valueEntryInfo);
			}
			throw new Exception("Unsupported PsoType5 type.");
		}
		case DataType.INT_05h:
			if (entryInfo.Unk_5h == 0)
			{
				return new PsoType5();
			}
			throw new Exception("Unsupported PsoType5 type.");
		case DataType.Byte:
			if (entryInfo.Unk_5h == 0)
			{
				return new PsoByte();
			}
			throw new Exception("Unsupported PsoByte type.");
		case DataType.Boolean:
			if (entryInfo.Unk_5h == 0)
			{
				return new PsoBoolean();
			}
			throw new Exception("Unsupported boolean type.");
		case DataType.Float:
			if (entryInfo.Unk_5h == 0)
			{
				return new PsoFloat();
			}
			throw new Exception("Unsupported float type.");
		case DataType.Float2:
			if (entryInfo.Unk_5h == 0)
			{
				return new PsoFloat2();
			}
			throw new Exception("Unsupported float2 type.");
		case DataType.Float3:
			if (entryInfo.Unk_5h == 0)
			{
				return new PsoFloat4A();
			}
			throw new Exception("Unsupported float3 type.");
		case DataType.Float4:
			if (entryInfo.Unk_5h == 0)
			{
				return new PsoFloat4B();
			}
			throw new Exception("Unsupported float4 type.");
		case DataType.TYPE_09h:
			if (entryInfo.Unk_5h == 0)
			{
				return new PsoType9();
			}
			throw new Exception("Unsupported PsoType9 type.");
		case DataType.LONG_20h:
			if (entryInfo.Unk_5h == 0)
			{
				return new PsoType32();
			}
			throw new Exception("Unsupported PsoType32 type.");
		case DataType.SHORT_1Eh:
			if (entryInfo.Unk_5h == 0)
			{
				return new PsoXXHalf();
			}
			throw new Exception("Unsupported PsoType30 type.");
		case DataType.SHORT_03h:
			if (entryInfo.Unk_5h == 0)
			{
				return new PsoType3();
			}
			throw new Exception("Unsupported PsoType3 type.");
		case DataType.SHORT_04h:
			if (entryInfo.Unk_5h == 0)
			{
				return new PsoType4();
			}
			throw new Exception("Unsupported PsoType4 type.");
		case DataType.LONG_01h:
			if (entryInfo.Unk_5h == 0)
			{
				return new PsoXXByte();
			}
			throw new Exception("Unsupported PsoType1 type.");
		case DataType.TYPE_14h:
			if (entryInfo.Unk_5h == 0)
			{
				return new PsoFloat3();
			}
			throw new Exception("Unsupported PsoType20 type.");
		default:
			throw new Exception("Unsupported type.");
		}
	}

	public static PsoStructureInfo GetStructureInfo(PsoFile meta, int structureKey)
	{
		PsoStructureInfo result = null;
		for (int i = 0; i < meta.DefinitionSection.Count; i++)
		{
			if (meta.DefinitionSection.EntriesIdx[i].NameHash == structureKey)
			{
				result = (PsoStructureInfo)meta.DefinitionSection.Entries[i];
			}
		}
		return result;
	}

	public static PsoEnumInfo GetEnumInfo(PsoFile meta, int structureKey)
	{
		PsoEnumInfo result = null;
		for (int i = 0; i < meta.DefinitionSection.Count; i++)
		{
			if (meta.DefinitionSection.EntriesIdx[i].NameHash == structureKey)
			{
				result = (PsoEnumInfo)meta.DefinitionSection.Entries[i];
			}
		}
		return result;
	}

	public static PsoElementIndexInfo GetStructureIndexInfo(PsoFile meta, int structureKey)
	{
		PsoElementIndexInfo result = null;
		for (int i = 0; i < meta.DefinitionSection.Count; i++)
		{
			if (meta.DefinitionSection.EntriesIdx[i].NameHash == structureKey)
			{
				result = meta.DefinitionSection.EntriesIdx[i];
			}
		}
		return result;
	}
}
