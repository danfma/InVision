using System.Runtime.InteropServices;

namespace InVision.FMod.Native
{
	[StructLayout(LayoutKind.Sequential)]
	public struct REVERB_CHANNELFLAGS
	{
		public const uint DIRECTHFAUTO  = 0x00000001; /* Automatic setting of 'Direct'  due to distance from listener */
		public const uint ROOMAUTO      = 0x00000002; /* Automatic setting of 'Room'  due to distance from listener */
		public const uint ROOMHFAUTO    = 0x00000004; /* Automatic setting of 'RoomHF' due to distance from listener */
		public const uint INSTANCE0     = 0x00000010; /* SFX/Wii. Specify channel to target reverb instance 0.  Default target. */
		public const uint INSTANCE1     = 0x00000020; /* SFX/Wii. Specify channel to target reverb instance 1. */
		public const uint INSTANCE2     = 0x00000040; /* SFX/Wii. Specify channel to target reverb instance 2. */
		public const uint INSTANCE3     = 0x00000080; /* SFX. Specify channel to target reverb instance 3. */
		public const uint DEFAULT       = (DIRECTHFAUTO | ROOMAUTO | ROOMHFAUTO | INSTANCE0);
	}
}