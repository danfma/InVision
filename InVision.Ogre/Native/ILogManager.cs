using System.Runtime.InteropServices;
using InVision.Native;

namespace InVision.Ogre.Native
{
	[OgreClass("LogManager")]
	public interface ILogManager : ICppInstance, ISingleton<ILogManager>
	{
		[Constructor(Implemented = true)]
		ILogManager Construct();

		[Destructor(Implemented = true)]
		void Destruct();

		[Method(Implemented = true)]
		ILog CreateLog(
			[MarshalAs(UnmanagedType.LPStr)] string name,
			[MarshalAs(UnmanagedType.I1)] bool defaultLog = false,
			[MarshalAs(UnmanagedType.I1)] bool debuggerOutput = true,
			[MarshalAs(UnmanagedType.I1)] bool suppressFileOutput = false);

		[Method(Implemented = true)]
		ILog GetLog([MarshalAs(UnmanagedType.LPStr)] string name);

		[Method(Implemented = true)]
		ILog GetDefaultLog();

		[Method(Implemented = true)]
		void DestroyLog([MarshalAs(UnmanagedType.LPStr)] string name);

		[Method(Implemented = true)]
		void DestroyLog(ILog log);

		[Method(Implemented = true)]
		ILog SetDefaultLog(ILog log);

		[Method(Implemented = true)]
		void LogMessage(
			[MarshalAs(UnmanagedType.LPStr)] string message,
			LogMessageLevel logLevel,
			[MarshalAs(UnmanagedType.I1)]
				bool maskDebug = false);

		[Method(Implemented = true)]
		void SetLogDetail(LoggingLevel level);
	}
}