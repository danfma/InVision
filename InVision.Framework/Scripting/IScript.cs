using System;
using System.Collections.Generic;
using System.Reflection;

namespace InVision.Framework.Scripting
{
	public interface IScript
	{
		/// <summary>
		/// Gets the execution mode.
		/// </summary>
		/// <value>The execution mode.</value>
		ExecutionMode ExecutionMode { get; }

		/// <summary>
		/// Gets a value indicating whether the source file has changed.
		/// </summary>
		/// <value><c>true</c> if the source file has changed; otherwise, <c>false</c>.</value>
		bool SourceChanged { get; }

		/// <summary>
		/// Gets or sets the compiler output.
		/// </summary>
		/// <value>The compiler output.</value>
		string CompilerOutput { set; }

		/// <summary>
		/// Gets or sets the assembly prefix.
		/// </summary>
		/// <value>The assembly prefix.</value>
		string AssemblyPrefix { get; set; }

		/// <summary>
		/// Gets or sets the name of the path.
		/// </summary>
		/// <value>The name of the path.</value>
		string Path { get; set; }

		/// <summary>
		/// Adds the reference.
		/// </summary>
		/// <param name="assembly">The assembly.</param>
		void AddReference(Assembly assembly);

		/// <summary>
		/// Adds the references.
		/// </summary>
		/// <param name="assemblies">The assemblies.</param>
		void AddReferences(IEnumerable<Assembly> assemblies);

		/// <summary>
		/// Loads (when compiled) or executes (when interpreted) the script.
		/// </summary>
		void LoadOrExecute();

		/// <summary>
		/// Gets the method or function.
		/// </summary>
		/// <typeparam name="TDelegate">The type of the delegate.</typeparam>
		/// <param name="name">The name.</param>
		/// <returns></returns>
		TDelegate GetMethodOrFunction<TDelegate>(string name);

		/// <summary>
		/// Gets the method or function.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <returns></returns>
		object GetMethodOrFunction(string name);

		/// <summary>
		/// Finds the services.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		IEnumerable<T> FindServices<T>();
	}
}