using System;
using System.Collections.Generic;
using InVision.Collections;
using InVision.Native.OIS;

namespace InVision.Input
{
	public class InputManager : Handle
	{
		/// <summary>
		/// 	Initializes a new instance of the <see cref = "InputManager" /> class.
		/// </summary>
		/// <param name = "winHandle">The win handle.</param>
		public InputManager(IntPtr winHandle)
			: base(NativeInputManager.New(winHandle), true)
		{
		}

		/// <summary>
		/// 	Initializes a new instance of the <see cref = "InputManager" /> class.
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
		/// <param name = "pSelf">The pointer to the unmanaged object.</param>
		/// <returns></returns>
		protected override bool Release(IntPtr pSelf)
		{
			NativeInputManager.Delete(pSelf);
			return true;
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
		public InputObject CreateInputObject(InputType type, bool bufferMode, string vendor = "")
		{
			return NativeInputManager.CreateInputObject(handle, type, bufferMode, vendor);
		}

		/// <summary>
		/// 	Destroys the input object manually.
		/// </summary>
		/// <remarks>
		/// The <paramref name="inputObject"/> should not be used after this call.
		/// </remarks>
		/// <param name = "inputObject">The input object.</param>
		public void DestroyInputObject(InputObject inputObject)
		{
			NativeInputManager.DestroyInputObject(handle, inputObject);
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