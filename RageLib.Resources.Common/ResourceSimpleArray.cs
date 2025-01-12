using System;
using System.Collections.Generic;

namespace RageLib.Resources.Common;

public class ResourceSimpleArray<T> : ListBase<T> where T : IResourceSystemBlock, new()
{
	public override long Length
	{
		get
		{
			long num = 0L;
			foreach (T datum in base.Data)
			{
				num += datum.Length;
			}
			return num;
		}
	}

	public ResourceSimpleArray()
	{
		base.Data = new List<T>();
	}

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		int num = Convert.ToInt32(parameters[0]);
		base.Data = new List<T>();
		for (int i = 0; i < num; i++)
		{
			T item = reader.ReadBlock<T>(new object[0]);
			base.Data.Add(item);
		}
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		foreach (T datum in base.Data)
		{
			datum.Write(writer);
		}
	}

	public override Tuple<long, IResourceBlock>[] GetParts()
	{
		List<Tuple<long, IResourceBlock>> list = new List<Tuple<long, IResourceBlock>>();
		long num = 0L;
		foreach (T datum in base.Data)
		{
			list.Add(new Tuple<long, IResourceBlock>(num, datum));
			num += datum.Length;
		}
		return list.ToArray();
	}
}
