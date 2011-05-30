using InVision.Native;
using InVision.Ogre.Native;

namespace InVision.Ogre.Logging
{
	public class LogManager : Singleton<LogManager, ILogManager>
	{
		#region Construction and Destruction

		/// <summary>
		/// Initializes a new instance of the <see cref="LogManager"/> class.
		/// </summary>
		/// <param name="nativeInstance">The native instance.</param>
		public LogManager(ICppInstance nativeInstance)
			: base(nativeInstance)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="LogManager"/> class.
		/// </summary>
		public LogManager()
			: this(CreateCppInstance<ILogManager>())
		{
			Native.Construct().SetOwner(this);
		}

		/// <summary>
		/// Releases unmanaged and - optionally - managed resources
		/// </summary>
		/// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
		protected override void Dispose(bool disposing)
		{
			if (Native != null)
				Native.Destruct();

			base.Dispose(disposing);
		}

		#endregion

		/// <summary>
		/// Gets or sets the default log.
		/// </summary>
		/// <value>The default log.</value>
		public Log DefaultLog
		{
			get { return GetOrCreateOwner(Native.GetDefaultLog(), native => new Log(native)); }
			set { Native.SetDefaultLog(value.Native); }
		}

		/// <summary>
		/// Sets the log detail.
		/// </summary>
		/// <value>The log detail.</value>
		public LoggingLevel LogDetail
		{
			set { Native.SetLogDetail(value); }
		}

		/// <summary>
		/// Creates the log.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <param name="defaultLog">if set to <c>true</c> [default log].</param>
		/// <param name="debuggerOutput">if set to <c>true</c> [debugger output].</param>
		/// <param name="suppressFileOutput">if set to <c>true</c> [suppress file output].</param>
		/// <returns></returns>
		public Log CreateLog(string name, bool defaultLog, bool debuggerOutput, bool suppressFileOutput)
		{
			ILog nativeLog = Native.CreateLog(name, defaultLog, debuggerOutput, suppressFileOutput);

			return GetOrCreateOwner(nativeLog, native => new Log(native));
		}

		/// <summary>
		/// Gets the log.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <returns></returns>
		public Log GetLog(string name)
		{
			ILog nativeLog = Native.GetLog(name);

			return GetOrCreateOwner(nativeLog, native => new Log(native));
		}

		/// <summary>
		/// Destroys the log.
		/// </summary>
		/// <param name="name">The name.</param>
		public void DestroyLog(string name)
		{
			Native.DestroyLog(name);
		}

		/// <summary>
		/// Destroys the log.
		/// </summary>
		/// <param name="log">The log.</param>
		public void DestroyLog(ILog log)
		{
			Native.DestroyLog(log);
		}

		/// <summary>
		/// Logs the message.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="logLevel">The log level.</param>
		/// <param name="maskDebug">if set to <c>true</c> [mask debug].</param>
		public void LogMessage(string message, LogMessageLevel logLevel = LogMessageLevel.Normal, bool maskDebug = false)
		{
			Native.LogMessage(message, logLevel, maskDebug);
		}
	}
}