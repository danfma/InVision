using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Boo.Lang.Compiler;
using Boo.Lang.Interpreter;
using InVision.Framework.Scripting;

namespace InVision.Scripting.Boo
{
	public class BooInterpretedScript : Script, IBooScript
	{
		private readonly InteractiveInterpreter _interpreter;
		private CompilerContext _context;

		/// <summary>
		/// Initializes a new instance of the <see cref="BooInterpretedScript"/> class.
		/// </summary>
		/// <param name="filename">The filename.</param>
		public BooInterpretedScript(string filename)
			: base(filename)
		{
			_interpreter = new InteractiveInterpreter();
		}

		/// <summary>
		/// Gets the name of the module.
		/// </summary>
		/// <value>The name of the module.</value>
		private static string ModuleName
		{
			get { return "Input1Module"; }
		}

		/// <summary>
		/// Gets the extension.
		/// </summary>
		/// <value>The extension.</value>
		protected override string Extension
		{
			get { return ".boo"; }
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
		/// Loads this instance.
		/// </summary>
		public override void LoadOrExecute()
		{
			_interpreter.Reset();
			_interpreter.References.Clear();
			_interpreter.RememberLastValue = true;

			foreach (Assembly assembly in References)
			{
				_interpreter.References.Add(assembly);
			}

			var booFile = new StringBuilder();
			booFile.Append(File.ReadAllText(Filename));

			_context = _interpreter.Eval(booFile.ToString());

			if (_context.GeneratedAssembly == null)
				BooCompiledScript.ThrowError(Filename, _context);
		}

		/// <summary>
		/// Finds the services.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public override IEnumerable<T> FindServices<T>()
		{
			return
				from t in _context.GeneratedAssembly.GetTypes()
				where typeof(T).IsAssignableFrom(t) && !(t.IsAbstract || t.IsInterface)
				select (T)Activator.CreateInstance(t);
		}
	}
}