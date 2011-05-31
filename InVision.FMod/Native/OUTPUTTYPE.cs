namespace InVision.FMod.Native
{
	public enum OUTPUTTYPE :int
	{
		AUTODETECT,    /* Picks the best output mode for the platform.  This is the default. */

		UNKNOWN,       /* All         - 3rd party plugin, unknown.  This is for use with System::getOutput only. */
		NOSOUND,       /* All         - All calls in this mode succeed but make no sound. */
		WAVWRITER,     /* All         - All         - Writes output to fmodout.wav by default.  Use System::setSoftwareFormat to set the filename. */
		NOSOUND_NRT,   /* All         - Non-realtime version of FMOD_OUTPUTTYPE_NOSOUND.  User can drive mixer with System::update at whatever rate they want. */
		WAVWRITER_NRT, /* All         - Non-realtime version of FMOD_OUTPUTTYPE_WAVWRITER.  User can drive mixer with System::update at whatever rate they want. */

		DSOUND,        /* Win32/Win64   - DirectSound output.  Use this to get hardware accelerated 3d audio and EAX Reverb support. (Default on Windows) */
		WINMM,         /* Win32/Win64   - Windows Multimedia output. */
		WASAPI,        /* Win32         - Windows Audio Session API. (Default on Windows Vista) */        
		ASIO,          /* Win32         - Low latency ASIO driver. */
		OSS,           /* Linux         - Open Sound System output. */
		ALSA,          /* Linux         - Advanced Linux Sound Architecture output. */
		ESD,           /* Linux         - Enlightment Sound Daemon output. */
		SOUNDMANAGER,  /* Mac           - Macintosh SoundManager output. */
		PULSEAUDIO,    /* Linux/Linux64 - PulseAudio output. */
		COREAUDIO,     /* Mac           - Macintosh CoreAudio output */
		XBOX,          /* Xbox          - Native hardware output. */
		PS2,           /* PS2           - Native hardware output. */
		PS3,           /* PS3           - Native hardware output. (Default on PS3) */
		GC,            /* GameCube      - Native hardware output. */
		XBOX360,       /* Xbox 360      - Native hardware output. */
		PSP,           /* PSP           - Native hardware output. */
		WII,           /* Wii           - Native hardware output. (Default on Wii) */
		ANDROID,       /* Android       - Native android output. */
		_3DS,          /* 3DS           - Native 3DS output */
		NGP,           /* NGP           - Native NGP output. */

		MAX            /* Maximum number of output types supported. */
	}
}