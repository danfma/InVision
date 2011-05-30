/*
 * GENERATED CODE
 * DO NOT EDIT THIS
 */

using System;
using System.Reflection;
using InVision.GameMath;
using InVision.Native;

namespace InVision.Native
{
	[CppImplementation(typeof(IHandleManager))]
	internal class HandleManagerImpl
		: CppInstance, IHandleManager
	{
		void IHandleManager.RegisterHandleDestroyed(HandleListenerHandleDestroyedHandler handleDestroyed)
		{
			CheckStaticOnlyCall();
			
			NativeHandleManager.RegisterHandleDestroyed(handleDestroyed);
		}
		
	}
	
}
