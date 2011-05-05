namespace InVision.Bullet.Collision.CollisionDispatch
{
	public class LocalInfoAdder : ConvexResultCallback 
	{
		public ConvexResultCallback m_userCallback;
		public int m_i;

		public LocalInfoAdder (int i, ConvexResultCallback user)
		{
			m_userCallback = user;
			m_i = i;
		}
            
		public override float AddSingleResult(LocalConvexResult	r,	bool b)
		{
			LocalShapeInfo	shapeInfo = new LocalShapeInfo();
			shapeInfo.m_shapePart = -1;
			shapeInfo.m_triangleIndex = m_i;
			if (r.m_localShapeInfo == null)
			{
				r.m_localShapeInfo = shapeInfo;
			}
			return m_userCallback.AddSingleResult(r, b);
		}
	}
}