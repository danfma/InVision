namespace InVision.Bullet.Collision.BroadphaseCollision
{
	public class BroadphaseRayTester : Collide
	{
		public BroadphaseRayTester(BroadphaseRayCallback orgCallback)
		{
			m_rayCallback = orgCallback;
		}
		public override void Process(DbvtNode leaf)
		{
			DbvtProxy	proxy=(DbvtProxy)leaf.data;
			m_rayCallback.Process(proxy);
		}
		BroadphaseRayCallback m_rayCallback;
	}
}