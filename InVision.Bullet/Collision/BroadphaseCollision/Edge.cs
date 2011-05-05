namespace InVision.Bullet.Collision.BroadphaseCollision
{
	public class Edge
	{
		public ushort m_pos;			// low bit is min/max
		public ushort m_handle;

		public void Copy(Edge edge)
		{
			m_pos = edge.m_pos;
			m_handle = edge.m_handle;
		}

		public bool IsMax()
		{
			return ((m_pos&1) != 0);
		}

		public static void Swap(Edge a, Edge b)
		{
			swapEdge.Copy(a);
			a.Copy(b);
			b.Copy(swapEdge);
		}
		private static Edge swapEdge = new Edge(); // not threadsafe
	}
}