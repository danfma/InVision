using System;
using System.Runtime.InteropServices;

namespace InVision.Ogre3D.Native
{
	internal sealed class NativeMath : PlatformInvoke
	{
		[DllImport(Library, EntryPoint = "MathGetAngleUnit")]
		[return: MarshalAs(UnmanagedType.U4)]
		public static extern AngleUnit GetAngleUnit();

		[DllImport(Library, EntryPoint = "MathSetAngleUnit")]
		public static extern void SetAngleUnit([MarshalAs(UnmanagedType.U4)] AngleUnit angleUnit);

		[DllImport(Library, EntryPoint = "MathRadianToAngleUnit")]
		public static extern float RadianToAngleUnit(float radians);

		[DllImport(Library, EntryPoint = "MathDegreeToAngleUnit")]
		public static extern float DegreeToAngleUnit(float degrees);
	}
}