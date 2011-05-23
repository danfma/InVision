using InVision.Native;
using InVision.OIS.Attributes;

namespace InVision.OIS.Native
{
    [OISInterface("Interface")]
    public interface IInterface
    {
        [Destructor]
        void Destruct();
    }
}