using System;
using System.Collections.Generic;

namespace RageLib.Resources.Common;

public class ResourceSimpleArrayArray64<T> : ListBase<ResourceSimpleArray<T>> where T : IResourceSystemBlock, new()
{
	public List<ulong> ptr_list;

	public override long Length
	{
		get
		{
			long num = 8 * base.Data.Count;
			foreach (ResourceSimpleArray<T> datum in base.Data)
			{
				num += datum.Length;
			}
			return num;
		}
	}

	public ResourceSimpleArrayArray64()
	{
		base.Data = new List<ResourceSimpleArray<T>>();
	}

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		ResourceSimpleArray<uint_r> resourceSimpleArray = (ResourceSimpleArray<uint_r>)parameters[1];
		ptr_list = new List<ulong>();
		for (int i = 0; i < resourceSimpleArray.Count; i++)
		{
			ptr_list.Add(reader.ReadUInt64());
		}
		for (int j = 0; j < resourceSimpleArray.Count; j++)
		{
			ResourceSimpleArray<T> item = reader.ReadBlockAt<ResourceSimpleArray<T>>(ptr_list[j], new object[1] { (uint)resourceSimpleArray[j] });
			base.Data.Add(item);
		}
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		ptr_list = new List<ulong>();
		foreach (ResourceSimpleArray<T> datum in base.Data)
		{
			ptr_list.Add((ulong)datum.Position);
		}
		foreach (ulong item in ptr_list)
		{
			writer.Write(item);
		}
		foreach (ResourceSimpleArray<T> datum2 in base.Data)
		{
			datum2.Write(writer);
		}
	}

	public override IResourceBlock[] GetReferences()
	{
		return new List<IResourceBlock>().ToArray();
	}

	public override Tuple<long, IResourceBlock>[] GetParts()
	{
		List<Tuple<long, IResourceBlock>> list = new List<Tuple<long, IResourceBlock>>();
		if (base.Data != null)
		{
			long num = 8 * base.Data.Count;
			foreach (ResourceSimpleArray<T> datum in base.Data)
			{
				list.Add(new Tuple<long, IResourceBlock>(num, datum));
				num += datum.Length;
			}
		}
		return list.ToArray();
	}
}
