namespace InVision.FMod.Native
{
	public enum INITFLAGS :int
	{
		NORMAL                  = 0x00000000,   /* All platforms - Initialize normally */
		STREAM_FROM_UPDATE      = 0x00000001,   /* All platforms - No stream thread is created internally.  Streams are driven from System::update.  Mainly used with non-realtime outputs. */
		_3D_RIGHTHANDED         = 0x00000002,   /* All platforms - FMOD will treat +X as left, +Y as up and +Z as forwards. */
		SOFTWARE_DISABLE        = 0x00000004,   /* All platforms - Disable software mixer to save memory.  Anything created with FMOD_SOFTWARE will fail and DSP will not work. */
		SOFTWARE_OCCLUSION      = 0x00000008,   /* All platforms - All FMOD_SOFTWARE with FMOD_3D based voices will add a software lowpass filter effect into the DSP chain which is automatically used when Channel::set3DOcclusion is used or the geometry API. */
		SOFTWARE_HRTF           = 0x00000010,   /* All platforms - All FMOD_SOFTWARE with FMOD_3D based voices will add a software lowpass filter effect into the DSP chain which causes sounds to sound duller when the sound goes behind the listener. */
		SOFTWARE_REVERB_LOWMEM  = 0x00000040,   /* All platforms - SFX reverb is run using 22/24khz delay buffers, halving the memory required. */
		ENABLE_PROFILE          = 0x00000020,   /* All platforms - Enable TCP/IP based host which allows "DSPNet Listener.exe" to connect to it, and view the DSP dataflow network graph in real-time. */
		VOL0_BECOMES_VIRTUAL    = 0x00000080,   /* All platforms - Any sounds that are 0 volume will go virtual and not be processed except for having their positions updated virtually.  Use System::setAdvancedSettings to adjust what volume besides zero to switch to virtual at. */
		WASAPI_EXCLUSIVE        = 0x00000100,   /* Win32 Vista only - for WASAPI output - Enable exclusive access to hardware, lower latency at the expense of excluding other applications from accessing the audio hardware. */
		PS2_DISABLECORE0REVERB  = 0x00010000,   /* PS2 only - Disable reverb on CORE 0 to regain SRAM. */
		PS2_DISABLECORE1REVERB  = 0x00020000,   /* PS2 only - Disable reverb on CORE 1 to regain SRAM. */
		PS2_DONTUSESCRATCHPAD   = 0x00040000,   /* PS2 only - Disable FMOD's usage of the scratchpad. */
		PS2_SWAPDMACHANNELS     = 0x00080000,   /* PS2 only - Changes FMOD from using SPU DMA channel 0 for software mixing, and 1 for sound data upload/file streaming, to 1 and 0 respectively. */
		DISABLEDOLBY            = 0x00100000,   /* Wii / 3DS - Disable Dolby Pro Logic surround. Speakermode will be set to STEREO even if user has selected surround in the system settings. */
		WII_DISABLEDOLBY        = 0x00100000,   /* Wii only - Disable Dolby Pro Logic surround. Speakermode will be set to STEREO even if user has selected surround in the Wii system settings. */
		_360_MUSICMUTENOTPAUSE  = 0x00200000,   /* Xbox 360 only - The "music" channelgroup which by default pauses when custom 360 dashboard music is played, can be changed to mute (therefore continues playing) instead of pausing, by using this flag. */
		SYNCMIXERWITHUPDATE     = 0x00400000,   /* Win32/Wii/PS3/Xbox 360 - FMOD Mixer thread is woken up to do a mix when System::update is called rather than waking periodically on its own timer. */
		DTS_NEURALSURROUND      = 0x02000000,   /* Win32/Mac/Linux - Use DTS Neural surround downmixing from 7.1 if speakermode set to FMOD_SPEAKERMODE_STEREO or FMOD_SPEAKERMODE_5POINT1.  Internal DSP structure will be set to 7.1. */
		GEOMETRY_USECLOSEST     = 0x04000000,   /* All platforms - With the geometry engine, only process the closest polygon rather than accumulating all polygons the sound to listener line intersects. */
		DISABLE_MYEARS          = 0x08000000    /* Win32 - Disables MyEars HRTF 7.1 downmixing.  MyEars will otherwise be disbaled if speakermode is not set to FMOD_SPEAKERMODE_STEREO or the data file is missing. */
	}
}