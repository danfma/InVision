using System;

namespace InVision.Framework.Util
{
	public class ConsoleColorRestore : IDisposable
	{
		private readonly ConsoleColor _consoleBgColor;
		private readonly ConsoleColor _consoleFgColor;

		/// <summary>
		/// Initializes a new instance of the <see cref="ConsoleColorRestore"/> class.
		/// </summary>
		public ConsoleColorRestore()
		{
			_consoleFgColor = Console.ForegroundColor;
			_consoleBgColor = Console.BackgroundColor;
		}

		#region IDisposable Members

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		/// <filterpriority>2</filterpriority>
		public void Dispose()
		{
			Console.ForegroundColor = _consoleFgColor;
			Console.BackgroundColor = _consoleBgColor;
		}

		#endregion
	}
}