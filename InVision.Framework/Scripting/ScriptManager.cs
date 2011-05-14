namespace InVision.Framework.Scripting
{
	public abstract class ScriptManager : IScriptManager
	{
		/// <summary>
		/// Gets or sets the preferred execution.
		/// </summary>
		/// <value>The preferred execution.</value>
		public ExecutionMode PreferredExecution { get; set; }

		/// <summary>
		/// Gets or sets the compiler output.
		/// </summary>
		/// <remarks>
		///	The default compiler output path is the current directory.
		/// </remarks>
		/// <value>The compiler output.</value>
		public string CompilerOutput { get; set; }

		/// <summary>
		/// Gets the target extension.
		/// </summary>
		/// <value>The target extension.</value>
		public abstract string TargetExtension { get; }

		/// <summary>
		/// Loads the script.
		/// </summary>
		/// <param name="filename">The filename.</param>
		/// <returns></returns>
		public abstract IScript LoadScript(string filename);
	}
}