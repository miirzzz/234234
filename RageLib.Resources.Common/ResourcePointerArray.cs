using System;
using System.Collections;
using System.Collections.Generic;

namespace RageLib.Resources.Common;

public class ResourcePointerArray<T> : ResourceSystemBlock, IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable where T : IResourceSystemBlock, new()
{
	public List<uint> data_pointers;

	public List<T> data_items;

	public override long Length => 4 * data_items.Count;

	public int ResSize => data_items.Count;

	public int ResCount
	{
		get
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
	}

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
		int num = Convert.ToInt32(parameters[0]);
		data_pointers = new List<uint>();
		for (int i = 0; i < num; i++)
		{
			data_pointers.Add(reader.ReadUInt32());
		}
		data_items = new List<T>();
		for (int j = 0; j < num; j++)
		{
			data_items.Add(reader.ReadBlockAt<T>(data_pointers[j], new object[0]));
		}
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		data_pointers = new List<uint>();
		foreach (T data_item in data_items)
		{
			if (data_item != null)
			{
				data_pointers.Add((uint)data_item.Position);
			}
			else
			{
				data_pointers.Add(0u);
			}
		}
		foreach (uint data_pointer in data_pointers)
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
		throw new NotImplementedException();
	}

	public void Add(T item)
	{
		data_items.Add(item);
		data_pointers.Add(0u);
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
		foreach (T data_item in data_items)
		{
			yield return data_item;
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}
