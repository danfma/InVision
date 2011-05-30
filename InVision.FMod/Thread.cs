using InVision.FMod.Attributes;

namespace InVision.FMod
{
	[FModEnumeration("FMOD_THREAD")]
	public enum Thread
	{
		Default,
		Core0Thread0,
		Core0Thread1,
		Core1Thread0,
		Core1Thread1,
		Core2Thread0,
		Core2Thread1,
		Max
	}
}