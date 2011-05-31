using System;
using System.Runtime.InteropServices;

namespace InVision.FMod.Native
{
	public class Reverb
	{

		public RESULT release()
		{
			return FMOD_Reverb_Release(reverbraw);
		}

		// Reverb manipulation.
		public RESULT set3DAttributes(ref VECTOR position, float mindistance, float maxdistance)
		{
			return FMOD_Reverb_Set3DAttributes(reverbraw, ref position, mindistance, maxdistance);
		}
		public RESULT get3DAttributes(ref VECTOR position, ref float mindistance, ref float maxdistance)
		{
			return FMOD_Reverb_Get3DAttributes(reverbraw, ref position, ref mindistance, ref maxdistance);
		}
		public RESULT setProperties(ref REVERB_PROPERTIES properties)
		{
			return FMOD_Reverb_SetProperties(reverbraw, ref properties);
		}
		public RESULT getProperties(ref REVERB_PROPERTIES properties)
		{
			return FMOD_Reverb_GetProperties(reverbraw, ref properties);
		}
		public RESULT setActive(bool active)
		{
			return FMOD_Reverb_SetActive(reverbraw, (active ? 1 : 0));
		}
		public RESULT getActive(ref bool active)
		{
			RESULT result;
			int a = 0;

			result = FMOD_Reverb_GetActive(reverbraw, ref a);

			active = (a != 0);

			return result;
		}

		// Userdata set/get.
		public RESULT setUserData(IntPtr userdata)
		{
			return FMOD_Reverb_SetUserData(reverbraw, userdata);
		}
		public RESULT getUserData(ref IntPtr userdata)
		{
			return FMOD_Reverb_GetUserData(reverbraw, ref userdata);
		}

		public RESULT getMemoryInfo(uint memorybits, uint event_memorybits, ref uint memoryused, ref MEMORY_USAGE_DETAILS memoryused_details)
		{
			return FMOD_Reverb_GetMemoryInfo(reverbraw, memorybits, event_memorybits, ref memoryused, ref memoryused_details);
		}

		#region importfunctions

		[DllImport(VERSION.dll)]
		private static extern RESULT FMOD_Reverb_Release(IntPtr reverb);
		[DllImport(VERSION.dll)]
		private static extern RESULT FMOD_Reverb_Set3DAttributes(IntPtr reverb, ref VECTOR position, float mindistance, float maxdistance);
		[DllImport(VERSION.dll)]
		private static extern RESULT FMOD_Reverb_Get3DAttributes(IntPtr reverb, ref VECTOR position, ref float mindistance, ref float maxdistance);
		[DllImport(VERSION.dll)]
		private static extern RESULT FMOD_Reverb_SetProperties(IntPtr reverb, ref REVERB_PROPERTIES properties);
		[DllImport(VERSION.dll)]
		private static extern RESULT FMOD_Reverb_GetProperties(IntPtr reverb, ref REVERB_PROPERTIES properties);
		[DllImport(VERSION.dll)]
		private static extern RESULT FMOD_Reverb_SetActive(IntPtr reverb, int active);
		[DllImport(VERSION.dll)]
		private static extern RESULT FMOD_Reverb_GetActive(IntPtr reverb, ref int active);
		[DllImport(VERSION.dll)]
		private static extern RESULT FMOD_Reverb_SetUserData(IntPtr reverb, IntPtr userdata);
		[DllImport(VERSION.dll)]
		private static extern RESULT FMOD_Reverb_GetUserData(IntPtr reverb, ref IntPtr userdata);
		[DllImport(VERSION.dll)]
		private static extern RESULT FMOD_Reverb_GetMemoryInfo(IntPtr reverb, uint memorybits, uint event_memorybits, ref uint memoryused, ref MEMORY_USAGE_DETAILS memoryused_details);
		#endregion

		#region wrapperinternal

		private IntPtr reverbraw;

		public void setRaw(IntPtr rev)
		{
			reverbraw = new IntPtr();

			reverbraw = rev;
		}

		public IntPtr getRaw()
		{
			return reverbraw;
		}

		#endregion
	}
}