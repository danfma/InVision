using System;
using InVision.Native;

namespace InVision.OIS.Native
{
	[CppClass("CustomMouseListener", DefinitionFile = "cCustomMouseListener.h", LocalDefinition = true)]
	public interface ICustomMouseListener : IMouseListener
	{
		[Constructor(Implemented = true)]
		ICustomMouseListener Construct(
			MouseMovedHandler mouseMoved,
			MouseClickHandler mousePressed,
			MouseClickHandler mouseReleased);
	}
}