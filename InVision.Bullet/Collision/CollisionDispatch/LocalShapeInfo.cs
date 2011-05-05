namespace InVision.Bullet.Collision.CollisionDispatch
{
	///LocalShapeInfo gives extra information for complex shapes
	///Currently, only btTriangleMeshShape is available, so it just contains triangleIndex and subpart
	public class LocalShapeInfo
	{
		public int	m_shapePart;
		public int	m_triangleIndex;
		
		//const btCollisionShape*	m_shapeTemp;
		//const btTransform*	m_shapeLocalTransform;
	};
}