using InVision.Native;

namespace InVision.OIS.Native
{
	[CppClass("CustomKeyListener", DefinitionFile = "cCustomKeyListener.h", LocalDefinition = true)]
	public interface ICustomKeyListener : IKeyListener
	{
		[Constructor(Implemented = true)]
		ICustomKeyListener Construct(
			KeyEventHandler keyPressed,
			KeyEventHandler keyReleased);
	}
}