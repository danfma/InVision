using InVision.Native.Ext;

namespace InVision.OIS.Native
{
    [CppInterface("Vector3", Namespace = "OIS", DefinitionFile = "OIS.h", BaseType = typeof(IComponent))]
    public unsafe interface IVector3 : IComponent
    {
        [Constructor]
        IVector3 Vector3(ref Vector3Descriptor descriptor);

        [Constructor]
        IVector3 Vector3(ref Vector3Descriptor descriptor, float x, float y, float z);
    }
}