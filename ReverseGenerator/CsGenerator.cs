using System;
using System.Collections.Generic;

namespace CodeGenerator
{
	public class CsGenerator : IGenerator
	{
		/// <summary>
		/// Generates the specified types.
		/// </summary>
		/// <param name="projectName">Name of the project.</param>
		/// <param name="types">The types.</param>
		public void Generate(string projectName, IEnumerable<Type> types)
		{
			throw new NotImplementedException();
		}
	}
}