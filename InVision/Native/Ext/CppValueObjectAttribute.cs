using System;

namespace InVision.Native.Ext
{
	/// <summary>
	/// 
	/// </summary>
	public class CppValueObjectAttribute : CppTypeAttribute
	{
        /// <summary>
        /// Initializes a new instance of the <see cref="CppValueObjectAttribute"/> class.
        /// </summary>
	    public CppValueObjectAttribute()
	    {
	    }

        /// <summary>
        /// Initializes a new instance of the <see cref="CppValueObjectAttribute"/> class.
        /// </summary>
        /// <param name="typename">The typename.</param>
	    public CppValueObjectAttribute(string typename) : base(typename)
	    {
	    }
	}
}