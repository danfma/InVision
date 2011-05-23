using System;

namespace InVision.Native
{
	[CppInterface("HandleManager")]
	public interface IHandleManager
	{
		[Method(Static = true)]
		void RegisterHandleDestroyed(HandleListenerHandleDestroyedHandler handleDestroyed);
	}
}