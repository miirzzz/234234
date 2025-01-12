using System.Runtime.InteropServices;

namespace RageLib.Compression;

internal class DXTex
{
	[DllImport("DirectXTex.dll", CallingConvention = CallingConvention.Cdecl)]
	public static extern void DeompressImage([MarshalAs(UnmanagedType.LPArray)] byte[] pIn, [MarshalAs(UnmanagedType.LPArray)] byte[] pOut, int width, int height, int stride, int format);

	[DllImport("DirectXTex.dll", CallingConvention = CallingConvention.Cdecl)]
	public static extern void ConvertImage([MarshalAs(UnmanagedType.LPArray)] byte[] pIn, int inFormat, int inStr, [MarshalAs(UnmanagedType.LPArray)] byte[] pOut, int oFormat, int oStr, int width, int height);
}
