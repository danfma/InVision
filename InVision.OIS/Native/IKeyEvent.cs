using InVision.Native.Ext;
using InVision.OIS.Attributes;

namespace InVision.OIS.Native
{
    [OISInterface("KeyEvent", BaseType = typeof(IEventArg))]
    public interface IKeyEvent : IEventArg
    {
        [Constructor]
        IKeyEvent Construct(ref KeyEventDescriptor descriptor, IObject device, KeyCode keyCode, uint text);
    }
}