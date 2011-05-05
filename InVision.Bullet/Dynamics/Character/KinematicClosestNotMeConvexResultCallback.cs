using InVision.Bullet.Collision.CollisionDispatch;
using InVision.GameMath;

namespace InVision.Bullet.Dynamics.Character
{
	public class KinematicClosestNotMeConvexResultCallback : ClosestConvexResultCallback
	{
    
		public KinematicClosestNotMeConvexResultCallback (CollisionObject me) : base(Vector3.Zero,Vector3.Zero)
		{
			m_me = me;
		}

		public override float AddSingleResult(LocalConvexResult convexResult,bool normalInWorldSpace)
		{
			if (convexResult.m_hitCollisionObject == m_me)
				return 1.0f;

			return base.AddSingleResult (convexResult, normalInWorldSpace);
		}
    
		protected CollisionObject m_me;
	}
}