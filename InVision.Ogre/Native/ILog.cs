using System.Runtime.InteropServices;
using InVision.Native;

namespace InVision.Ogre.Native
{
	[OgreInterface("Log")]
	public interface ILog : ICppInterface
	{
		[Method]
		void AddListener(ICustomLogListener listener);

		[Method]
		void RemoveListener(ICustomLogListener listener);

		[Method]
		[return: MarshalAs(UnmanagedType.LPStr)]
		string GetName();

		[Method]
		[return: MarshalAs(UnmanagedType.I1)]
		bool IsDebugOutputEnabled();

		[Method]
		[return: MarshalAs(UnmanagedType.I1)]
		bool IsFileOutputSuppressed();

		[Method]
		[return: MarshalAs(UnmanagedType.I1)]
		bool IsTimeStampEnabled();

		[Method]
		void LogMessage(
			[MarshalAs(UnmanagedType.LPStr)] string message,
			LogMessageLevel level = LogMessageLevel.Normal,
			[MarshalAs(UnmanagedType.I1)] bool maskDebug = false);
	}
}