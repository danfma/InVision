using InVision.Native;
using InVision.OIS.Attributes;

namespace InVision.OIS.Native
{
	[OISClass("MouseListener")]
	public interface IMouseListener : ICppInstance
	{
		[Destructor(Implemented = true)]
		void Destruct();
	}
}