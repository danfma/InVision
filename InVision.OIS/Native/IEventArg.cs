using InVision.Native.Ext;
using InVision.OIS.Attributes;

namespace InVision.OIS.Native
{
    [OISInterface("EventArg")]
    public interface IEventArg
    {
        [Constructor]
        IEventArg Construct(IObject device);

        [Destructor]
        void Destruct();

        [Method]
        Handle GetDevice();
    }
}