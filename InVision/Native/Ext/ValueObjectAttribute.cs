using System;

namespace InVision.Native.Ext
{
	/// <summary>
	/// 
	/// </summary>
	public class ValueObjectAttribute : CppTypeAttribute
	{
        /// <summary>
        /// Initializes a new instance of the <see cref="ValueObjectAttribute"/> class.
        /// </summary>
	    public ValueObjectAttribute()
	    {
	    }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValueObjectAttribute"/> class.
        /// </summary>
        /// <param name="typename">The typename.</param>
	    public ValueObjectAttribute(string typename) : base(typename)
	    {
	    }
	}
}