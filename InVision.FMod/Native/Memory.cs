using System.Runtime.InteropServices;

namespace InVision.FMod.Native
{
	public class Memory
	{
		public static RESULT GetStats(ref int currentalloced, ref int maxalloced)
		{
			return FMOD_Memory_GetStats(ref currentalloced, ref maxalloced, 1);
		}
    
		public static RESULT GetStats(ref int currentalloced, ref int maxalloced, bool blocking)
		{
			return FMOD_Memory_GetStats(ref currentalloced, ref maxalloced, (blocking ? 1 : 0));
		}


		#region importfunctions
  
		[DllImport (VERSION.dll)]
		private static extern RESULT FMOD_Memory_GetStats(ref int currentalloced, ref int maxalloced, int blocking);

		#endregion
	}
}