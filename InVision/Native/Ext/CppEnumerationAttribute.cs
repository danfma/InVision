namespace InVision.Native.Ext
{
	public class CppEnumerationAttribute : CppTypeAttribute
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="CppEnumerationAttribute"/> class.
		/// </summary>
		public CppEnumerationAttribute()
		{
			
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="CppEnumerationAttribute"/> class.
		/// </summary>
		/// <param name="typename">The typename.</param>
		public CppEnumerationAttribute(string typename)
			: base(typename)
		{
		}
	}
}