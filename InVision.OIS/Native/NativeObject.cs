using System;
using System.Runtime.InteropServices;

namespace InVision.OIS.Native
{
	internal class NativeObject : NativeOIS
	{
		/// <summary>
		/// Initializes the <see cref="NativeObject"/> class.
		/// </summary>
		static NativeObject()
		{
			Init();
		}

		[DllImport(OISLibrary, EntryPoint = "ois_object_delete")]
		public static extern void Delete(IntPtr self);

		[DllImport(OISLibrary, EntryPoint = "ois_object_type")]
		public static extern DeviceType GetType(IntPtr self);

		[DllImport(OISLibrary, EntryPoint = "ois_object_vendor")]
		public static extern string GetVendor(IntPtr self);

		[DllImport(OISLibrary, EntryPoint = "ois_object_get_buffered")]
		public static extern bool GetBuffered(IntPtr self);

		[DllImport(OISLibrary, EntryPoint = "ois_object_set_buffered")]
		public static extern void SetBuffered(IntPtr self, bool value);

		[DllImport(OISLibrary, EntryPoint = "ois_object_get_creator")]
		public static extern IntPtr GetCreator(IntPtr self);

		[DllImport(OISLibrary, EntryPoint = "ois_object_capture")]
		public static extern void Capture(IntPtr self);

		[DllImport(OISLibrary, EntryPoint = "ois_object_get_id")]
		public static extern int GetId(IntPtr self);

		[DllImport(OISLibrary, EntryPoint = "ois_object_query_interface")]
		public static extern IntPtr QueryInterface(IntPtr self, InterfaceType itype);
	}
}