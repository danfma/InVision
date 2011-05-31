using System;

namespace InVision.FMod.Native
{
	public delegate RESULT SOUND_PCMREADCALLBACK    (IntPtr soundraw, IntPtr data, uint datalen);
}