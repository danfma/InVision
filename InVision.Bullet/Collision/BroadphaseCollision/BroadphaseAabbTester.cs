namespace InVision.Bullet.Collision.BroadphaseCollision
{
	public class BroadphaseAabbTester : Collide
	{
		IBroadphaseAabbCallback m_aabbCallback;
		public BroadphaseAabbTester(IBroadphaseAabbCallback orgCallback)
		{
			m_aabbCallback = orgCallback;
		}
		public void	Process(DbvtNode leaf)
		{
			DbvtProxy	proxy=(DbvtProxy)leaf.data;
			m_aabbCallback.Process(proxy);
		}
	}
}