using System;

namespace InVision.FMod.Native
{
	public delegate RESULT CHANNEL_CALLBACK         (IntPtr channelraw, CHANNEL_CALLBACKTYPE type, IntPtr commanddata1, IntPtr commanddata2);
}