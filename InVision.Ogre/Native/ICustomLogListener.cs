using InVision.Native;

namespace InVision.Ogre.Native
{
	[CppClass("CustomLogListener", DefinitionFile = "cCustomLogListener.h", LocalDefinition = true)]
	public interface ICustomLogListener : ILogListener
	{
		[Constructor(Implemented = true)]
		ICustomLogListener Construct(LogListenerMessageLoggedHandler messageLoggedHandler);
	}
}