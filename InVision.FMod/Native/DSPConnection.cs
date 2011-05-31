using System;
using System.Runtime.InteropServices;

namespace InVision.FMod.Native
{
	public class DSPConnection
	{
		public RESULT getInput              (ref DSP input)
		{
			RESULT result = RESULT.OK;
			IntPtr dspraw = new IntPtr();
			DSP    dspnew = null;

			try
			{
				result = FMOD_DSPConnection_GetInput(dspconnectionraw, ref dspraw);
			}
			catch
			{
				result = RESULT.ERR_INVALID_PARAM;
			}
			if (result != RESULT.OK)
			{
				return result;
			}

			if (input == null)
			{
				dspnew = new DSP();
				dspnew.setRaw(dspraw);
				input = dspnew;
			}
			else
			{
				input.setRaw(dspraw);
			}

			return result;
		}
		public RESULT getOutput             (ref DSP output)
		{
			RESULT result = RESULT.OK;
			IntPtr dspraw = new IntPtr();
			DSP dspnew = null;

			try
			{
				result = FMOD_DSPConnection_GetOutput(dspconnectionraw, ref dspraw);
			}
			catch
			{
				result = RESULT.ERR_INVALID_PARAM;
			}
			if (result != RESULT.OK)
			{
				return result;
			}

			if (output == null)
			{
				dspnew = new DSP();
				dspnew.setRaw(dspraw);
				output = dspnew;
			}
			else
			{
				output.setRaw(dspraw);
			}

			return result;
		}
		public RESULT setMix                (float volume)
		{
			return FMOD_DSPConnection_SetMix(dspconnectionraw, volume);
		}
		public RESULT getMix                (ref float volume)
		{
			return FMOD_DSPConnection_GetMix(dspconnectionraw, ref volume);
		}
		public RESULT setLevels             (SPEAKER speaker, float[] levels, int numlevels)
		{
			return FMOD_DSPConnection_SetLevels(dspconnectionraw, speaker, levels, numlevels);
		}
		public RESULT getLevels             (SPEAKER speaker, float[] levels, int numlevels)
		{
			return FMOD_DSPConnection_GetLevels(dspconnectionraw, speaker, levels, numlevels);
		}
		public RESULT setUserData(IntPtr userdata)
		{
			return FMOD_DSPConnection_SetUserData(dspconnectionraw, userdata);
		}
		public RESULT getUserData(ref IntPtr userdata)
		{
			return FMOD_DSPConnection_GetUserData(dspconnectionraw, ref userdata);
		}

		public RESULT getMemoryInfo(uint memorybits, uint event_memorybits, ref uint memoryused, ref MEMORY_USAGE_DETAILS memoryused_details)
		{
			return FMOD_DSPConnection_GetMemoryInfo(dspconnectionraw, memorybits, event_memorybits, ref memoryused, ref memoryused_details);
		}

		#region importfunctions

		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_DSPConnection_GetInput        (IntPtr dspconnection, ref IntPtr input);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_DSPConnection_GetOutput       (IntPtr dspconnection, ref IntPtr output);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_DSPConnection_SetMix          (IntPtr dspconnection, float volume);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_DSPConnection_GetMix          (IntPtr dspconnection, ref float volume);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_DSPConnection_SetLevels       (IntPtr dspconnection, SPEAKER speaker, float[] levels, int numlevels);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_DSPConnection_GetLevels       (IntPtr dspconnection, SPEAKER speaker, [MarshalAs(UnmanagedType.LPArray)]float[] levels, int numlevels);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_DSPConnection_SetUserData     (IntPtr dspconnection, IntPtr userdata);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_DSPConnection_GetUserData     (IntPtr dspconnection, ref IntPtr userdata);
		[DllImport(VERSION.dll)]
		private static extern RESULT FMOD_DSPConnection_GetMemoryInfo   (IntPtr dspconnection, uint memorybits, uint event_memorybits, ref uint memoryused, ref MEMORY_USAGE_DETAILS memoryused_details);
		#endregion

		#region wrapperinternal

		private IntPtr dspconnectionraw;

		public void setRaw(IntPtr dspconnection)
		{
			dspconnectionraw = new IntPtr();

			dspconnectionraw = dspconnection;
		}

		public IntPtr getRaw()
		{
			return dspconnectionraw;
		}

		#endregion
	}
}