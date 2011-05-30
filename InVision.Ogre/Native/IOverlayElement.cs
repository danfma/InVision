using System.Runtime.InteropServices;
using InVision.Native;

namespace InVision.Ogre.Native
{
	[OgreClass("OverlayElement")]
	public interface IOverlayElement : IStringInterface, IRenderable
	{
		[Method(Implemented = true)]
		[return: MarshalAs(UnmanagedType.LPStr)]
		string GetCaption();

		[Method(Implemented = true)]
		void SetCaption([MarshalAs(UnmanagedType.LPStr)] string value);

		[Method(Implemented = true)]
		void Show();
	}
}