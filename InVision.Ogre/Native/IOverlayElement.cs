using System;
using System.Runtime.InteropServices;
using InVision.Native;

namespace InVision.Ogre.Native
{
	[OgreClass("OverlayElement")]
	public unsafe interface IOverlayElement : IStringInterface, IRenderable
	{
		[Method(Implemented = true)]
		char* GetCaption();

		[Method(Implemented = true)]
		void SetCaption([MarshalAs(UnmanagedType.LPWStr)] string value);

		[Method(Implemented = true)]
		void Show();

		[Method(Static = true)]
		void DeleteWideString(char* pdata);
	}
}