using System;

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

	public class CppWrapperAttribute : CppTypeAttribute
	{
        /// <summary>
        /// Initializes a new instance of the <see cref="CppWrapperAttribute"/> class.
        /// </summary>
	    public CppWrapperAttribute()
	    {
	        
	    }

		/// <summary>
		/// Initializes a new instance of the <see cref="CppWrapperAttribute"/> class.
		/// </summary>
		/// <param name="typename">The typename.</param>
		public CppWrapperAttribute(string typename)
			: base(typename)
		{
		}

		/// <summary>
		/// Gets or sets the inheritance by.
		/// </summary>
		/// <value>The inheritance by.</value>
		public InherintanceMode InheritanceBy { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is abstract.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is abstract; otherwise, <c>false</c>.
        /// </value>
	    public bool IsAbstract { get; set; }

        /// <summary>
        /// Gets or sets the type of the descriptor.
        /// </summary>
        /// <value>The type of the descriptor.</value>
	    public Type DescriptorType { get; set; }
	}

	public enum InherintanceMode
	{
		BaseType,
		Interface,
		ArtificialVTable
	}

	public class FieldAttribute : Attribute
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="FieldAttribute"/> class.
		/// </summary>
		public FieldAttribute() { }

		/// <summary>
		/// Initializes a new instance of the <see cref="FieldAttribute"/> class.
		/// </summary>
		/// <param name="name">The name.</param>
		public FieldAttribute(string name)
		{
			Name = name;
		}

		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>The name.</value>
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the type of the CPP.
		/// </summary>
		/// <value>The type of the CPP.</value>
		public string CppType { get; set; }

		/// <summary>
		/// Gets or sets the special casting.
		/// </summary>
		/// <value>The special casting.</value>
		public string SpecialCasting { get; set; }
	}
}