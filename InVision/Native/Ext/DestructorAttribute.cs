using System;

namespace InVision.Native.Ext
{
    /// <summary>
    /// 
    /// </summary>
    public class DestructorAttribute : Attribute { }

    /// <summary>
    /// 
    /// </summary>
    public class MethodAttribute : Attribute
    {
        /// <summary>
        /// Gets or sets a value indicating whether this instance is static.
        /// </summary>
        /// <value><c>true</c> if this instance is static; otherwise, <c>false</c>.</value>
        public bool IsStatic { get; set; }

        /// <summary>
        /// Gets or sets the property.
        /// </summary>
        /// <value>The property.</value>
        public string Property { get; set; }
    }
}