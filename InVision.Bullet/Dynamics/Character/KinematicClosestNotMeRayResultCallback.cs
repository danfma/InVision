using InVision.Bullet.Collision.CollisionDispatch;
using InVision.GameMath;

namespace InVision.Bullet.Dynamics.Character
{
	///@todo Interact with dynamic objects,
	///Ride kinematicly animated platforms properly
	///More realistic (or maybe just a config option) falling
	/// -> Should integrate falling velocity manually and use that in stepDown()
	///Support jumping
	///Support ducking
	public class KinematicClosestNotMeRayResultCallback : ClosestRayResultCallback
	{
        
		public KinematicClosestNotMeRayResultCallback (CollisionObject me) : base(Vector3.Zero,Vector3.Zero)
		{
			m_me = me;
		}

		public override float AddSingleResult(LocalRayResult rayResult,bool normalInWorldSpace)
		{
			if (rayResult.m_collisionObject == m_me)
				return 1.0f;

			return base.AddSingleResult (rayResult, normalInWorldSpace);
		}
    
		protected CollisionObject m_me;
	}
}