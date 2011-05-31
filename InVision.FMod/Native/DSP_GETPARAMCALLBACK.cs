using System.Text;

namespace InVision.FMod.Native
{
	public delegate RESULT DSP_GETPARAMCALLBACK       (ref DSP_STATE dsp_state, int index, ref float val, StringBuilder valuestr);
}