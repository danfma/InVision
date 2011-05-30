using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using InVision.Extensions;
using InVision.Native;

namespace ReverseGenerator.Cpp
{
	public class CppImplGenerator : CppHeaderGenerator
	{
		/// <summary>
		/// Generates the specified options.
		/// </summary>
		/// <param name="configOptions">The options.</param>
		/// <param name="types">The types.</param>
		public override void Generate(ConfigOptions configOptions, IEnumerable<Type> types)
		{
			Options = configOptions;

			var headerFilename = (ProjectName + ".h").ToLower();
			var filename = (ProjectName + ".cpp").ToLower();
			var wrapperTypes = types.Where(t => t.HasAttribute<CppClassAttribute>(true));

			using (Writer = new SourceWriter(Path.Combine(Path.GetFullPath(Options.CppOutputDir), filename))) {
				var definitions =
					(from type in types
					 let attribute = type.GetAttribute<CppTypeAttribute>(true)
					 where attribute != null
					 select new {
						 attribute.DefinitionFile,
						 attribute.LocalDefinition
					 }).Distinct();

				Writer.WriteLine("#include \"{0}\"", headerFilename);

				foreach (var definition in definitions) {
					if (string.IsNullOrEmpty(definition.DefinitionFile))
						continue;

					if (definition.LocalDefinition)
						Writer.WriteLine("#include \"{0}\"", definition.DefinitionFile);
					else
						Writer.WriteLine("#include <{0}>", definition.DefinitionFile);
				}

				Writer.WriteLine();
				Writer.WriteLine("using namespace invision;");
				Writer.WriteLine();

				WriteImplementations(wrapperTypes);

				Writer.WriteLine();
				Writer.Close();
			}
		}

		/// <summary>
		/// Writes the implementations.
		/// </summary>
		/// <param name="wrapperTypes">The wrapper types.</param>
		private void WriteImplementations(IEnumerable<Type> wrapperTypes)
		{
			wrapperTypes = wrapperTypes.Where(t => !t.IsGenericTypeDefinition);

			Writer.WriteLine();

			foreach (Type wrapperType in wrapperTypes) {
				WriteWrapperMethods(wrapperType, true);
			}
		}

		/// <summary>
		/// Writes the method.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <param name="methodInfo">The method info.</param>
		/// <param name="writeContent">if set to <c>true</c> [write content].</param>
		protected override void WriteMethod(Type type, System.Reflection.MethodInfo methodInfo, bool writeContent = false)
		{
			var attr = methodInfo.GetAttribute<MethodAttribute>(true);

			if (attr == null || attr.Implemented)
				return;

			base.WriteMethod(type, methodInfo, writeContent);
		}

		/// <summary>
		/// Writes the content of the method.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <param name="methodInfo">The method info.</param>
		protected override void WriteMethodContent(Type type, System.Reflection.MethodInfo methodInfo)
		{
			var returnValueTypename = GetCppNativeTypename(methodInfo, methodInfo.ReturnType);

			if (methodInfo.ReturnType != typeof(void))
				Writer.WriteLine("{0} returnValue;", returnValueTypename);

			Writer.WriteLine();

			if (methodInfo.ReturnType != typeof(void))
				Writer.WriteLine("return returnValue;");
		}

		/// <summary>
		/// Gets the CPP native typename.
		/// </summary>
		/// <param name="method">The method.</param>
		/// <param name="returnType">Type of the return.</param>
		/// <returns></returns>
		private static string GetCppNativeTypename(MethodInfo method, Type returnType)
		{
			if (returnType == typeof(bool))
				return "bool";

			return ConfigOptions.ToCppTypename(method, returnType);
		}
	}
}
