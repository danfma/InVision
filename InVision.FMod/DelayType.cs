using InVision.FMod.Attributes;

namespace InVision.FMod
{
	[FModEnumeration("FMOD_DELAYTYPE")]
	public enum DelayType
	{
		EndMs,
		DspclockStart,
		DspclockEnd,
		DspclockPause,
		Max
	}
}