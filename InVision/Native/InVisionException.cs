using System;

namespace InVision.Native
{
	/// <summary>
	/// 
	/// </summary>
	public class InVisionNativeException : Exception
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="InVisionNativeException"/> class.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="filename">The filename.</param>
		/// <param name="line">The line.</param>
		public InVisionNativeException(string message, string filename, int line)
			: base(message)
		{
			Filename = filename;
			Line = line;
		}

		/// <summary>
		/// Gets or sets the filename.
		/// </summary>
		/// <value>The filename.</value>
		public string Filename { get; private set; }

		/// <summary>
		/// Gets or sets the line.
		/// </summary>
		/// <value>The line.</value>
		public int Line { get; private set; }
	}
}