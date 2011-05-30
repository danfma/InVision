using System.Runtime.InteropServices;
using InVision.Native;

namespace InVision.Ogre.Native
{
	[OgreClass("OverlayManager")]
	public interface IOverlayManager : IScriptLoader, ISingleton<IOverlayManager>
	{
		[Method(Implemented = true)]
		IOverlayElement GetOverlayElement(
			[MarshalAs(UnmanagedType.LPStr)] string name,
			[MarshalAs(UnmanagedType.I1)] bool isTemplate = false);

		[Method(Implemented = true)]
		IOverlay GetByName([MarshalAs(UnmanagedType.LPStr)] string name);
	}
}