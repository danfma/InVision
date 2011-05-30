using InVision.Native;
using InVision.OIS.Attributes;

namespace InVision.OIS.Native
{
	[OISClass("EventArg")]
	public interface IEventArg : ICppInstance
	{
		[Constructor(Implemented = true)]
		IEventArg Construct(IObject device);

		[Destructor(Implemented = true)]
		void Destruct();

		[Method(Implemented = true)]
		IObject GetDevice();
	}
}