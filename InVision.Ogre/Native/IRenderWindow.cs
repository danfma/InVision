using System;
using System.Runtime.InteropServices;
using InVision.Native;

namespace InVision.Ogre.Native
{
	[OgreClass("RenderWindow")]
	public interface IRenderWindow : IRenderTarget
	{
		[Method(Implemented = true)]
		void GetCustomAttribute([MarshalAs(UnmanagedType.LPStr)] string name, out IntPtr data);

		[Method(Implemented = true)]
		IViewport AddViewport(ICamera camera, int zOrder = 0,
			float left = 0, float top = 0,
			float width = 1f, float height = 1f);

		[Method(Implemented = true)]
		[return: MarshalAs(UnmanagedType.I1)]
		bool IsClosed();

		[Method(Implemented = true)]
		[return: MarshalAs(UnmanagedType.LPStr)]
		string WriteContentsToTimestampedFile(
			[MarshalAs(UnmanagedType.LPStr)] string filenamePrefix,
			[MarshalAs(UnmanagedType.LPStr)] string filenameSuffix);

		[Method(Implemented = true)]
		FrameStats GetStatistics();
	}
}