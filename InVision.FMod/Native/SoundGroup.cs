using System;
using System.Runtime.InteropServices;
using System.Text;

namespace InVision.FMod.Native
{
	public class SoundGroup
	{
		public RESULT release                ()
		{
			return FMOD_SoundGroup_Release(soundgroupraw);
		}

		public RESULT getSystemObject        (ref System system)
		{
			RESULT result         = RESULT.OK;
			IntPtr systemraw      = new IntPtr();
			System systemnew      = null;

			try
			{
				result = FMOD_SoundGroup_GetSystemObject(soundgroupraw, ref systemraw);
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

		// SoundGroup control functions.
		public RESULT setMaxAudible          (int maxaudible)
		{
			return FMOD_SoundGroup_SetMaxAudible(soundgroupraw, maxaudible);
		}

		public RESULT getMaxAudible          (ref int maxaudible)
		{
			return FMOD_SoundGroup_GetMaxAudible(soundgroupraw, ref maxaudible);
		}

		public RESULT setMaxAudibleBehavior  (SOUNDGROUP_BEHAVIOR behavior)
		{
			return FMOD_SoundGroup_SetMaxAudibleBehavior(soundgroupraw, behavior);
		}
		public RESULT getMaxAudibleBehavior  (ref SOUNDGROUP_BEHAVIOR behavior)
		{
			return FMOD_SoundGroup_GetMaxAudibleBehavior(soundgroupraw, ref behavior);
		}
		public RESULT setMuteFadeSpeed       (float speed)
		{
			return FMOD_SoundGroup_SetMuteFadeSpeed(soundgroupraw, speed);
		}
		public RESULT getMuteFadeSpeed       (ref float speed)
		{
			return FMOD_SoundGroup_GetMuteFadeSpeed(soundgroupraw, ref speed);
		}
        
		public RESULT setVolume       (float volume)
		{
			return FMOD_SoundGroup_SetVolume(soundgroupraw, volume);
		}        
		public RESULT getVolume       (ref float volume)
		{
			return FMOD_SoundGroup_GetVolume(soundgroupraw, ref volume);
		}
		public RESULT stop       ()
		{
			return FMOD_SoundGroup_Stop(soundgroupraw);
		}

		// Information only functions.
		public RESULT getName                (StringBuilder name, int namelen)
		{
			return FMOD_SoundGroup_GetName(soundgroupraw, name, namelen);
		}
		public RESULT getNumSounds           (ref int numsounds)
		{
			return FMOD_SoundGroup_GetNumSounds(soundgroupraw, ref numsounds);
		}
		public RESULT getSound               (int index, ref Sound sound)
		{
			RESULT result         = RESULT.OK;
			IntPtr soundraw      = new IntPtr();
			Sound soundnew      = null;

			try
			{
				result = FMOD_SoundGroup_GetSound(soundgroupraw, index, ref soundraw);
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
		public RESULT getNumPlaying          (ref int numplaying)
		{
			return FMOD_SoundGroup_GetNumPlaying(soundgroupraw, ref numplaying);
		}

		// Userdata set/get.
		public RESULT setUserData            (IntPtr userdata)
		{
			return FMOD_SoundGroup_SetUserData(soundgroupraw, userdata);
		}
		public RESULT getUserData            (ref IntPtr userdata)
		{
			return FMOD_SoundGroup_GetUserData(soundgroupraw, ref userdata);
		}

		public RESULT getMemoryInfo(uint memorybits, uint event_memorybits, ref uint memoryused, ref MEMORY_USAGE_DETAILS memoryused_details)
		{
			return FMOD_SoundGroup_GetMemoryInfo(soundgroupraw, memorybits, event_memorybits, ref memoryused, ref memoryused_details);
		}

		#region importfunctions
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_SoundGroup_Release            (IntPtr soundgroup);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_SoundGroup_GetSystemObject    (IntPtr soundgroup, ref IntPtr system);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_SoundGroup_SetMaxAudible      (IntPtr soundgroup, int maxaudible);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_SoundGroup_GetMaxAudible      (IntPtr soundgroup, ref int maxaudible);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_SoundGroup_SetMaxAudibleBehavior(IntPtr soundgroup, SOUNDGROUP_BEHAVIOR behavior);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_SoundGroup_GetMaxAudibleBehavior(IntPtr soundgroup, ref SOUNDGROUP_BEHAVIOR behavior);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_SoundGroup_SetMuteFadeSpeed   (IntPtr soundgroup, float speed);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_SoundGroup_GetMuteFadeSpeed   (IntPtr soundgroup, ref float speed);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_SoundGroup_SetVolume          (IntPtr soundgroup, float volume);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_SoundGroup_GetVolume          (IntPtr soundgroup, ref float volume);
		[DllImport(VERSION.dll)]
		private static extern RESULT FMOD_SoundGroup_Stop               (IntPtr soundgroup);
		[DllImport(VERSION.dll)]
		private static extern RESULT FMOD_SoundGroup_GetName            (IntPtr soundgroup, StringBuilder name, int namelen);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_SoundGroup_GetNumSounds       (IntPtr soundgroup, ref int numsounds);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_SoundGroup_GetSound           (IntPtr soundgroup, int index, ref IntPtr sound);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_SoundGroup_GetNumPlaying      (IntPtr soundgroup, ref int numplaying);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_SoundGroup_SetUserData        (IntPtr soundgroup, IntPtr userdata);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_SoundGroup_GetUserData        (IntPtr soundgroup, ref IntPtr userdata);
		[DllImport(VERSION.dll)]
		private static extern RESULT FMOD_SoundGroup_GetMemoryInfo      (IntPtr soundgroup, uint memorybits, uint event_memorybits, ref uint memoryused, ref MEMORY_USAGE_DETAILS memoryused_details);
		#endregion

		#region wrapperinternal

		private IntPtr soundgroupraw;

		public void setRaw(IntPtr soundgroup)
		{
			soundgroupraw = new IntPtr();

			soundgroupraw = soundgroup;
		}

		public IntPtr getRaw()
		{
			return soundgroupraw;
		}

		#endregion
	}
}