using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;
using InVision.Extensions;
using InVision.Input;

namespace InVision.Native.OIS
{
	internal sealed class NativeObject : PlatformInvoke
	{
		[DllImport(Library, EntryPoint = "ois_object_delete")]
		public static extern void Delete(IntPtr self);

		[DllImport(Library, EntryPoint = "ois_object_get_type")]
		[return: MarshalAs(UnmanagedType.I4)]
		public static extern InputType GetType(IntPtr self);

		[DllImport(Library, EntryPoint = "ois_object_get_vendor")]
		public static extern IntPtr _GetVendor(IntPtr self);

		[DllImport(Library, EntryPoint = "ois_object_get_buffered")]
		public static extern bool GetBuffered(IntPtr self);

		[DllImport(Library, EntryPoint = "ois_object_set_buffered")]
		public static extern void SetBuffered(IntPtr self, bool value);

		[DllImport(Library, EntryPoint = "ois_object_get_creator")]
		public static extern IntPtr _GetCreator(IntPtr self);

		[DllImport(Library, EntryPoint = "ois_object_capture")]
		public static extern void Capture(IntPtr self);

		[DllImport(Library, EntryPoint = "ois_object_get_id")]
		public static extern int GetId(IntPtr self);

		[DllImport(Library, EntryPoint = "ois_object_query_interface")]
		public static extern IntPtr _QueryInterface(IntPtr self, InterfaceType interfaceType);

		#region Helpers

		public static readonly Dictionary<InputType, Type> InputObjectTypeMapping =
			new Dictionary<InputType, Type>
				{
					{InputType.Mouse, typeof (Mouse)},
					{InputType.Keyboard, typeof(Keyboard)}
				};

		public static string GetVendor(IntPtr self)
		{
			return _GetVendor(self).AsConstString();
		}

		public static InputManager GetCreator(IntPtr self)
		{
			return _GetCreator(self).AsHandle(ptr => new InputManager(ptr, false));
		}

		public static IntPtr QueryInterface(IntPtr self, InterfaceType interfaceType)
		{
			throw new NotImplementedException();
		}

		#endregion

		/// <summary>
		/// Creates the specified input type.
		/// </summary>
		/// <param name="inputType">Type of the input.</param>
		/// <param name="handle">The handle.</param>
		/// <param name="isReference">if set to <c>true</c> [is reference].</param>
		/// <returns></returns>
		public static InputObject Create(InputType inputType, IntPtr handle, bool isReference)
		{
			Type type;

			if (!InputObjectTypeMapping.TryGetValue(inputType, out type))
				type = typeof(UnknownInputObject);

			return handle.AsHandle(ptr => (InputObject)type.CreateInstance(handle, !isReference));
		}
	}
}