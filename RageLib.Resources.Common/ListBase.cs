using System.Collections;
using System.Collections.Generic;

namespace RageLib.Resources.Common;

public abstract class ListBase<T> : ResourceSystemBlock, IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable where T : IResourceSystemBlock, new()
{
	public List<T> Data { get; set; }

	public T this[int index]
	{
		get
		{
			return Data[index];
		}
		set
		{
			Data[index] = value;
		}
	}

	public int Count => Data.Count;

	public bool IsReadOnly => false;

	public ListBase()
	{
		Data = new List<T>();
	}

	public void Add(T item)
	{
		Data.Add(item);
	}

	public void Clear()
	{
		Data.Clear();
	}

	public bool Contains(T item)
	{
		return Data.Contains(item);
	}

	public void CopyTo(T[] array, int arrayIndex)
	{
		Data.CopyTo(array, arrayIndex);
	}

	public IEnumerator<T> GetEnumerator()
	{
		return Data.GetEnumerator();
	}

	public int IndexOf(T item)
	{
		return Data.IndexOf(item);
	}

	public void Insert(int index, T item)
	{
		Data.Insert(index, item);
	}

	public bool Remove(T item)
	{
		return Data.Remove(item);
	}

	public void RemoveAt(int index)
	{
		Data.RemoveAt(index);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return Data.GetEnumerator();
	}
}
