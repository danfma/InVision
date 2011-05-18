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
        /// <param name="errorType">Type of the error.</param>
		public InVisionNativeException(string message, int errorType)
			: base(message)
        {
            ErrorType = errorType;
        }

        /// <summary>
        /// Gets or sets the type of the error.
        /// </summary>
        /// <value>The type of the error.</value>
	    public int ErrorType { get; private set; }
	}
}