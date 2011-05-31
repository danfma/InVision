using System;

namespace InVision.FMod.Native
{
	public delegate RESULT FILE_SEEKCALLBACK        (IntPtr handle, int pos, IntPtr userdata);
}