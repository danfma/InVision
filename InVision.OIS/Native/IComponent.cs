using InVision.Native.Ext;
using InVision.OIS.Attributes;
using InVision.OIS.Components;

namespace InVision.OIS.Native
{
    [OISInterface("Component")]
    public interface IComponent : ICppInterface
    {
        [Constructor]
        IComponent Component(ref ComponentDescriptor descriptor);

        [Constructor]
        IComponent Component(ref ComponentDescriptor descriptor, ComponentType ctype);

        [Destructor]
        void Dispose();
    }
}