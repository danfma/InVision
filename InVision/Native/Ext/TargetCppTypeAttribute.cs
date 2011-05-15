using System;

namespace InVision.Native.Ext
{
	public class TargetCppTypeAttribute : Attribute
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="TargetCppTypeAttribute"/> class.
		/// </summary>
		/// <param name="typename">The typename.</param>
		public TargetCppTypeAttribute(string typename)
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
	}
}