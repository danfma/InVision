using System;

namespace InVision
{
	public class InVisionException : Exception
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="InVisionException"/> class.
		/// </summary>
		public InVisionException()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="InVisionException"/> class.
		/// </summary>
		/// <param name="message">The message.</param>
		public InVisionException(string message) : base(message)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="InVisionException"/> class.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="innerException">The inner exception.</param>
		public InVisionException(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}