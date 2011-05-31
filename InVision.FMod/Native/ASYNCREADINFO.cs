using System;
using System.Runtime.InteropServices;

namespace InVision.FMod.Native
{
	[StructLayout(LayoutKind.Sequential)]
	public struct ASYNCREADINFO
	{
		public IntPtr   handle;         /* [r] The file handle that was filled out in the open callback. */
		public uint     offset;         /* [r] Seek position, make sure you read from this file offset. */
		public uint     sizebytes;      /* [r] how many bytes requested for read. */
		public int      priority;       /* [r] 0 = low importance.  100 = extremely important (ie 'must read now or stuttering may occur') */

		public IntPtr   buffer;         /* [w] Buffer to read file data into. */
		public uint     bytesread;      /* [w] Fill this in before setting result code to tell FMOD how many bytes were read. */
		public RESULT   result;         /* [r/w] Result code, FMOD_OK tells the system it is ready to consume the data.  Set this last!  Default value = FMOD_ERR_NOTREADY. */

		public IntPtr   userdata;       /* [r] User data pointer. */
	}
}