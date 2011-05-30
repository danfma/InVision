using InVision.FMod.Attributes;

namespace InVision.FMod
{
	[FModEnumeration("FMOD_OPENSTATE")]
	public enum OpenState
	{
		Ready,
		Loading,
		Error,
		Connecting,
		Buffering,
		Seeking,
		Playing,
		SetPosition,
		Max
	}
}