using System.Runtime.InteropServices;

namespace InVision.Ogre
{
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