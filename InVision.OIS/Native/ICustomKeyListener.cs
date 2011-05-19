using InVision.Native.Ext;
using InVision.OIS.Attributes;

namespace InVision.OIS.Native
{
    [OISInterface("KeyListener")]
    public interface ICustomKeyListener : ICppInterface
    {
        [Constructor]
        ICustomKeyListener Construct(
            KeyEventHandler keyPressed,
            KeyEventHandler keyReleased);

        [Destructor]
        void Destruct();
    }
}