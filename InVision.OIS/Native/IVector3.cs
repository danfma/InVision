using InVision.Native;
using InVision.OIS.Attributes;

namespace InVision.OIS.Native
{
    [OISClass("Vector3", BaseType = typeof(IComponent))]
    public interface IVector3 : IComponent
    {
		[Constructor(Implemented = true)]
        IVector3 Construct(ref Vector3Descriptor descriptor);

		[Constructor(Implemented = true)]
        IVector3 Construct(ref Vector3Descriptor descriptor, float x, float y, float z);
    }
}