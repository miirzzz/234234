using System;

namespace RageLib.Resources;

public class RAGE_AABB : ResourceSystemBlock
{
	public RAGE_Vector4 AABB_Max;

	public RAGE_Vector4 AABB_Min;

	public override long Length => 32L;

	public override void Read(ResourceDataReader reader, params object[] parameters)
	{
		AABB_Max = reader.ReadBlock<RAGE_Vector4>(Array.Empty<object>());
		AABB_Min = reader.ReadBlock<RAGE_Vector4>(Array.Empty<object>());
	}

	public override void Write(ResourceDataWriter writer, params object[] parameters)
	{
		writer.WriteBlock(AABB_Max);
		writer.WriteBlock(AABB_Min);
	}
}
