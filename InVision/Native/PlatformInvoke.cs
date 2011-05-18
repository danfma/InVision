using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace InVision.Native
{
	public class PlatformInvoke
	{
		public const string CommonLibrary = "InVisionNative.dll";

		private static bool initialized;
		public static ExceptionRaiser ExceptionRaiser;

		/// <summary>
		/// Inits this instance.
		/// </summary>
		[MethodImpl(MethodImplOptions.Synchronized)]
		protected static void Init()
		{
			if (initialized)
				return;

			ExceptionRaiser = new ExceptionRaiser();
			initialized = true;
		}

		[DllImport(CommonLibrary, EntryPoint = "register_exception_handler")]
		public static extern void RegisterExceptionHandler(RaiseExceptionHandler exceptionHandler);

		[DllImport(CommonLibrary, EntryPoint = "util_string_delete")]
		public static extern void DeleteString(IntPtr pString);
	}
}