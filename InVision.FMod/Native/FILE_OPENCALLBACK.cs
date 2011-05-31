using System;
using System.Runtime.InteropServices;

namespace InVision.FMod.Native
{
	public delegate RESULT FILE_OPENCALLBACK        ([MarshalAs(UnmanagedType.LPWStr)]string name, int unicode, ref uint filesize, ref IntPtr handle, ref IntPtr userdata);
}