using System;
using System.Runtime.InteropServices;
using InVision.Native.Ext;

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

		[DllImport(OISLibrary, EntryPoint = "ois_new_axis")]
		public static extern AxisDescriptor New();

		[DllImport(OISLibrary, EntryPoint = "ois_delete_axis")]
		public static extern void Delete(Handle self);
	}
}