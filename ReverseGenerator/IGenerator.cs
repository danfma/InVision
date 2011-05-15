using System;
using System.Collections.Generic;

namespace CodeGenerator
{
	internal interface IGenerator
	{
		/// <summary>
		/// Generates the specified types.
		/// </summary>
		/// <param name="projectName">Name of the project.</param>
		/// <param name="types">The types.</param>
		void Generate(string projectName, IEnumerable<Type> types);
	}
}