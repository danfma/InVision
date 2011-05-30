using InVision.OIS.Native;

namespace InVision.OIS.Devices
{
	internal interface ITypeConstructor
	{
		/// <summary>
		/// Creates the instance.
		/// </summary>
		/// <param name="device">The device.</param>
		/// <returns></returns>
		object CreateInstance(IObject device);
	}
}