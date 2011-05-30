using System;

namespace InVision.Native
{
	[CppClass("HandleManager")]
	public interface IHandleManager
	{
		[Method(Static = true, Implemented = true)]
		void RegisterHandleDestroyed(HandleListenerHandleDestroyedHandler handleDestroyed);
	}
}