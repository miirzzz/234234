using System;
using System.Collections;
using System.Collections.Generic;

namespace RageLib.Resources.Common;

public class ResourcePointerArray64<T> : ResourceSystemBlock, IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable where T : IResourceSystemBlock, new()
{
	public List<ulong> data_pointers;

	public List<T> data_items;

	public override long Length => 8 * data_items.Count;

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

	public int GetNonEmptyNumber()
	{
		int num = 0;
		foreach (T data_item in data_items)
		{
			if (data_item != null)
			{
				num++;
			}
		}
		return num;
	}

	public ResourcePointerArray64()
	{
		data_items = new List<T>();
	}

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		int num = Convert.ToInt32(parameters[0]);
		data_pointers = new List<ulong>();
		for (int i = 0; i < num; i++)
		{
			data_pointers.Add(reader.ReadUInt64());
		}
		foreach (ulong data_pointer in data_pointers)
		{
			_ = data_pointer;
		}
		data_items = new List<T>();
		for (int j = 0; j < num; j++)
		{
			data_items.Add(reader.ReadBlockAt<T>(data_pointers[j], new object[0]));
		}
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		data_pointers = new List<ulong>();
		foreach (T data_item in data_items)
		{
			if (data_item != null)
			{
				data_pointers.Add((uint)data_item.Position);
			}
			else
			{
				data_pointers.Add(0uL);
			}
		}
		foreach (ulong data_pointer in data_pointers)
		{
			writer.Write(data_pointer);
		}
	}

	public override IResourceBlock[] GetReferences()
	{
		List<IResourceBlock> list = new List<IResourceBlock>();
		foreach (T data_item in data_items)
		{
			list.Add(data_item);
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
		data_items.RemoveAt(index);
	}

	public void Add(T item)
	{
		data_items.Add(item);
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
		return data_items.Remove(item);
	}

	public IEnumerator<T> GetEnumerator()
	{
		return data_items.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		throw new NotImplementedException();
	}
}
