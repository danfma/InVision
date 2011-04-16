using System;
using InVision.Native;
using InVision.Native.Collections;
using InVision.OIS.Native;

namespace InVision.OIS
{
	public class DeviceObject : Handle, IObject
	{
		private static readonly Dictionary<DeviceType, Type> DeviceTypes;

		/// <summary>
		/// Initializes the <see cref="DeviceObject"/> class.
		/// </summary>
		static DeviceObject()
		{
			DeviceTypes = new Dictionary<DeviceType, Type> {
				{ DeviceType.Mouse, typeof (Mouse) },
				{ DeviceType.Keyboard, typeof (Keyboard) },
				{ DeviceType.Joystick, typeof (Joystick) },
				{ DeviceType.Tablet, typeof (Tablet) },
				{ DeviceType.Unknown, typeof (Unknown) }
			};
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="DeviceObject"/> class.
		/// </summary>
		/// <param name="pSelf">The p self.</param>
		/// <param name="ownsHandle">if set to <c>true</c> [owns handle].</param>
		public DeviceObject(IntPtr pSelf, bool ownsHandle)
			: base(pSelf, ownsHandle)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="DeviceObject"/> class.
		/// </summary>
		/// <param name="ownsHandle">if set to <c>true</c> [owns handle].</param>
		public DeviceObject(bool ownsHandle)
			: base(ownsHandle)
		{
		}


		/// <summary>
		/// Gets the type.
		/// </summary>
		/// <value>The type.</value>
		public DeviceType Type
		{
			get { return NativeObject.GetType(handle); }
		}

		/// <summary>
		/// Gets the vendor.
		/// </summary>
		/// <value>The vendor.</value>
		public string Vendor
		{
			get { return NativeObject.GetVendor(handle); }
		}

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="DeviceObject"/> is buffered.
		/// </summary>
		/// <value><c>true</c> if buffered; otherwise, <c>false</c>.</value>
		public bool Buffered
		{
			get { return NativeObject.GetBuffered(handle); }
			set { NativeObject.SetBuffered(handle, value); }
		}

		/// <summary>
		/// Gets the id.
		/// </summary>
		/// <value>The id.</value>
		public int Id
		{
			get { return NativeObject.GetId(handle); }
		}

		/// <summary>
		/// Releases the valid handle.
		/// </summary>
		protected override void ReleaseValidHandle()
		{
			NativeObject.Delete(handle);
		}

		/// <summary>
		/// Captures this instance.
		/// </summary>
		public void Capture()
		{
			NativeObject.Capture(handle);
		}

		/// <summary>
		/// Queries the interface.
		/// </summary>
		/// <param name="interfaceType">Type of the interface.</param>
		/// <returns></returns>
		public IntPtr QueryInterface(InterfaceType interfaceType)
		{
			return NativeObject.QueryInterface(handle, interfaceType);
		}

		/// <summary>
		/// Creates the specified type.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <param name="handle">The handle.</param>
		/// <returns></returns>
		internal static DeviceObject Create(DeviceType type, IntPtr handle)
		{
			return (DeviceObject)Activator.CreateInstance(DeviceTypes[type], handle);
		}
	}
}