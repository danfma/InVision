using System;
using System.Runtime.InteropServices;
using InVision.Native.Ext;
using InVision.OIS.Components;

namespace InVision.OIS.Native
{
	[GeneratorType, FunctionProvider, TargetCppType("Component", Namespace = "OIS")]
	internal class NativeComponent : NativeOIS
	{
		/// <summary>
		/// Initializes the <see cref="NativeComponent"/> class.
		/// </summary>
		static NativeComponent()
		{
			Init();
		}

		[DllImport(OISLibrary, EntryPoint = "new_component_by_ctype")]
		public static extern ComponentDescriptor New(ComponentType ctype);

		/// <summary>
		/// Deletes the specified handle.
		/// </summary>
		/// <param name="handle">The handle.</param>
		[DllImport(OISLibrary, EntryPoint = "delete_component")]
		public static extern void Delete(Handle handle);
	}
}