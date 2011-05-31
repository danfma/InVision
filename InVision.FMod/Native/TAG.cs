using System;
using System.Runtime.InteropServices;

namespace InVision.FMod.Native
{
	[StructLayout(LayoutKind.Sequential)]
	public struct TAG
	{
		public TAGTYPE           type;         /* [out] The type of this tag. */
		public TAGDATATYPE       datatype;     /* [out] The type of data that this tag contains */
		public IntPtr            namePtr;      /* [out] The name of this tag i.e. "TITLE", "ARTIST" etc. */
		public IntPtr            data;         /* [out] Pointer to the tag data - its format is determined by the datatype member */
		public uint              datalen;      /* [out] Length of the data contained in this tag */
		public bool              updated;      /* [out] True if this tag has been updated since last being accessed with Sound::getTag */

		public string name { get { return Marshal.PtrToStringAnsi(namePtr); } }
	}
}