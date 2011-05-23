using InVision.Native;
using InVision.OIS.Attributes;
using InVision.OIS.Devices;

namespace InVision.OIS.Native
{
    [OISInterface("Component")]
    public interface IComponent : ICppInterface
    {
        [Constructor]
        IComponent Construct(ref ComponentDescriptor descriptor);

        [Constructor]
        IComponent Construct(ref ComponentDescriptor descriptor, ComponentType ctype);

        [Destructor]
        void Destruct();
    }
}