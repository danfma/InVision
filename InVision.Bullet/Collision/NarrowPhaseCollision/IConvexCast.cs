using InVision.GameMath;

namespace InVision.Bullet.Collision.NarrowPhaseCollision
{
	public interface IConvexCast
	{
		/// cast a convex against another convex object
		bool CalcTimeOfImpact(ref Matrix fromA,ref Matrix toA,ref Matrix fromB, ref Matrix toB,CastResult result);
	}
}