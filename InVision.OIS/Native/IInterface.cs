using InVision.Native;
using InVision.OIS.Attributes;

namespace InVision.OIS.Native
{
    [OISClass("Interface")]
    public interface IInterface
    {
		[Destructor(Implemented = true)]
        void Destruct();
    }
}