using System.Collections.Generic;
using InVision.GameMath;

namespace InVision.Bullet.Collision.CollisionShapes
{
	public class CylinderShapeX : CylinderShape
	{
		public CylinderShapeX(Vector3 halfExtents)
			: this(ref halfExtents)
		{ }

		public CylinderShapeX(ref Vector3 halfExtents)
			: base(ref halfExtents)
		{
			m_upAxis = 0;
		}

		public override Vector3 LocalGetSupportingVertexWithoutMargin(ref Vector3 vec)
		{
			return CylinderLocalSupportX(GetHalfExtentsWithoutMargin(), vec);
		}

		public override void BatchedUnitVectorGetSupportingVertexWithoutMargin(IList<Vector3> vectors, IList<Vector4> supportVerticesOut, int numVectors)
		{
			Vector3 halfExtents = GetHalfExtentsWithoutMargin();
			for (int i = 0; i < numVectors; i++)
			{
				supportVerticesOut[i] = new Vector4(CylinderLocalSupportX(halfExtents, vectors[i]), 0);
			}
		}

		//debugging

		public override string Name
		{
			get { return "CylinderX"; }
		}

		public override float GetRadius()
		{
			return GetHalfExtentsWithMargin().Y;
		}

	}
}