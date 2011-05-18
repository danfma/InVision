using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using InVision.Extensions;
using InVision.Native.Ext;
using NDesk.Options;
using ReverseGenerator.Cpp;
using ReverseGenerator.CSharp;

namespace ReverseGenerator
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            if (args.Count() < 3)
            {
                ShowUsage();
                return;
            }

            var options = new ConfigOptions();
            var optionSet = new OptionSet {
				{ "p|project=",		v => options.ProjectName = v },
				{ "a|assembly=",	v => options.AssembliesToScan.Add(Assembly.LoadFrom(v)) },
				{ "cs|csout=",		v => options.CsOutputDir = v },
				{ "cpp|cppout=",	v => options.CppOutputDir = v }
			};

            optionSet.Parse(args);

            GenerateFiles(options);
        }

        /// <summary>
        /// Shows the usage.
        /// </summary>
        private static void ShowUsage()
        {
            Console.WriteLine("Usage: CodeGenerator projectName outputDir assembly [assembly2 assembly3 ...]");
        }

        /// <summary>
        /// Generates the files.
        /// </summary>
        /// <param name="configOptions">The options.</param>
        private static void GenerateFiles(ConfigOptions configOptions)
        {
            IEnumerable<IGenerator> generators = GetGenerators();

            foreach (IGenerator generator in generators)
            {
                generator.Generate(configOptions, GetCppTypes(configOptions.AssembliesToScan));
            }
        }

        /// <summary>
        /// Gets the generators.
        /// </summary>
        /// <returns></returns>
        private static IEnumerable<IGenerator> GetGenerators()
        {
            return new IGenerator[] { new CppHeaderGenerator(), new CSharpGenerator() };
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
                let attributes = type.GetAttributes<GeneratorModelAttribute>(true)
                where attributes.Count() > 0
                select type;
        }
    }
}