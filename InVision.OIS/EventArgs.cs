using System;
using InVision.Native.Ext;
using InVision.OIS.Native;

namespace InVision.OIS
{
	public class EventArgs : HandleReference
	{
		private readonly EventArgDescriptor _descriptor;

		/// <summary>
		/// Initializes a new instance of the <see cref="EventArgs"/> class.
		/// </summary>
		/// <param name="descriptor">The descriptor.</param>
		internal EventArgs(EventArgDescriptor descriptor)
			: base(descriptor.Self)
		{
			_descriptor = descriptor;
		}

		/// <summary>
		/// Gets or sets the device.
		/// </summary>
		/// <value>The device.</value>
		public IDevice Device
		{
			get { throw new NotImplementedException(); }
		}
	}
}