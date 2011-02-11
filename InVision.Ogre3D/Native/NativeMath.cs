using System;
using System.Runtime.InteropServices;

namespace InVision.Ogre3D.Native
{
	internal sealed class NativeMath : PlatformInvoke
	{
		[DllImport(Library, EntryPoint = "math_get_angle_unit")]
		[return: MarshalAs(UnmanagedType.U4)]
		public static extern AngleUnit GetAngleUnit();

		[DllImport(Library, EntryPoint = "math_set_angle_unit")]
		public static extern void SetAngleUnit([MarshalAs(UnmanagedType.U4)] AngleUnit angleUnit);

		[DllImport(Library, EntryPoint = "math_radian_to_angle_unit")]
		public static extern float RadianToAngleUnit(float radians);

		[DllImport(Library, EntryPoint = "math_degree_to_angle_unit")]
		public static extern float DegreeToAngleUnit(float degrees);
	}
}