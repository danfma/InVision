namespace InVision.Native
{
	public class HandleConverterAttribute : GeneratorModelAttribute
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="HandleConverterAttribute"/> class.
		/// </summary>
		/// <param name="ns">The ns.</param>
		/// <param name="typeName">Name of the type.</param>
		/// <param name="definitionFile">The definition file.</param>
		public HandleConverterAttribute(string ns, string typeName, string definitionFile)
		{
			Namespace = ns;
			TypeName = typeName;
			DefinitionFile = definitionFile;
		}

		/// <summary>
		/// Gets or sets the name of the custom.
		/// </summary>
		/// <value>The name of the custom.</value>
		public string CustomName { get; set; }

		/// <summary>
		/// Gets or sets the namespace.
		/// </summary>
		/// <value>The namespace.</value>
		public string Namespace { get; set; }

		/// <summary>
		/// Gets or sets the full name of the type.
		/// </summary>
		/// <value>The full name of the type.</value>
		public string TypeName { get; set; }

		/// <summary>
		/// Gets or sets the definition file.
		/// </summary>
		/// <value>The definition file.</value>
		public string DefinitionFile { get; set; }

		/// <summary>
		/// Gets the full name of the type.
		/// </summary>
		/// <value>The full name of the type.</value>
		public string FullTypeName
		{
			get
			{
				if (string.IsNullOrEmpty(Namespace))
					return TypeName;

				return Namespace + "::" + TypeName;
			}
		}

		/// <summary>
		/// Customs the name of the or type.
		/// </summary>
		/// <returns></returns>
		public object CustomOrTypeName()
		{
			return CustomName ?? TypeName;
		}
	}
}