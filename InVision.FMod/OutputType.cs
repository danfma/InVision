using InVision.FMod.Attributes;

namespace InVision.FMod
{
	[FModEnumeration("FMOD_OUTPUTTYPE")]
	public enum OutputType
	{
		AutoDetect,
		Unknown,
		NoSound,
		WavWriter,
		NoSoundNrt,
		WavWriterNrt,
		DSound,
		Winmm,
		Wasapi,
		Asio,
		Oss,
		Alsa,
		Esd,
		PulseAudio,
		CoreAudio,
		Ps2,
		Ps3,
		Xbox360,
		Psp,
		Wii,
		Android,
		ThreeDs,
		Max
	}
}