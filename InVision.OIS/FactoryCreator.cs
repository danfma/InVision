using System;

namespace InVision.OIS
{
	public class FactoryCreator : IFactoryCreator
	{
		/// <summary>
		/// Frees the device list.
		/// </summary>
		/// <returns></returns>
		public DeviceList FreeDeviceList()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Gets the total devices.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <returns></returns>
		public int GetTotalDevices(InputType type)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Frees the devices.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <returns></returns>
		public int FreeDevices(InputType type)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Vendors the exists.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <param name="vendor">The vendor.</param>
		/// <returns></returns>
		public bool VendorExists(InputType type, string vendor)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Creates the object.
		/// </summary>
		/// <param name="creator">The creator.</param>
		/// <param name="type">The type.</param>
		/// <param name="bufferMode">if set to <c>true</c> [buffer mode].</param>
		/// <param name="vendor">The vendor.</param>
		/// <returns></returns>
		public IDevice CreateObject(InputManager creator, InputType type, bool bufferMode, string vendor)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Destroys the object.
		/// </summary>
		/// <param name="device">The input object.</param>
		public void DestroyObject(IDevice device)
		{
			throw new NotImplementedException();
		}
	}
}