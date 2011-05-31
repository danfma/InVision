using System;

namespace InVision.FMod.Native
{
	public delegate RESULT DSP_READCALLBACK           (ref DSP_STATE dsp_state, IntPtr inbuffer, IntPtr outbuffer, uint length, int inchannels, int outchannels);
}