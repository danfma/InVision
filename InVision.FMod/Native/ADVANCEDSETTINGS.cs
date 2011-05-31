using System;
using System.Runtime.InteropServices;

namespace InVision.FMod.Native
{
	[StructLayout(LayoutKind.Sequential)]
	public struct ADVANCEDSETTINGS
	{                       
		public int     cbsize;                      /* Size of structure.  Use sizeof(FMOD_ADVANCEDSETTINGS) */
		public int     maxMPEGcodecs;               /* For use with FMOD_CREATECOMPRESSEDSAMPLE only.  Mpeg  codecs consume 48,696 per instance and this number will determine how many mpeg channels can be played simultaneously.  Default = 16. */
		public int     maxADPCMcodecs;              /* For use with FMOD_CREATECOMPRESSEDSAMPLE only.  ADPCM codecs consume 1k per instance and this number will determine how many ADPCM channels can be played simultaneously.  Default = 32. */
		public int     maxXMAcodecs;                /* For use with FMOD_CREATECOMPRESSEDSAMPLE only.  XMA   codecs consume 8k per instance and this number will determine how many XMA channels can be played simultaneously.  Default = 32.  */
		public int     maxPCMcodecs;                /* [in/out] Optional. Specify 0 to ignore. For use with PS3 only.                          PCM   codecs consume 12,672 bytes per instance and this number will determine how many streams and PCM voices can be played simultaneously. Default = 16 */
		public int     maxCELTcodecs;               /* [in/out] Optional. Specify 0 to ignore. For use with FMOD_CREATECOMPRESSEDSAMPLE only.  CELT  codecs consume 11,500 bytes per instance and this number will determine how many CELT channels can be played simultaneously. Default = 16 */    
		public int     ASIONumChannels;             /* [in/out] */
		public IntPtr  ASIOChannelList;             /* [in/out] */
		public IntPtr  ASIOSpeakerList;             /* [in/out] Optional. Specify 0 to ignore. Pointer to a list of speakers that the ASIO channels map to.  This can be called after System::init to remap ASIO output. */
		public int     max3DReverbDSPs;             /* [in/out] The max number of 3d reverb DSP's in the system. */
		public float   HRTFMinAngle;                /* [in/out] For use with FMOD_INIT_SOFTWARE_HRTF.  The angle (0-360) of a 3D sound from the listener's forward vector at which the HRTF function begins to have an effect.  Default = 180.0. */
		public float   HRTFMaxAngle;                /* [in/out] For use with FMOD_INIT_SOFTWARE_HRTF.  The angle (0-360) of a 3D sound from the listener's forward vector at which the HRTF function begins to have maximum effect.  Default = 360.0.  */
		public float   HRTFFreq;                    /* [in/out] For use with FMOD_INIT_SOFTWARE_HRTF.  The cutoff frequency of the HRTF's lowpass filter function when at maximum effect. (i.e. at HRTFMaxAngle).  Default = 4000.0. */
		public float   vol0virtualvol;              /* [in/out] For use with FMOD_INIT_VOL0_BECOMES_VIRTUAL.  If this flag is used, and the volume is 0.0, then the sound will become virtual.  Use this value to raise the threshold to a different point where a sound goes virtual. */
		public int     eventqueuesize;              /* [in/out] Optional. Specify 0 to ignore. For use with FMOD Event system only.  Specifies the number of slots available for simultaneous non blocking loads.  Default = 32. */
		public uint    defaultDecodeBufferSize;     /* [in/out] Optional. Specify 0 to ignore. For streams. This determines the default size of the double buffer (in milliseconds) that a stream uses.  Default = 400ms */
		public IntPtr  debugLogFilename;            /* [in/out] Optional. Specify 0 to ignore. Gives fmod's logging system a path/filename.  Normally the log is placed in the same directory as the executable and called fmod.log. When using System::getAdvancedSettings, provide at least 256 bytes of memory to copy into. */
		public ushort  profileport;                 /* [in/out] Optional. Specify 0 to ignore. For use with FMOD_INIT_ENABLE_PROFILE.  Specify the port to listen on for connections by the profiler application. */
		public uint    geometryMaxFadeTime;         /* [in/out] Optional. Specify 0 to ignore. The maximum time in miliseconds it takes for a channel to fade to the new level when its occlusion changes. */
		public uint    maxSpectrumWaveDataBuffers;  /* [in/out] Optional. Specify 0 to ignore. The maximum number of buffers for use with getWaveData/getSpectrum. */
		public uint    musicSystemCacheDelay;       /* [in/out] Optional. Specify 0 to ignore. The delay the music system should allow for loading a sample from disk (in milliseconds). Default = 400 ms. */
	}
}