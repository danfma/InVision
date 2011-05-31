using System;

namespace InVision.FMod.Native
{
	public struct DSP_STATE
	{
		public IntPtr   instance;      /* [out] Handle to the DSP hand the user created.  Not to be modified.  C++ users cast to FMOD::DSP to use.  */
		public IntPtr   plugindata;    /* [in] Plugin writer created data the output author wants to attach to this object. */
		public ushort   speakermask;   /* Specifies which speakers the DSP effect is active on */
	};
}