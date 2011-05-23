using System;

namespace InVision.Native
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
		/// Gets or sets the type of the interface.
		/// </summary>
		/// <value>The type of the interface.</value>
        public CppInterfaceType CppInterfaceType { get; set; }

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

        /// <summary>
        /// Gets or sets the type of the base.
        /// </summary>
        /// <value>The type of the base.</value>
    	public Type BaseType { get; set; }
    }
}