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
		/// Adds the reference.
		/// </summary>
		/// <param name="assembly">The assembly.</param>
		void AddReference(Assembly assembly);

		/// <summary>
		/// Loads (when compiled) or executes (when interpreted) the script.
		/// </summary>
		void LoadOrExecute();

		/// <summary>
		/// Finds the services.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		IEnumerable<T> FindServices<T>();
	}
}