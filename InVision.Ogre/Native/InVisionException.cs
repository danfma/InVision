using System;

namespace InVision.Native
{
	public class InVisionException : Exception
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="InVisionException"/> class.
		/// </summary>
		/// <param name="message">The message.</param>
		public InVisionException(string message)
			: base(message)
		{
		}
	}
}