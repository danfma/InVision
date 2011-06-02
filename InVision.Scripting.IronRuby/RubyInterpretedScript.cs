using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using InVision.Framework.Scripting;
using IronRuby.Builtins;
using IronRuby.Compiler;
using Microsoft.Scripting.Hosting;
using System.Linq;

namespace InVision.Scripting.IronRuby
{
	public class RubyInterpretedScript : DlrScript
	{
		private readonly RubyScriptManager _manager;
		private ScriptScope _scope;

		/// <summary>
		/// Initializes a new instance of the <see cref="RubyInterpretedScript"/> class.
		/// </summary>
		/// <param name="manager">The manager.</param>
		/// <param name="filename">The filename.</param>
		/// <param name="compilerOutput">The compiler output.</param>
		public RubyInterpretedScript(RubyScriptManager manager, string filename, string compilerOutput)
			: base(filename, compilerOutput)
		{
			_manager = manager;

			ResetScope();
		}

		/// <summary>
		/// Gets the engine.
		/// </summary>
		/// <value>The engine.</value>
		public ScriptEngine Engine
		{
			get { return _manager.Engine; }
		}

		/// <summary>
		/// Gets the extension.
		/// </summary>
		/// <value>The extension.</value>
		protected override string Extension
		{
			get { return ".rb"; }
		}

		/// <summary>
		/// Gets the execution mode.
		/// </summary>
		/// <value>The execution mode.</value>
		public override ExecutionMode ExecutionMode
		{
			get { return ExecutionMode.Interpreted; }
		}

		/// <summary>
		/// Resets the scope.
		/// </summary>
		protected override void ResetScope()
		{
			_scope = _manager.Engine.CreateScope();
		}

		/// <summary>
		/// Loads this instance.
		/// </summary>
		public override void LoadOrExecute()
		{
			var file = new StringBuilder();

			foreach (Assembly assembly in References)
			{
				file.AppendFormat("require \"{0}\"", assembly.FullName).AppendLine();
			}

			file.AppendLine();
			file.Append(File.ReadAllText(Filename));

			ScriptSource source = _manager.Engine.CreateScriptSourceFromString(file.ToString());
			source.Compile().Execute(_scope);
		}

		/// <summary>
		/// Gets the method or function.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <returns></returns>
		public override object GetMethodOrFunction(string name)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Finds the service.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public override IEnumerable<T> FindServices<T>()
		{
			string searchType = typeof(T).FullName.Replace(".", "::");

			foreach (var item in Engine.Runtime.Globals.GetItems())
			{
				if (!(item.Value is RubyClass))
					continue;

				var rubyClass = (RubyClass)item.Value;
				var mixins = rubyClass.GetMixins();
				bool hasInterface = mixins.Where(m => m.Name == searchType).Any();

				if (hasInterface)
				{
					dynamic instance = Engine.Operations.CreateInstance(rubyClass);

					yield return instance;
				}
			}
		}
	}
}