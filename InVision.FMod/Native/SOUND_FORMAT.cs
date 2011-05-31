namespace InVision.FMod.Native
{
	public enum SOUND_FORMAT :int
	{
		NONE,     /* Unitialized / unknown */
		PCM8,     /* 8bit integer PCM data */
		PCM16,    /* 16bit integer PCM data  */
		PCM24,    /* 24bit integer PCM data  */
		PCM32,    /* 32bit integer PCM data  */
		PCMFLOAT, /* 32bit floating point PCM data  */
		GCADPCM,  /* Compressed GameCube DSP data */
		IMAADPCM, /* Compressed XBox ADPCM data */
		VAG,      /* Compressed PlayStation 2 ADPCM data */
		HEVAG,    /* Compressed NGP ADPCM data. */
		XMA,      /* Compressed Xbox360 data. */
		MPEG,     /* Compressed MPEG layer 2 or 3 data. */
		MAX,      /* Maximum number of sound formats supported. */ 
		CELT,     /* Compressed CELT data. */
		AT9,      /* Compressed ATRAC9 data. */
	}
}