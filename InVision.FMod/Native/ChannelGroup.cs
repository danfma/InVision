using System;
using System.Runtime.InteropServices;
using System.Text;

namespace InVision.FMod.Native
{
	public class ChannelGroup
	{
		public RESULT release                ()
		{
			return FMOD_ChannelGroup_Release(channelgroupraw);
		}
		public RESULT getSystemObject        (ref System system)
		{
			RESULT result = RESULT.OK;
			IntPtr systemraw = new IntPtr();
			System systemnew = null;

			try
			{
				result = FMOD_ChannelGroup_GetSystemObject(channelgroupraw, ref systemraw);
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


		// Channelgroup scale values.  (scales the current volume or pitch of all channels and channel groups, DOESN'T overwrite)
		public RESULT setVolume              (float volume)
		{
			return FMOD_ChannelGroup_SetVolume(channelgroupraw, volume);
		}
		public RESULT getVolume              (ref float volume)
		{
			return FMOD_ChannelGroup_GetVolume(channelgroupraw, ref volume);
		}
		public RESULT setPitch               (float pitch)
		{
			return FMOD_ChannelGroup_SetPitch(channelgroupraw, pitch);
		}
		public RESULT getPitch               (ref float pitch)
		{
			return FMOD_ChannelGroup_GetPitch(channelgroupraw, ref pitch);
		}
		public RESULT set3DOcclusion               (float directocclusion, float reverbocclusion)
		{
			return FMOD_ChannelGroup_Set3DOcclusion(channelgroupraw, directocclusion, reverbocclusion);
		}
		public RESULT get3DOcclusion               (ref float directocclusion, ref float reverbocclusion)
		{
			return FMOD_ChannelGroup_Get3DOcclusion(channelgroupraw, ref directocclusion, ref reverbocclusion);
		}
		public RESULT setPaused              (bool paused)
		{
			return FMOD_ChannelGroup_SetPaused(channelgroupraw, (paused ? 1 : 0));
		}
		public RESULT getPaused              (ref bool paused)
		{
			RESULT result;
			int p = 0;

			result = FMOD_ChannelGroup_GetPaused(channelgroupraw, ref p);

			paused = (p != 0);

			return result;
		}
		public RESULT setMute                (bool mute)
		{
			return FMOD_ChannelGroup_SetMute(channelgroupraw, (mute ? 1 : 0));
		}
		public RESULT getMute                (ref bool mute)
		{
			RESULT result;
			int m = 0;

			result = FMOD_ChannelGroup_GetMute(channelgroupraw, ref m);
            
			mute = (m != 0);

			return result;
		}


		// Channelgroup override values.  (recursively overwrites whatever settings the channels had)
		public RESULT stop                   ()
		{
			return FMOD_ChannelGroup_Stop(channelgroupraw);
		}
		public RESULT overrideVolume         (float volume)
		{
			return FMOD_ChannelGroup_OverrideVolume(channelgroupraw, volume);
		}
		public RESULT overrideFrequency      (float frequency)
		{
			return FMOD_ChannelGroup_OverrideFrequency(channelgroupraw, frequency);
		}
		public RESULT overridePan            (float pan)
		{
			return FMOD_ChannelGroup_OverridePan(channelgroupraw, pan);
		}
		public RESULT overrideReverbProperties (ref REVERB_CHANNELPROPERTIES prop)
		{
			return FMOD_ChannelGroup_OverrideReverbProperties(channelgroupraw, ref prop);
		}
		public RESULT override3DAttributes   (ref VECTOR pos, ref VECTOR vel)
		{
			return FMOD_ChannelGroup_Override3DAttributes(channelgroupraw, ref pos, ref vel);
		}
		public RESULT overrideSpeakerMix     (float frontleft, float frontright, float center, float lfe, float backleft, float backright, float sideleft, float sideright)
		{
			return FMOD_ChannelGroup_OverrideSpeakerMix(channelgroupraw, frontleft, frontright, center, lfe, backleft, backright, sideleft, sideright);
		}


		// Nested channel groups.
		public RESULT addGroup               (ChannelGroup group)
		{
			return FMOD_ChannelGroup_AddGroup(channelgroupraw, group.getRaw());
		}
		public RESULT getNumGroups           (ref int numgroups)
		{
			return FMOD_ChannelGroup_GetNumGroups(channelgroupraw, ref numgroups);
		}
		public RESULT getGroup               (int index, ref ChannelGroup group)
		{
			RESULT result = RESULT.OK;
			IntPtr channelraw = new IntPtr();
			ChannelGroup    channelnew = null;

			try
			{
				result = FMOD_ChannelGroup_GetGroup(channelgroupraw, index, ref channelraw);
			}
			catch
			{
				result = RESULT.ERR_INVALID_PARAM;
			}
			if (result != RESULT.OK)
			{
				return result;
			}

			if (group == null)
			{
				channelnew = new ChannelGroup();
				channelnew.setRaw(channelraw);
				group = channelnew;
			}
			else
			{
				group.setRaw(channelraw);
			}
                             
			return result;
		}
		public RESULT getParentGroup         (ref ChannelGroup group)
		{
			RESULT result = RESULT.OK;
			IntPtr channelraw = new IntPtr();
			ChannelGroup    channelnew = null;

			try
			{
				result = FMOD_ChannelGroup_GetParentGroup(channelgroupraw, ref channelraw);
			}
			catch
			{
				result = RESULT.ERR_INVALID_PARAM;
			}
			if (result != RESULT.OK)
			{
				return result;
			}

			if (group == null)
			{
				channelnew = new ChannelGroup();
				channelnew.setRaw(channelraw);
				group = channelnew;
			}
			else
			{
				group.setRaw(channelraw);
			}
                             
			return result;
		}


		// DSP functionality only for channel groups playing sounds created with FMOD_SOFTWARE.
		public RESULT getDSPHead             (ref DSP dsp)
		{
			RESULT result = RESULT.OK;
			IntPtr dspraw = new IntPtr();
			DSP    dspnew = null;

			try
			{
				result = FMOD_ChannelGroup_GetDSPHead(channelgroupraw, ref dspraw);
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
				result = FMOD_ChannelGroup_AddDSP(channelgroupraw, dsp.getRaw(), ref dspconnectionraw);
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


		// Information only functions.
		public RESULT getName                (StringBuilder name, int namelen)
		{
			return FMOD_ChannelGroup_GetName(channelgroupraw, name, namelen);
		}
		public RESULT getNumChannels         (ref int numchannels)
		{
			return FMOD_ChannelGroup_GetNumChannels(channelgroupraw, ref numchannels);
		}
		public RESULT getChannel             (int index, ref Channel channel)
		{
			RESULT result = RESULT.OK;
			IntPtr channelraw = new IntPtr();
			Channel    channelnew = null;

			try
			{
				result = FMOD_ChannelGroup_GetChannel(channelgroupraw, index, ref channelraw);
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
		public RESULT getSpectrum            (float[] spectrumarray, int numvalues, int channeloffset, DSP_FFT_WINDOW windowtype)
		{
			return FMOD_ChannelGroup_GetSpectrum(channelgroupraw, spectrumarray, numvalues, channeloffset, windowtype);
		}
		public RESULT getWaveData            (float[] wavearray, int numvalues, int channeloffset)
		{
			return FMOD_ChannelGroup_GetWaveData(channelgroupraw, wavearray, numvalues, channeloffset);
		}


		// Userdata set/get.
		public RESULT setUserData            (IntPtr userdata)
		{
			return FMOD_ChannelGroup_SetUserData(channelgroupraw, userdata);
		}
		public RESULT getUserData            (ref IntPtr userdata)
		{
			return FMOD_ChannelGroup_GetUserData(channelgroupraw, ref userdata);
		}

		public RESULT getMemoryInfo(uint memorybits, uint event_memorybits, ref uint memoryused, ref MEMORY_USAGE_DETAILS memoryused_details)
		{
			return FMOD_ChannelGroup_GetMemoryInfo(channelgroupraw, memorybits, event_memorybits, ref memoryused, ref memoryused_details);
		}

		#region importfunctions


		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_ChannelGroup_Release          (IntPtr channelgroup);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_ChannelGroup_GetSystemObject  (IntPtr channelgroup, ref IntPtr system);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_ChannelGroup_SetVolume        (IntPtr channelgroup, float volume);
		[DllImport (VERSION.dll)]        
		private static extern RESULT FMOD_ChannelGroup_GetVolume        (IntPtr channelgroup, ref float volume);
		[DllImport (VERSION.dll)]       
		private static extern RESULT FMOD_ChannelGroup_SetPitch         (IntPtr channelgroup, float pitch);
		[DllImport (VERSION.dll)]       
		private static extern RESULT FMOD_ChannelGroup_GetPitch         (IntPtr channelgroup, ref float pitch);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_ChannelGroup_Set3DOcclusion   (IntPtr channelgroup, float directocclusion, float reverbocclusion);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_ChannelGroup_Get3DOcclusion   (IntPtr channelgroup, ref float directocclusion, ref float reverbocclusion);
		[DllImport (VERSION.dll)]        
		private static extern RESULT FMOD_ChannelGroup_SetPaused        (IntPtr channelgroup, int paused);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_ChannelGroup_GetPaused        (IntPtr channelgroup, ref int paused);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_ChannelGroup_SetMute          (IntPtr channelgroup, int mute);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_ChannelGroup_GetMute          (IntPtr channelgroup, ref int mute);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_ChannelGroup_Stop             (IntPtr channelgroup);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_ChannelGroup_OverridePaused   (IntPtr channelgroup, int paused);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_ChannelGroup_OverrideVolume   (IntPtr channelgroup, float volume);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_ChannelGroup_OverrideFrequency(IntPtr channelgroup, float frequency);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_ChannelGroup_OverridePan      (IntPtr channelgroup, float pan);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_ChannelGroup_OverrideMute     (IntPtr channelgroup, int mute);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_ChannelGroup_OverrideReverbProperties(IntPtr channelgroup, ref REVERB_CHANNELPROPERTIES prop);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_ChannelGroup_Override3DAttributes  (IntPtr channelgroup, ref VECTOR pos, ref VECTOR vel);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_ChannelGroup_OverrideSpeakerMix(IntPtr channelgroup, float frontleft, float frontright, float center, float lfe, float backleft, float backright, float sideleft, float sideright);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_ChannelGroup_AddGroup         (IntPtr channelgroup, IntPtr group);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_ChannelGroup_GetNumGroups     (IntPtr channelgroup, ref int numgroups);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_ChannelGroup_GetGroup         (IntPtr channelgroup, int index, ref IntPtr group);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_ChannelGroup_GetParentGroup   (IntPtr channelgroup, ref IntPtr group);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_ChannelGroup_GetDSPHead       (IntPtr channelgroup, ref IntPtr dsp);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_ChannelGroup_AddDSP           (IntPtr channelgroup, IntPtr dsp, ref IntPtr connection);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_ChannelGroup_GetName          (IntPtr channelgroup, StringBuilder name, int namelen);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_ChannelGroup_GetNumChannels   (IntPtr channelgroup, ref int numchannels);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_ChannelGroup_GetChannel       (IntPtr channelgroup, int index, ref IntPtr channel);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_ChannelGroup_GetSpectrum      (IntPtr channelgroup, [MarshalAs(UnmanagedType.LPArray)] float[] spectrumarray, int numvalues, int channeloffset, DSP_FFT_WINDOW windowtype);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_ChannelGroup_GetWaveData      (IntPtr channelgroup, [MarshalAs(UnmanagedType.LPArray)] float[] wavearray, int numvalues, int channeloffset);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_ChannelGroup_SetUserData      (IntPtr channelgroup, IntPtr userdata);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_ChannelGroup_GetUserData      (IntPtr channelgroup, ref IntPtr userdata);
		[DllImport(VERSION.dll)]
		private static extern RESULT FMOD_ChannelGroup_GetMemoryInfo    (IntPtr channelgroup, uint memorybits, uint event_memorybits, ref uint memoryused, ref MEMORY_USAGE_DETAILS memoryused_details);
		#endregion

		#region wrapperinternal

		private IntPtr channelgroupraw;

		public void setRaw(IntPtr channelgroup)
		{
			channelgroupraw = new IntPtr();

			channelgroupraw = channelgroup;
		}

		public IntPtr getRaw()
		{
			return channelgroupraw;
		}

		#endregion
	}
}