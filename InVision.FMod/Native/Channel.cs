using System;
using System.Runtime.InteropServices;

namespace InVision.FMod.Native
{
	public class Channel
	{
		public RESULT getSystemObject       (ref System system)
		{
			RESULT result   = RESULT.OK;
			IntPtr systemraw   = new IntPtr();
			System systemnew   = null;

			try
			{
				result = FMOD_Channel_GetSystemObject(channelraw, ref systemraw);
			}
			catch
			{
				result = RESULT.ERR_INVALID_PARAM;
			}
			if (result != RESULT.OK)
			{
				return result;
			}

			if (system == null)
			{
				systemnew = new System();
				systemnew.setRaw(systemraw);
				system = systemnew;
			}
			else
			{
				system.setRaw(systemraw);
			}

			return result;  
		}


		public RESULT stop                  ()
		{
			return FMOD_Channel_Stop(channelraw);
		}
		public RESULT setPaused             (bool paused)
		{
			return FMOD_Channel_SetPaused(channelraw, (paused ? 1 : 0));
		}
		public RESULT getPaused             (ref bool paused)
		{
			RESULT result;
			int p = 0;

			result = FMOD_Channel_GetPaused(channelraw, ref p);

			paused = (p != 0);

			return result;
		}
		public RESULT setVolume             (float volume)
		{
			return FMOD_Channel_SetVolume(channelraw, volume);
		}
		public RESULT getVolume             (ref float volume)
		{
			return FMOD_Channel_GetVolume(channelraw, ref volume);
		}
		public RESULT setFrequency          (float frequency)
		{
			return FMOD_Channel_SetFrequency(channelraw, frequency);
		}
		public RESULT getFrequency          (ref float frequency)
		{
			return FMOD_Channel_GetFrequency(channelraw, ref frequency);
		}
		public RESULT setPan                (float pan)
		{
			return FMOD_Channel_SetPan(channelraw, pan);
		}
		public RESULT getPan                (ref float pan)
		{
			return FMOD_Channel_GetPan(channelraw, ref pan);
		}
		public RESULT setDelay              (DELAYTYPE delaytype, uint delayhi, uint delaylo)
		{
			return FMOD_Channel_SetDelay(channelraw, delaytype, delayhi, delaylo);
		}
		public RESULT getDelay              (DELAYTYPE delaytype, ref uint delayhi, ref uint delaylo)
		{
			return FMOD_Channel_GetDelay(channelraw, delaytype, ref delayhi, ref delaylo);
		}
		public RESULT setSpeakerMix         (float frontleft, float frontright, float center, float lfe, float backleft, float backright, float sideleft, float sideright)
		{
			return FMOD_Channel_SetSpeakerMix(channelraw, frontleft, frontright, center, lfe, backleft, backright, sideleft, sideright);
		}
		public RESULT getSpeakerMix         (ref float frontleft, ref float frontright, ref float center, ref float lfe, ref float backleft, ref float backright, ref float sideleft, ref float sideright)
		{
			return FMOD_Channel_GetSpeakerMix(channelraw, ref frontleft, ref frontright, ref center, ref lfe, ref backleft, ref backright, ref sideleft, ref sideright);
		}
		public RESULT setSpeakerLevels      (SPEAKER speaker, float[] levels, int numlevels)
		{
			return FMOD_Channel_SetSpeakerLevels(channelraw, speaker, levels, numlevels);
		}
		public RESULT getSpeakerLevels      (SPEAKER speaker, float[] levels, int numlevels)
		{
			return FMOD_Channel_GetSpeakerLevels(channelraw, speaker, levels, numlevels);
		}
		public RESULT setInputChannelMix    (float[] levels, int numlevels)
		{
			return FMOD_Channel_SetInputChannelMix(channelraw, levels, numlevels);
		}
		public RESULT getInputChannelMix    (float[] levels, int numlevels)
		{
			return FMOD_Channel_GetInputChannelMix(channelraw, levels, numlevels);
		}
		public RESULT setMute               (bool mute)
		{
			return FMOD_Channel_SetMute(channelraw, (mute ? 1 : 0));
		}
		public RESULT getMute               (ref bool mute)
		{
			RESULT result;
			int m = 0;

			result = FMOD_Channel_GetMute(channelraw, ref m);

			mute = (m != 0);

			return result;
		}
		public RESULT setPriority           (int priority)
		{
			return FMOD_Channel_SetPriority(channelraw, priority);
		}
		public RESULT getPriority           (ref int priority)
		{
			return FMOD_Channel_GetPriority(channelraw, ref priority);
		}
		public RESULT setPosition           (uint position, TIMEUNIT postype)
		{
			return FMOD_Channel_SetPosition(channelraw, position, postype);
		}
		public RESULT getPosition           (ref uint position, TIMEUNIT postype)
		{
			return FMOD_Channel_GetPosition(channelraw, ref position, postype);
		}
        
