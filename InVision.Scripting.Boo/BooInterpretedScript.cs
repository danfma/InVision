using System;
using System.IO;
using System.Reflection;
using System.Text;
using Boo.Lang.Compiler;
using Boo.Lang.Interpreter;
using InVision.Framework.Scripting;

namespace InVision.Scripting.Boo
{
	public class BooInterpretedScript : BooScript
	{
		private readonly InteractiveInterpreter _interpreter;
		private CompilerContext _context;

		/// <summary>
		/// Initializes a new instance of the <see cref="BooInterpretedScript"/> class.
		/// </summary>
		/// <param name="filename">The filename.</param>
		/// <param name="compilerOutput"></param>
		public BooInterpretedScript(string filename, string compilerOutput)
			: base(filename, compilerOutput)
		{
			_interpreter = new InteractiveInterpreter();
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

			foreach (Assembly assembly in References) {
				_interpreter.References.Add(assembly);
			}

			var booFile = new StringBuilder();
			booFile.Append(File.ReadAllText(Filename));

			_context = _interpreter.Eval(booFile.ToString());

			if (_context.GeneratedAssembly == null)
				ThrowError(Filename, _context);

			GeneratedAssembly = _context.GeneratedAssembly;
			GetFileLastChange();
		}
	}
}