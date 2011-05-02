using System;
using InVision.Native;
using InVision.Native.Collections;
using InVision.OIS.Native;

namespace InVision.OIS
{
	public class InputManager : Handle
	{
		private static uint? _versionNumber;
		private string _inputSystemName;
		private string _versionName;
		private readonly List<WeakReference> _devices = new List<WeakReference>();

		/// <summary>
		/// Initializes a new instance of the <see cref="InputManager"/> class.
		/// </summary>
		/// <param name="pSelf">The p self.</param>
		/// <param name="ownsHandle">if set to <c>true</c> [owns handle].</param>
		private InputManager(IntPtr pSelf, bool ownsHandle)
			: base(pSelf, ownsHandle)
		{
		}

		/// <summary>
		/// Gets the name of the input system.
		/// </summary>
		/// <value>The name of the input system.</value>
		public string InputSystemName
		{
			get { return _inputSystemName ?? (_inputSystemName = NativeInputManager.InputSystemName(handle)); }
		}

		/// <summary>
		/// Gets the version number.
		/// </summary>
		/// <value>The version number.</value>
		public static uint VersionNumber
		{
			get
			{
				if (_versionNumber == null)
					_versionNumber = NativeInputManager.GetVersionNumber();

				return _versionNumber.Value;
			}
		}

		/// <summary>
		/// Gets the name of the version.
		/// </summary>
		/// <value>The name of the version.</value>
		public string VersionName
		{
			get { return _versionName ?? (_versionName = NativeInputManager.GetVersionName(handle)); }
		}

		/// <summary>
		/// Creates the specified win handle.
		/// </summary>
		/// <param name="winHandle">The win handle.</param>
		/// <returns></returns>
		public static InputManager Create(int winHandle)
		{
			return NativeInputManager.CreateInputSystem(winHandle).
				AsHandle(pt => new InputManager(pt, true));
		}

		/// <summary>
		/// Creates the specified param list.
		/// </summary>
		/// <param name="paramList">The param list.</param>
		/// <returns></returns>
		public static InputManager Create(ParamList paramList)
		{
			int count;
			NameValueItem[] parameters = NameValueItem.ToArray(paramList, out count);

			return NativeInputManager.CreateInputSystem(parameters, count).
				AsHandle(pt => new InputManager(pt, true));
		}

		/// <summary>
		/// Gets the number of devices.
		/// </summary>
		/// <value>The number of devices.</value>
		public int GetNumberOfDevices(DeviceType type)
		{
			return NativeInputManager.GetNumberOfDevices(handle, type);
		}

		/// <summary>
		/// Lists the free devices.
		/// </summary>
		/// <returns></returns>
		public DeviceList ListFreeDevices()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Creates the input object.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <param name="bufferMode">if set to <c>true</c> [buffer mode].</param>
		/// <param name="vendor">The vendor.</param>
		/// <returns></returns>
		public DeviceObject CreateInputObject(DeviceType type, bool bufferMode, string vendor = "")
		{
			var objHandle = NativeInputManager.CreateInputObject(handle, type, bufferMode, vendor);
			var device = objHandle.AsHandle(pt => DeviceObject.Create(type, pt));

			_devices.Add(new WeakReference(device));

			return device;
		}

		/// <summary>
		/// Adds the factory creator.
		/// </summary>
		/// <param name="factory">The factory.</param>
		public void AddFactoryCreator(IFactoryCreator factory)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Removes the factory creator.
		/// </summary>
		/// <param name="factory">The factory.</param>
		public void RemoveFactoryCreator(IFactoryCreator factory)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Enables the add on factory.
		/// </summary>
		/// <param name="addOnFactory">The add on factory.</param>
		public void EnableAddOnFactory(AddOnFactory addOnFactory)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Releases the valid handle.
		/// </summary>
		protected override void ReleaseValidHandle()
		{
			foreach (var weakReference in _devices)
			{
				if (weakReference.IsAlive)
					((DeviceObject)weakReference.Target).Dispose();
			}

			_devices.Clear();

			NativeInputManager.Destroy(handle);
		}
	}
}