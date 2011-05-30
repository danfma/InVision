using InVision.FMod.Attributes;

namespace InVision.FMod
{
	[FModEnumeration("FMOD_DSP_RESAMPLER")]
	public enum DspResampler
	{
		Nointerp,
		Linear,
		Cubic,
		Spline,
		Max
	}
}