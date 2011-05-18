using InVision.Native.Ext;

namespace InVision.OIS.Native
{
    [CppInterface("Axis", Namespace = "OIS", DefinitionFile = "OIS.h", BaseType = typeof(IComponent))]
    public unsafe interface IAxis : IComponent
    {
        [Constructor]
        IAxis Axis(ref AxisDescriptor descriptor);
    }
}