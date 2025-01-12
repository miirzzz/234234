using System;
using System.Collections.Generic;

namespace RageLib.Resources;

public static class ResourceHelpers
{
	private const int SKIP_SIZE = 64;

	private const int ALIGN_SIZE = 64;

	public static void GetBlocks(IResourceBlock rootBlock, out IList<IResourceBlock> sys, out IList<IResourceBlock> gfx)
	{
		HashSet<IResourceBlock> hashSet = new HashSet<IResourceBlock>();
		HashSet<IResourceBlock> hashSet2 = new HashSet<IResourceBlock>();
		List<IResourceBlock> list = new List<IResourceBlock>();
		Stack<IResourceBlock> stack = new Stack<IResourceBlock>();
		stack.Push(rootBlock);
		HashSet<IResourceBlock> hashSet3 = new HashSet<IResourceBlock>();
		hashSet3.Add(rootBlock);
		while (stack.Count > 0)
		{
			IResourceBlock resourceBlock = stack.Pop();
			if (resourceBlock == null)
			{
				continue;
			}
			if (resourceBlock is IResourceSystemBlock)
			{
				if (!hashSet.Contains(resourceBlock))
				{
					hashSet.Add(resourceBlock);
				}
				IResourceBlock[] references = ((IResourceSystemBlock)resourceBlock).GetReferences();
				foreach (IResourceBlock item in references)
				{
					if (!hashSet3.Contains(item))
					{
						stack.Push(item);
						hashSet3.Add(item);
					}
				}
				Stack<IResourceSystemBlock> stack2 = new Stack<IResourceSystemBlock>();
				Tuple<long, IResourceBlock>[] parts = ((IResourceSystemBlock)resourceBlock).GetParts();
				foreach (Tuple<long, IResourceBlock> tuple in parts)
				{
					stack2.Push((IResourceSystemBlock)tuple.Item2);
				}
				while (stack2.Count > 0)
				{
					IResourceSystemBlock resourceSystemBlock = stack2.Pop();
					references = resourceSystemBlock.GetReferences();
					foreach (IResourceBlock item2 in references)
					{
						if (!hashSet3.Contains(item2))
						{
							stack.Push(item2);
							hashSet3.Add(item2);
						}
					}
					parts = resourceSystemBlock.GetParts();
					foreach (Tuple<long, IResourceBlock> tuple2 in parts)
					{
						stack2.Push((IResourceSystemBlock)tuple2.Item2);
					}
					list.Add(resourceSystemBlock);
				}
			}
			else if (!hashSet2.Contains(resourceBlock))
			{
				hashSet2.Add(resourceBlock);
			}
		}
		foreach (IResourceBlock item3 in list)
		{
			if (hashSet.Contains(item3))
			{
				hashSet.Remove(item3);
			}
		}
		sys = new List<IResourceBlock>();
		foreach (IResourceBlock item4 in hashSet)
		{
			sys.Add(item4);
		}
		gfx = new List<IResourceBlock>();
		foreach (IResourceBlock item5 in hashSet2)
		{
			gfx.Add(item5);
		}
	}

	public static void AssignPositions(IList<IResourceBlock> blocks, uint basePosition, ref int pageSize, out int pageCount)
	{
		long num = 0L;
		foreach (IResourceBlock block in blocks)
		{
			if (num < block.Length)
			{
				num = block.Length;
			}
		}
		long num2;
		for (num2 = 8192L; num2 < num; num2 *= 2)
		{
		}
		long num3;
		while (true)
		{
			num3 = 0L;
			long num4 = 0L;
			foreach (IResourceBlock block2 in blocks)
			{
				block2.Position = -1L;
			}
			foreach (IResourceBlock block3 in blocks)
			{
				if (block3.Position != -1)
				{
					throw new Exception("A position of -1 is not possible!");
				}
				if (num3 * num2 - num4 < block3.Length + 64)
				{
					num3++;
					num4 = num2 * (num3 - 1);
				}
				block3.Position = basePosition + num4;
				num4 += block3.Length + 64;
				if (num4 % 64 != 0L)
				{
					num4 += 64 - num4 % 64;
				}
			}
			if (num3 < 128)
			{
				break;
			}
			num2 *= 2;
		}
		pageSize = (int)num2;
		pageCount = (int)num3;
	}
}
