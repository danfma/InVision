using InVision.Native;
using InVision.OIS.Attributes;

namespace InVision.OIS.Native
{
	[OISInterface("Button", BaseType = typeof (IComponent))]
	public interface IButton : IComponent
	{
		[Constructor]
		IButton Construct(ref ButtonDescriptor descriptor);

		[Constructor]
		IButton Construct(ref ButtonDescriptor descriptor, bool pushed);
	}
}