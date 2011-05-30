using InVision.FMod.Attributes;

namespace InVision.FMod
{
	[FModEnumeration("FMOD_DSP_FFT_WINDOW")]
	public enum DspFftWindow
	{
		Rect,
		Triangle,
		Hamming,
		Hanning,
		Blackman,
		BlackManharris,
		Max
	}
}