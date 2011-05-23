using InVision.Native;

namespace InVision.OIS.Native
{
    [CppInterface("Axis", Namespace = "OIS", DefinitionFile = "OIS.h", BaseType = typeof(IComponent))]
    public unsafe interface IAxis : IComponent
    {
        [Constructor]
        IAxis Construct(ref AxisDescriptor descriptor);
    }
}