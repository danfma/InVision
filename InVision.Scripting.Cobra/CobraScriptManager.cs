using System;
using InVision.Framework.Scripting;

namespace InVision.Scripting.Cobra
{
	public class CobraScriptManager : ScriptManager
	{
		/// <summary>
		/// Gets the target extension.
		/// </summary>
		/// <value>The target extension.</value>
		public override string TargetExtension
		{
			get { return ".cobra"; }
		}

		/// <summary>
		/// Loads the script.
		/// </summary>
		/// <param name="filename">The filename.</param>
		/// <returns></returns>
		public override IScript LoadScript(string filename)
		{
			return new CobraCompiledScript(filename);
		}
	}
}