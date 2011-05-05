namespace InVision.Bullet.Collision.BroadphaseCollision
{
	public class ProfileBlock
	{
		public ulong m_total;
		public ulong m_ddcollide;
		public ulong m_fdcollide;
		public ulong m_cleanup;
		public ulong m_jobcount;

		public void clear()
		{
			m_total = 0;
			m_ddcollide = 0;
			m_fdcollide = 0;
			m_cleanup = 0;
			m_jobcount = 0;
		}
	}
}