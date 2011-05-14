using System;

namespace InVision.Framework.Scripting
{
	public interface IScriptManager
	{
		/// <summary>
		/// Gets or sets the preferred execution.
		/// </summary>
		/// <value>The preferred execution.</value>
		ExecutionMode PreferredExecution { get; set; }

		/// <summary>
		/// Gets or sets the compiler output.
		/// </summary>
		/// <remarks>
		///	The default compiler output path is the current directory.
		/// </remarks>
		/// <value>The compiler output.</value>
		string CompilerOutput { get; set; }

		/// <summary>
		/// Gets the target extension.
		/// </summary>
		/// <value>The target extension.</value>
		string TargetExtension { get; }

		/// <summary>
		/// Loads the script.
		/// </summary>
		/// <param name="filename">The filename.</param>
		/// <returns></returns>
		IScript LoadScript(string filename);
	}
}