using InVision.Native;

namespace InVision.Ogre.Native
{
	[CppInterface("CustomLogListener", DefinitionFile = "cCustomLogListener.h", LocalDefinition = true)]
	public interface ICustomLogListener : ICppInterface
	{
		[Constructor]
		ICustomLogListener Construct(LogListenerMessageLoggedHandler messageLoggedHandler);

		[Destructor]
		void Destruct();
	}
}