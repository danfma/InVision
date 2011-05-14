using System;

namespace InVision.Framework.Scripting
{
	public class ScriptNotLoadedException : InVisionException
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ScriptNotLoadedException"/> class.
		/// </summary>
		public ScriptNotLoadedException()
			: base("Script is not loaded")
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ScriptNotLoadedException"/> class.
		/// </summary>
		/// <param name="message">The message.</param>
		public ScriptNotLoadedException(string message)
			: base(message)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ScriptNotLoadedException"/> class.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="innerException">The inner exception.</param>
		public ScriptNotLoadedException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
	}
}