		public RESULT setLowPassGain           (float gain)
		{
			return FMOD_Channel_SetLowPassGain(channelraw, gain);
		}
		public RESULT getLowPassGain           (ref float gain)
		{
			return FMOD_Channel_GetLowPassGain(channelraw, ref gain);
		}
        
		public RESULT setReverbProperties   (ref REVERB_CHANNELPROPERTIES prop)
		{
			return FMOD_Channel_SetReverbProperties(channelraw, ref prop);
		}
		public RESULT getReverbProperties   (ref REVERB_CHANNELPROPERTIES prop)
		{
			return FMOD_Channel_GetReverbProperties(channelraw, ref prop);
		}
		public RESULT setChannelGroup       (ChannelGroup channelgroup)
		{
			return FMOD_Channel_SetChannelGroup(channelraw, channelgroup.getRaw());
		}
		public RESULT getChannelGroup        (ref ChannelGroup channelgroup)
		{
			RESULT result = RESULT.OK;
			IntPtr channelgroupraw = new IntPtr();
			ChannelGroup    channelgroupnew = null;

			try
			{
				result = FMOD_Channel_GetChannelGroup(channelraw, ref channelgroupraw);
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

		public RESULT setCallback           (CHANNEL_CALLBACK callback)
		{
			return FMOD_Channel_SetCallback(channelraw, callback);
		}


		public RESULT set3DAttributes       (ref VECTOR pos, ref VECTOR vel)
		{
			return FMOD_Channel_Set3DAttributes(channelraw, ref pos, ref vel);
		}
		public RESULT get3DAttributes       (ref VECTOR pos, ref VECTOR vel)
		{
			return FMOD_Channel_Get3DAttributes(channelraw, ref pos, ref vel);
		}
		public RESULT set3DMinMaxDistance   (float mindistance, float maxdistance)
		{
			return FMOD_Channel_Set3DMinMaxDistance(channelraw, mindistance, maxdistance);
		}
		public RESULT get3DMinMaxDistance   (ref float mindistance, ref float maxdistance)
		{
			return FMOD_Channel_Get3DMinMaxDistance(channelraw, ref mindistance, ref maxdistance);
		}
		public RESULT set3DConeSettings     (float insideconeangle, float outsideconeangle, float outsidevolume)
		{
			return FMOD_Channel_Set3DConeSettings(channelraw, insideconeangle, outsideconeangle, outsidevolume);
		}
		public RESULT get3DConeSettings     (ref float insideconeangle, ref float outsideconeangle, ref float outsidevolume)
		{
			return FMOD_Channel_Get3DConeSettings(channelraw, ref insideconeangle, ref outsideconeangle, ref outsidevolume);
		}
		public RESULT set3DConeOrientation  (ref VECTOR orientation)
		{
			return FMOD_Channel_Set3DConeOrientation(channelraw, ref orientation);
		}
		public RESULT get3DConeOrientation  (ref VECTOR orientation)
		{
			return FMOD_Channel_Get3DConeOrientation(channelraw, ref orientation);
		}
		public RESULT set3DCustomRolloff    (ref VECTOR points, int numpoints)
		{
			return FMOD_Channel_Set3DCustomRolloff(channelraw, ref points, numpoints);
		}
		public RESULT get3DCustomRolloff    (ref IntPtr points, ref int numpoints)
		{
			return FMOD_Channel_Get3DCustomRolloff(channelraw, ref points, ref numpoints);
		}
		public RESULT set3DOcclusion        (float directocclusion, float reverbocclusion)
		{
			return FMOD_Channel_Set3DOcclusion(channelraw, directocclusion, reverbocclusion);
		}
		public RESULT get3DOcclusion        (ref float directocclusion, ref float reverbocclusion)
		{
			return FMOD_Channel_Get3DOcclusion(channelraw, ref directocclusion, ref reverbocclusion);
		}
		public RESULT set3DSpread           (float angle)
		{
			return FMOD_Channel_Set3DSpread(channelraw, angle);
		}
		public RESULT get3DSpread           (ref float angle)
		{
			return FMOD_Channel_Get3DSpread(channelraw, ref angle);
		}
		public RESULT set3DPanLevel         (float level)
		{
			return FMOD_Channel_Set3DPanLevel(channelraw, level);
		}
		public RESULT get3DPanLevel         (ref float level)
		{
			return FMOD_Channel_Get3DPanLevel(channelraw, ref level);
		}
		public RESULT set3DDopplerLevel     (float level)
		{
			return FMOD_Channel_Set3DDopplerLevel(channelraw, level);
		}
		public RESULT get3DDopplerLevel     (ref float level)
		{
			return FMOD_Channel_Get3DDopplerLevel(channelraw, ref level);
		}

		public RESULT isPlaying             (ref bool isplaying)
		{
			RESULT result;
			int p = 0;

			result = FMOD_Channel_IsPlaying(channelraw, ref p);

			isplaying = (p != 0);

			return result;
		}
		public RESULT isVirtual             (ref bool isvirtual)
		{
			RESULT result;
			int v = 0;

			result = FMOD_Channel_IsVirtual(channelraw, ref v);

			isvirtual = (v != 0);

			return result;
		}
		public RESULT getAudibility         (ref float audibility)
		{
			return FMOD_Channel_GetAudibility(channelraw, ref audibility);
		}
		public RESULT getCurrentSound       (ref Sound sound)
		{
			RESULT result      = RESULT.OK;
			IntPtr soundraw    = new IntPtr();
			Sound  soundnew    = null;

			try
			{
				result = FMOD_Channel_GetCurrentSound(channelraw, ref soundraw);
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
		public RESULT getSpectrum           (float[] spectrumarray, int numvalues, int channeloffset, DSP_FFT_WINDOW windowtype)
		{
			return FMOD_Channel_GetSpectrum(channelraw, spectrumarray, numvalues, channeloffset, windowtype);
		}
		public RESULT getWaveData           (float[] wavearray, int numvalues, int channeloffset)
		{
			return FMOD_Channel_GetWaveData(channelraw, wavearray, numvalues, channeloffset);
		}
		public RESULT getIndex              (ref int index)
		{
			return FMOD_Channel_GetIndex(channelraw, ref index);
		}

		public RESULT getDSPHead            (ref DSP dsp)
		{
			RESULT result      = RESULT.OK;
			IntPtr dspraw      = new IntPtr();
			DSP    dspnew      = null;

			try
			{
				result = FMOD_Channel_GetDSPHead(channelraw, ref dspraw);
			}
			catch
			{
				result = RESULT.ERR_INVALID_PARAM;
			}
			if (result != RESULT.OK)
			{
				return result;
			}

			dspnew = new DSP();
			dspnew.setRaw(dspraw);
			dsp = dspnew;

			return result; 
		}
		public RESULT addDSP                (DSP dsp, ref DSPConnection connection)
		{
			RESULT result = RESULT.OK;
			IntPtr dspconnectionraw = new IntPtr();
			DSPConnection dspconnectionnew = null;

			try
			{
				result = FMOD_Channel_AddDSP(channelraw, dsp.getRaw(), ref dspconnectionraw);
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
         
            
		public RESULT setMode               (MODE mode)
		{
			return FMOD_Channel_SetMode(channelraw, mode);
		}
		public RESULT getMode               (ref MODE mode)
		{
			return FMOD_Channel_GetMode(channelraw, ref mode);
		}
		public RESULT setLoopCount          (int loopcount)
		{
			return FMOD_Channel_SetLoopCount(channelraw, loopcount);
		}
		public RESULT getLoopCount          (ref int loopcount)
		{
			return FMOD_Channel_GetLoopCount(channelraw, ref loopcount);
		}
		public RESULT setLoopPoints         (uint loopstart, TIMEUNIT loopstarttype, uint loopend, TIMEUNIT loopendtype)
		{
			return FMOD_Channel_SetLoopPoints(channelraw, loopstart, loopstarttype, loopend, loopendtype);
		}
		public RESULT getLoopPoints         (ref uint loopstart, TIMEUNIT loopstarttype, ref uint loopend, TIMEUNIT loopendtype)
		{
			return FMOD_Channel_GetLoopPoints(channelraw, ref loopstart, loopstarttype, ref loopend, loopendtype);
		}


		public RESULT setUserData           (IntPtr userdata)
		{
			return FMOD_Channel_SetUserData(channelraw, userdata);
		}
		public RESULT getUserData           (ref IntPtr userdata)
		{
			return FMOD_Channel_GetUserData(channelraw, ref userdata);
		}

		public RESULT getMemoryInfo(uint memorybits, uint event_memorybits, ref uint memoryused, ref MEMORY_USAGE_DETAILS memoryused_details)
		{
			return FMOD_Channel_GetMemoryInfo(channelraw, memorybits, event_memorybits, ref memoryused, ref memoryused_details);
		}

		#region importfunctions

		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Channel_GetSystemObject       (IntPtr channel, ref IntPtr system);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Channel_Stop                  (IntPtr channel);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Channel_SetPaused             (IntPtr channel, int paused);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Channel_GetPaused             (IntPtr channel, ref int paused);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Channel_SetVolume             (IntPtr channel, float volume);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Channel_GetVolume             (IntPtr channel, ref float volume);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Channel_SetFrequency          (IntPtr channel, float frequency);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Channel_GetFrequency          (IntPtr channel, ref float frequency);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Channel_SetPan                (IntPtr channel, float pan);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Channel_GetPan                (IntPtr channel, ref float pan);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Channel_SetDelay              (IntPtr channel, DELAYTYPE delaytype, uint delayhi, uint delaylo);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Channel_GetDelay              (IntPtr channel, DELAYTYPE delaytype, ref uint delayhi, ref uint delaylo);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Channel_SetSpeakerMix         (IntPtr channel, float frontleft, float frontright, float center, float lfe, float backleft, float backright, float sideleft, float sideright);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Channel_GetSpeakerMix         (IntPtr channel, ref float frontleft, ref float frontright, ref float center, ref float lfe, ref float backleft, ref float backright, ref float sideleft, ref float sideright);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Channel_SetSpeakerLevels      (IntPtr channel, SPEAKER speaker, float[] levels, int numlevels);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Channel_GetSpeakerLevels      (IntPtr channel, SPEAKER speaker, [MarshalAs(UnmanagedType.LPArray)]float[] levels, int numlevels);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Channel_SetInputChannelMix    (IntPtr channel, float[] levels, int numlevels);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Channel_GetInputChannelMix    (IntPtr channel, [MarshalAs(UnmanagedType.LPArray)]float[] levels, int numlevels);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Channel_SetMute               (IntPtr channel, int mute);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Channel_GetMute               (IntPtr channel, ref int mute);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Channel_SetPriority           (IntPtr channel, int priority);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Channel_GetPriority           (IntPtr channel, ref int priority);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Channel_Set3DAttributes       (IntPtr channel, ref VECTOR pos, ref VECTOR vel);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Channel_Get3DAttributes       (IntPtr channel, ref VECTOR pos, ref VECTOR vel);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Channel_Set3DMinMaxDistance   (IntPtr channel, float mindistance, float maxdistance);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Channel_Get3DMinMaxDistance   (IntPtr channel, ref float mindistance, ref float maxdistance);
		[DllImport (VERSION.dll)]        
		private static extern RESULT FMOD_Channel_Set3DConeSettings     (IntPtr channel, float insideconeangle, float outsideconeangle, float outsidevolume);
		[DllImport (VERSION.dll)] 
		private static extern RESULT FMOD_Channel_Get3DConeSettings     (IntPtr channel, ref float insideconeangle, ref float outsideconeangle, ref float outsidevolume);
		[DllImport (VERSION.dll)] 
		private static extern RESULT FMOD_Channel_Set3DConeOrientation  (IntPtr channel, ref VECTOR orientation);
		[DllImport (VERSION.dll)] 
		private static extern RESULT FMOD_Channel_Get3DConeOrientation  (IntPtr channel, ref VECTOR orientation);
		[DllImport (VERSION.dll)] 
		private static extern RESULT FMOD_Channel_Set3DCustomRolloff    (IntPtr channel, ref VECTOR points, int numpoints);
		[DllImport (VERSION.dll)] 
		private static extern RESULT FMOD_Channel_Get3DCustomRolloff    (IntPtr channel, ref IntPtr points, ref int numpoints);
		[DllImport (VERSION.dll)]        
		private static extern RESULT FMOD_Channel_Set3DOcclusion        (IntPtr channel, float directocclusion, float reverbocclusion);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Channel_Get3DOcclusion        (IntPtr channel, ref float directocclusion, ref float reverbocclusion);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Channel_Set3DSpread           (IntPtr channel, float angle);
		[DllImport (VERSION.dll)]    
		private static extern RESULT FMOD_Channel_Get3DSpread           (IntPtr channel, ref float angle);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Channel_Set3DPanLevel         (IntPtr channel, float level);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Channel_Get3DPanLevel         (IntPtr channel, ref float level);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Channel_Set3DDopplerLevel     (IntPtr channel, float level);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Channel_Get3DDopplerLevel     (IntPtr channel, ref float level);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Channel_SetReverbProperties   (IntPtr channel, ref REVERB_CHANNELPROPERTIES prop);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Channel_GetReverbProperties   (IntPtr channel, ref REVERB_CHANNELPROPERTIES prop);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Channel_SetLowPassGain        (IntPtr channel, float gain);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Channel_GetLowPassGain        (IntPtr channel, ref float gain);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Channel_SetChannelGroup       (IntPtr channel, IntPtr channelgroup);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Channel_GetChannelGroup       (IntPtr channel, ref IntPtr channelgroup);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Channel_IsPlaying             (IntPtr channel, ref int isplaying);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Channel_IsVirtual             (IntPtr channel, ref int isvirtual);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Channel_GetAudibility         (IntPtr channel, ref float audibility);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Channel_GetCurrentSound       (IntPtr channel, ref IntPtr sound);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Channel_GetSpectrum           (IntPtr channel, [MarshalAs(UnmanagedType.LPArray)] float[] spectrumarray, int numvalues, int channeloffset, DSP_FFT_WINDOW windowtype);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Channel_GetWaveData           (IntPtr channel, [MarshalAs(UnmanagedType.LPArray)] float[] wavearray, int numvalues, int channeloffset);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Channel_GetIndex              (IntPtr channel, ref int index);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Channel_SetCallback           (IntPtr channel, CHANNEL_CALLBACK callback);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Channel_SetPosition           (IntPtr channel, uint position, TIMEUNIT postype);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Channel_GetPosition           (IntPtr channel, ref uint position, TIMEUNIT postype);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Channel_GetDSPHead            (IntPtr channel, ref IntPtr dsp);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Channel_AddDSP                (IntPtr channel, IntPtr dsp, ref IntPtr connection);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Channel_SetMode               (IntPtr channel, MODE mode);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Channel_GetMode               (IntPtr channel, ref MODE mode);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Channel_SetLoopCount          (IntPtr channel, int loopcount);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Channel_GetLoopCount          (IntPtr channel, ref int loopcount);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Channel_SetLoopPoints         (IntPtr channel, uint  loopstart, TIMEUNIT loopstarttype, uint  loopend, TIMEUNIT loopendtype);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Channel_GetLoopPoints         (IntPtr channel, ref uint loopstart, TIMEUNIT loopstarttype, ref uint loopend, TIMEUNIT loopendtype);
		[DllImport (VERSION.dll)]                                        
		private static extern RESULT FMOD_Channel_SetUserData           (IntPtr channel, IntPtr userdata);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Channel_GetUserData           (IntPtr channel, ref IntPtr userdata);
		[DllImport(VERSION.dll)]
		private static extern RESULT FMOD_Channel_GetMemoryInfo         (IntPtr channel, uint memorybits, uint event_memorybits, ref uint memoryused, ref MEMORY_USAGE_DETAILS memoryused_details);
		#endregion
        
		#region wrapperinternal

		private IntPtr channelraw;

		public void setRaw(IntPtr channel)
		{
			channelraw = new IntPtr();

			channelraw = channel;
		}

		public IntPtr getRaw()
		{
			return channelraw;
		}

		#endregion
	}
}