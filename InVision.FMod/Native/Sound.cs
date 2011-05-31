using System;
using System.Runtime.InteropServices;
using System.Text;

namespace InVision.FMod.Native
{
	public class Sound
	{
		public RESULT release                 ()
		{
			return FMOD_Sound_Release(soundraw);
		}
		public RESULT getSystemObject         (ref System system)
		{
			RESULT result   = RESULT.OK;
			IntPtr systemraw   = new IntPtr();
			System systemnew   = null;

			try
			{
				result = FMOD_Sound_GetSystemObject(soundraw, ref systemraw);
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
                     

		public RESULT @lock                   (uint offset, uint length, ref IntPtr ptr1, ref IntPtr ptr2, ref uint len1, ref uint len2)
		{
			return FMOD_Sound_Lock(soundraw, offset, length, ref ptr1, ref ptr2, ref len1, ref len2);
		}
		public RESULT unlock                  (IntPtr ptr1,  IntPtr ptr2, uint len1, uint len2)
		{
			return FMOD_Sound_Unlock(soundraw, ptr1, ptr2, len1, len2);
		}
		public RESULT setDefaults             (float frequency, float volume, float pan, int priority)
		{
			return FMOD_Sound_SetDefaults(soundraw, frequency, volume, pan, priority);
		}
		public RESULT getDefaults             (ref float frequency, ref float volume, ref float pan, ref int priority)
		{
			return FMOD_Sound_GetDefaults(soundraw, ref frequency, ref volume, ref pan, ref priority);
		}
		public RESULT setVariations           (float frequencyvar, float volumevar, float panvar)
		{
			return FMOD_Sound_SetVariations(soundraw, frequencyvar, volumevar, panvar);
		}
		public RESULT getVariations           (ref float frequencyvar, ref float volumevar, ref float panvar)
		{
			return FMOD_Sound_GetVariations(soundraw, ref frequencyvar, ref volumevar, ref panvar); 
		}
		public RESULT set3DMinMaxDistance     (float min, float max)
		{
			return FMOD_Sound_Set3DMinMaxDistance(soundraw, min, max);
		}
		public RESULT get3DMinMaxDistance     (ref float min, ref float max)
		{
			return FMOD_Sound_Get3DMinMaxDistance(soundraw, ref min, ref max);
		}
		public RESULT set3DConeSettings       (float insideconeangle, float outsideconeangle, float outsidevolume)
		{
			return FMOD_Sound_Set3DConeSettings(soundraw, insideconeangle, outsideconeangle, outsidevolume);
		}
		public RESULT get3DConeSettings       (ref float insideconeangle, ref float outsideconeangle, ref float outsidevolume)
		{
			return FMOD_Sound_Get3DConeSettings(soundraw, ref insideconeangle, ref outsideconeangle, ref outsidevolume);
		}
		public RESULT set3DCustomRolloff      (ref VECTOR points, int numpoints)
		{
			return FMOD_Sound_Set3DCustomRolloff(soundraw, ref points, numpoints);
		}
		public RESULT get3DCustomRolloff      (ref IntPtr points, ref int numpoints)
		{
			return FMOD_Sound_Get3DCustomRolloff(soundraw, ref points, ref numpoints);
		}
		public RESULT setSubSound             (int index, Sound subsound)
		{
			IntPtr subsoundraw = subsound.getRaw();

			return FMOD_Sound_SetSubSound(soundraw, index, subsoundraw);
		}
		public RESULT getSubSound             (int index, ref Sound subsound)
		{
			RESULT result       = RESULT.OK;
			IntPtr subsoundraw  = new IntPtr();
			Sound  subsoundnew  = null;

			try
			{
				result = FMOD_Sound_GetSubSound(soundraw, index, ref subsoundraw);
			}
			catch
			{
				result = RESULT.ERR_INVALID_PARAM;
			}
			if (result != RESULT.OK)
			{
				return result;
			}

			if (subsound == null)
			{
				subsoundnew = new Sound();
				subsoundnew.setRaw(subsoundraw);
				subsound = subsoundnew;
			}
			else
			{
				subsound.setRaw(subsoundraw);
			}

			return result;
		}
		public RESULT setSubSoundSentence     (int[] subsoundlist, int numsubsounds)
		{
			return FMOD_Sound_SetSubSoundSentence(soundraw, subsoundlist, numsubsounds);
		}
		public RESULT getName                 (StringBuilder name, int namelen)
		{
			return FMOD_Sound_GetName(soundraw, name, namelen);
		}
		public RESULT getLength               (ref uint length, TIMEUNIT lengthtype)
		{
			return FMOD_Sound_GetLength(soundraw, ref length, lengthtype);
		}
		public RESULT getFormat               (ref SOUND_TYPE type, ref SOUND_FORMAT format, ref int channels, ref int bits)
		{
			return FMOD_Sound_GetFormat(soundraw, ref type, ref format, ref channels, ref bits);
		}
		public RESULT getNumSubSounds         (ref int numsubsounds)
		{
			return FMOD_Sound_GetNumSubSounds(soundraw, ref numsubsounds);
		}
		public RESULT getNumTags              (ref int numtags, ref int numtagsupdated)
		{
			return FMOD_Sound_GetNumTags(soundraw, ref numtags, ref numtagsupdated);
		}
		public RESULT getTag                  (string name, int index, ref TAG tag)
		{
			return FMOD_Sound_GetTag(soundraw, name, index, ref tag);
		}
		public RESULT getOpenState            (ref OPENSTATE openstate, ref uint percentbuffered, ref bool starving, ref bool diskbusy)
		{
			RESULT result;
			int s = 0;
			int b = 0;

			result = FMOD_Sound_GetOpenState(soundraw, ref openstate, ref percentbuffered, ref s, ref b);

			starving = (s != 0);
			diskbusy = (b != 0);

			return result;
		}
		public RESULT readData                (IntPtr buffer, uint lenbytes, ref uint read)
		{
			return FMOD_Sound_ReadData(soundraw, buffer, lenbytes, ref read);
		}
		public RESULT seekData                (uint pcm)
		{
			return FMOD_Sound_SeekData(soundraw, pcm);
		}


		public RESULT setSoundGroup           (SoundGroup soundgroup)
		{
			return FMOD_Sound_SetSoundGroup(soundraw, soundgroup.getRaw());
		}
		public RESULT getSoundGroup           (ref SoundGroup soundgroup)
		{
			RESULT result = RESULT.OK;
			IntPtr soundgroupraw = new IntPtr();
			SoundGroup    soundgroupnew = null;

			try
			{
				result = FMOD_Sound_GetSoundGroup(soundraw, ref soundgroupraw);
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


		public RESULT getNumSyncPoints        (ref int numsyncpoints)
		{
			return FMOD_Sound_GetNumSyncPoints(soundraw, ref numsyncpoints);
		}
		public RESULT getSyncPoint            (int index, ref IntPtr point)
		{
			return FMOD_Sound_GetSyncPoint(soundraw, index, ref point);
		}
		public RESULT getSyncPointInfo        (IntPtr point, StringBuilder name, int namelen, ref uint offset, TIMEUNIT offsettype)
		{
			return FMOD_Sound_GetSyncPointInfo(soundraw, point, name, namelen, ref offset, offsettype);
		}
		public RESULT addSyncPoint            (uint offset, TIMEUNIT offsettype, string name, ref IntPtr point)
		{
			return FMOD_Sound_AddSyncPoint(soundraw, offset, offsettype, name, ref point);
		}
		public RESULT deleteSyncPoint         (IntPtr point)
		{
			return FMOD_Sound_DeleteSyncPoint(soundraw, point);
		}


		public RESULT setMode                 (MODE mode)
		{
			return FMOD_Sound_SetMode(soundraw, mode);
		}
		public RESULT getMode                 (ref MODE mode)
		{
			return FMOD_Sound_GetMode(soundraw, ref mode);
		}
		public RESULT setLoopCount            (int loopcount)
		{
			return FMOD_Sound_SetLoopCount(soundraw, loopcount);
		}
		public RESULT getLoopCount            (ref int loopcount)
		{
			return FMOD_Sound_GetLoopCount(soundraw, ref loopcount);
		}
		public RESULT setLoopPoints           (uint loopstart, TIMEUNIT loopstarttype, uint loopend, TIMEUNIT loopendtype)
		{
			return FMOD_Sound_SetLoopPoints(soundraw, loopstart, loopstarttype, loopend, loopendtype);
		}
		public RESULT getLoopPoints           (ref uint loopstart, TIMEUNIT loopstarttype, ref uint loopend, TIMEUNIT loopendtype)
		{
			return FMOD_Sound_GetLoopPoints(soundraw, ref loopstart, loopstarttype, ref loopend, loopendtype);
		}

		public RESULT getMusicNumChannels       (ref int numchannels)
		{
			return FMOD_Sound_GetMusicNumChannels(soundraw, ref numchannels);
		}
		public RESULT setMusicChannelVolume     (int channel, float volume)
		{
			return FMOD_Sound_SetMusicChannelVolume(soundraw, channel, volume);
		}
		public RESULT getMusicChannelVolume     (int channel, ref float volume)
		{
			return FMOD_Sound_GetMusicChannelVolume(soundraw, channel, ref volume);
		}
		public RESULT setMusicSpeed(float speed)
		{
			return FMOD_Sound_SetMusicSpeed(soundraw, speed);
		}
		public RESULT getMusicSpeed(ref float speed)
		{
			return FMOD_Sound_GetMusicSpeed(soundraw, ref speed);
		}

		public RESULT setUserData             (IntPtr userdata)
		{
			return FMOD_Sound_SetUserData(soundraw, userdata);
		}
		public RESULT getUserData             (ref IntPtr userdata)
		{
			return FMOD_Sound_GetUserData(soundraw, ref userdata);
		}

		public RESULT getMemoryInfo(uint memorybits, uint event_memorybits, ref uint memoryused, ref MEMORY_USAGE_DETAILS memoryused_details)
		{
			return FMOD_Sound_GetMemoryInfo(soundraw, memorybits, event_memorybits, ref memoryused, ref memoryused_details);
		}


		#region importfunctions

		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Sound_Release                 (IntPtr sound);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Sound_GetSystemObject         (IntPtr sound, ref IntPtr system);
		[DllImport (VERSION.dll)]                   
		private static extern RESULT FMOD_Sound_Lock                   (IntPtr sound, uint offset, uint length, ref IntPtr ptr1, ref IntPtr ptr2, ref uint len1, ref uint len2);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Sound_Unlock                  (IntPtr sound, IntPtr ptr1,  IntPtr ptr2, uint len1, uint len2);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Sound_SetDefaults             (IntPtr sound, float frequency, float volume, float pan, int priority);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Sound_GetDefaults             (IntPtr sound, ref float frequency, ref float volume, ref float pan, ref int priority);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Sound_SetVariations           (IntPtr sound, float frequencyvar, float volumevar, float panvar);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Sound_GetVariations           (IntPtr sound, ref float frequencyvar, ref float volumevar, ref float panvar);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Sound_Set3DMinMaxDistance     (IntPtr sound, float min, float max);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Sound_Get3DMinMaxDistance     (IntPtr sound, ref float min, ref float max);
		[DllImport(VERSION.dll)]
		private static extern RESULT FMOD_Sound_Set3DConeSettings       (IntPtr sound, float insideconeangle, float outsideconeangle, float outsidevolume);
		[DllImport(VERSION.dll)]
		private static extern RESULT FMOD_Sound_Get3DConeSettings       (IntPtr sound, ref float insideconeangle, ref float outsideconeangle, ref float outsidevolume);
		[DllImport(VERSION.dll)]
		private static extern RESULT FMOD_Sound_Set3DCustomRolloff      (IntPtr sound, ref VECTOR points, int numpoints);
		[DllImport(VERSION.dll)]
		private static extern RESULT FMOD_Sound_Get3DCustomRolloff      (IntPtr sound, ref IntPtr points, ref int numpoints);
		[DllImport(VERSION.dll)]
		private static extern RESULT FMOD_Sound_SetSubSound             (IntPtr sound, int index, IntPtr subsound);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Sound_GetSubSound             (IntPtr sound, int index, ref IntPtr subsound);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Sound_SetSubSoundSentence     (IntPtr sound, int[] subsoundlist, int numsubsounds);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Sound_GetName                 (IntPtr sound, StringBuilder name, int namelen);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Sound_GetLength               (IntPtr sound, ref uint length, TIMEUNIT lengthtype);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Sound_GetFormat               (IntPtr sound, ref SOUND_TYPE type, ref SOUND_FORMAT format, ref int channels, ref int bits);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Sound_GetNumSubSounds         (IntPtr sound, ref int numsubsounds);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Sound_GetNumTags              (IntPtr sound, ref int numtags, ref int numtagsupdated);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Sound_GetTag                  (IntPtr sound, string name, int index, ref TAG tag);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Sound_GetOpenState            (IntPtr sound, ref OPENSTATE openstate, ref uint percentbuffered, ref int starving, ref int diskbusy);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Sound_ReadData                (IntPtr sound, IntPtr buffer, uint lenbytes, ref uint read);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Sound_SeekData                (IntPtr sound, uint pcm);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Sound_SetSoundGroup           (IntPtr sound, IntPtr soundgroup);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Sound_GetSoundGroup           (IntPtr sound, ref IntPtr soundgroup);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Sound_GetNumSyncPoints        (IntPtr sound, ref int numsyncpoints);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Sound_GetSyncPoint            (IntPtr sound, int index, ref IntPtr point);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Sound_GetSyncPointInfo        (IntPtr sound, IntPtr point, StringBuilder name, int namelen, ref uint offset, TIMEUNIT offsettype);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Sound_AddSyncPoint            (IntPtr sound, uint offset, TIMEUNIT offsettype, string name, ref IntPtr point);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Sound_DeleteSyncPoint         (IntPtr sound, IntPtr point);
		[DllImport (VERSION.dll)]                   
		private static extern RESULT FMOD_Sound_SetMode                 (IntPtr sound, MODE mode);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Sound_GetMode                 (IntPtr sound, ref MODE mode);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Sound_SetLoopCount            (IntPtr sound, int loopcount);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Sound_GetLoopCount            (IntPtr sound, ref int loopcount);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Sound_SetLoopPoints           (IntPtr sound, uint loopstart, TIMEUNIT loopstarttype, uint loopend, TIMEUNIT loopendtype);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Sound_GetLoopPoints           (IntPtr sound, ref uint loopstart, TIMEUNIT loopstarttype, ref uint loopend, TIMEUNIT loopendtype);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Sound_GetMusicNumChannels     (IntPtr sound, ref int numchannels);
		[DllImport(VERSION.dll)]
		private static extern RESULT FMOD_Sound_SetMusicChannelVolume   (IntPtr sound, int channel, float volume);
		[DllImport(VERSION.dll)]
		private static extern RESULT FMOD_Sound_GetMusicChannelVolume   (IntPtr sound, int channel, ref float volume);
		[DllImport(VERSION.dll)]
		private static extern RESULT FMOD_Sound_SetMusicSpeed           (IntPtr sound, float speed);
		[DllImport(VERSION.dll)]
		private static extern RESULT FMOD_Sound_GetMusicSpeed           (IntPtr sound, ref float speed);
		[DllImport(VERSION.dll)]                
		private static extern RESULT FMOD_Sound_SetUserData             (IntPtr sound, IntPtr userdata);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Sound_GetUserData             (IntPtr sound, ref IntPtr userdata);
		[DllImport(VERSION.dll)]
		private static extern RESULT FMOD_Sound_GetMemoryInfo           (IntPtr sound, uint memorybits, uint event_memorybits, ref uint memoryused, ref MEMORY_USAGE_DETAILS memoryused_details);
		#endregion

		#region wrapperinternal

		private IntPtr soundraw;

		public void setRaw(IntPtr sound)
		{
			soundraw = new IntPtr();
			soundraw = sound;
		}

		public IntPtr getRaw()
		{
			return soundraw;
		}

		#endregion
	}
}