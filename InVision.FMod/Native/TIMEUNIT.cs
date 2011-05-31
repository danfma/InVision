namespace InVision.FMod.Native
{
	public enum TIMEUNIT
	{
		MS                = 0x00000001,  /* Milliseconds. */
		PCM               = 0x00000002,  /* PCM Samples, related to milliseconds * samplerate / 1000. */
		PCMBYTES          = 0x00000004,  /* Bytes, related to PCM samples * channels * datawidth (ie 16bit = 2 bytes). */
		RAWBYTES          = 0x00000008,  /* Raw file bytes of (compressed) sound data (does not include headers).  Only used by Sound::getLength and Channel::getPosition. */        
		PCMFRACTION       = 0x00000010,  /* Fractions of 1 PCM sample.  Unsigned int range 0 to 0xFFFFFFFF.  Used for sub-sample granularity for DSP purposes. */
		MODORDER          = 0x00000100,  /* MOD/S3M/XM/IT.  Order in a sequenced module format.  Use Sound::getFormat to determine the format. */
		MODROW            = 0x00000200,  /* MOD/S3M/XM/IT.  Current row in a sequenced module format.  Sound::getLength will return the number if rows in the currently playing or seeked to pattern. */
		MODPATTERN        = 0x00000400,  /* MOD/S3M/XM/IT.  Current pattern in a sequenced module format.  Sound::getLength will return the number of patterns in the song and Channel::getPosition will return the currently playing pattern. */
		SENTENCE_MS       = 0x00010000,  /* Currently playing subsound in a sentence time in milliseconds. */
		SENTENCE_PCM      = 0x00020000,  /* Currently playing subsound in a sentence time in PCM Samples, related to milliseconds * samplerate / 1000. */
		SENTENCE_PCMBYTES = 0x00040000,  /* Currently playing subsound in a sentence time in bytes, related to PCM samples * channels * datawidth (ie 16bit = 2 bytes). */
		SENTENCE          = 0x00080000,  /* Currently playing sentence index according to the channel. */
		SENTENCE_SUBSOUND = 0x00100000,  /* Currently playing subsound index in a sentence. */
		BUFFERED          = 0x10000000,  /* Time value as seen by buffered stream.  This is always ahead of audible time, and is only used for processing. */
	}
}