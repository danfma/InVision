using InVision.Native;
using InVision.OIS.Attributes;

namespace InVision.OIS.Native
{
	[OISClass("MouseEvent", BaseType = typeof(IEventArg))]
	public interface IMouseEvent : IEventArg
	{
		[Constructor(Implemented = true)]
		IMouseEvent Construct(ref MouseEventDescriptor descriptor, IObject obj, IMouseState mouseState);
	}
}