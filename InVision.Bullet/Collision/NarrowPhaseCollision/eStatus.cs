namespace InVision.Bullet.Collision.NarrowPhaseCollision
{
	public enum eStatus
	{
		Valid,
		Touching,
		Degenerated,
		NonConvex,
		InvalidHull,		
		OutOfFaces,
		OutOfVertices,
		AccuraryReached,
		FallBack,
		Failed		
	}
}