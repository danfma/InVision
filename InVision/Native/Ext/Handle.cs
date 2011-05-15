using System;
using System.Runtime.InteropServices;

namespace InVision.Native.Ext
{
	[StructLayout(LayoutKind.Sequential)]
	public struct Handle
	{
		private readonly uint _value;

		/// <summary>
		/// Initializes a new instance of the <see cref="Handle"/> struct.
		/// </summary>
		/// <param name="value">The value.</param>
		public Handle(uint value)
		{
			_value = value;
		}

		/// <summary>
		/// Gets the handle.
		/// </summary>
		/// <value>The handle.</value>
		public uint Value
		{
			get { return _value; }
		}
	}

	public class GeneratorTypeAttribute : Attribute
	{
		
	}

	[AttributeUsage(AttributeTargets.Interface)]
	public class FunctionProviderAttribute : Attribute
	{
		
	}

	[AttributeUsage(AttributeTargets.Interface)]
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

	/// <summary>
	/// 
	/// </summary>
	public class ConstructorAttribute : Attribute { }

	/// <summary>
	/// 
	/// </summary>
	public class DestructorAttribute : Attribute { }

	/// <summary>
	/// 
	/// </summary>
	public class ValueObjectAttribute : Attribute { }
}