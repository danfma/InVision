using System;

namespace InVision.FMod.Native
{
	public delegate RESULT SOUND_PCMSETPOSCALLBACK  (IntPtr soundraw, int subsound, uint position, TIMEUNIT postype);
}