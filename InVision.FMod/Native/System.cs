using System;
using System.Runtime.InteropServices;
using System.Text;

namespace InVision.FMod.Native
{
	public class System
	{
		public RESULT release                ()
		{
			return FMOD_System_Release(systemraw);
		}


		// Pre-init functions.
		public RESULT setOutput              (OUTPUTTYPE output)
		{
			return FMOD_System_SetOutput(systemraw, output);
		}
		public RESULT getOutput              (ref OUTPUTTYPE output)
		{
			return FMOD_System_GetOutput(systemraw, ref output);
		}
		public RESULT getNumDrivers          (ref int numdrivers)
		{
			return FMOD_System_GetNumDrivers(systemraw, ref numdrivers);
		}
		public RESULT getDriverInfo          (int id, [MarshalAs(UnmanagedType.LPWStr)]StringBuilder name, int namelen, ref GUID guid)
		{
			//use multibyte version
			return FMOD_System_GetDriverInfoW(systemraw, id, name, namelen, ref guid);
		}
		public RESULT getDriverCaps          (int id, ref CAPS caps, ref int minfrequency, ref int maxfrequency, ref SPEAKERMODE controlpanelspeakermode)
		{
			return FMOD_System_GetDriverCaps(systemraw, id, ref caps, ref minfrequency, ref maxfrequency, ref controlpanelspeakermode);
		}
		public RESULT setDriver              (int driver)
		{
			return FMOD_System_SetDriver(systemraw, driver);
		}
		public RESULT getDriver              (ref int driver)
		{
			return FMOD_System_GetDriver(systemraw, ref driver);
		}
		public RESULT setHardwareChannels    (int min2d, int max2d, int min3d, int max3d)
		{
			return FMOD_System_SetHardwareChannels(systemraw, min2d, max2d, min3d, max3d);
		}
		public RESULT setSoftwareChannels    (int numsoftwarechannels)
		{
			return FMOD_System_SetSoftwareChannels(systemraw, numsoftwarechannels);
		}
		public RESULT getSoftwareChannels    (ref int numsoftwarechannels)
		{
			return FMOD_System_GetSoftwareChannels(systemraw, ref numsoftwarechannels);
		}
		public RESULT setSoftwareFormat      (int samplerate, SOUND_FORMAT format, int numoutputchannels, int maxinputchannels, DSP_RESAMPLER resamplemethod)
		{
			return FMOD_System_SetSoftwareFormat(systemraw, samplerate, format, numoutputchannels, maxinputchannels, resamplemethod);
		}
		public RESULT getSoftwareFormat      (ref int samplerate, ref SOUND_FORMAT format, ref int numoutputchannels, ref int maxinputchannels, ref DSP_RESAMPLER resamplemethod, ref int bits)
		{
			return FMOD_System_GetSoftwareFormat(systemraw, ref samplerate, ref format, ref numoutputchannels, ref maxinputchannels, ref resamplemethod, ref bits);
		}
		public RESULT setDSPBufferSize       (uint bufferlength, int numbuffers)
		{
			return FMOD_System_SetDSPBufferSize(systemraw, bufferlength, numbuffers);
		}
		public RESULT getDSPBufferSize       (ref uint bufferlength, ref int numbuffers)
		{
			return FMOD_System_GetDSPBufferSize(systemraw, ref bufferlength, ref numbuffers);
		}
		public RESULT setFileSystem          (FILE_OPENCALLBACK useropen, FILE_CLOSECALLBACK userclose, FILE_READCALLBACK userread, FILE_SEEKCALLBACK userseek, FILE_ASYNCREADCALLBACK userasyncread, FILE_ASYNCCANCELCALLBACK userasynccancel, int blockalign)
		{
			return FMOD_System_SetFileSystem(systemraw, useropen, userclose, userread, userseek, userasyncread, userasynccancel, blockalign);
		}
		public RESULT attachFileSystem       (FILE_OPENCALLBACK useropen, FILE_CLOSECALLBACK userclose, FILE_READCALLBACK userread, FILE_SEEKCALLBACK userseek)
		{
			return FMOD_System_AttachFileSystem(systemraw, useropen, userclose, userread, userseek);
		}
		public RESULT setAdvancedSettings    (ref ADVANCEDSETTINGS settings)
		{
			return FMOD_System_SetAdvancedSettings(systemraw, ref settings);
		}
		public RESULT getAdvancedSettings    (ref ADVANCEDSETTINGS settings)
		{
			return FMOD_System_GetAdvancedSettings(systemraw, ref settings);
		}
		public RESULT setSpeakerMode         (SPEAKERMODE speakermode)
		{
			return FMOD_System_SetSpeakerMode(systemraw, speakermode);
		}
		public RESULT getSpeakerMode         (ref SPEAKERMODE speakermode)
		{
			return FMOD_System_GetSpeakerMode(systemraw, ref speakermode);
		}
		public RESULT setCallback            (SYSTEM_CALLBACK callback)
		{
			return FMOD_System_SetCallback(systemraw, callback);
		}
                         
