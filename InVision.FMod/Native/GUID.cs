using System.Runtime.InteropServices;

namespace InVision.FMod.Native
{
	[StructLayout(LayoutKind.Sequential)]
	public struct GUID
	{
		public uint   Data1;       /* Specifies the first 8 hexadecimal digits of the GUID */
		public ushort Data2;       /* Specifies the first group of 4 hexadecimal digits.   */
		public ushort Data3;       /* Specifies the second group of 4 hexadecimal digits.  */
		[MarshalAs(UnmanagedType.ByValArray,SizeConst=8)]
		public byte[] Data4;       /* Array of 8 bytes. The first 2 bytes contain the third group of 4 hexadecimal digits. The remaining 6 bytes contain the final 12 hexadecimal digits. */
	}
}