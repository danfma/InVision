using InVision.Native.Ext;
using InVision.OIS.Attributes;

namespace InVision.OIS.Native
{
	[OISInterface("Button", BaseType = typeof (IComponent))]
	public interface IButton : IComponent
	{
		[Constructor]
		IButton Button(ref ButtonDescriptor descriptor);

		[Constructor]
		IButton Button(ref ButtonDescriptor descriptor, bool pushed);
	}
}