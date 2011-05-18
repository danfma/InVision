using InVision.Native.Ext;

namespace InVision.OIS.Native
{
    [CppInterface("Button", Namespace = "OIS", DefinitionFile = "OIS.h", BaseType = typeof(IComponent))]
    public unsafe interface IButton : IComponent
    {
        [Constructor]
        IButton Button(ref ButtonDescriptor descriptor);

        [Constructor]
        IButton Button(ref ButtonDescriptor descriptor, bool pushed);
    }
}