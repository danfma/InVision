using System;
using System.Runtime.InteropServices;

namespace InVision.OIS.Native
{
	internal class NativeAxis : NativeOIS
	{
		/// <summary>
		/// Initializes the <see cref="NativeAxis"/> class.
		/// </summary>
		static NativeAxis()
		{
			Init();
		}

		[DllImport(OISLibrary, EntryPoint = "ois_axis_new")]
		public static extern AxisExtended New();

		[DllImport(OISLibrary, EntryPoint = "ois_axis_delete")]
		public static extern void Delete(IntPtr self);
	}
}