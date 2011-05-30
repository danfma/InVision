using System;
using InVision.Native;
using InVision.OIS.Native;

namespace InVision.OIS.Devices
{
	public abstract class EventArgs : CppWrapper
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="EventArgs"/> class.
		/// </summary>
		/// <param name="nativeInstance">The native instance.</param>
		protected EventArgs(ICppInstance nativeInstance)
			: base(nativeInstance)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="EventArgs"/> class.
		/// </summary>
		/// <param name="descriptor">The descriptor.</param>
		/// <param name="native">The native.</param>
		protected EventArgs(EventArgDescriptor descriptor, IEventArg native)
			: this(native)
		{
			Native.SetOwner(this);
			Initialize(descriptor);
		}

		/// <summary>
		/// Initializes the specified descriptor.
		/// </summary>
		/// <param name="descriptor">The descriptor.</param>
		protected void Initialize(EventArgDescriptor descriptor)
		{
		}

		/// <summary>
		/// Gets or sets the native instance.
		/// </summary>
		/// <value>The native instance.</value>
		public new IEventArg Native
		{
			get { return (IEventArg)base.Native; }
		}

		/// <summary>
		/// Gets or sets the device.
		/// </summary>
		/// <value>The device.</value>
		public DeviceObject Device
		{
			get
			{
				var nativeDevice = Native.GetDevice();

				return GetOwner<DeviceObject>(nativeDevice);
			}
		}
	}
}