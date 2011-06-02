using System;
using System.Collections.Generic;
using System.IO;
using Boo.Lang.Compiler;
using InVision.Framework.Scripting;

namespace InVision.Scripting.Boo
{
	public abstract class BooScript : CliCompiledScript, IBooScript
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="InVision.Scripting.Boo.BooScript"/> class.
		/// </summary>
		/// <param name="filename">The filename.</param>
		/// <param name="compilerOutput">The compiler output.</param>
		public BooScript(string filename, string compilerOutput)
			: base(filename, compilerOutput)
		{
		}

		/// <summary>
		/// Gets the extension.
		/// </summary>
		/// <value>The extension.</value>
		protected override sealed string Extension
		{
			get { return ".boo"; }
		}

		/// <summary>
		/// Throws the error.
		/// </summary>
		/// <param name="filename">The filename.</param>
		/// <param name="context">The context.</param>
		internal static void ThrowError(string filename, CompilerContext context)
		{
			var errors = new List<string>();

			using (StreamWriter errorFile = File.CreateText(filename + ".errors")) {
				foreach (CompilerError error in context.Errors) {
					errorFile.WriteLine("= ERROR ========================================================================");
					errorFile.WriteLine(error);
					errorFile.WriteLine("================================================================================");
					errorFile.WriteLine();

					errors.Add(error.ToString());
				}

				errorFile.Flush();
			}

			throw new ScriptErrorException(filename, errors.ToArray());
		}
	}
}