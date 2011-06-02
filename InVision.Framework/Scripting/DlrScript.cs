using Microsoft.Scripting.Hosting;

namespace InVision.Framework.Scripting
{
	public abstract class DlrScript : Script
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="DlrScript"/> class.
		/// </summary>
		/// <param name="filename">The filename.</param>
		/// <param name="compilerOutput">The compiler output.</param>
		protected DlrScript(string filename, string compilerOutput)
			: base(filename, compilerOutput)
		{
		}

		/// <summary>
		/// Gets or sets the scope.
		/// </summary>
		/// <value>The scope.</value>
		protected ScriptScope Scope { get; set; }

		/// <summary>
		/// Resets the scope.
		/// </summary>
		protected abstract void ResetScope();
	}
}