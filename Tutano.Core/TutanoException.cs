using System;

namespace Tutano.Core
{
	public class TutanoException : Exception
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="TutanoException"/> class.
		/// </summary>
		/// <param name="message">The message.</param>
		public TutanoException(string message)
			: base(message)
		{
			
		}
	}
}