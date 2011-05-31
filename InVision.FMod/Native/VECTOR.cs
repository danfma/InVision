using System.Runtime.InteropServices;

namespace InVision.FMod.Native
{
	[StructLayout(LayoutKind.Sequential)]
	public struct VECTOR
	{
		public float x;        /* X co-ordinate in 3D space. */
		public float y;        /* Y co-ordinate in 3D space. */
		public float z;        /* Z co-ordinate in 3D space. */
	}
}