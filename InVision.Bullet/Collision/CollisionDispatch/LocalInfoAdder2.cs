namespace InVision.Bullet.Collision.CollisionDispatch
{
	public class LocalInfoAdder2 : RayResultCallback 
	{
		public int m_i;
		public RayResultCallback m_userCallback;
		public LocalInfoAdder2 (int i, RayResultCallback user)
		{ 
			m_i = i;
			m_userCallback = user;
		}
	
		public override float AddSingleResult(LocalRayResult r, bool b)
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
		public virtual void cleanup()
		{
		}

	};
}