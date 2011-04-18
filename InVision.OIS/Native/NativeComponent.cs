using System;
using System.Runtime.InteropServices;

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

		[DllImport(OISLibrary, EntryPoint = "ois_component_new")]
		public static extern ComponentExtended New(ComponentType componentType);

		[DllImport(OISLibrary, EntryPoint = "ois_component_delete")]
		public static extern void Delete(IntPtr self);

		[DllImport(OISLibrary, EntryPoint = "ois_create_component_wrapper")]
		[return: MarshalAs(UnmanagedType.Interface)]
		public static extern IComponentWrapper NewWrapper(ComponentType componentType);
	}
}