using System;

namespace InVision.OIS
{
	public class InvalidInputObjectCastException : InvalidCastException
	{
		/// <summary>
		/// 	Initializes a new instance of the <see cref = "InvalidInputObjectCastException" /> class.
		/// </summary>
		/// <param name = "actual">The actual.</param>
		/// <param name = "target">The target.</param>
		public InvalidInputObjectCastException(DeviceType actual, DeviceType target)
			: base(string.Format("Can not convert from {0} to {1} input object", actual, target))
		{
		}
	}
}