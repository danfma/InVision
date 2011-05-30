using System;

namespace InVision.Native
{
    /// <summary>
    /// 
    /// </summary>
    public class MethodAttribute : Attribute
    {
        /// <summary>
        /// Gets or sets a value indicating whether this instance is static.
        /// </summary>
        /// <value><c>true</c> if this instance is static; otherwise, <c>false</c>.</value>
        public bool Static { get; set; }

        /// <summary>
        /// Gets or sets the property.
        /// </summary>
        /// <value>The property.</value>
        public string Property { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether [custom impl].
		/// </summary>
		/// <value><c>true</c> if [custom impl]; otherwise, <c>false</c>.</value>
		public bool Implemented { get; set; }
    }
}