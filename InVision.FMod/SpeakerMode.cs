using InVision.FMod.Attributes;

namespace InVision.FMod
{
	[FModEnumeration("FMOD_SPEAKERMODE")]
	public enum SpeakerMode
	{
		Raw,
		Mono,
		Stereo,
		Quad,
		Surround,
		FivePoint1,
		SevenPoint1,
		Prologic,
		Max
	}
}