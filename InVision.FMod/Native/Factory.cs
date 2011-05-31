using System;
using System.Runtime.InteropServices;

namespace InVision.FMod.Native
{
	public class Factory
	{        
		public static RESULT System_Create(ref System system)
		{
#if WIN64
            if (IntPtr.Size != 8)
            {
                /* Attempting to use 64-bit FMOD dll with 32-bit application.*/
            
                return RESULT.ERR_FILE_BAD;
            }
#else
			if (IntPtr.Size != 4)
			{
				/* Attempting to use 32-bit FMOD dll with 64-bit application. A likely cause of this error 
                 * is targetting platform 'Any CPU'. You cannot link to unmanaged dll with 'Any CPU'
                 * target. 
                 * 
                 * For 32-bit applications: set the platform to 'x86'.
                 * 
                 * For 64-bit applications:
                 * 1. set the platform to x64
                 * 2. add the conditional complication symbol WIN64
                 * 3. download the win64 fmod release
                 * 4. copy the fmodex64.dll to the location of the .exe file for your application */

				return RESULT.ERR_FILE_BAD;
			}
#endif

			RESULT result           = RESULT.OK;
			IntPtr      systemraw   = new IntPtr();
			System      systemnew   = null;

			result = FMOD_System_Create(ref systemraw);
			if (result != RESULT.OK)
			{
				return result;
			}

			systemnew = new System();
			systemnew.setRaw(systemraw);
			system = systemnew;

			return result;
		}


		#region importfunctions
  
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_System_Create                      (ref IntPtr system);

		#endregion
	}
}