using InVision.Bullet.Collision.CollisionShapes;
using InVision.GameMath;

namespace InVision.Bullet.Collision.NarrowPhaseCollision
{
	public class GjkEpaSolver2MinkowskiDiff
	{
		public GjkEpaSolver2MinkowskiDiff()
		{
		}

		public void EnableMargin(bool enable)
		{
			m_enableMargin = enable;
		}	
		public Vector3 Support0(ref Vector3 d)
		{
			if(m_enableMargin)
			{
				return m_shapes[0].LocalGetSupportVertexNonVirtual(ref d);
			}
			return m_shapes[0].LocalGetSupportVertexWithoutMarginNonVirtual(ref d);
		}

		public Vector3 Support1(ref Vector3 d)
		{
			Vector3 dcopy = Vector3.TransformNormal(d, m_toshape1);
			Vector3 temp = m_enableMargin?m_shapes[1].LocalGetSupportVertexNonVirtual(ref dcopy) :
			                                                                                     	m_shapes[1].LocalGetSupportVertexWithoutMarginNonVirtual(ref dcopy);

			return Vector3.Transform(temp,m_toshape0);
		}

		public Vector3 Support(ref Vector3 d)
		{
			Vector3 minusD = -d;
			return(Support0(ref d)-Support1(ref minusD));
		}
        
		public Vector3	Support(ref Vector3 d,uint index)
		{
			if(index > 0)
				return(Support1(ref d));
			else
				return(Support0(ref d));
		}

		public bool m_enableMargin;
		public ConvexShape[] m_shapes = new ConvexShape[2];
		public Matrix m_toshape1 = Matrix.Identity;
		public Matrix m_toshape0 = Matrix.Identity;

	}
}