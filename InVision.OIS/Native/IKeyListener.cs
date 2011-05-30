using InVision.Native;
using InVision.OIS.Attributes;

namespace InVision.OIS.Native
{
	[OISClass("KeyListener")]
	public interface IKeyListener : ICppInstance
	{
		[Destructor(Implemented = true)]
		void Destruct();
	}
}