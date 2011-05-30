using System.Runtime.InteropServices;
using InVision.Native;

namespace InVision.Ogre.Native
{
	[OgreClass("Log")]
	public interface ILog : ICppInstance
	{
		[Method(Implemented = true)]
		void AddListener(ICustomLogListener listener);

		[Method(Implemented = true)]
		void RemoveListener(ICustomLogListener listener);

		[Method(Implemented = true)]
		[return: MarshalAs(UnmanagedType.LPStr)]
		string GetName();

		[Method(Implemented = true)]
		[return: MarshalAs(UnmanagedType.I1)]
		bool IsDebugOutputEnabled();

		[Method(Implemented = true)]
		[return: MarshalAs(UnmanagedType.I1)]
		bool IsFileOutputSuppressed();

		[Method(Implemented = true)]
		[return: MarshalAs(UnmanagedType.I1)]
		bool IsTimeStampEnabled();

		[Method(Implemented = true)]
		void LogMessage(
			[MarshalAs(UnmanagedType.LPStr)] string message,
			LogMessageLevel level = LogMessageLevel.Normal,
			[MarshalAs(UnmanagedType.I1)] bool maskDebug = false);
	}
}