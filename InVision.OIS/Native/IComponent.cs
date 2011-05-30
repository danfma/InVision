using InVision.Native;
using InVision.OIS.Attributes;
using InVision.OIS.Devices;

namespace InVision.OIS.Native
{
    [OISClass("Component")]
    public interface IComponent : ICppInstance
    {
        [Constructor(Implemented = true)]
        IComponent Construct(ref ComponentDescriptor descriptor);

		[Constructor(Implemented = true)]
        IComponent Construct(ref ComponentDescriptor descriptor, ComponentType ctype);

		[Destructor(Implemented = true)]
        void Destruct();
    }
}