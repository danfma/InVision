using InVision.Native;
using InVision.OIS.Attributes;

namespace InVision.OIS.Native
{
	[OISInterface("MouseEvent", BaseType = typeof(IEventArg))]
	public interface IMouseEvent : IEventArg
	{
		[Constructor]
		IMouseEvent Construct(ref MouseEventDescriptor descriptor, IObject obj, IMouseState mouseState);
	}
}