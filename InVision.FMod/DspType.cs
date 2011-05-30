using InVision.FMod.Attributes;

namespace InVision.FMod
{
	[FModEnumeration("FMOD_DSP_TYPE")]
	public enum DspType
	{
		Unknown,
		Mixer,
		Oscillator,
		Lowpass,
		ItLowpass,
		Highpass,
		Echo,
		Flange,
		Distortion,
		Normalize,
		Parameq,
		PitchShift,
		Chorus,
		Reverb,
		VstPlugin,
		WinampPlugin,
		Itecho,
		Compressor,
		SfxReverb,
		LowpassSimple,
		Delay,
		Tremolo,
		LadspaPlugin
	}
}