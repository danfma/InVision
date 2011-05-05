using System;

namespace InVision.Bullet.Collision.NarrowPhaseCollision
{
	[Flags]
	public enum EFlags
	{
		kF_None = 0,
		kF_FilterBackfaces = 1 << 0,
		kF_KeepUnflippedNormal = 1 << 1,   // Prevents returned face normal getting flipped when a ray hits a back-facing triangle
		kF_Terminator = (int)0xFFFFFFF
	}
}