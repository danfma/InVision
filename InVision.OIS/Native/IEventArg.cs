using InVision.Native;
using InVision.OIS.Attributes;

namespace InVision.OIS.Native
{
	[OISInterface("EventArg")]
	public interface IEventArg : ICppInterface
	{
		[Constructor]
		IEventArg Construct(IObject device);

		[Destructor]
		void Destruct();

		[Method]
		IObject GetDevice();
	}
}