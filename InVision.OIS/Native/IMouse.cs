using InVision.Native;
using InVision.OIS.Attributes;

namespace InVision.OIS.Native
{
    [OISClass("Mouse", BaseType = typeof(IObject))]
    public interface IMouse : IObject
    {
		[Method(Implemented = true)]
        void SetEventCallback(ICustomMouseListener mouseListener);

		[Method(Implemented = true)]
        ICustomMouseListener GetEventCallback();

		[Method(Implemented = true)]
        IMouseState GetMouseState();
    }
}