		// Plug-in support
		public RESULT setPluginPath          (string path)
		{
			return FMOD_System_SetPluginPath(systemraw, path);
		}
		public RESULT loadPlugin             (string filename, ref uint handle, uint priority)
		{
			return FMOD_System_LoadPlugin(systemraw, filename, ref handle, priority);
		}
		public RESULT unloadPlugin           (uint handle)
		{
			return FMOD_System_UnloadPlugin(systemraw, handle);
		}
		public RESULT getNumPlugins          (PLUGINTYPE plugintype, ref int numplugins)
		{
			return FMOD_System_GetNumPlugins(systemraw, plugintype, ref numplugins);
		}
		public RESULT getPluginHandle        (PLUGINTYPE plugintype, int index, ref uint handle)
		{
			return FMOD_System_GetPluginHandle(systemraw, plugintype, index, ref handle);
		}
		public RESULT getPluginInfo          (uint handle, ref PLUGINTYPE plugintype, StringBuilder name, int namelen, ref uint version)
		{
			return FMOD_System_GetPluginInfo(systemraw, handle, ref plugintype, name, namelen, ref version);
		}

		public RESULT setOutputByPlugin      (uint handle)
		{
			return FMOD_System_SetOutputByPlugin(systemraw, handle);
		}
		public RESULT getOutputByPlugin      (ref uint handle)
		{
			return FMOD_System_GetOutputByPlugin(systemraw, ref handle);
		}
		public RESULT createDSPByPlugin      (uint handle, ref IntPtr dsp)
		{
			return FMOD_System_CreateDSPByPlugin(systemraw, handle, ref dsp);
		}
		public RESULT createCodec            (IntPtr description, uint priority)
		{
			return FMOD_System_CreateCodec(systemraw, description, priority);
		}


		// Init/Close 
		public RESULT init                   (int maxchannels, INITFLAGS flags, IntPtr extradriverdata)
		{
			return FMOD_System_Init(systemraw, maxchannels, flags, extradriverdata);
		}
		public RESULT close                  ()
		{
			return FMOD_System_Close(systemraw);
		}


		// General post-init system functions
		public RESULT update                 ()
		{
			return FMOD_System_Update(systemraw);
		}

		public RESULT set3DSettings          (float dopplerscale, float distancefactor, float rolloffscale)
		{
			return FMOD_System_Set3DSettings(systemraw, dopplerscale, distancefactor, rolloffscale);
		}
		public RESULT get3DSettings          (ref float dopplerscale, ref float distancefactor, ref float rolloffscale)
		{
			return FMOD_System_Get3DSettings(systemraw, ref dopplerscale, ref distancefactor, ref rolloffscale);
		}
		public RESULT set3DNumListeners      (int numlisteners)
		{
			return FMOD_System_Set3DNumListeners(systemraw, numlisteners);
		}
		public RESULT get3DNumListeners      (ref int numlisteners)
		{
			return FMOD_System_Get3DNumListeners(systemraw, ref numlisteners);
		}
		public RESULT set3DListenerAttributes(int listener, ref VECTOR pos, ref VECTOR vel, ref VECTOR forward, ref VECTOR up)
		{
			return FMOD_System_Set3DListenerAttributes(systemraw, listener, ref pos, ref vel, ref forward, ref up);
		}
		public RESULT get3DListenerAttributes(int listener, ref VECTOR pos, ref VECTOR vel, ref VECTOR forward, ref VECTOR up)
		{
			return FMOD_System_Get3DListenerAttributes(systemraw, listener, ref pos, ref vel, ref forward, ref up);
		}

		public RESULT set3DRolloffCallback   (CB_3D_ROLLOFFCALLBACK callback)
		{
			return  FMOD_System_Set3DRolloffCallback   (systemraw, callback);
		}
		public RESULT set3DSpeakerPosition     (SPEAKER speaker, float x, float y, bool active)
		{
			return FMOD_System_Set3DSpeakerPosition(systemraw, speaker, x, y, (active ? 1 : 0));
		}
		public RESULT get3DSpeakerPosition     (SPEAKER speaker, ref float x, ref float y, ref bool active)
		{
			RESULT result;
            
			int isactive = 0;

			result = FMOD_System_Get3DSpeakerPosition(systemraw, speaker, ref x, ref y, ref isactive);

			active = (isactive != 0);

			return result;
		}

		public RESULT setStreamBufferSize    (uint filebuffersize, TIMEUNIT filebuffersizetype)
		{
			return FMOD_System_SetStreamBufferSize(systemraw, filebuffersize, filebuffersizetype);
		}
		public RESULT getStreamBufferSize    (ref uint filebuffersize, ref TIMEUNIT filebuffersizetype)
		{
			return FMOD_System_GetStreamBufferSize(systemraw, ref filebuffersize, ref filebuffersizetype);
		}


		// System information functions.
		public RESULT getVersion             (ref uint version)
		{
			return FMOD_System_GetVersion(systemraw, ref version);
		}
		public RESULT getOutputHandle        (ref IntPtr handle)
		{
			return FMOD_System_GetOutputHandle(systemraw, ref handle);
		}
		public RESULT getChannelsPlaying     (ref int channels)
		{
			return FMOD_System_GetChannelsPlaying(systemraw, ref channels);
		}
		public RESULT getHardwareChannels(ref int num2d, ref int num3d, ref int total)
		{
			return FMOD_System_GetHardwareChannels(systemraw, ref num2d, ref num3d, ref total);
		}
		public RESULT getCPUUsage            (ref float dsp, ref float stream, ref float geometry, ref float update, ref float total)
		{
			return FMOD_System_GetCPUUsage(systemraw, ref dsp, ref stream, ref geometry, ref update, ref total);
		}
		public RESULT getSoundRAM            (ref int currentalloced, ref int maxalloced, ref int total)
		{
			return FMOD_System_GetSoundRAM(systemraw, ref currentalloced, ref maxalloced, ref total);
		}
		public RESULT getNumCDROMDrives      (ref int numdrives)
		{
			return FMOD_System_GetNumCDROMDrives(systemraw, ref numdrives);
		}
		public RESULT getCDROMDriveName      (int drive, StringBuilder drivename, int drivenamelen, StringBuilder scsiname, int scsinamelen, StringBuilder devicename, int devicenamelen)
		{
			return FMOD_System_GetCDROMDriveName(systemraw, drive, drivename, drivenamelen, scsiname, scsinamelen, devicename, devicenamelen);
		}
		public RESULT getSpectrum            (float[] spectrumarray, int numvalues, int channeloffset, DSP_FFT_WINDOW windowtype)
		{
			return FMOD_System_GetSpectrum(systemraw, spectrumarray, numvalues, channeloffset, windowtype);
		}
		public RESULT getWaveData            (float[] wavearray, int numvalues, int channeloffset)
		{
			return FMOD_System_GetWaveData(systemraw, wavearray, numvalues, channeloffset);
		}


