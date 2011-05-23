using System;
using System.Globalization;
using System.Reflection;
using InVision.Native;
using InVision.Native.Collections;
using InVision.OIS.Native;

namespace InVision.OIS.Devices
{
	public class DeviceObject : CppWrapper
	{
		private static readonly Dictionary<DeviceType, Type> DeviceTypes;

		/// <summary>
		/// Initializes the <see cref="DeviceObject"/> class.
		/// </summary>
		static DeviceObject()
		{
			DeviceTypes = new Dictionary<DeviceType, Type> {
				{ DeviceType.Mouse, typeof (Mouse) },
				{ DeviceType.Keyboard, typeof (Keyboard) }
			};
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="DeviceObject"/> class.
		/// </summary>
		/// <param name="nativeInstance">The native instance.</param>
		protected DeviceObject(ICppInterface nativeInstance)
			: base(nativeInstance)
		{
		}

		/// <summary>
		/// Releases unmanaged and - optionally - managed resources
		/// </summary>
		/// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
		protected override void Dispose(bool disposing)
		{
			if (Native != null && InputManager != null)
				InputManager.Native.DestroyInputObject(Native);

			if (disposing)
				InputManager = null;

			base.Dispose(disposing);
		}

		/// <summary>
		/// Gets or sets the native instance.
		/// </summary>
		/// <value>The native instance.</value>
		public new IObject Native
		{
			get { return (IObject)base.Native; }
		}


		/// <summary>
		/// Gets the type.
		/// </summary>
		/// <value>The type.</value>
		public DeviceType Type
		{
			get { return Native.Type(); }
		}

		/// <summary>
		/// Gets the vendor.
		/// </summary>
		/// <value>The vendor.</value>
		public string Vendor
		{
			get { return Native.Vendor(); }
		}

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="DeviceObject"/> is buffered.
		/// </summary>
		/// <value><c>true</c> if buffered; otherwise, <c>false</c>.</value>
		public bool Buffered
		{
			get { return Native.Buffered(); }
			set { Native.SetBuffered(value); }
		}

		/// <summary>
		/// Gets the id.
		/// </summary>
		/// <value>The id.</value>
		public int Id
		{
			get { return Native.GetID(); }
		}

		/// <summary>
		/// Gets or sets the input manager.
		/// </summary>
		/// <value>The input manager.</value>
		protected InputManager InputManager { get; private set; }

		/// <summary>
		/// Captures this instance.
		/// </summary>
		public void Capture()
		{
			Native.Capture();
		}

		/// <summary>
		/// Initializes this instance.
		/// </summary>
		protected virtual void Initialize()
		{

		}

		/// <summary>
		/// Queries the interface.
		/// </summary>
		/// <param name="interfaceType">Type of the interface.</param>
		/// <returns></returns>
		public DeviceObject QueryInterface(InterfaceType interfaceType)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Creates the specified input manager.
		/// </summary>
		/// <param name="inputManager">The input manager.</param>
		/// <param name="type">The type.</param>
		/// <param name="nativeObject">The native object.</param>
		/// <returns></returns>
		internal static DeviceObject Create(InputManager inputManager, DeviceType type, IObject nativeObject)
		{
			var owner = (DeviceObject)GetOwner<IObject>(nativeObject);

			if (owner == null)
			{
				owner = (DeviceObject)Activator.CreateInstance(
					DeviceTypes[type],
					BindingFlags.Public | BindingFlags.NonPublic,
					null,
					new[] { nativeObject },
					CultureInfo.CurrentCulture);

				owner.InputManager = inputManager;
				owner.Initialize();

				RegisterOwnership(nativeObject, owner);
			}

			return owner;
		}
	}
}