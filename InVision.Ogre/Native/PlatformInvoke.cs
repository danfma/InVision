using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace InVision.Ogre.Native
{
	internal class PlatformInvoke
	{
		public const string Library = "InVisionWrap.dll";
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

		[DllImport(Library, EntryPoint = "register_exception_raise_handler")]
		public static extern void RegisterExceptionHandler(RaiseExceptionHandler exceptionHandler);
	}
}