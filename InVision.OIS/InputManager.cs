using System;
using System.Collections.Generic;

namespace InVision.OIS
{
	public class InputManager : Handle
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="InVision.OIS.InputManager"/> class.
		/// </summary>
		/// <param name="pSelf">The p self.</param>
		/// <param name="ownsHandle">if set to <c>true</c> [owns handle].</param>
		protected internal InputManager(IntPtr pSelf, bool ownsHandle)
			: base(pSelf, ownsHandle)
		{
		}

		/// <summary>
		/// 	Initializes a new instance of the <see cref = "InVision.OIS.InputManager" /> class.
		/// </summary>
		/// <param name = "winHandle">The win handle.</param>
		public InputManager(IntPtr winHandle)
			: base(NativeInputManager.New(winHandle), true)
		{
		}

		/// <summary>
		/// 	Initializes a new instance of the <see cref = "InVision.OIS.InputManager" /> class.
		/// </summary>
		/// <param name = "paramList">The param list.</param>
		public InputManager(NameValueCollection paramList)
			: base(NativeInputManager.NewWithParamList(paramList), true)
		{
		}


		/// <summary>
		/// 	Gets the name of the input system.
		/// </summary>
		/// <value>The name of the input system.</value>
		public string InputSystemName
		{
			get { return NativeInputManager.GetName(handle); }
		}

		/// <summary>
		/// 	Releases the specified pointer to the unmanaged object.
		/// </summary>
		/// <returns></returns>
		protected override void ReleaseValidHandle()
		{
			NativeInputManager.Delete(handle);
		}

		/// <summary>
		/// 	Lists the free devices.
		/// </summary>
		/// <returns></returns>
		public IEnumerable<DeviceInfo> ListFreeDevices()
		{
			return NativeInputManager.ListFreeDevices(handle);
		}

		/// <summary>
		/// 	Gets the number of devices.
		/// </summary>
		/// <param name = "type">The type.</param>
		/// <returns></returns>
		public int GetNumberOfDevices(InputType type)
		{
			return NativeInputManager.GetNumberOfDevices(handle, type);
		}

		/// <summary>
		/// 	Creates the input object.
		/// </summary>
		/// <param name = "type">The type.</param>
		/// <param name = "bufferMode">if set to <c>true</c> [buffer mode].</param>
		/// <param name = "vendor">The vendor.</param>
		/// <returns></returns>
		public Device CreateInputObject(InputType type, bool bufferMode, string vendor = "")
		{
			return NativeInputManager.CreateInputObject(handle, type, bufferMode, vendor);
		}

		/// <summary>
		/// 	Destroys the input object manually.
		/// </summary>
		/// <remarks>
		/// The <paramref name="device"/> should not be used after this call.
		/// </remarks>
		/// <param name = "device">The input object.</param>
		public void DestroyInputObject(Device device)
		{
			NativeInputManager.DestroyInputObject(handle, device);
		}

		/// <summary>
		/// 	Adds the factory creator.
		/// </summary>
		/// <param name = "factory">The factory.</param>
		public void AddFactoryCreator(FactoryCreator factory)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// 	Removes the factory creator.
		/// </summary>
		/// <param name = "factory">The factory.</param>
		public void RemoveFactoryCreator(FactoryCreator factory)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// 	Enables the add on factory.
		/// </summary>
		/// <param name = "factory">The factory.</param>
		public void EnableAddOnFactory(AddOnFactory factory)
		{
			throw new NotImplementedException();
		}
	}
}