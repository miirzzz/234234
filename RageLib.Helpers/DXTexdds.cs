using System.Runtime.InteropServices;

namespace RageLib.Helpers;

internal class DXTexdds
{
	[DllImport("DirectXTex.dll", CallingConvention = CallingConvention.Cdecl)]
	public static extern void SaveDDSImage([MarshalAs(UnmanagedType.LPWStr)] string fileName, [MarshalAs(UnmanagedType.LPArray)] byte[] pIn, int size, int width, int height, int stride, int mipLevels, int format);

	[DllImport("DirectXTex.dll", CallingConvention = CallingConvention.Cdecl)]
	public static extern void LoadDDSImage([MarshalAs(UnmanagedType.LPWStr)] string fileName, [MarshalAs(UnmanagedType.LPArray)] byte[] dataPointer, ref int dataLength, ref int width, ref int height, ref int stride, ref int mipLevels, ref int format);

	[DllImport("DirectXTex.dll", CallingConvention = CallingConvention.Cdecl)]
	public static extern void SaveDDSImageToStream([MarshalAs(UnmanagedType.LPArray)] byte[] pStreamData, ref int length, [MarshalAs(UnmanagedType.LPArray)] byte[] pIn, int size, int width, int height, int stride, int mipLevels, int format);

	[DllImport("DirectXTex.dll", CallingConvention = CallingConvention.Cdecl)]
	public static extern void LoadDDSImageFromStream([MarshalAs(UnmanagedType.LPArray)] byte[] pStreamData, int streamLength, [MarshalAs(UnmanagedType.LPArray)] byte[] dataPointer, ref int dataLength, ref int width, ref int height, ref int stride, ref int mipLevels, ref int format);
}
