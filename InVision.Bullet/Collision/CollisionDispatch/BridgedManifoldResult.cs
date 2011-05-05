using InVision.Bullet.Collision.NarrowPhaseCollision;
using InVision.Bullet.LinearMath;
using InVision.GameMath;

namespace InVision.Bullet.Collision.CollisionDispatch
{
	public class BridgedManifoldResult : ManifoldResult
	{
		ContactResultCallback	m_resultCallback;

		public BridgedManifoldResult(CollisionObject obj0,CollisionObject obj1,ContactResultCallback resultCallback)
			:base(obj0,obj1)
		{
			m_resultCallback = resultCallback;
		}

		public override void AddContactPoint(ref Vector3 normalOnBInWorld,ref Vector3 pointInWorld,float depth)
		{
			bool isSwapped = m_manifoldPtr.GetBody0() != m_body0;
			Vector3 pointA = pointInWorld + normalOnBInWorld * depth;
			Vector3 localA = Vector3.Zero;
			Vector3 localB = Vector3.Zero;;
			if (isSwapped)
			{
				localA = MathUtil.InverseTransform(ref m_rootTransB,ref pointA );
				localB = MathUtil.InverseTransform(ref m_rootTransA,ref pointInWorld);
			} 
			else
			{
				localA = MathUtil.InverseTransform(ref m_rootTransA,ref pointA );
				localB = MathUtil.InverseTransform(ref m_rootTransB,ref pointInWorld);
			}
    		
			ManifoldPoint newPt = new ManifoldPoint(ref localA,ref localB,ref normalOnBInWorld,depth);
			newPt.m_positionWorldOnA = pointA;
			newPt.m_positionWorldOnB = pointInWorld;
    		
			//BP mod, store contact triangles.
			if (isSwapped)
			{
				newPt.m_partId0 = m_partId1;
				newPt.m_partId1 = m_partId0;
				newPt.m_index0  = m_index1;
				newPt.m_index1  = m_index0;
			} 
			else
			{
				newPt.m_partId0 = m_partId0;
				newPt.m_partId1 = m_partId1;
				newPt.m_index0  = m_index0;
				newPt.m_index1  = m_index1;
			}

			//experimental feature info, for per-triangle material etc.
			CollisionObject obj0 = isSwapped? m_body1 : m_body0;
			CollisionObject obj1 = isSwapped? m_body0 : m_body1;
			m_resultCallback.AddSingleResult(newPt,obj0,newPt.m_partId0,newPt.m_index0,obj1,newPt.m_partId1,newPt.m_index1);
		}
	}
}