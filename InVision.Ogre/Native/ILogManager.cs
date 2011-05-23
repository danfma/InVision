using System.Runtime.InteropServices;
using InVision.Native;

namespace InVision.Ogre.Native
{
	[OgreInterface("LogManager")]
	public interface ILogManager : ICppInterface, ISingleton<ILogManager>
	{
		[Constructor]
		ILogManager Construct();

		[Destructor]
		void Destruct();

		[Method]
		ILog CreateLog(
			[MarshalAs(UnmanagedType.LPStr)] string name,
			[MarshalAs(UnmanagedType.I1)] bool defaultLog = false,
			[MarshalAs(UnmanagedType.I1)] bool debuggerOutput = true,
			[MarshalAs(UnmanagedType.I1)] bool suppressFileOutput = false);

		[Method]
		ILog GetLog([MarshalAs(UnmanagedType.LPStr)] string name);

		[Method]
		ILog GetDefaultLog();

		[Method]
		void DestroyLog([MarshalAs(UnmanagedType.LPStr)] string name);

		[Method]
		void DestroyLog(ILog log);

		[Method]
		ILog SetDefaultLog(ILog log);

		[Method]
		void LogMessage(
			[MarshalAs(UnmanagedType.LPStr)] string message,
			LogMessageLevel logLevel,
			[MarshalAs(UnmanagedType.I1)]
				bool maskDebug = false);

		[Method]
		void SetLogDetail(LoggingLevel level);
	}
}