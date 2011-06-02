using System;
using System.IO;
using System.Reflection;
using Boo.Lang.Compiler;
using Boo.Lang.Compiler.IO;
using Boo.Lang.Compiler.Pipelines;
using InVision.Framework.Scripting;

namespace InVision.Scripting.Boo
{
	public class BooCompiledScript : BooScript
	{
		private CompilerContext _context;

		/// <summary>
		/// Initializes a new instance of the <see cref="BooCompiledScript"/> class.
		/// </summary>
		/// <param name="filename">The filename.</param>
		/// <param name="compilerOutput">The compiler output.</param>
		public BooCompiledScript(string filename, string compilerOutput)
			: base(filename, compilerOutput)
		{
		}

		/// <summary>
		/// Gets the execution mode.
		/// </summary>
		/// <value>The execution mode.</value>
		public override ExecutionMode ExecutionMode
		{
			get { return ExecutionMode.Compiled; }
		}

		/// <summary>
		/// Loads this instance.
		/// </summary>
		public override void LoadOrExecute()
		{
			var compiler = new BooCompiler();

			foreach (Assembly assembly in References) {
				compiler.Parameters.AddAssembly(assembly);
			}

			string outputDir = CompilerOutput;

			if (!string.IsNullOrEmpty(outputDir))
				outputDir = System.IO.Path.GetFullPath(outputDir);
			else
				outputDir = System.IO.Path.GetDirectoryName(Filename);

			string outputAssembly = System.IO.Path.Combine(
				outputDir,
				AssemblyPrefix + System.IO.Path.GetFileNameWithoutExtension(Filename) + ".dll");

			if (File.Exists(outputAssembly) &&
			    File.GetLastWriteTime(outputAssembly) > File.GetLastWriteTime(Filename)) {
				GeneratedAssembly = Assembly.LoadFrom(outputAssembly);
				InvokeEntryPoint();
				return;
			}

			compiler.Parameters.Input.Add(new FileInput(Filename));
			//compiler.Parameters.Pipeline = new CompileToMemory();
			compiler.Parameters.Pipeline = new CompileToFile();
#if DEBUG
			compiler.Parameters.Debug = true;
#else
			compiler.Parameters.Debug = false;
#endif
			compiler.Parameters.OutputAssembly = outputAssembly;
			compiler.Parameters.OutputType = CompilerOutputType.ConsoleApplication;
			compiler.Parameters.Ducky = false;

			_context = compiler.Run();
			GeneratedAssembly = _context.GeneratedAssembly;

			if (GeneratedAssembly == null)
				ThrowError(Filename, _context);

			InvokeEntryPoint();
		}

		/// <summary>
		/// Invokes the entry point.
		/// </summary>
		private void InvokeEntryPoint()
		{
			if (GeneratedAssembly.EntryPoint != null) {
				dynamic invoker = Delegate.CreateDelegate(typeof (Action<string[]>), GeneratedAssembly.EntryPoint);
				invoker(new string[0]);
			}
		}
	}
}