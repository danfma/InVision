using System;
using InVision.Framework.Util;

namespace Tutano.Core.Util
{
	public class ScriptColorRestore : ConsoleColorRestore
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ScriptColorRestore"/> class.
		/// </summary>
		public ScriptColorRestore()
		{
			Console.ForegroundColor = ConsoleColor.White;
		}
	}
}