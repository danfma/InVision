using System;
using System.Runtime.InteropServices;

namespace InVision.Ogre.Native
{
	internal sealed class NativeLogManager : PlatformInvoke
	{
		[DllImport(Library, EntryPoint = "ogre_logmanager_get_singleton")]
		public static extern IntPtr _GetInstance();

		[DllImport(Library, EntryPoint = "ogre_logmanager_log_message")]
		public static extern void LogMessage(IntPtr handle, string message, LogMessageLevel level, bool maskDebug);

		#region Helpers

		/// <summary>
		/// 	Gets the instance.
		/// </summary>
		/// <returns></returns>
		public static LogManager GetInstance()
		{
			return _GetInstance().AsHandle(ptr => new LogManager(ptr));
		}

		#endregion
	}
}