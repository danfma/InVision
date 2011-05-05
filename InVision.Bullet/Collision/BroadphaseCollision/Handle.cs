namespace InVision.Bullet.Collision.BroadphaseCollision
{
	public class Handle : BroadphaseProxy
	{
		public ushort[] m_minEdges = new ushort[3];
		public ushort[] m_maxEdges = new ushort[3];
		public BroadphaseProxy	m_dbvtProxy;//for faster raycast

		public Handle()
			: base()
		{
			m_minEdges[0] = m_minEdges[1] = m_minEdges[2] = 52685;
			m_maxEdges[0] = m_maxEdges[1] = m_maxEdges[2] = 52685;
		}

		public void SetNextFree(ushort next) 
		{
			m_minEdges[0] = next;
		}
		public ushort GetNextFree() 
		{
			return m_minEdges[0];
		}
	}
}