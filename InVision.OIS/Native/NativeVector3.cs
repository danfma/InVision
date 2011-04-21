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

		[DllImport(OISLibrary, EntryPoint = "ois_new_vector3")]
		public static extern Vector3ProxyInfo NewProxy(float x, float y, float z);
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void Vector3ClearMethod(IntPtr self);


	[StructLayout(LayoutKind.Sequential)]
	internal unsafe struct Vector3ProxyInfo
	{
		private readonly ComponentProxyInfo @base;
		private readonly float* x;
		private readonly float* y;
		private readonly float* z;
		private readonly IntPtr* clearMethod;

		public ComponentProxyInfo Base
		{
			get { return @base; }
		}

		public float X
		{
			get { return *x; }
		}

		public float Y
		{
			get { return *y; }
		}

		public float Z
		{
			get { return *z; }
		}

		public Vector3ClearMethod ClearMethod
		{
			get { return (Vector3ClearMethod)Marshal.GetDelegateForFunctionPointer(*clearMethod, typeof(Vector3ClearMethod)); }
			set { *clearMethod = Marshal.GetFunctionPointerForDelegate(value); }
		}

		public VTable CreateVTable()
		{
			return new VTable
			{
				ClearMethod = ClearMethod
			};
		}

		internal struct VTable
		{
			public Vector3ClearMethod ClearMethod;
		}
	}
}