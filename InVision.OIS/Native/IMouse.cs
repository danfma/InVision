using InVision.Native.Ext;
using InVision.OIS.Attributes;

namespace InVision.OIS.Native
{
    [OISInterface("Mouse", BaseType = typeof(IObject))]
    public interface IMouse : IObject
    {
        [Method]
        void SetEventCallback(ICustomMouseListener mouseListener);

        [Method]
        ICustomMouseListener GetEventCallback();

        [Method]
        IMouseState GetMouseState();
    }
}