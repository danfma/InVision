using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Boo.Lang.Compiler;
using Boo.Lang.Compiler.IO;
using Boo.Lang.Compiler.Pipelines;
using InVision.Framework.Scripting;

namespace InVision.Scripting.Boo
{
	public class BooCompiledScript : Script, IBooScript
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
		/// Gets the extension.
		/// </summary>
		/// <value>The extension.</value>
		protected override string Extension
		{
			get { return ".boo"; }
		}


		/// <summary>
		/// Gets the generated assembly.
		/// </summary>
		/// <value>The generated assembly.</value>
		public Assembly GeneratedAssembly { get; private set; }

		#region IBooScript Members

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
			compiler.Parameters.Ducky = true;

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
				dynamic invoker = Delegate.CreateDelegate(typeof(Action<string[]>), GeneratedAssembly.EntryPoint);
				invoker(new string[0]);
			}
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

		/// <summary>
		/// Finds the services.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public override IEnumerable<T> FindServices<T>()
		{
			if (GeneratedAssembly == null)
				return Enumerable.Empty<T>();

			return
				from t in GeneratedAssembly.GetTypes()
				where typeof(T).IsAssignableFrom(t) && !(t.IsAbstract || t.IsInterface)
				select (T)Activator.CreateInstance(t);
		}

		#endregion
	}
}