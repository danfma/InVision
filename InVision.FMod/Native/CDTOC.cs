using System.Runtime.InteropServices;

namespace InVision.FMod.Native
{
	[StructLayout(LayoutKind.Sequential)]
	public struct CDTOC
	{
		public int numtracks;                  /* [out] The number of tracks on the CD */
		[MarshalAs(UnmanagedType.ByValArray,SizeConst=100)]
		public int[] min;                   /* [out] The start offset of each track in minutes */
		[MarshalAs(UnmanagedType.ByValArray,SizeConst=100)]
		public int[] sec;                   /* [out] The start offset of each track in seconds */
		[MarshalAs(UnmanagedType.ByValArray,SizeConst=100)]
		public int[] frame;                 /* [out] The start offset of each track in frames */
	}
}