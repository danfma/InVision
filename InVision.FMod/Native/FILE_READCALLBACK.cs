using System;

namespace InVision.FMod.Native
{
	public delegate RESULT FILE_READCALLBACK        (IntPtr handle, IntPtr buffer, uint sizebytes, ref uint bytesread, IntPtr userdata);
}