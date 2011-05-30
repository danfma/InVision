using InVision.Native;
using InVision.OIS.Attributes;
using InVision.OIS.Devices;

namespace InVision.OIS.Native
{
    [OISClass("KeyEvent", BaseType = typeof(IEventArg))]
    public interface IKeyEvent : IEventArg
    {
		[Constructor(Implemented = true)]
        IKeyEvent Construct(ref KeyEventDescriptor descriptor, IObject device, KeyCode keyCode, uint text);
    }
}