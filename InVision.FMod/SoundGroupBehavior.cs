using InVision.FMod.Attributes;

namespace InVision.FMod
{
	[FModEnumeration("FMOD_SOUNDGROUP_BEHAVIOR")]
	public enum SoundGroupBehavior
	{
		Fail,
		Mute,
		Steallowest,
		Max
	}
}