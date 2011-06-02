using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace InVision.Framework.Scripting
{
	/// <summary>
	/// 
	/// </summary>
	public abstract class CliCompiledScript : Script
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="CliCompiledScript"/> class.
		/// </summary>
		/// <param name="filename">The filename.</param>
		/// <param name="compilerOutput">The compiler output.</param>
		protected CliCompiledScript(string filename, string compilerOutput)
			: base(filename, compilerOutput)
		{
		}

		/// <summary>
		/// Gets or sets the generated assembly.
		/// </summary>
		/// <value>The generated assembly.</value>
		protected Assembly GeneratedAssembly { get; set; }

		/// <summary>
		/// Finds the service.
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

		/// <summary>
		/// Gets the method or function.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <returns></returns>
		public override object GetMethodOrFunction(string name)
		{
			if (GeneratedAssembly == null)
				return null;

			var declaringType = GeneratedAssembly.EntryPoint.DeclaringType;
			var method = declaringType.GetMethod(name);

			return Delegate.CreateDelegate(declaringType, method);
		}
	}
}