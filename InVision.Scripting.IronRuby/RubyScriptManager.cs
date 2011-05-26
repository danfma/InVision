using System;
using InVision.Framework.Scripting;
using IronRuby;
using IronRuby.Builtins;
using Microsoft.Scripting.Hosting;

namespace InVision.Scripting.IronRuby
{
	public class RubyScriptManager : ScriptManager
	{
		private readonly ScriptEngine _engine;
		private readonly ScriptRuntime _runtime;

		/// <summary>
		/// Initializes a new instance of the <see cref="RubyScriptManager"/> class.
		/// </summary>
		public RubyScriptManager()
		{
			_runtime = Ruby.CreateRuntime();
			_engine = Ruby.GetEngine(_runtime);
		}

		/// <summary>
		/// Gets the engine.
		/// </summary>
		/// <value>The engine.</value>
		public ScriptEngine Engine
		{
			get { return _engine; }
		}

		/// <summary>
		/// Gets the target extension.
		/// </summary>
		/// <value>The target extension.</value>
		public override string TargetExtension
		{
			get { return ".rb"; }
		}

		/// <summary>
		/// Loads the script.
		/// </summary>
		/// <param name="filename">The filename.</param>
		/// <returns></returns>
		public override IScript LoadScript(string filename)
		{
			return new RubyInterpretedScript(this, filename, CompilerOutput);
		}

		#region Nested type: ForceLibraryDependency

		private static class ForceLibraryDependency
		{
			/// <summary>
			/// Initializes the <see cref="ForceLibraryDependency"/> class.
			/// </summary>
			static ForceLibraryDependency()
			{
				ClrString.ToStr("abc");
			}
		}

		#endregion
	}
}