using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using InVision.Framework.Scripting;

namespace InVision.Scripting.Cobra
{
	public class CobraCompiledScript : Script
	{
		private Assembly _generatedAssembly;

		/// <summary>
		/// Initializes a new instance of the <see cref="CobraCompiledScript"/> class.
		/// </summary>
		/// <param name="filename">The filename.</param>
		public CobraCompiledScript(string filename)
			: base(filename)
		{
		}

		/// <summary>
		/// Gets the extension.
		/// </summary>
		/// <value>The extension.</value>
		protected override string Extension
		{
			get { return ".cobra"; }
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
		/// Gets the generated assembly.
		/// </summary>
		/// <value>The generated assembly.</value>
		public Assembly GeneratedAssembly
		{
			get { return _generatedAssembly; }
		}

		/// <summary>
		/// Loads this instance.
		/// </summary>
		public override void LoadOrExecute()
		{
			string outputDir = CompilerOutput;

			if (string.IsNullOrEmpty(outputDir))
				outputDir = Path.GetDirectoryName(Filename);
			else
				outputDir = Path.GetFullPath(outputDir);

			string outputFilename = Path.Combine(
				outputDir ?? Environment.CurrentDirectory,
				Path.GetFileNameWithoutExtension(Filename) + ".dll");

			var compilerParameters = new List<string>();
			compilerParameters.Add("-cin");
			compilerParameters.Add("-compile");
			compilerParameters.Add("-back-end:clr");
			compilerParameters.Add("-o");
			compilerParameters.AddRange(References.Select(assembly => string.Format("-ref:\"{0}\"", assembly.GetName().Name)));
			compilerParameters.Add("-t:lib");
			compilerParameters.Add(string.Format("-out:\"{0}\"", outputFilename));
			compilerParameters.Add(Filename);

			try
			{
				using (var ms = new MemoryStream())
				using (var writer = new StreamWriter(ms))
				{
					var processStart = new ProcessStartInfo("Cobra.Lang.Compiler.exe", string.Join(" ", compilerParameters));
					processStart.CreateNoWindow = true;
					processStart.UseShellExecute = false;
					processStart.RedirectStandardError = true;

					var process = Process.Start(processStart);
					process.ErrorDataReceived += (sender, args) => writer.WriteLine(args.Data);
					process.BeginErrorReadLine();
					process.WaitForExit();
					process.CancelErrorRead();

					writer.Flush();
					ms.Seek(0, SeekOrigin.Begin);

					using (var reader = new StreamReader(ms))
					{
						var lines = new List<string>();

						while (!reader.EndOfStream)
							lines.Add(reader.ReadLine());

						if (process.ExitCode != 0)
							throw new ScriptErrorException(Filename, lines.ToArray());
					}
				}

				_generatedAssembly = Assembly.LoadFrom(outputFilename);
			}
			catch (ScriptErrorException ex)
			{
				using (var file = File.CreateText(Filename + ".errors"))
				{
					foreach (var error in ex.Errors)
					{
						file.WriteLine("= ERROR ========================================================================");
						file.WriteLine(error);
						file.WriteLine("================================================================================");
					}

					file.Flush();
				}

				throw;
			}
		}

		/// <summary>
		/// Finds the service.
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
	}
}