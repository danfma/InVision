using System;
using System.Runtime.InteropServices;
using InVision.OIS.Components;

namespace InVision.OIS.Native
{
	internal class NativeComponent : NativeOIS
	{
		/// <summary>
		/// Initializes the <see cref="NativeComponent"/> class.
		/// </summary>
		static NativeComponent()
		{
			Init();
		}

		[DllImport(OISLibrary, EntryPoint = "ois_new_component")]
		public static extern ComponentDescriptor New(ComponentType componentType);

		[DllImport(OISLibrary, EntryPoint = "ois_delete_component")]
		public static extern void Delete(IntPtr self);
	}
}