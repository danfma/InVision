namespace InVision.OIS
{
	public interface IFactoryCreator
	{
		/// <summary>
		/// Frees the device list.
		/// </summary>
		/// <returns></returns>
		DeviceList FreeDeviceList();

		/// <summary>
		/// Gets the total devices.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <returns></returns>
		int GetTotalDevices(DeviceType type);

		/// <summary>
		/// Frees the devices.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <returns></returns>
		int FreeDevices(DeviceType type);

		/// <summary>
		/// Vendors the exists.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <param name="vendor">The vendor.</param>
		/// <returns></returns>
		bool VendorExists(DeviceType type, string vendor);

		/// <summary>
		/// Creates the object.
		/// </summary>
		/// <param name="creator">The creator.</param>
		/// <param name="type">The type.</param>
		/// <param name="bufferMode">if set to <c>true</c> [buffer mode].</param>
		/// <param name="vendor">The vendor.</param>
		/// <returns></returns>
		IDevice CreateObject(InputManager creator, DeviceType type, bool bufferMode, string vendor = "");

		/// <summary>
		/// Destroys the object.
		/// </summary>
		/// <param name="device">The input object.</param>
		void DestroyObject(IDevice device);
	}
}