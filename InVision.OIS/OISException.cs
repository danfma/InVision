using System;

namespace InVision.OIS
{
	public class OISException : Exception
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="OISException"/> class.
		/// </summary>
		public OISException()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="OISException"/> class.
		/// </summary>
		/// <param name="message">The message.</param>
		public OISException(string message)
			: base(message)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="OISException"/> class.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="errorType">Type of the error.</param>
		/// <param name="line">The line.</param>
		/// <param name="filename">The filename.</param>
		public OISException(string message, ErrorType errorType, int line, string filename)
			: base(message)
		{
			ErrorType = errorType;
			Line = line;
			Filename = filename;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="OISException"/> class.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="innerException">The inner exception.</param>
		public OISException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		/// <summary>
		/// Gets or sets the type of the error.
		/// </summary>
		/// <value>The type of the error.</value>
		public ErrorType ErrorType { get; private set; }

		/// <summary>
		/// Gets or sets the line.
		/// </summary>
		/// <value>The line.</value>
		public int Line { get; private set; }

		/// <summary>
		/// Gets or sets the filename.
		/// </summary>
		/// <value>The filename.</value>
		public string Filename { get; private set; }
	}
}