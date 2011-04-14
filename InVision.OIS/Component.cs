using System;
using InVision.OIS.Native;

namespace InVision.OIS
{
	public class Component : Handle
	{
		public Component (ComponentType componentType)
			: base(NativeComponent.NewComponent(componentType))
		{
		}
	}
}

