namespace InVision.Native.Ext
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
		/// Gets the full name of the CPP.
		/// </summary>
		/// <param name="memberName">Name of the member.</param>
		/// <returns></returns>
		public string GetCppFullName(string memberName = "")
		{
			if (string.IsNullOrEmpty(Namespace))
				return Typename;

			return Namespace + "::" + (Typename ?? memberName);
		}
	}
}