		// Sound/DSP/Channel creation and retrieval. 
		public RESULT createSound            (string name_or_data, MODE mode, ref CREATESOUNDEXINFO exinfo, ref Sound sound)
		{
			RESULT result           = RESULT.OK;
			IntPtr      soundraw    = new IntPtr();
			Sound       soundnew    = null;

			mode = mode | MODE.UNICODE;

			try
			{
				result = FMOD_System_CreateSound(systemraw, name_or_data, mode, ref exinfo, ref soundraw);
			}
			catch
			{
				result = RESULT.ERR_INVALID_PARAM;
			}
			if (result != RESULT.OK)
			{
				return result;
			}

			if (sound == null)
			{
				soundnew = new Sound();
				soundnew.setRaw(soundraw);
				sound = soundnew;
			}
			else
			{
				sound.setRaw(soundraw);
			}

			return result;
		}
		public RESULT createSound            (byte[] data, MODE mode, ref CREATESOUNDEXINFO exinfo, ref Sound sound)
		{
			RESULT result           = RESULT.OK;
			IntPtr      soundraw    = new IntPtr();
			Sound       soundnew    = null;

			try
			{
				result = FMOD_System_CreateSound(systemraw, data, mode, ref exinfo, ref soundraw);
			}
			catch
			{
				result = RESULT.ERR_INVALID_PARAM;
			}
			if (result != RESULT.OK)
			{
				return result;
			}

			if (sound == null)
			{
				soundnew = new Sound();
				soundnew.setRaw(soundraw);
				sound = soundnew;
			}
			else
			{
				sound.setRaw(soundraw);
			}

			return result;
		}
		public RESULT createSound            (string name_or_data, MODE mode, ref Sound sound)
		{
			RESULT result           = RESULT.OK;
			IntPtr      soundraw    = new IntPtr();
			Sound       soundnew    = null;

			mode = mode | MODE.UNICODE;

			try
			{
				result = FMOD_System_CreateSound(systemraw, name_or_data, mode, 0, ref soundraw);
			}
			catch
			{
				result = RESULT.ERR_INVALID_PARAM;
			}
			if (result != RESULT.OK)
			{
				return result;
			}

			if (sound == null)
			{
				soundnew = new Sound();
				soundnew.setRaw(soundraw);
				sound = soundnew;
			}
			else
			{
				sound.setRaw(soundraw);
			}

			return result;
		}
		public RESULT createStream            (string name_or_data, MODE mode, ref CREATESOUNDEXINFO exinfo, ref Sound sound)
		{
			RESULT result           = RESULT.OK;
			IntPtr      soundraw    = new IntPtr();
			Sound       soundnew    = null;

			mode = mode | MODE.UNICODE;

			try
			{
				result = FMOD_System_CreateStream(systemraw, name_or_data, mode, ref exinfo, ref soundraw);
			}
			catch
			{
				result = RESULT.ERR_INVALID_PARAM;
			}
			if (result != RESULT.OK)
			{
				return result;
			}

			if (sound == null)
			{
				soundnew = new Sound();
				soundnew.setRaw(soundraw);
				sound = soundnew;
			}
			else
			{
				sound.setRaw(soundraw);
			}

			return result;
		}
		public RESULT createStream            (byte[] data, MODE mode, ref CREATESOUNDEXINFO exinfo, ref Sound sound)
		{
			RESULT result           = RESULT.OK;
			IntPtr      soundraw    = new IntPtr();
			Sound       soundnew    = null;

			try
			{
				result = FMOD_System_CreateStream(systemraw, data, mode, ref exinfo, ref soundraw);
			}
			catch
			{
				result = RESULT.ERR_INVALID_PARAM;
			}
			if (result != RESULT.OK)
			{
				return result;
			}

			if (sound == null)
			{
				soundnew = new Sound();
				soundnew.setRaw(soundraw);
				sound = soundnew;
			}
			else
			{
				sound.setRaw(soundraw);
			}

			return result;
		}
		public RESULT createStream            (string name_or_data, MODE mode, ref Sound sound)
		{
			RESULT result           = RESULT.OK;
			IntPtr      soundraw    = new IntPtr();
			Sound       soundnew    = null;

			mode = mode | MODE.UNICODE;

			try
			{
				result = FMOD_System_CreateStream(systemraw, name_or_data, mode, 0, ref soundraw);
			}
			catch
			{
				result = RESULT.ERR_INVALID_PARAM;
			}
			if (result != RESULT.OK)
			{
				return result;
			}

			if (sound == null)
			{
				soundnew = new Sound();
				soundnew.setRaw(soundraw);
				sound = soundnew;
			}
			else
			{
				sound.setRaw(soundraw);
			}

			return result;
		}
		public RESULT createDSP              (ref DSP_DESCRIPTION description, ref DSP dsp)
		{
			RESULT result = RESULT.OK;
			IntPtr dspraw = new IntPtr();
			DSP    dspnew = null;

			try
			{
				result = FMOD_System_CreateDSP(systemraw, ref description, ref dspraw);
			}
			catch
			{
				result = RESULT.ERR_INVALID_PARAM;
			}
			if (result != RESULT.OK)
			{
				return result;
			}

			if (dsp == null)
			{
				dspnew = new DSP();
				dspnew.setRaw(dspraw);
				dsp = dspnew;
			}
			else
			{
				dsp.setRaw(dspraw);
			}
                             
			return result;  
		}
		public RESULT createDSPByType          (DSP_TYPE type, ref DSP dsp)
		{
			RESULT result = RESULT.OK;
			IntPtr dspraw = new IntPtr();
			DSP    dspnew = null;

			try
			{
				result = FMOD_System_CreateDSPByType(systemraw, type, ref dspraw);
			}
			catch
			{
				result = RESULT.ERR_INVALID_PARAM;
			}
			if (result != RESULT.OK)
			{
				return result;
			}

			if (dsp == null)
			{
				dspnew = new DSP();
				dspnew.setRaw(dspraw);
				dsp = dspnew;
			}
			else
			{
				dsp.setRaw(dspraw);
			}
                             
			return result;  
		}
		public RESULT createChannelGroup     (string name, ref ChannelGroup channelgroup)
		{
			RESULT result = RESULT.OK;
			IntPtr channelgroupraw = new IntPtr();
			ChannelGroup    channelgroupnew = null;

			try
			{
				result = FMOD_System_CreateChannelGroup(systemraw, name, ref channelgroupraw);
			}
			catch
			{
				result = RESULT.ERR_INVALID_PARAM;
			}
			if (result != RESULT.OK)
			{
				return result;
			}

			if (channelgroup == null)
			{
				channelgroupnew = new ChannelGroup();
				channelgroupnew.setRaw(channelgroupraw);
				channelgroup = channelgroupnew;
			}
			else
			{
				channelgroup.setRaw(channelgroupraw);
			}
                             
			return result;
		}
		public RESULT createSoundGroup       (string name, ref SoundGroup soundgroup)
		{
			RESULT result = RESULT.OK;
			IntPtr soundgroupraw = new IntPtr();
			SoundGroup soundgroupnew = null;

			try
			{
				result = FMOD_System_CreateSoundGroup(systemraw, name, ref soundgroupraw);
			}
			catch
			{
				result = RESULT.ERR_INVALID_PARAM;
			}
			if (result != RESULT.OK)
			{
				return result;
			}

			if (soundgroup == null)
			{
				soundgroupnew = new SoundGroup();
				soundgroupnew.setRaw(soundgroupraw);
				soundgroup = soundgroupnew;
			}
			else
			{
				soundgroup.setRaw(soundgroupraw);
			}

			return result;
		}
		public RESULT createReverb           (ref Reverb reverb)
		{
			RESULT result = RESULT.OK;
			IntPtr reverbraw = new IntPtr();
			Reverb reverbnew = null;

			try
			{
				result = FMOD_System_CreateReverb(systemraw, ref reverbraw);
			}
			catch
			{
				result = RESULT.ERR_INVALID_PARAM;
			}
			if (result != RESULT.OK)
			{
				return result;
			}

			if (reverb == null)
			{
				reverbnew = new Reverb();
				reverbnew.setRaw(reverbraw);
				reverb = reverbnew;
			}
			else
			{
				reverb.setRaw(reverbraw);
			}

			return result;
		}
		public RESULT playSound              (CHANNELINDEX channelid, Sound sound, bool paused, ref Channel channel)
		{
			RESULT result      = RESULT.OK;
			IntPtr      channelraw;
			Channel     channelnew  = null;

			if (channel != null)
			{
				channelraw = channel.getRaw();
			}
			else
			{
				channelraw  = new IntPtr();
			}

			try
			{
				result = FMOD_System_PlaySound(systemraw, channelid, sound.getRaw(), (paused ? 1 : 0), ref channelraw);
			}
			catch
			{
				result = RESULT.ERR_INVALID_PARAM;
			}
			if (result != RESULT.OK)
			{
				return result;
			}

			if (channel == null)
			{
				channelnew = new Channel();
				channelnew.setRaw(channelraw);
				channel = channelnew;
			}
			else
			{
				channel.setRaw(channelraw);
			}
                             
			return result;                                                                    
		}
		public RESULT playDSP                (CHANNELINDEX channelid, DSP dsp, bool paused, ref Channel channel)
		{
			RESULT result           = RESULT.OK;
			IntPtr      channelraw;
			Channel     channelnew  = null;

			if (channel != null)
			{
				channelraw = channel.getRaw();
			}
			else
			{
				channelraw  = new IntPtr();
			}

			try
			{
				result = FMOD_System_PlayDSP(systemraw, channelid, dsp.getRaw(), (paused ? 1 : 0), ref channelraw);
			}
			catch
			{
				result = RESULT.ERR_INVALID_PARAM;
			}
			if (result != RESULT.OK)
			{
				return result;
			}

			if (channel == null)
			{
				channelnew = new Channel();
				channelnew.setRaw(channelraw);
				channel = channelnew;
			}
			else
			{
				channel.setRaw(channelraw);
			}
                             
			return result;  
		}
		public RESULT getChannel             (int channelid, ref Channel channel)
		{
			RESULT result      = RESULT.OK;
			IntPtr      channelraw  = new IntPtr();
			Channel     channelnew  = null;

			try
			{
				result = FMOD_System_GetChannel(systemraw, channelid, ref channelraw);
			}
			catch
			{
				result = RESULT.ERR_INVALID_PARAM;
			}
			if (result != RESULT.OK)
			{
				return result;
			}

			if (channel == null)
			{
				channelnew = new Channel();
				channelnew.setRaw(channelraw);
				channel = channelnew;
			}
			else
			{
				channel.setRaw(channelraw);
			}

			return result;
		}
     
