using System.Collections.Generic;
using System.Diagnostics;
using InVision.Bullet.LinearMath;
using InVision.GameMath;

namespace InVision.Bullet.Collision.CollisionShapes
{
	public abstract class PolyhedralConvexAabbCachingShape : PolyhedralConvexShape
	{
		public PolyhedralConvexAabbCachingShape()
		{
			m_localAabbMin = new Vector3(1, 1, 1);
			m_localAabbMax = new Vector3(-1, -1, -1);
			m_isLocalAabbValid = false;
			//m_optionalHull = null;
		}

		protected void SetCachedLocalAabb(ref Vector3 aabbMin, ref Vector3 aabbMax)
		{
			m_isLocalAabbValid = true;
			m_localAabbMin = aabbMin;
			m_localAabbMax = aabbMax;
		}

		protected void GetCachedLocalAabb(ref Vector3 aabbMin, ref Vector3 aabbMax)
		{
			Debug.Assert(m_isLocalAabbValid);
			aabbMin = m_localAabbMin;
			aabbMax = m_localAabbMax;
		}

		public void GetNonvirtualAabb(ref Matrix trans, ref Vector3 aabbMin, ref Vector3 aabbMax, float margin)
		{
			//lazy evaluation of local aabb
			Debug.Assert(m_isLocalAabbValid);
			MathUtil.TransformAabb(ref m_localAabbMin, ref m_localAabbMax, margin, ref trans, ref aabbMin, ref aabbMax);
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

		public void RecalcLocalAabb()
		{
			m_isLocalAabbValid = true;

#if TRUE
			IList<Vector3> _directions = new List<Vector3>();
			_directions.Add(Vector3.Right);
			_directions.Add(Vector3.Up);
			_directions.Add(Vector3.Backward);
			_directions.Add(Vector3.Left);
			_directions.Add(Vector3.Down);
			_directions.Add(Vector3.Forward);

			IList<Vector4> _supporting = new List<Vector4>();
			_supporting.Add(new Vector4());
			_supporting.Add(new Vector4());
			_supporting.Add(new Vector4());
			_supporting.Add(new Vector4());
			_supporting.Add(new Vector4());
			_supporting.Add(new Vector4());

			BatchedUnitVectorGetSupportingVertexWithoutMargin(_directions, _supporting, 6);

			for (int i = 0; i < 3; ++i)
			{
				Vector4 temp = _supporting[i];
				MathUtil.VectorComponent(ref m_localAabbMax, i, (MathUtil.VectorComponent(ref temp, i) + m_collisionMargin));
				temp = _supporting[i + 3];
				MathUtil.VectorComponent(ref m_localAabbMin, i, (MathUtil.VectorComponent(ref temp, i) - m_collisionMargin));
			}
			int ibreak = 0;
#else

	        for (int i=0;i<3;i++)
	        {
		        Vector3 vec = new Vector3();
		        MathUtil.VectorComponent(ref vec,i,1f);
		        Vector3 tmp = LocalGetSupportingVertex(ref vec);
                MathUtil.VectorComponent(ref m_localAabbMax,i,(MathUtil.VectorComponent(ref tmp,i) + m_collisionMargin));

                MathUtil.VectorComponent(ref vec,i,-1f);
		        tmp = LocalGetSupportingVertex(ref vec);
                MathUtil.VectorComponent(ref m_localAabbMin,i,(MathUtil.VectorComponent(ref tmp,i) - m_collisionMargin));

	        }
#endif

		}
		protected Vector3 m_localAabbMin;
		protected Vector3 m_localAabbMax;
		protected bool m_isLocalAabbValid;

	}
}