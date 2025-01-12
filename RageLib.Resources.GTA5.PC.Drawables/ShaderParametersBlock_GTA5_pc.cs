using System;
using System.Collections.Generic;
using RageLib.Resources.Common;
using RageLib.Resources.GTA5.PC.Textures;

namespace RageLib.Resources.GTA5.PC.Drawables;

public class ShaderParametersBlock_GTA5_pc : ResourceSystemBlock
{
	public List<ShaderParameter> Parameters = new List<ShaderParameter>();

	public List<uint> Hashes = new List<uint>();

	public override long Length
	{
		get
		{
			long num = 0L;
			foreach (ShaderParameter parameter in Parameters)
			{
				_ = parameter;
				num += 16;
			}
			foreach (ShaderParameter parameter2 in Parameters)
			{
				num += 16 * parameter2.DataType;
			}
			return num + Parameters.Count * 4;
		}
	}

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		int num = Convert.ToInt32(parameters[0]);
		Parameters = new List<ShaderParameter>();
		for (int i = 0; i < num; i++)
		{
			Parameters.Add(reader.ReadBlock<ShaderParameter>(Array.Empty<object>()));
		}
		int num2 = 0;
		for (int j = 0; j < num; j++)
		{
			ShaderParameter shaderParameter = Parameters[j];
			switch (shaderParameter.DataType)
			{
			case 0:
				num2 = num2;
				shaderParameter.Data = reader.ReadBlockAt<Texture>(shaderParameter.DataPointer, Array.Empty<object>());
				break;
			case 1:
				num2 += 16;
				shaderParameter.Data = reader.ReadBlockAt<RAGE_Vector4>(shaderParameter.DataPointer, Array.Empty<object>());
				break;
			default:
				num2 += 16 * shaderParameter.DataType;
				shaderParameter.Data = reader.ReadBlockAt<ResourceSimpleArray<RAGE_Vector4>>(shaderParameter.DataPointer, new object[1] { shaderParameter.DataType });
				break;
			}
		}
		reader.Position += num2;
		Hashes = new List<uint>();
		for (int k = 0; k < num; k++)
		{
			Hashes.Add(reader.ReadUInt32());
		}
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		foreach (ShaderParameter parameter in Parameters)
		{
			if (parameter.Data != null)
			{
				parameter.DataPointer = (ulong)parameter.Data.Position;
			}
			else
			{
				parameter.DataPointer = 0uL;
			}
		}
		foreach (ShaderParameter parameter2 in Parameters)
		{
			writer.WriteBlock(parameter2);
		}
		foreach (ShaderParameter parameter3 in Parameters)
		{
			if (parameter3.DataType != 0)
			{
				writer.WriteBlock(parameter3.Data);
			}
		}
		foreach (uint hash in Hashes)
		{
			writer.Write(hash);
		}
	}

	public override IResourceBlock[] GetReferences()
	{
		List<IResourceBlock> list = new List<IResourceBlock>();
		list.AddRange(base.GetReferences());
		foreach (ShaderParameter parameter in Parameters)
		{
			if (parameter.DataType == 0)
			{
				list.Add(parameter.Data);
			}
		}
		return list.ToArray();
	}

	public override Tuple<long, IResourceBlock>[] GetParts()
	{
		List<Tuple<long, IResourceBlock>> list = new List<Tuple<long, IResourceBlock>>();
		list.AddRange(base.GetParts());
		long num = 0L;
		foreach (ShaderParameter parameter in Parameters)
		{
			list.Add(new Tuple<long, IResourceBlock>(num, parameter));
			num += 16;
		}
		foreach (ShaderParameter parameter2 in Parameters)
		{
			if (parameter2.DataType != 0)
			{
				list.Add(new Tuple<long, IResourceBlock>(num, parameter2.Data));
			}
			num += 16 * parameter2.DataType;
		}
		return list.ToArray();
	}
}
