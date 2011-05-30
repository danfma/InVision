using System;
using InVision.Extensions;

namespace InVision.Native
{
	public class CppTypeAttribute : GeneratorModelAttribute
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="CppTypeAttribute"/> class.
		/// </summary>
		public CppTypeAttribute()
		{
			
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="CppTypeAttribute"/> class.
		/// </summary>
		/// <param name="typename">The typename.</param>
		public CppTypeAttribute(string typename)
			: this()
		{
			Typename = typename;
		}

		/// <summary>
		/// Gets or sets the typename.
		/// </summary>
		/// <value>The typename.</value>
		public string Typename { get; private set; }

		/// <summary>
		/// Gets or sets the namespace.
		/// </summary>
		/// <value>The namespace.</value>
		public string Namespace { get; set; }

		/// <summary>
		/// Gets or sets the definition file.
		/// </summary>
		/// <value>The definition file.</value>
		public string DefinitionFile { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether [local definition].
		/// </summary>
		/// <value><c>true</c> if [local definition]; otherwise, <c>false</c>.</value>
		public bool LocalDefinition { get; set; }

		/// <summary>
		/// Gets the full name of the CPP.
		/// </summary>
		/// <param name="typename">The typename.</param>
		/// <param name="generics">The generics.</param>
		/// <returns></returns>
		public string GetCppFullName(string typename = "", string[] generics = null)
		{
			string fullname;

			if (string.IsNullOrEmpty(Namespace))
				fullname = Typename ?? typename;
			else
				fullname = Namespace + "::" + (Typename ?? typename);

			if (generics != null && generics.Length > 0) {
				fullname += "< ";
				fullname += generics.Join(", ");
				fullname += " >";
			}

			return fullname;
		}
	}
}