		public RESULT getMasterChannelGroup  (ref ChannelGroup channelgroup)
		{
			RESULT result = RESULT.OK;
			IntPtr channelgroupraw = new IntPtr();
			ChannelGroup    channelgroupnew = null;

			try
			{
				result = FMOD_System_GetMasterChannelGroup(systemraw, ref channelgroupraw);
			}
			catch
			{
				result = RESULT.ERR_INVALID_PARAM;
			}
			if (result != RESULT.OK)
			{
				return result;
			}

			if (channelgroup == null)
			{
				channelgroupnew = new ChannelGroup();
				channelgroupnew.setRaw(channelgroupraw);
				channelgroup = channelgroupnew;
			}
			else
			{
				channelgroup.setRaw(channelgroupraw);
			}
                             
			return result; 
		}

		public RESULT getMasterSoundGroup    (ref SoundGroup soundgroup)
		{
			RESULT result = RESULT.OK;
			IntPtr soundgroupraw = new IntPtr();
			SoundGroup    soundgroupnew = null;

			try
			{
				result = FMOD_System_GetMasterSoundGroup(systemraw, ref soundgroupraw);
			}
			catch
			{
				result = RESULT.ERR_INVALID_PARAM;
			}
			if (result != RESULT.OK)
			{
				return result;
			}

			if (soundgroup == null)
			{
				soundgroupnew = new SoundGroup();
				soundgroupnew.setRaw(soundgroupraw);
				soundgroup = soundgroupnew;
			}
			else
			{
				soundgroup.setRaw(soundgroupraw);
			}
                             
			return result; 
		}

