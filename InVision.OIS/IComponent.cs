using InVision.Input;

namespace InVision.OIS
{
	public interface IComponent
	{
		/// <summary>
		/// 	Gets the type of the component.
		/// </summary>
		/// <value>The type of the component.</value>
		ComponentType ComponentType { get; }
	}
}