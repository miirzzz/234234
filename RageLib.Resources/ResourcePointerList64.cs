using System;
using System.Collections;
using System.Collections.Generic;
using RageLib.Resources.Common;

namespace RageLib.Resources;

public class ResourcePointerList64<T> : ResourceSystemBlock, IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable where T : IResourceSystemBlock, new()
{
	public ulong DataPointer;

	public ushort DataCount1;

	public ushort DataCount2;

	public ResourcePointerArray64<T> data_items;

	public override long Length => 12L;

	public T this[int index]
	{
		get
		{
			return data_items[index];
		}
		set
		{
			throw new NotImplementedException();
		}
	}

	public int Count => data_items.Count;

	public bool IsReadOnly
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		DataPointer = reader.ReadUInt64();
		DataCount1 = reader.ReadUInt16();
		DataCount2 = reader.ReadUInt16();
		data_items = reader.ReadBlockAt<ResourcePointerArray64<T>>(DataPointer, new object[1] { DataCount1 });
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		DataPointer = (ulong)data_items.Position;
		DataCount1 = (ushort)data_items.Count;
		DataCount2 = (ushort)data_items.Count;
		writer.Write(DataPointer);
		writer.Write(DataCount1);
		writer.Write(DataCount2);
	}

	public override IResourceBlock[] GetReferences()
	{
		List<IResourceBlock> list = new List<IResourceBlock>();
		if (data_items != null)
		{
			list.Add(data_items);
		}
		return list.ToArray();
	}

	public int IndexOf(T item)
	{
		throw new NotImplementedException();
	}

	public void Insert(int index, T item)
	{
		throw new NotImplementedException();
	}

	public void RemoveAt(int index)
	{
		throw new NotImplementedException();
	}

	public void Add(T item)
	{
		throw new NotImplementedException();
	}

	public void Clear()
	{
		throw new NotImplementedException();
	}

	public bool Contains(T item)
	{
		throw new NotImplementedException();
	}

	public void CopyTo(T[] array, int arrayIndex)
	{
		throw new NotImplementedException();
	}

	public bool Remove(T item)
	{
		throw new NotImplementedException();
	}

	public IEnumerator<T> GetEnumerator()
	{
		throw new NotImplementedException();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		throw new NotImplementedException();
	}

	public IResourceBlock CheckForCast(ResourceDataReader reader, params object[] parameters)
	{
		throw new NotImplementedException();
	}
}
