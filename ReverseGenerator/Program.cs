using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using InVision.Extensions;
using InVision.Native.Ext;

namespace CodeGenerator
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			if (args.Count() < 2)
			{
				ShowUsage();
				return;
			}

			string projectName = args[0];
			IEnumerable<Assembly> assemblies = ParseArguments(args.Skip(1));

			GenerateFiles(projectName, assemblies);
		}

		/// <summary>
		/// Shows the usage.
		/// </summary>
		private static void ShowUsage()
		{
			Console.WriteLine("Usage: CodeGenerator projectName assembly [assembly2 assembly3 ...]");
		}

		/// <summary>
		/// Generates the files.
		/// </summary>
		/// <param name="projectName">Name of the project.</param>
		/// <param name="assemblies">The assemblies.</param>
		private static void GenerateFiles(string projectName, IEnumerable<Assembly> assemblies)
		{
			IEnumerable<IGenerator> generators = GetGenerators();

			foreach (IGenerator generator in generators)
			{
				generator.Generate(projectName, GetCppTypes(assemblies));
			}
		}

		/// <summary>
		/// Gets the generators.
		/// </summary>
		/// <returns></returns>
		private static IEnumerable<IGenerator> GetGenerators()
		{
			return new IGenerator[] { new CppGenerator() };
		}

		/// <summary>
		/// Gets the CPP types.
		/// </summary>
		/// <param name="assemblies"></param>
		/// <returns></returns>
		private static IEnumerable<Type> GetCppTypes(IEnumerable<Assembly> assemblies)
		{
			return
				from assembly in assemblies
				from type in assembly.GetTypes()
				where type.HasAttribute<GeneratorTypeAttribute>()
				select type;
		}

		/// <summary>
		/// Parses the arguments.
		/// </summary>
		/// <param name="args">The args.</param>
		/// <returns></returns>
		private static IEnumerable<Assembly> ParseArguments(IEnumerable<string> args)
		{
			return args.Select(Assembly.LoadFrom).ToList();
		}
	}
}