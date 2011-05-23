using InVision.Native;
using InVision.OIS.Attributes;

namespace InVision.OIS.Native
{
    [OISInterface("MouseState")]
    public interface IMouseState : ICppInterface
    {
        [Constructor]
        IMouseState Construct(ref MouseStateDescriptor descriptor);

        [Destructor]
        void Destruct();
    }
}