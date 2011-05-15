using System;
using System.Collections.Generic;
using System.Reflection;

namespace CodeGenerator
{
	public class Options
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Options"/> class.
		/// </summary>
		public Options()
		{
			AssembliesToScan = new List<Assembly>();
			CsOutputDir = CppOutputDir = Environment.CurrentDirectory;
		}

		/// <summary>
		/// Gets or sets the name of the project.
		/// </summary>
		/// <value>The name of the project.</value>
		public string ProjectName { get; set; }

		/// <summary>
		/// Gets or sets the cs output dir.
		/// </summary>
		/// <value>The cs output dir.</value>
		public string CsOutputDir { get; set; }

		/// <summary>
		/// Gets or sets the CPP output dir.
		/// </summary>
		/// <value>The CPP output dir.</value>
		public string CppOutputDir { get; set; }

		/// <summary>
		/// Gets or sets the assemblies to scan.
		/// </summary>
		/// <value>The assemblies to scan.</value>
		public List<Assembly> AssembliesToScan { get; set; }
	}
}