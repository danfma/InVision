using System;

namespace InVision.Framework.Scripting
{
	public class ScriptErrorException : InVisionException
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ScriptErrorException"/> class.
		/// </summary>
		/// <param name="filename">The filename.</param>
		/// <param name="errors">The errors.</param>
		public ScriptErrorException(string filename, string[] errors)
			: base(string.Format("The script {0} contains errors", filename))
		{
			Errors = errors;
		}

		/// <summary>
		/// Gets or sets the errors.
		/// </summary>
		/// <value>The errors.</value>
		public string[] Errors { get; private set; }
	}
}