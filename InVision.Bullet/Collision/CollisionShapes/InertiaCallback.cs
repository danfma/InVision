using InVision.Bullet.LinearMath;
using InVision.GameMath;

namespace InVision.Bullet.Collision.CollisionShapes
{
	public class InertiaCallback: IInternalTriangleIndexCallback
	{
		public InertiaCallback(ref Vector3 center)
		{
			m_sum = new Matrix();
			m_center = center;
		}

		public virtual void InternalProcessTriangleIndex(ObjectArray<Vector3> triangle, int partId, int triangleIndex)
		{
			Matrix i = new Matrix();
			Vector3 a = triangle[0] - m_center;
			Vector3 b = triangle[1] - m_center;
			Vector3 c = triangle[2] - m_center;
			float volNeg = -System.Math.Abs(MathUtil.Vector3Triple(ref a,ref b,ref c) * (1f / 6f));
			for (int j = 0; j < 3; j++)
			{
				for (int k = 0; k <= j; k++)
				{
					float aj = MathUtil.VectorComponent(ref a,j);
					float ak = MathUtil.VectorComponent(ref a,k);
					float bj = MathUtil.VectorComponent(ref b,j);
					float bk = MathUtil.VectorComponent(ref b,k);
					float cj = MathUtil.VectorComponent(ref c,j);
					float ck = MathUtil.VectorComponent(ref c,k);

					float temp = volNeg * (.1f * (aj * ak + bj * bk + cj * ck)
					                       + .05f * (aj * bk + ak * bj + aj * ck + ak * cj + bj * ck + bk * cj));

					MathUtil.MatrixComponent(ref i,j,k,temp);
					MathUtil.MatrixComponent(ref i,k,j,temp);
				}
			}
			float i00 = -i.M11;
			float i11 = -i.M22;
			float i22 = -i.M33;
			i.M11 = i11 + i22; 
			i.M22 = i22 + i00; 
			i.M33 = i00 + i11;
			m_sum.Right += i.Right;
			m_sum.Up += i.Up;
			m_sum.Backward += i.Backward;
		}

		public Matrix GetInertia()
		{
			return m_sum;
		}

		public void Cleanup()
		{

		}

		Matrix m_sum;
		Vector3 m_center;
	}
}