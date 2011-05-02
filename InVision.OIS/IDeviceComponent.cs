using InVision.OIS.Components;

namespace InVision.OIS
{
	public interface IDeviceComponent
	{
		/// <summary>
		/// Gets the type of the component.
		/// </summary>
		/// <value>The type of the component.</value>
		ComponentType ComponentType { get; }
	}
}