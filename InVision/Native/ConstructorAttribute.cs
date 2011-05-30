using System;

namespace InVision.Native
{
	/// <summary>
	/// 
	/// </summary>
	public class ConstructorAttribute : Attribute
	{
		/// <summary>
		/// Gets or sets a value indicating whether [custom impl].
		/// </summary>
		/// <value><c>true</c> if [custom impl]; otherwise, <c>false</c>.</value>
		public bool Implemented { get; set; }
	}
}