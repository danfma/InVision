using System;

namespace InVision.Native
{
    /// <summary>
    /// 
    /// </summary>
    public class DestructorAttribute : Attribute
    {
		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="DestructorAttribute"/> is implemented.
		/// </summary>
		/// <value><c>true</c> if implemented; otherwise, <c>false</c>.</value>
		public bool Implemented { get; set; }
    }
}