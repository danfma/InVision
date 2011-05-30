using System.Runtime.InteropServices;
using InVision.Ogre.Native;

namespace InVision.Ogre
{
	[OgreValueObject("FrameStats")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FrameStats
	{
		public float LastFPS;
		public float AvgFPS;
		public float BestFPS;
		public float WorstFPS;
		public ulong BestFrameTime;
		public ulong WorstFrameTime;
		public int TriangleCount;
		public int BatchCount;
	}
}