		// Reverb api
		public RESULT setReverbProperties    (ref REVERB_PROPERTIES prop)
		{
			return FMOD_System_SetReverbProperties(systemraw, ref prop);
		}
		public RESULT getReverbProperties    (ref REVERB_PROPERTIES prop)
		{
			return FMOD_System_GetReverbProperties(systemraw, ref prop);
		}
                                        
		public RESULT setReverbAmbientProperties (ref REVERB_PROPERTIES prop)
		{
			return FMOD_System_SetReverbAmbientProperties(systemraw, ref prop);
		}
		public RESULT getReverbAmbientProperties (ref REVERB_PROPERTIES prop)
		{
			return FMOD_System_GetReverbAmbientProperties(systemraw, ref prop);
		}

		// System level DSP access.
		public RESULT getDSPHead             (ref DSP dsp)
		{
			RESULT result   = RESULT.OK;
			IntPtr dspraw   = new IntPtr();
			DSP    dspnew   = null;

			try
			{
				result = FMOD_System_GetDSPHead(systemraw, ref dspraw);
			}
			catch
			{
				result = RESULT.ERR_INVALID_PARAM;
			}
			if (result != RESULT.OK)
			{
				return result;
			}

			if (dsp == null)
			{
				dspnew = new DSP();
				dspnew.setRaw(dspraw);
				dsp = dspnew;
			}
			else
			{
				dsp.setRaw(dspraw);
			}

			return result;
		}
		public RESULT addDSP                 (DSP dsp, ref DSPConnection connection)
		{
			RESULT result = RESULT.OK;
			IntPtr dspconnectionraw = new IntPtr();
			DSPConnection dspconnectionnew = null;

			try
			{
				result = FMOD_System_AddDSP(systemraw, dsp.getRaw(), ref dspconnectionraw);
			}
			catch
			{
				result = RESULT.ERR_INVALID_PARAM;
			}
			if (result != RESULT.OK)
			{ 
				return result;
			}

			if (connection == null)
			{
				dspconnectionnew = new DSPConnection();
				dspconnectionnew.setRaw(dspconnectionraw);
				connection = dspconnectionnew;
			}
			else
			{
				connection.setRaw(dspconnectionraw);
			}

			return result;
		}
		public RESULT lockDSP            ()
		{
			return FMOD_System_LockDSP(systemraw);
		}
		public RESULT unlockDSP          ()
		{
			return FMOD_System_UnlockDSP(systemraw);
		}
		public RESULT getDSPClock          (ref uint hi, ref uint lo)
		{
			return FMOD_System_GetDSPClock   (systemraw, ref hi, ref lo);
		}
                                            
        
		// Recording api
		public RESULT getRecordNumDrivers    (ref int numdrivers)
		{
			return FMOD_System_GetRecordNumDrivers(systemraw, ref numdrivers);
		}
		public RESULT getRecordDriverInfo    (int id, [MarshalAs(UnmanagedType.LPWStr)]StringBuilder name, int namelen, ref GUID guid)
		{
			//use multibyte version
			return FMOD_System_GetRecordDriverInfoW(systemraw, id, name, namelen, ref guid);
		}
		public RESULT getRecordDriverCaps    (int id, ref CAPS caps, ref int minfrequency, ref int maxfrequency)
		{
			return FMOD_System_GetRecordDriverCaps(systemraw, id, ref caps, ref minfrequency, ref maxfrequency);
		}
		public RESULT getRecordPosition      (int id, ref uint position)
		{
			return FMOD_System_GetRecordPosition(systemraw, id, ref position);
		}

