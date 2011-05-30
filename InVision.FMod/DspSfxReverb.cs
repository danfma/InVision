using InVision.FMod.Attributes;

namespace InVision.FMod
{
	[FModEnumeration("FMOD_DSP_SFXREVERB")]
	public enum DspSfxReverb
	{
		DryLevel,
		Room,
		RoomHf,
		RoomRolloffFactor,
		DecayTime,
		DecayHFratio,
		ReflectionsLevel,
		ReflectionsDelay,
		ReverbLevel,
		ReverbDelay,
		Diffusion,
		Density,
		HfReference,
		RoomLf,
		LfReference
	}
}