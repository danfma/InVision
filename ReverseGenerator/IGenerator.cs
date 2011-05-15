using System;
using System.Collections.Generic;

namespace CodeGenerator
{
	internal interface IGenerator
	{
		/// <summary>
		/// Generates the specified options.
		/// </summary>
		/// <param name="options">The options.</param>
		/// <param name="types">The types.</param>
		void Generate(Options options, IEnumerable<Type> types);
	}
}