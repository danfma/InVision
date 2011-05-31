using System;
using System.Runtime.InteropServices;
using System.Text;

namespace InVision.FMod.Native
{
	public class DSP
	{
		public RESULT release                   ()
		{
			return FMOD_DSP_Release(dspraw);
		}
		public RESULT getSystemObject           (ref System system)
		{
			RESULT result         = RESULT.OK;
			IntPtr systemraw      = new IntPtr();
			System systemnew      = null;

			try
			{
				result = FMOD_DSP_GetSystemObject(dspraw, ref systemraw);
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
				systemnew.setRaw(dspraw);
				system = systemnew;
			}
			else
			{
				system.setRaw(systemraw);
			}

			return result;             
		}


		public RESULT addInput(DSP target, ref DSPConnection connection)
		{
			RESULT result = RESULT.OK;
			IntPtr dspconnectionraw = new IntPtr();
			DSPConnection dspconnectionnew = null;

			try
			{
				result = FMOD_DSP_AddInput(dspraw, target.getRaw(), ref dspconnectionraw);
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
		public RESULT disconnectFrom            (DSP target)
		{
			return FMOD_DSP_DisconnectFrom(dspraw, target.getRaw());
		}
		public RESULT disconnectAll             (bool inputs, bool outputs)
		{
			return FMOD_DSP_DisconnectAll(dspraw, (inputs ? 1 : 0), (outputs ? 1 : 0));
		}
		public RESULT remove                    ()
		{
			return FMOD_DSP_Remove(dspraw);
		}
		public RESULT getNumInputs              (ref int numinputs)
		{
			return FMOD_DSP_GetNumInputs(dspraw, ref numinputs);
		}
		public RESULT getNumOutputs             (ref int numoutputs)
		{
			return FMOD_DSP_GetNumOutputs(dspraw, ref numoutputs);
		}
		public RESULT getInput                  (int index, ref DSP input, ref DSPConnection inputconnection)
		{
			RESULT result      = RESULT.OK;
			IntPtr dsprawnew   = new IntPtr();
			DSP    dspnew      = null;
			IntPtr dspconnectionraw = new IntPtr();
			DSPConnection dspconnectionnew = null;

			try
			{
				result = FMOD_DSP_GetInput(dspraw, index, ref dsprawnew, ref dspconnectionraw);
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
				dspnew.setRaw(dsprawnew);
				input = dspnew;
			}
			else
			{
				input.setRaw(dsprawnew);
			}

			if (inputconnection == null)
			{
				dspconnectionnew = new DSPConnection();
				dspconnectionnew.setRaw(dspconnectionraw);
				inputconnection = dspconnectionnew;
			}
			else
			{
				inputconnection.setRaw(dspconnectionraw);
			}

			return result; 
		}
		public RESULT getOutput                 (int index, ref DSP output, ref DSPConnection outputconnection)
		{
			RESULT result      = RESULT.OK;
			IntPtr dsprawnew   = new IntPtr();
			DSP    dspnew      = null;
			IntPtr dspconnectionraw = new IntPtr();
			DSPConnection dspconnectionnew = null;

			try
			{
				result = FMOD_DSP_GetOutput(dspraw, index, ref dsprawnew, ref dspconnectionraw);
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
				dspnew.setRaw(dsprawnew);
				output = dspnew;
			}
			else
			{
				output.setRaw(dsprawnew);
			}

			if (outputconnection == null)
			{
				dspconnectionnew = new DSPConnection();
				dspconnectionnew.setRaw(dspconnectionraw);
				outputconnection = dspconnectionnew;
			}
			else
			{
				outputconnection.setRaw(dspconnectionraw);
			}

			return result; 
		}

		public RESULT setActive                 (bool active)
		{
			return FMOD_DSP_SetActive(dspraw, (active ? 1 : 0));
		}
		public RESULT getActive                 (ref bool active)
		{
			RESULT result;
			int a = 0;

			result = FMOD_DSP_GetActive(dspraw, ref a);

			active = (a != 0);

			return result;
		}
		public RESULT setBypass                 (bool bypass)
		{
			return FMOD_DSP_SetBypass(dspraw, (bypass? 1 : 0));
		}
		public RESULT getBypass                 (ref bool bypass)
		{
			RESULT result;
			int b = 0;

			result = FMOD_DSP_GetBypass(dspraw, ref b);

			bypass = (b != 0);

			return result;
		}

		public RESULT setSpeakerActive                 (SPEAKER speaker, bool active)
		{
			return FMOD_DSP_SetSpeakerActive(dspraw, speaker, (active ? 1 : 0));
		}
		public RESULT getSpeakerActive                 (SPEAKER speaker, ref bool active)
		{
			RESULT result;
			int a = 0;

			result = FMOD_DSP_GetSpeakerActive(dspraw, speaker, ref a);

			active = (a != 0);

			return result;
		}

		public RESULT reset                     ()
		{
			return FMOD_DSP_Reset(dspraw);
		}

                     
		public RESULT setParameter              (int index, float value)
		{
			return FMOD_DSP_SetParameter(dspraw, index, value);
		}
		public RESULT getParameter              (int index, ref float value, StringBuilder valuestr, int valuestrlen)
		{
			return FMOD_DSP_GetParameter(dspraw, index, ref value, valuestr, valuestrlen);
		}
		public RESULT getNumParameters          (ref int numparams)
		{
			return FMOD_DSP_GetNumParameters(dspraw, ref numparams);
		}
		public RESULT getParameterInfo          (int index, StringBuilder name, StringBuilder label, StringBuilder description, int descriptionlen, ref float min, ref float max)
		{
			return FMOD_DSP_GetParameterInfo(dspraw, index, name, label, description, descriptionlen, ref min, ref max);
		}
		public RESULT showConfigDialog          (IntPtr hwnd, bool show)
		{
			return FMOD_DSP_ShowConfigDialog          (dspraw, hwnd, (show ? 1 : 0));
		}


		public RESULT getInfo                   (ref IntPtr name, ref uint version, ref int channels, ref int configwidth, ref int configheight)
		{
			return FMOD_DSP_GetInfo(dspraw, ref name, ref version, ref channels, ref configwidth, ref configheight);
		}
		public RESULT getType                   (ref DSP_TYPE type)
		{
			return FMOD_DSP_GetType(dspraw, ref type);
		}
		public RESULT setDefaults               (float frequency, float volume, float pan, int priority)
		{
			return FMOD_DSP_SetDefaults(dspraw, frequency, volume, pan, priority);
		}
		public RESULT getDefaults               (ref float frequency, ref float volume, ref float pan, ref int priority)
		{
			return FMOD_DSP_GetDefaults(dspraw, ref frequency, ref volume, ref pan, ref priority);
		}


		public RESULT setUserData               (IntPtr userdata)
		{
			return FMOD_DSP_SetUserData(dspraw, userdata);
		}
		public RESULT getUserData               (ref IntPtr userdata)
		{
			return FMOD_DSP_GetUserData(dspraw, ref userdata);
		}

		public RESULT getMemoryInfo(uint memorybits, uint event_memorybits, ref uint memoryused, ref MEMORY_USAGE_DETAILS memoryused_details)
		{
			return FMOD_DSP_GetMemoryInfo(dspraw, memorybits, event_memorybits, ref memoryused, ref memoryused_details);
		}

		#region importfunctions

		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_DSP_Release                   (IntPtr dsp);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_DSP_GetSystemObject           (IntPtr dsp, ref IntPtr system);
		[DllImport (VERSION.dll)]                   
		private static extern RESULT FMOD_DSP_AddInput                  (IntPtr dsp, IntPtr target, ref IntPtr connection);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_DSP_DisconnectFrom            (IntPtr dsp, IntPtr target);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_DSP_DisconnectAll             (IntPtr dsp, int inputs, int outputs);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_DSP_Remove                    (IntPtr dsp);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_DSP_GetNumInputs              (IntPtr dsp, ref int numinputs);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_DSP_GetNumOutputs             (IntPtr dsp, ref int numoutputs);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_DSP_GetInput                  (IntPtr dsp, int index, ref IntPtr input, ref IntPtr inputconnection);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_DSP_GetOutput                 (IntPtr dsp, int index, ref IntPtr output, ref IntPtr outputconnection);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_DSP_SetActive                 (IntPtr dsp, int active);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_DSP_GetActive                 (IntPtr dsp, ref int active);    
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_DSP_SetBypass                 (IntPtr dsp, int bypass);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_DSP_GetBypass                 (IntPtr dsp, ref int bypass);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_DSP_SetSpeakerActive          (IntPtr dsp, SPEAKER speaker, int active);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_DSP_GetSpeakerActive          (IntPtr dsp, SPEAKER speaker, ref int active);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_DSP_Reset                     (IntPtr dsp);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_DSP_SetParameter              (IntPtr dsp, int index, float value);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_DSP_GetParameter              (IntPtr dsp, int index, ref float value, StringBuilder valuestr, int valuestrlen);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_DSP_GetNumParameters          (IntPtr dsp, ref int numparams);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_DSP_GetParameterInfo          (IntPtr dsp, int index, StringBuilder name, StringBuilder label, StringBuilder description, int descriptionlen, ref float min, ref float max);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_DSP_ShowConfigDialog          (IntPtr dsp, IntPtr hwnd, int show);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_DSP_GetInfo                   (IntPtr dsp, ref IntPtr name, ref uint version, ref int channels, ref int configwidth, ref int configheight);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_DSP_GetType                   (IntPtr dsp, ref DSP_TYPE type);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_DSP_SetDefaults               (IntPtr dsp, float frequency, float volume, float pan, int priority);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_DSP_GetDefaults               (IntPtr dsp, ref float frequency, ref float volume, ref float pan, ref int priority);
		[DllImport (VERSION.dll)]                   
		private static extern RESULT FMOD_DSP_SetUserData               (IntPtr dsp, IntPtr userdata);
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_DSP_GetUserData               (IntPtr dsp, ref IntPtr userdata);
		[DllImport(VERSION.dll)]
		private static extern RESULT FMOD_DSP_GetMemoryInfo             (IntPtr dsp, uint memorybits, uint event_memorybits, ref uint memoryused, ref MEMORY_USAGE_DETAILS memoryused_details);
		#endregion

		#region wrapperinternal

		private IntPtr dspraw;

		public void setRaw(IntPtr dsp)
		{
			dspraw = new IntPtr();

			dspraw = dsp;
		}

		public IntPtr getRaw()
		{
			return dspraw;
		}

		#endregion
	}
}