		public RESULT recordStart            (int id, Sound sound, bool loop)
		{
			return FMOD_System_RecordStart(systemraw, id, sound.getRaw(), (loop ? 1 : 0));
		}
		public RESULT recordStop             (int id)
		{
			return FMOD_System_RecordStop(systemraw, id);
		}
		public RESULT isRecording            (int id, ref bool recording)
		{
			RESULT result;
			int r = 0;
            
			result = FMOD_System_IsRecording(systemraw, id, ref r);

			recording = (r != 0);

			return result;
		}
         
      
		// Geometry api 
		public RESULT createGeometry         (int maxpolygons, int maxvertices, ref Geometry geometry)
		{
			RESULT result           = RESULT.OK;
			IntPtr geometryraw      = new IntPtr();
			Geometry geometrynew    = null;

			try
			{
				result = FMOD_System_CreateGeometry(systemraw, maxpolygons, maxvertices, ref geometryraw);
			}
			catch
			{
				result = RESULT.ERR_INVALID_PARAM;
			}
			if (result != RESULT.OK)
			{
				return result;
			}

			if (geometry == null)
			{
				geometrynew = new Geometry();
				geometrynew.setRaw(geometryraw);
				geometry = geometrynew;
			}
			else
			{
				geometry.setRaw(geometryraw);
			}

			return result;
		}
		public RESULT setGeometrySettings    (float maxworldsize)
		{
			return FMOD_System_SetGeometrySettings(systemraw, maxworldsize);
		}
		public RESULT getGeometrySettings    (ref float maxworldsize)
		{
			return FMOD_System_GetGeometrySettings(systemraw, ref maxworldsize);
		}
		public RESULT loadGeometry(IntPtr data, int datasize, ref Geometry geometry)
		{
			RESULT result           = RESULT.OK;
			IntPtr      geometryraw    = new IntPtr();
			Geometry    geometrynew    = null;

			try
			{
				result = FMOD_System_LoadGeometry(systemraw, data, datasize, ref geometryraw);
			}
			catch
			{
				result = RESULT.ERR_INVALID_PARAM;
			}
			if (result != RESULT.OK)
			{
				return result;
			}

			if (geometry == null)
			{
				geometrynew = new Geometry();
				geometrynew.setRaw(geometryraw);
				geometry = geometrynew;
			}
			else
			{
				geometry.setRaw(geometryraw);
			}

			return result;
		} 
		public RESULT getGeometryOcclusion    (ref VECTOR listener, ref VECTOR source, ref float direct, ref float reverb)
		{
			return FMOD_System_GetGeometryOcclusion(systemraw, ref listener, ref source, ref direct, ref reverb);
		}
  
		// Network functions
		public RESULT setNetworkProxy               (string proxy)
		{
			return FMOD_System_SetNetworkProxy(systemraw, proxy);
		}
		public RESULT getNetworkProxy               (StringBuilder proxy, int proxylen)
		{
			return FMOD_System_GetNetworkProxy(systemraw, proxy, proxylen);
		}
		public RESULT setNetworkTimeout      (int timeout)
		{
			return FMOD_System_SetNetworkTimeout(systemraw, timeout);
		}
		public RESULT getNetworkTimeout(ref int timeout)
		{
			return FMOD_System_GetNetworkTimeout(systemraw, ref timeout);
		}
                                     
		// Userdata set/get                         
		public RESULT setUserData            (IntPtr userdata)
		{
			return FMOD_System_SetUserData(systemraw, userdata);
		}
		public RESULT getUserData            (ref IntPtr userdata)
		{
			return FMOD_System_GetUserData(systemraw, ref userdata);
		}

		public RESULT getMemoryInfo(uint memorybits, uint event_memorybits, ref uint memoryused, ref MEMORY_USAGE_DETAILS memoryused_details)
		{
			return FMOD_System_GetMemoryInfo(systemraw, memorybits, event_memorybits, ref memoryused, ref memoryused_details);
		}


