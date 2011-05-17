using System;

namespace InVision.Native.Ext
{
    public class CppInterfaceAttribute : CppTypeAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CppInterfaceAttribute"/> class.
        /// </summary>
        public CppInterfaceAttribute()
        {
	        
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CppInterfaceAttribute"/> class.
        /// </summary>
        /// <param name="typename">The typename.</param>
        public CppInterfaceAttribute(string typename)
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

    	public Type BaseType { get; set; }
    }
}