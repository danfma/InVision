using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Tutano
{
	public static class Program
	{
		/// <summary>
		/// 
		/// </summary>
		public static readonly IList<string> AssemblyDirectories;

		/// <summary>
		/// Initializes the <see cref="Program"/> class.
		/// </summary>
		static Program()
		{
			Console.WriteLine("Configuring Tutano environment for launch");

			AssemblyDirectories = new List<string> { Path.GetFullPath("Bin") };

			AppDomain domain = AppDomain.CurrentDomain;
			domain.AssemblyResolve += OnAssemblyResolve;
			domain.UnhandledException += OnUnhandledException;
		}

		/// <summary>
		/// Called when [unhandled exception].
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="unhandledExceptionEventArgs">The <see cref="System.UnhandledExceptionEventArgs"/> instance containing the event data.</param>
		private static void OnUnhandledException(object sender, UnhandledExceptionEventArgs unhandledExceptionEventArgs)
		{
			using (var errorFile = new StreamWriter("Tutano.error.log"))
			{
				errorFile.WriteLine("Error: {0}", unhandledExceptionEventArgs.ExceptionObject);
				errorFile.Flush();
				errorFile.Close();
			}
		}

		/// <summary>
		/// Currents the domain on assembly resolve.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="args">The <see cref="System.ResolveEventArgs"/> instance containing the event data.</param>
		/// <returns></returns>
		private static Assembly OnAssemblyResolve(object sender, ResolveEventArgs args)
		{
			var assemblyName = new AssemblyName(args.Name);
			string assemblyFile = assemblyName.Name + ".dll";

			return (from assemblyDirectory in AssemblyDirectories
					select Path.Combine(assemblyDirectory, assemblyFile)
						into assemblyPath
						where File.Exists(assemblyPath)
						select Assembly.LoadFrom(assemblyPath)).FirstOrDefault();
		}

		/// <summary>
		/// Entry point.
		/// </summary>
		/// <param name="args">The args.</param>
		public static void Main(string[] args)
		{
			TutanoLauncher.Run();
		}
	}
}