		#region importfunctions

		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_Release                (IntPtr system);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_SetOutput              (IntPtr system, OUTPUTTYPE output);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_GetOutput              (IntPtr system, ref OUTPUTTYPE output);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_GetNumDrivers          (IntPtr system, ref int numdrivers);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_GetDriverInfo          (IntPtr system, int id, StringBuilder name, int namelen, ref GUID guid);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_GetDriverInfoW         (IntPtr system, int id, [MarshalAs(UnmanagedType.LPWStr)]StringBuilder name, int namelen, ref GUID guid);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_GetDriverCaps          (IntPtr system, int id, ref CAPS caps, ref int minfrequency, ref int maxfrequency, ref SPEAKERMODE controlpanelspeakermode);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_SetDriver              (IntPtr system, int driver);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_GetDriver              (IntPtr system, ref int driver);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_SetHardwareChannels    (IntPtr system, int min2d, int max2d, int min3d, int max3d);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_GetHardwareChannels    (IntPtr system, ref int num2d, ref int num3d, ref int total);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_SetSoftwareChannels    (IntPtr system, int numsoftwarechannels);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_GetSoftwareChannels    (IntPtr system, ref int numsoftwarechannels);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_SetSoftwareFormat      (IntPtr system, int samplerate, SOUND_FORMAT format, int numoutputchannels, int maxinputchannels, DSP_RESAMPLER resamplemethod);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_GetSoftwareFormat      (IntPtr system, ref int samplerate, ref SOUND_FORMAT format, ref int numoutputchannels, ref int maxinputchannels, ref DSP_RESAMPLER resamplemethod, ref int bits);        
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_SetDSPBufferSize       (IntPtr system, uint bufferlength, int numbuffers);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_GetDSPBufferSize       (IntPtr system, ref uint bufferlength, ref int numbuffers);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_SetFileSystem(IntPtr system, FILE_OPENCALLBACK useropen, FILE_CLOSECALLBACK userclose, FILE_READCALLBACK userread, FILE_SEEKCALLBACK userseek, FILE_ASYNCREADCALLBACK userasyncread, FILE_ASYNCCANCELCALLBACK userasynccancel, int blockalign);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_AttachFileSystem       (IntPtr system, FILE_OPENCALLBACK useropen, FILE_CLOSECALLBACK userclose, FILE_READCALLBACK userread, FILE_SEEKCALLBACK userseek);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_SetPluginPath          (IntPtr system, string path);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_LoadPlugin             (IntPtr system, string filename, ref uint handle, uint priority);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_UnloadPlugin           (IntPtr system, uint handle);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_GetNumPlugins          (IntPtr system, PLUGINTYPE plugintype, ref int numplugins);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_GetPluginHandle        (IntPtr system, PLUGINTYPE plugintype, int index, ref uint handle);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_GetPluginInfo          (IntPtr system, uint handle, ref PLUGINTYPE plugintype, StringBuilder name, int namelen, ref uint version);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_CreateDSPByPlugin      (IntPtr system, uint handle, ref IntPtr dsp);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_CreateCodec            (IntPtr system, IntPtr description, uint priority);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_SetOutputByPlugin      (IntPtr system, uint handle);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_GetOutputByPlugin      (IntPtr system, ref uint handle);        
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_Init                   (IntPtr system, int maxchannels, INITFLAGS flags, IntPtr extradriverdata);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_Close                  (IntPtr system);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_Update                 (IntPtr system);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_UpdateFinished         (IntPtr system);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_SetAdvancedSettings    (IntPtr system, ref ADVANCEDSETTINGS settings);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_GetAdvancedSettings    (IntPtr system, ref ADVANCEDSETTINGS settings);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_SetSpeakerMode         (IntPtr system, SPEAKERMODE speakermode);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_GetSpeakerMode         (IntPtr system, ref SPEAKERMODE speakermode);
		[DllImport(VERSION.dll)]
		private static extern RESULT FMOD_System_Set3DRolloffCallback(IntPtr system, CB_3D_ROLLOFFCALLBACK callback);
		[DllImport(VERSION.dll)]
		private static extern RESULT FMOD_System_SetCallback            (IntPtr system, SYSTEM_CALLBACK callback);
		[DllImport(VERSION.dll)]
		private static extern RESULT FMOD_System_Set3DSpeakerPosition   (IntPtr system, SPEAKER speaker, float x, float y, int active);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_Get3DSpeakerPosition   (IntPtr system, SPEAKER speaker, ref float x, ref float y, ref int active);
		[DllImport (VERSION.dll)]                       
		private static extern RESULT FMOD_System_Set3DSettings          (IntPtr system, float dopplerscale, float distancefactor, float rolloffscale);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_Get3DSettings          (IntPtr system, ref float dopplerscale, ref float distancefactor, ref float rolloffscale);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_Set3DNumListeners      (IntPtr system, int numlisteners);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_Get3DNumListeners      (IntPtr system, ref int numlisteners);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_Set3DListenerAttributes(IntPtr system, int listener, ref VECTOR pos, ref VECTOR vel, ref VECTOR forward, ref VECTOR up);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_Get3DListenerAttributes(IntPtr system, int listener, ref VECTOR pos, ref VECTOR vel, ref VECTOR forward, ref VECTOR up);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_SetFileBufferSize      (IntPtr system, int sizebytes);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_GetFileBufferSize      (IntPtr system, ref int sizebytes);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_SetStreamBufferSize    (IntPtr system, uint filebuffersize, TIMEUNIT filebuffersizetype);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_GetStreamBufferSize    (IntPtr system, ref uint filebuffersize, ref TIMEUNIT filebuffersizetype);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_GetVersion             (IntPtr system, ref uint version);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_GetOutputHandle        (IntPtr system, ref IntPtr handle);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_GetChannelsPlaying     (IntPtr system, ref int channels);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_GetCPUUsage            (IntPtr system, ref float dsp, ref float stream, ref float geometry, ref float update, ref float total);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_GetSoundRAM            (IntPtr system, ref int currentalloced, ref int maxalloced, ref int total);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_GetNumCDROMDrives      (IntPtr system, ref int numdrives);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_GetCDROMDriveName      (IntPtr system, int drive, StringBuilder drivename, int drivenamelen, StringBuilder scsiname, int scsinamelen, StringBuilder devicename, int devicenamelen);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_GetSpectrum            (IntPtr system, [MarshalAs(UnmanagedType.LPArray)]float[] spectrumarray, int numvalues, int channeloffset, DSP_FFT_WINDOW windowtype);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_GetWaveData            (IntPtr system, [MarshalAs(UnmanagedType.LPArray)]float[] wavearray, int numvalues, int channeloffset);
		[DllImport (VERSION.dll, CharSet = CharSet.Unicode)]
		private static extern RESULT FMOD_System_CreateSound            (IntPtr system, string name_or_data, MODE mode, ref CREATESOUNDEXINFO exinfo, ref IntPtr sound);
		[DllImport (VERSION.dll, CharSet = CharSet.Unicode)]  
		private static extern RESULT FMOD_System_CreateStream           (IntPtr system, string name_or_data, MODE mode, ref CREATESOUNDEXINFO exinfo, ref IntPtr sound);
		[DllImport(VERSION.dll, CharSet = CharSet.Unicode)]
		private static extern RESULT FMOD_System_CreateSound            (IntPtr system, string name_or_data, MODE mode, int exinfo, ref IntPtr sound);
		[DllImport(VERSION.dll, CharSet = CharSet.Unicode)]
		private static extern RESULT FMOD_System_CreateStream           (IntPtr system, string name_or_data, MODE mode, int exinfo, ref IntPtr sound);   
		[DllImport (VERSION.dll)]   
		private static extern RESULT FMOD_System_CreateSound            (IntPtr system, byte[] name_or_data, MODE mode, ref CREATESOUNDEXINFO exinfo, ref IntPtr sound);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_CreateStream           (IntPtr system, byte[] name_or_data, MODE mode, ref CREATESOUNDEXINFO exinfo, ref IntPtr sound);
		[DllImport (VERSION.dll)]   
		private static extern RESULT FMOD_System_CreateSound            (IntPtr system, byte[] name_or_data, MODE mode, int exinfo, ref IntPtr sound);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_CreateStream           (IntPtr system, byte[] name_or_data, MODE mode, int exinfo, ref IntPtr sound);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_CreateDSP              (IntPtr system, ref DSP_DESCRIPTION description, ref IntPtr dsp);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_CreateDSPByType        (IntPtr system, DSP_TYPE type, ref IntPtr dsp);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_CreateChannelGroup     (IntPtr system, string name, ref IntPtr channelgroup);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_CreateSoundGroup       (IntPtr system, string name, ref IntPtr soundgroup);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_CreateReverb           (IntPtr system, ref IntPtr reverb);
		[DllImport (VERSION.dll)]                 
		private static extern RESULT FMOD_System_PlaySound              (IntPtr system, CHANNELINDEX channelid, IntPtr sound, int paused, ref IntPtr channel);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_PlayDSP                (IntPtr system, CHANNELINDEX channelid, IntPtr dsp, int paused, ref IntPtr channel);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_GetChannel             (IntPtr system, int channelid, ref IntPtr channel);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_GetMasterChannelGroup  (IntPtr system, ref IntPtr channelgroup);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_GetMasterSoundGroup    (IntPtr system, ref IntPtr soundgroup);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_SetReverbProperties    (IntPtr system, ref REVERB_PROPERTIES prop);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_GetReverbProperties    (IntPtr system, ref REVERB_PROPERTIES prop);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_SetReverbAmbientProperties(IntPtr system, ref REVERB_PROPERTIES prop);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_GetReverbAmbientProperties(IntPtr system, ref REVERB_PROPERTIES prop);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_GetDSPHead             (IntPtr system, ref IntPtr dsp);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_AddDSP                 (IntPtr system, IntPtr dsp, ref IntPtr connection);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_LockDSP                (IntPtr system);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_UnlockDSP              (IntPtr system);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_GetDSPClock            (IntPtr system, ref uint hi, ref uint lo);
		[DllImport(VERSION.dll)]
		private static extern RESULT FMOD_System_GetRecordNumDrivers    (IntPtr system, ref int numdrivers);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_GetRecordDriverInfo    (IntPtr system, int id, StringBuilder name, int namelen, ref GUID guid);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_GetRecordDriverInfoW   (IntPtr system, int id, [MarshalAs(UnmanagedType.LPWStr)]StringBuilder name, int namelen, ref GUID guid);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_GetRecordDriverCaps    (IntPtr system, int id, ref CAPS caps, ref int minfrequency, ref int maxfrequency);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_GetRecordPosition      (IntPtr system, int id, ref uint position);
		[DllImport (VERSION.dll)]  
		private static extern RESULT FMOD_System_RecordStart            (IntPtr system, int id, IntPtr sound, int loop);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_RecordStop             (IntPtr system, int id);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_IsRecording            (IntPtr system, int id, ref int recording);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_CreateGeometry         (IntPtr system, int maxpolygons, int maxvertices, ref IntPtr geometry);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_SetGeometrySettings    (IntPtr system, float maxworldsize);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_GetGeometrySettings    (IntPtr system, ref float maxworldsize);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_LoadGeometry           (IntPtr system, IntPtr data, int datasize, ref IntPtr geometry);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_GetGeometryOcclusion   (IntPtr system, ref VECTOR listener, ref VECTOR source, ref float direct, ref float reverb);
		[DllImport (VERSION.dll)]               
		private static extern RESULT FMOD_System_SetNetworkProxy        (IntPtr system, string proxy);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_GetNetworkProxy        (IntPtr system, StringBuilder proxy, int proxylen);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_SetNetworkTimeout      (IntPtr system, int timeout);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_GetNetworkTimeout      (IntPtr system, ref int timeout);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_SetUserData            (IntPtr system, IntPtr userdata);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_GetUserData            (IntPtr system, ref IntPtr userdata);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_GetMemoryInfo          (IntPtr system, uint memorybits, uint event_memorybits, ref uint memoryused, ref MEMORY_USAGE_DETAILS memoryused_details);

		#endregion

		#region wrapperinternal
        
		private IntPtr systemraw;

		public void setRaw(IntPtr system)
		{
			systemraw = new IntPtr();

			systemraw = system;
		}

		public IntPtr getRaw()
		{
			return systemraw;
		}

		#endregion
	}
}