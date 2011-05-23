using System;
using System.Runtime.InteropServices;
using InVision.Native;

namespace InVision.Ogre.Native
{
	[OgreInterface("RenderWindow")]
	public interface IRenderWindow : ICppInterface
	{
		[Method]
		void GetCustomAttribute([MarshalAs(UnmanagedType.LPStr)] string name, out IntPtr data);

		[Method]
		IViewport AddViewport(ICamera camera, int zOrder = 0,
			float left = 0, float top = 0,
			float width = 1f, float height = 1f);
	}
}