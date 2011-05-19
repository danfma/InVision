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
            IsDescriptor = false;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CppValueObjectAttribute"/> class.
        /// </summary>
        /// <param name="typename">The typename.</param>
        public CppValueObjectAttribute(string typename)
            : base(typename)
        {
            IsDescriptor = false;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is descriptor.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is descriptor; otherwise, <c>false</c>.
        /// </value>
        public bool IsDescriptor { get; protected set; }

        /// <summary>
        /// Gets the full typename.
        /// </summary>
        public string GetFullTypename()
        {
            if (string.IsNullOrEmpty(Namespace))
                return Typename;

            return Namespace + "::" + Typename;
        }
    }
}