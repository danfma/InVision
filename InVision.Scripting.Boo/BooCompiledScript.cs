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
		public BooCompiledScript(string filename)
			: base(filename)
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

			foreach (Assembly assembly in References)
			{
				compiler.Parameters.AddAssembly(assembly);
			}

			var booFile = new StringBuilder();

			booFile.Append(File.ReadAllText(Filename));

			string tmp = Path.Combine(Path.GetTempPath(), Path.GetFileName(Filename));

			using (StreamWriter output = File.CreateText(tmp))
			{
				output.Write(booFile.ToString());
				output.Flush();
			}

			string outputDir = CompilerOutput;

			if (!string.IsNullOrEmpty(outputDir))
				outputDir = Path.GetFullPath(outputDir);
			else
				outputDir = Path.GetDirectoryName(Filename);

			string outputAssembly = Path.Combine(
				outputDir,
				Path.GetFileNameWithoutExtension(Filename) + ".dll");

			if (File.Exists(outputAssembly) &&
				File.GetLastWriteTime(outputAssembly) > File.GetLastWriteTime(Filename))
			{
				GeneratedAssembly = Assembly.LoadFrom(outputAssembly);
				return;
			}

			compiler.Parameters.Input.Add(new FileInput(tmp));
			//compiler.Parameters.Pipeline = new CompileToMemory();
			compiler.Parameters.Pipeline = new CompileToFile();
			compiler.Parameters.Debug = false;
			compiler.Parameters.OutputAssembly = outputAssembly;
			compiler.Parameters.OutputType = CompilerOutputType.Library;
			compiler.Parameters.Ducky = true;

			_context = compiler.Run();
			GeneratedAssembly = _context.GeneratedAssembly;

			File.Delete(tmp);

			if (GeneratedAssembly == null)
			{
				var errors = new List<string>();

				using (StreamWriter errorFile = File.CreateText(Filename + ".errors"))
				{
					foreach (CompilerError error in _context.Errors)
					{
						errorFile.WriteLine("= ERROR ========================================================================");
						errorFile.WriteLine(error);
						errorFile.WriteLine("================================================================================");
						errorFile.WriteLine();

						errors.Add(error.ToString());
					}

					errorFile.Flush();
				}

				throw new ScriptErrorException(Filename, errors.ToArray());
			}
		}

		/// <summary>
		/// Finds the services.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public override IEnumerable<T> FindServices<T>()
		{
			return
				from t in GeneratedAssembly.GetTypes()
				where typeof(T).IsAssignableFrom(t) && !(t.IsAbstract || t.IsInterface)
				select (T)Activator.CreateInstance(t);
		}

		#endregion
	}
}