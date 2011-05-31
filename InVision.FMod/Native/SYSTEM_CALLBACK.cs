using System;

namespace InVision.FMod.Native
{
	public delegate RESULT SYSTEM_CALLBACK          (IntPtr systemraw, SYSTEM_CALLBACKTYPE type, IntPtr commanddata1, IntPtr commanddata2);
}