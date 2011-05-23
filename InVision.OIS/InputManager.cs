using System;
using System.Collections.Generic;
using InVision.Native;
using InVision.OIS.Devices;
using InVision.OIS.Native;
using System.Linq;

namespace InVision.OIS
{
	public sealed class InputManager : CppWrapper
	{
		private static readonly IInputManager Static = CreateCppInstance<IInputManager>();

		/// <summary>
		/// Initializes a new instance of the <see cref="InputManager"/> class.
		/// </summary>
		/// <param name="nativeInstance">The native instance.</param>
		private InputManager(IInputManager nativeInstance)
			: base(nativeInstance)
		{
			nativeInstance.SetOwner(this);
		}

		/// <summary>
		/// Gets or sets the native instance.
		/// </summary>
		/// <value>The native instance.</value>
		public new IInputManager Native
		{
			get { return (IInputManager)base.Native; }
		}

		/// <summary>
		/// Releases unmanaged and - optionally - managed resources
		/// </summary>
		/// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
		protected override void Dispose(bool disposing)
		{
			if (Native != null)
				Native.DestroyInputSystem(Native);

			base.Dispose(disposing);
		}

		/// <summary>
		/// Gets the version number.
		/// </summary>
		/// <value>The version number.</value>
		public static uint VersionNumber
		{
			get { return Static.GetVersionNumber(); }
		}

		/// <summary>
		/// Gets the name of the version.
		/// </summary>
		/// <value>The name of the version.</value>
		public string VersionName
		{
			get { return Native.GetVersionName(); }
		}

		/// <summary>
		/// Gets the name.
		/// </summary>
		/// <value>The name.</value>
		public string Name
		{
			get { return Native.InputSystemName(); }
		}

		/// <summary>
		/// Gets the number of devices.
		/// </summary>
		/// <param name="iType">Type of the i.</param>
		/// <returns></returns>
		public int GetNumberOfDevices(DeviceType iType)
		{
			return Native.GetNumberOfDevices(iType);
		}

		public IDictionary<DeviceType, string> ListFreeDevices()
		{
			var pDevices = Native.ListFreeDevices();
			var deviceItems = DeviceList.ReadData(pDevices);

			return deviceItems.ToDictionary(item => item.Key, item => item.Value);
		}

		public DeviceObject CreateInputObject(DeviceType iType, bool bufferMode)
		{
			var nativeDevice = Native.CreateInputObject(iType, bufferMode);

			if (nativeDevice == null)
				return null;

			return DeviceObject.Create(this, iType, nativeDevice);
		}

		public DeviceObject CreateInputObject(DeviceType iType, bool bufferMode, string vendor)
		{
			var nativeDevice = Native.CreateInputObject(iType, bufferMode, vendor);

			if (nativeDevice == null)
				return null;

			return DeviceObject.Create(this, iType, nativeDevice);
		}

		public void AddFactoryCreator(IFactoryCreator factory)
		{
			Native.AddFactoryCreator(factory);
		}

		public void RemoveFactoryCreator(IFactoryCreator factory)
		{
			Native.RemoveFactoryCreator(factory);
		}

		public void EnableAddOnFactory(AddOnFactory factory)
		{
			Native.EnableAddOnFactory(factory);
		}

		/// <summary>
		/// Creates the instance.
		/// </summary>
		/// <param name="winHandle">The win handle.</param>
		/// <returns></returns>
		public static InputManager CreateInstance(int winHandle)
		{
			IInputManager native = Static.CreateInputSystem(winHandle);

			if (native == null)
				throw new OISException("Could not create an InputManager instance");

			return new InputManager(native);
		}

		/// <summary>
		/// Creates the instance.
		/// </summary>
		/// <param name="parameters">The parameters.</param>
		/// <returns></returns>
		public static InputManager CreateInstance(ParamList parameters)
		{
			int count;
			NameValueItem[] items = NameValueItem.ToArray(parameters, out count);

			IInputManager native = Static.CreateInputSystem(items, count);

			if (native == null)
				throw new OISException("Could not create an InputManager instance");

			return new InputManager(native);
		}
	}
}