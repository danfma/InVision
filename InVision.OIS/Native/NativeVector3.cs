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

		[DllImport(OISLibrary, EntryPoint = "ois_new_vector3")]
		public static extern Vector3Descriptor New(float x, float y, float z);

		[DllImport(OISLibrary, EntryPoint = "ois_delete_vector3")]
		public static extern void Delete(IntPtr self);
	}
}