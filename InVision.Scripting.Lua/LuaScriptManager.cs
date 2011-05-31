using System;
using InVision.Framework.Scripting;

namespace InVision.Scripting.Lua
{
	public class LuaScriptManager : ScriptManager
	{
		/// <summary>
		/// Gets the target extension.
		/// </summary>
		/// <value>The target extension.</value>
		public override string TargetExtension
		{
			get { return ".lua"; }
		}

		/// <summary>
		/// Loads the script.
		/// </summary>
		/// <param name="filename">The filename.</param>
		/// <returns></returns>
		public override IScript CreateScriptFrom(string filename)
		{
			return new LuaInterpretedScript(filename, CompilerOutput);
		}
	}
}