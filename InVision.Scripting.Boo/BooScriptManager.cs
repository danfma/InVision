using System;
using InVision.Framework.Scripting;

namespace InVision.Scripting.Boo
{
	public class BooScriptManager : ScriptManager
	{
		/// <summary>
		/// Gets the target extension.
		/// </summary>
		/// <value>The target extension.</value>
		public override string TargetExtension
		{
			get { return ".boo"; }
		}

		/// <summary>
		/// Loads the script.
		/// </summary>
		/// <param name="filename">The filename.</param>
		/// <returns></returns>
		public override IScript LoadScript(string filename)
		{
			if (PreferredExecution == ExecutionMode.Interpreted)
				return new BooInterpretedScript(filename);

			return new BooCompiledScript(filename);
		}
	}
}