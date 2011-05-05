namespace InVision.Bullet.Collision.NarrowPhaseCollision
{
	public enum GjkEpaSolver2Status
	{
		Separated,		/* Shapes doesnt penetrate												*/ 
		Penetrating,	/* Shapes are penetrating												*/ 
		GJK_Failed,		/* GJK phase fail, no big issue, shapes are probably just 'touching'	*/ 
		EPA_Failed		/* EPA phase fail, bigger problem, need to save parameters, and debug	*/ 
	}
}