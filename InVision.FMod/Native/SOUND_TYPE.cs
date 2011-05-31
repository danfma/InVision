namespace InVision.FMod.Native
{
	public enum SOUND_TYPE
	{
		UNKNOWN,         /* 3rd party / unknown plugin format. */
		AAC,             /* AAC.  Currently unsupported. */
		AIFF,            /* AIFF. */
		ASF,             /* Microsoft Advanced Systems Format (ie WMA/ASF/WMV). */
		AT3,             /* Sony ATRAC 3 format */
		CDDA,            /* Digital CD audio. */
		DLS,             /* Sound font / downloadable sound bank. */
		FLAC,            /* FLAC lossless codec. */
		FSB,             /* FMOD Sample Bank. */
		GCADPCM,         /* GameCube ADPCM */
		IT,              /* Impulse Tracker. */
		MIDI,            /* MIDI. */
		MOD,             /* Protracker / Fasttracker MOD. */
		MPEG,            /* MP2/MP3 MPEG. */
		OGGVORBIS,       /* Ogg vorbis. */
		PLAYLIST,        /* Information only from ASX/PLS/M3U/WAX playlists */
		RAW,             /* Raw PCM data. */
		S3M,             /* ScreamTracker 3. */
		SF2,             /* Sound font 2 format. */
		USER,            /* User created sound. */
		WAV,             /* Microsoft WAV. */
		XM,              /* FastTracker 2 XM. */
		XMA,             /* Xbox360 XMA */
		VAG,             /* PlayStation 2 / PlayStation Portable adpcm VAG format. */        
		AUDIOQUEUE,      /* iPhone hardware decoder, supports AAC, ALAC and MP3. */
		XWMA,            /* Xbox360 XWMA */
		BCWAV,           /* 3DS BCWAV container format for DSP ADPCM and PCM */
	}
}