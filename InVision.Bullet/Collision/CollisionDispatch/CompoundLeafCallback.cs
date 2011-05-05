using System.Collections.Generic;
using InVision.Bullet.Collision.BroadphaseCollision;
using InVision.Bullet.Collision.CollisionShapes;
using InVision.Bullet.Collision.NarrowPhaseCollision;
using InVision.Bullet.Debuging;
using InVision.Bullet.LinearMath;
using InVision.GameMath;

namespace InVision.Bullet.Collision.CollisionDispatch
{
	public class CompoundLeafCallback : Collide
	{
		public CollisionObject m_compoundColObj;
		public CollisionObject m_otherObj;
		public IDispatcher m_dispatcher;
		public DispatcherInfo m_dispatchInfo;
		public ManifoldResult	m_resultOut;
		public IList<CollisionAlgorithm>	m_childCollisionAlgorithms;
		public PersistentManifold	m_sharedManifold;

		public CompoundLeafCallback (CollisionObject compoundObj,CollisionObject otherObj,IDispatcher dispatcher,DispatcherInfo dispatchInfo,ManifoldResult resultOut,IList<CollisionAlgorithm> childCollisionAlgorithms,PersistentManifold sharedManifold)
		{
			m_compoundColObj = compoundObj;
			m_otherObj = otherObj;
			m_dispatcher = dispatcher;
			m_dispatchInfo = dispatchInfo;
			m_resultOut = resultOut;
			m_childCollisionAlgorithms = childCollisionAlgorithms;
			m_sharedManifold = sharedManifold;
		}

		public void ProcessChildShape(CollisionShape childShape,int index)
		{
			CompoundShape compoundShape = (CompoundShape)(m_compoundColObj.GetCollisionShape());


			//backup
			Matrix orgTrans = m_compoundColObj.GetWorldTransform();
			Matrix orgInterpolationTrans = m_compoundColObj.GetInterpolationWorldTransform();
			Matrix childTrans = compoundShape.GetChildTransform(index);
			Matrix	newChildWorldTrans = MathUtil.BulletMatrixMultiply(ref orgTrans,ref childTrans);

			//perform an AABB check first
			Vector3 aabbMin0 = Vector3.Zero;
			Vector3 aabbMax0 = Vector3.Zero;
			Vector3 aabbMin1 = Vector3.Zero;
			Vector3 aabbMax1 = Vector3.Zero;

			childShape.GetAabb(ref newChildWorldTrans,ref aabbMin0,ref aabbMax0);
			m_otherObj.GetCollisionShape().GetAabb(m_otherObj.GetWorldTransform(),ref aabbMin1,ref aabbMax1);

			if (AabbUtil2.TestAabbAgainstAabb2(ref aabbMin0,ref aabbMax0,ref aabbMin1,ref aabbMax1))
			{
				m_compoundColObj.SetWorldTransform(ref newChildWorldTrans);
				m_compoundColObj.SetInterpolationWorldTransform(ref newChildWorldTrans);

				//the contactpoint is still projected back using the original inverted worldtrans
				CollisionShape tmpShape = m_compoundColObj.GetCollisionShape();
				m_compoundColObj.InternalSetTemporaryCollisionShape( childShape );

				if (m_childCollisionAlgorithms[index] == null)
				{
					m_childCollisionAlgorithms[index] = m_dispatcher.FindAlgorithm(m_compoundColObj,m_otherObj,m_sharedManifold);
				}

				///detect swapping case
				if (m_resultOut.GetBody0Internal() == m_compoundColObj)
				{
					m_resultOut.SetShapeIdentifiersA(-1, index);
				}
				else
				{
					m_resultOut.SetShapeIdentifiersB(-1, index);
				}


				m_childCollisionAlgorithms[index].ProcessCollision(m_compoundColObj,m_otherObj,m_dispatchInfo, m_resultOut);
				if (m_dispatchInfo.getDebugDraw() != null && (((m_dispatchInfo.getDebugDraw().GetDebugMode() & DebugDrawModes.DBG_DrawAabb)) != 0))
				{
					Vector3 worldAabbMin = Vector3.Zero, worldAabbMax = Vector3.Zero;
					m_dispatchInfo.getDebugDraw().DrawAabb(aabbMin0, aabbMax0, new Vector3(1, 1, 1));
					m_dispatchInfo.getDebugDraw().DrawAabb(aabbMin1, aabbMax1, new Vector3(1, 1, 1));
				}
    			
				//revert back transform 
				m_compoundColObj.InternalSetTemporaryCollisionShape( tmpShape);
				m_compoundColObj.SetWorldTransform( ref orgTrans );
				m_compoundColObj.SetInterpolationWorldTransform(ref orgInterpolationTrans);
			}
		}

		public override void Process(DbvtNode leaf)
		{
			int index = leaf.dataAsInt;

			CompoundShape compoundShape = (CompoundShape)(m_compoundColObj.GetCollisionShape());
			CollisionShape childShape = compoundShape.GetChildShape(index);
			if (m_dispatchInfo.getDebugDraw() != null && (((m_dispatchInfo.getDebugDraw().GetDebugMode() & DebugDrawModes.DBG_DrawAabb)) != 0))
			{
				Vector3 worldAabbMin = Vector3.Zero;
				Vector3 worldAabbMax = Vector3.Zero;
				Matrix orgTrans = m_compoundColObj.GetWorldTransform();
				MathUtil.TransformAabb(leaf.volume.Mins(),leaf.volume.Maxs(),0f,orgTrans,ref worldAabbMin,ref worldAabbMax);
				m_dispatchInfo.getDebugDraw().DrawAabb(worldAabbMin, worldAabbMax, new Vector3(1, 0, 0));
			}
			ProcessChildShape(childShape,index);
		}
	}
}