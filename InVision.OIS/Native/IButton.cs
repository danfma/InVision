using InVision.Native;
using InVision.OIS.Attributes;

namespace InVision.OIS.Native
{
	[OISClass("Button", BaseType = typeof(IComponent))]
	public interface IButton : IComponent
	{
		[Constructor(Implemented = true)]
		IButton Construct(ref ButtonDescriptor descriptor);

		[Constructor(Implemented = true)]
		IButton Construct(ref ButtonDescriptor descriptor, bool pushed);
	}
}