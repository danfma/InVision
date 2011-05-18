using InVision.Native.Ext;
using InVision.OIS.Components;

namespace InVision.OIS.Native
{
    [CppInterface("Component", Namespace = "OIS", DefinitionFile = "OIS.h")]
    public unsafe interface IComponent
    {
        [Constructor]
        IComponent Component(ref ComponentDescriptor descriptor);

        [Constructor]
        IComponent Component(ref ComponentDescriptor descriptor, ComponentType ctype);

        [Destructor]
        void Dispose();
    }
}