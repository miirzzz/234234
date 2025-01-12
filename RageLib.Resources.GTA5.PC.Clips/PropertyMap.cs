using System.Collections.Generic;
using RageLib.Resources.Common;

namespace RageLib.Resources.GTA5.PC.Clips;

public class PropertyMap : ResourceSystemBlock
{
	public ulong PropertyEntriesPointer;

	public ushort PropertyEntriesCount;

	public ushort PropertyEntriesTotalCount;

	public uint Unknown_Ch;

	public ResourcePointerArray64<PropertyMapEntry> Properties;

	public override long Length => 16L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		PropertyEntriesPointer = reader.ReadUInt64();
		PropertyEntriesCount = reader.ReadUInt16();
		PropertyEntriesTotalCount = reader.ReadUInt16();
		Unknown_Ch = reader.ReadUInt32();
		Properties = reader.ReadBlockAt<ResourcePointerArray64<PropertyMapEntry>>(PropertyEntriesPointer, new object[1] { PropertyEntriesCount });
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		PropertyEntriesPointer = (ulong)((Properties != null) ? Properties.Position : 0);
		PropertyEntriesCount = (ushort)((Properties != null) ? ((uint)Properties.Count) : 0u);
		if (Properties != null)
		{
			int num = 0;
			foreach (PropertyMapEntry data_item in Properties.data_items)
			{
				if (data_item == null)
				{
					continue;
				}
				PropertyMapEntry propertyMapEntry = data_item;
				while (true)
				{
					if (propertyMapEntry.Data != null)
					{
						num++;
					}
					if (propertyMapEntry.Next == null)
					{
						break;
					}
					propertyMapEntry = propertyMapEntry.Next;
				}
			}
			PropertyEntriesTotalCount = (ushort)num;
		}
		else
		{
			PropertyEntriesTotalCount = 0;
		}
		writer.Write(PropertyEntriesPointer);
		writer.Write(PropertyEntriesCount);
		writer.Write(PropertyEntriesTotalCount);
		writer.Write(Unknown_Ch);
	}

	public override IResourceBlock[] GetReferences()
	{
		List<IResourceBlock> list = new List<IResourceBlock>();
		if (Properties != null)
		{
			list.Add(Properties);
		}
		return list.ToArray();
	}
}
