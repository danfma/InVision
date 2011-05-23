using InVision.Native;
using InVision.OIS.Attributes;

namespace InVision.OIS.Native
{
    [OISInterface("Vector3", BaseType = typeof(IComponent))]
    public interface IVector3 : IComponent
    {
        [Constructor]
        IVector3 Construct(ref Vector3Descriptor descriptor);

        [Constructor]
        IVector3 Construct(ref Vector3Descriptor descriptor, float x, float y, float z);
    }
}