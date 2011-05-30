using System;
using System.Runtime.InteropServices;
using InVision.Native;

namespace InVision.Ogre.Native
{
	[CppValueObject]
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct Setting
	{
		public IntPtr Name;
		public IntPtr Value;
		public Setting* Next;

		/// <summary>
		/// Gets the name string.
		/// </summary>
		/// <value>The name string.</value>
		public string NameString
		{
			get { return Marshal.PtrToStringAnsi(Name); }
		}

		/// <summary>
		/// Gets the value string.
		/// </summary>
		/// <value>The value string.</value>
		public string ValueString
		{
			get { return Marshal.PtrToStringAnsi(Value); }
		}
	}
}