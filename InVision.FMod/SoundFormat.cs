using InVision.FMod.Attributes;

namespace InVision.FMod
{
	[FModEnumeration("FMOD_SOUND_FORMAT")]
	public enum SoundFormat
	{
		None,
		Pcm8,
		Pcm16,
		Pcm24,
		Pcm32,
		Pcmfloat,
		Gcadpcm,
		Imaadpcm,
		Vag,
		Xma,
		Mpeg,
		Celt,
		Max
	}
}