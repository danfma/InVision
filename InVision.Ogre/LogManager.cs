using System;
using InVision.Native;
using InVision.Native.Ogre;

namespace InVision.Rendering
{
	public class LogManager : ReferenceHandle
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="LogManager"/> class.
		/// </summary>
		/// <param name="pSelf">The p self.</param>
		public LogManager(IntPtr pSelf)
			: base(pSelf)
		{
		}

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>The instance.</value>
		public static LogManager Instance
		{
			get { return NativeLogManager.GetInstance(); }
		}

		/// <summary>
		/// Logs the message.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="messageLevel">The message level.</param>
		/// <param name="maskDebug">if set to <c>true</c> [mask debug].</param>
		public void LogMessage(string message, LogMessageLevel messageLevel = LogMessageLevel.Normal, bool maskDebug = false)
		{
			NativeLogManager.LogMessage(handle, message, messageLevel, maskDebug);
		}
	}
}