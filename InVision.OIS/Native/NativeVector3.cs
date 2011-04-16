using System;
using System.Runtime.InteropServices;

namespace InVision.OIS.Native
{
	internal class NativeVector3 : NativeOIS
	{
		/// <summary>
		/// Initializes the <see cref="NativeVector3"/> class.
		/// </summary>
		static NativeVector3()
		{
			Init();
		}

		[DllImport(OISLibrary, EntryPoint = "ois_vector3_new")]
		public static extern Vector3Extended New(float x, float y, float z);

		[DllImport(OISLibrary, EntryPoint = "ois_vector3_delete")]
		public static extern void Delete(IntPtr self);
	}
}