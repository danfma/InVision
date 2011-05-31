namespace InVision.FMod.Native
{
	public enum MEMBITS :uint
	{
		OTHER                     = 0x00000001,               /* Memory not accounted for by other types */
		STRING                    = 0x00000002,              /* String data */

		SYSTEM                    = 0x00000004,              /* System object and various internals */
		PLUGINS                   = 0x00000008,             /* Plugin objects and internals */
		OUTPUT                    = 0x00000010,              /* Output module object and internals */
		CHANNEL                   = 0x00000020,             /* Channel related memory */
		CHANNELGROUP              = 0x00000040,        /* ChannelGroup objects and internals */
		CODEC                     = 0x00000080,               /* Codecs allocated for streaming */
		FILE                      = 0x00000100,                /* Codecs allocated for streaming */
		SOUND                     = 0x00000200,               /* Sound objects and internals */
		SOUND_SECONDARYRAM        = 0x00000400,  /* Sound data stored in secondary RAM */
		SOUNDGROUP                = 0x00000800,          /* SoundGroup objects and internals */
		STREAMBUFFER              = 0x00001000,        /* Stream buffer memory */
		DSPCONNECTION             = 0x00002000,       /* DSPConnection objects and internals */
		DSP                       = 0x00004000,                 /* DSP implementation objects */
		DSPCODEC                  = 0x00008000,            /* Realtime file format decoding DSP objects */
		PROFILE                   = 0x00010000,             /* Profiler memory footprint. */
		RECORDBUFFER              = 0x00020000,        /* Buffer used to store recorded data from microphone */
		REVERB                    = 0x00040000,              /* Reverb implementation objects */
		REVERBCHANNELPROPS        = 0x00080000,  /* Reverb channel properties structs */
		GEOMETRY                  = 0x00100000,            /* Geometry objects and internals */
		SYNCPOINT                 = 0x00200000,           /* Sync point memory. */
		ALL                       = 0xffffffff                          /* All memory used by FMOD Ex */
	}
}