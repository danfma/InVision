using System;

namespace InVision.Framework.Scripting
{
	public class InvalidScriptFileException : InVisionException
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="InvalidScriptFileException"/> class.
		/// </summary>
		public InvalidScriptFileException()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="InvalidScriptFileException"/> class.
		/// </summary>
		/// <param name="message">The message.</param>
		public InvalidScriptFileException(string message)
			: base(message)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="InvalidScriptFileException"/> class.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="innerException">The inner exception.</param>
		public InvalidScriptFileException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
	}
}