using InVision.FMod.Attributes;

namespace InVision.FMod
{
	[FModEnumeration("FMOD_TAGDATATYPE")]
	public enum TagDataType
	{
		Binary,
		Int,
		Float,
		String,
		StringUtf16,
		StringUtf16Be,
		StringUtf8,
		Cdtoc,
		Max
	}
}