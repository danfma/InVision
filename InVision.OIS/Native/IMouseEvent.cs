using InVision.Native.Ext;
using InVision.OIS.Attributes;

namespace InVision.OIS.Native
{
    [OISInterface("MouseEvent")]
    public interface IMouseEvent : ICppInterface
    {
        [Constructor]
        IMouseEvent Construct(ref MouseEventDescriptor descriptor, IObject obj, IMouseState mouseState);

        [Destructor]
        void Destruct();
    }
}