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
		int GetTotalDevices(InputType type);

		/// <summary>
		/// Frees the devices.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <returns></returns>
		int FreeDevices(InputType type);

		/// <summary>
		/// Vendors the exists.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <param name="vendor">The vendor.</param>
		/// <returns></returns>
		bool VendorExists(InputType type, string vendor);

		/// <summary>
		/// Creates the object.
		/// </summary>
		/// <param name="creator">The creator.</param>
		/// <param name="type">The type.</param>
		/// <param name="bufferMode">if set to <c>true</c> [buffer mode].</param>
		/// <param name="vendor">The vendor.</param>
		/// <returns></returns>
		IDevice CreateObject(InputManager creator, InputType type, bool bufferMode, string vendor = "");

		/// <summary>
		/// Destroys the object.
		/// </summary>
		/// <param name="device">The input object.</param>
		void DestroyObject(IDevice device);
	}

	public enum MouseButton
	{
		Left,
		Right,
		Middle,
		Button3,
		Button4,
		Button5,
		Button6,
		Button7
	}
}