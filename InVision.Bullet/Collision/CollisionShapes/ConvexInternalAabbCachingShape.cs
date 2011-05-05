using System.Collections.Generic;
using System.Diagnostics;
using InVision.Bullet.LinearMath;
using InVision.GameMath;

namespace InVision.Bullet.Collision.CollisionShapes
{
	public class ConvexInternalAabbCachingShape : ConvexInternalShape
	{
		protected Vector3 m_localAabbMin;
		protected Vector3 m_localAabbMax;
		protected bool m_isLocalAabbValid;


		protected void SetCachedLocalAabb(ref Vector3 aabbMin, ref Vector3 aabbMax)
		{
			m_isLocalAabbValid = true;
			m_localAabbMin = aabbMin;
			m_localAabbMax = aabbMax;
		}

		public void GetCachedLocalAabb(ref Vector3 aabbMin, ref Vector3 aabbMax)
		{
			Debug.Assert(m_isLocalAabbValid);
			aabbMin = m_localAabbMin;
			aabbMax = m_localAabbMax;
		}

		public void GetNonvirtualAabb(ref Matrix trans, ref Vector3 aabbMin, ref Vector3 aabbMax, float margin)
		{
			//lazy evaluation of local aabb
			Debug.Assert(m_isLocalAabbValid);
			AabbUtil2.TransformAabb(ref m_localAabbMin, ref m_localAabbMax, margin, ref trans, ref aabbMin, ref aabbMax);
		}

		public override Vector3 LocalGetSupportingVertexWithoutMargin(ref Vector3 vec)
		{
			return Vector3.Zero;
		}


		//public:

		//    virtual void	setLocalScaling(const btVector3& scaling);

		//    virtual void getAabb(const btTransform& t,btVector3& aabbMin,btVector3& aabbMax) const;

		//    void	recalcLocalAabb();


		public ConvexInternalAabbCachingShape()
		{
			m_localAabbMin = new Vector3(1, 1, 1);
			m_localAabbMax = new Vector3(-1, -1, -1);
			m_isLocalAabbValid = false;
		}

		public override void GetAabb(ref Matrix trans, ref Vector3 aabbMin, ref Vector3 aabbMax)
		{
			GetNonvirtualAabb(ref trans, ref aabbMin, ref aabbMax, Margin);
		}

		public override void SetLocalScaling(ref Vector3 scaling)
		{
			base.SetLocalScaling(ref scaling);
			RecalcLocalAabb();
		}

		public virtual void RecalcLocalAabb()
		{
			m_isLocalAabbValid = true;

#if true
			//fixme - make a static list.
			IList<Vector3> localDirections = new List<Vector3>();
			for (int i = 0; i < _directions.Length; ++i)
			{
				localDirections.Add(_directions[i]);
			}
			IList<Vector4> _supporting = new List<Vector4>();

			BatchedUnitVectorGetSupportingVertexWithoutMargin(localDirections, _supporting, 6);

			for (int i = 0; i < 3; ++i)
			{
				Vector4 temp = _supporting[i];
				MathUtil.VectorComponent(ref m_localAabbMax, i, (MathUtil.VectorComponent(ref temp, i) + m_collisionMargin));
				MathUtil.VectorComponent(ref m_localAabbMin, i, (MathUtil.VectorComponent(ref temp, i) - m_collisionMargin));
			}

#else

	        for (int i=0;i<3;i++)
	        {
		        btVector3 vec(btScalar(0.),btScalar(0.),btScalar(0.));
		        vec[i] = btScalar(1.);
		        btVector3 tmp = localGetSupportingVertex(vec);
		        m_localAabbMax[i] = tmp[i]+m_collisionMargin;
		        vec[i] = btScalar(-1.);
		        tmp = localGetSupportingVertex(vec);
		        m_localAabbMin[i] = tmp[i]-m_collisionMargin;
	        }
#endif
		}

		public override void BatchedUnitVectorGetSupportingVertexWithoutMargin(IList<Vector3> vectors, IList<Vector4> supportVerticesOut, int numVectors)
		{
		}


		public static Vector3[] _directions = new Vector3[]
		                                      	{
		                                      		new Vector3( 1.0f,  0.0f,  0.0f),
		                                      		new Vector3( 0.0f,  1.0f,  0.0f),
		                                      		new Vector3( 0.0f,  0.0f,  1.0f),
		                                      		new Vector3( -1.0f, 0.0f,  0.0f),
		                                      		new Vector3( 0.0f, -1.0f,  0.0f),
		                                      		new Vector3( 0.0f,  0.0f, -1.0f)
		                                      	};


	}
}