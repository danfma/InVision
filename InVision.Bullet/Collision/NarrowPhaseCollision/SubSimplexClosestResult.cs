using System.Collections;
using InVision.GameMath;

namespace InVision.Bullet.Collision.NarrowPhaseCollision
{
	public class SubSimplexClosestResult
	{
		public Vector3 m_closestPointOnSimplex;
		//MASK for m_usedVertices
		//stores the simplex vertex-usage, using the MASK, 
		// if m_usedVertices & MASK then the related vertex is used
		public BitArray m_usedVertices = new BitArray(4);
		//public float[] m_barycentricCoords = new float[4];
		public Vector4 m_barycentricCoords = new Vector4();
		public bool m_degenerate;

		public void Reset()
		{
			m_degenerate = false;
			SetBarycentricCoordinates(0f, 0f, 0f, 0f);
			m_usedVertices.SetAll(false);
		}
		public bool IsValid()
		{
			bool valid = (m_barycentricCoords.X >= 0f) &&
			             (m_barycentricCoords.Y >= 0f) &&
			             (m_barycentricCoords.Z >= 0f) &&
			             (m_barycentricCoords.W >= 0f);
			return valid;
		}
		public void SetBarycentricCoordinates(float a, float b, float c, float d)
		{
			m_barycentricCoords.X = a;
			m_barycentricCoords.Y = b;
			m_barycentricCoords.Z = c;
			m_barycentricCoords.W = d;
		}
	}
}