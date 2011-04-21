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

		[DllImport(OISLibrary, EntryPoint = "ois_new_component")]
		public static extern ComponentProxyInfo NewProxy(ComponentType componentType);

		[DllImport(OISLibrary, EntryPoint = "ois_delete_component")]
		public static extern void DeleteProxy(IntPtr proxy);
	}

	[StructLayout(LayoutKind.Sequential)]
	internal unsafe struct ComponentProxyInfo
	{
		private IntPtr handle;
		private ComponentType* type;

		/// <summary>
		/// Initializes a new instance of the <see cref="ComponentProxyInfo"/> struct.
		/// </summary>
		/// <param name="handle">The handle.</param>
		/// <param name="type">The type.</param>
		public ComponentProxyInfo(IntPtr handle, ComponentType* type)
		{
			this.handle = handle;
			this.type = type;
		}

		public IntPtr Handle
		{
			get { return handle; }
		}

		public ComponentType Type
		{
			get { return *type; }
		}
	}
}