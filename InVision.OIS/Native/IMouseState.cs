using InVision.Native;
using InVision.OIS.Attributes;

namespace InVision.OIS.Native
{
    [OISClass("MouseState")]
    public interface IMouseState : ICppInstance
    {
		[Constructor(Implemented = true)]
        IMouseState Construct(ref MouseStateDescriptor descriptor);

		[Destructor(Implemented = true)]
        void Destruct();
    }
}