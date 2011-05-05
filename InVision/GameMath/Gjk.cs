namespace InVision.GameMath
{
	public class Gjk
	{
		private static readonly int[] BitsToIndices;

		private readonly float[][] det;
		private readonly float[][] edgeLengthSq;
		private readonly Vector3[][] edges;
		private readonly Vector3[] y;
		private readonly float[] yLengthSq;
		private Vector3 closestPoint;
		private float maxLengthSq;
		private int simplexBits;

		static Gjk()
		{
			BitsToIndices = new[] {
				0,
				1,
				2,
				17,
				3,
				25,
				26,
				209,
				4,
				33,
				34,
				273,
				35,
				281,
				282,
				2257
			};
		}

		public Gjk()
		{
			y = new Vector3[4];
			yLengthSq = new float[4];
			
			edges = new[] {
				new Vector3[4],
				new Vector3[4],
				new Vector3[4],
				new Vector3[4]
			};

			edgeLengthSq = new[] {
				new float[4],
				new float[4],
				new float[4],
				new float[4]
			};

			det = new float[16][];

			for (int i = 0; i < 16; i++)
			{
				det[i] = new float[4];
			}
		}

		public bool FullSimplex
		{
			get { return simplexBits == 15; }
		}

		public float MaxLengthSquared
		{
			get { return maxLengthSq; }
		}

		public Vector3 ClosestPoint
		{
			get { return closestPoint; }
		}

		public void Reset()
		{
			simplexBits = 0;
			maxLengthSq = 0f;
		}

		public bool AddSupportPoint(ref Vector3 newPoint)
		{
			int num = (BitsToIndices[simplexBits ^ 15] & 7) - 1;
			
			y[num] = newPoint;
			yLengthSq[num] = newPoint.LengthSquared();
			
			for (int num2 = BitsToIndices[simplexBits]; num2 != 0; num2 >>= 3)
			{
				int num3 = (num2 & 7) - 1;
				Vector3 vector = y[num3] - newPoint;
				edges[num3][num] = vector;
				edges[num][num3] = -vector;
				edgeLengthSq[num][num3] = (edgeLengthSq[num3][num] = vector.LengthSquared());
			}

			UpdateDeterminant(num);

			return UpdateSimplex(num);
		}

		private static float Dot(ref Vector3 a, ref Vector3 b)
		{
			return a.X * b.X + a.Y * b.Y + a.Z * b.Z;
		}

		private void UpdateDeterminant(int xmIdx)
		{
			int num = 1 << (xmIdx & 31);
			det[num][xmIdx] = 1f;
			
			int num2 = BitsToIndices[simplexBits];
			int num3 = num2;
			int num4 = 0;

			while (num3 != 0)
			{
				int num5 = (num3 & 7) - 1;
				int num6 = 1 << (num5 & 31);
				int num7 = num6 | num;

				det[num7][num5] = Dot(ref edges[xmIdx][num5], ref y[xmIdx]);
				det[num7][xmIdx] = Dot(ref edges[num5][xmIdx], ref y[num5]);
				
				int num8 = num2;
				
				for (int i = 0; i < num4; i++)
				{
					int num9 = (num8 & 7) - 1;
					int num10 = 1 << (num9 & 31);
					int num11 = num7 | num10;
					int num12 = (edgeLengthSq[num5][num9] < edgeLengthSq[xmIdx][num9]) ? num5 : xmIdx;

					det[num11][num9] = det[num7][num5] * Dot(ref edges[num12][num9], ref y[num5]) +
									   det[num7][xmIdx] * Dot(ref edges[num12][num9], ref y[xmIdx]);
					num12 = ((edgeLengthSq[num9][num5] < edgeLengthSq[xmIdx][num5]) ? num9 : xmIdx);
					det[num11][num5] = det[num10 | num][num9] * Dot(ref edges[num12][num5], ref y[num9]) +
									   det[num10 | num][xmIdx] * Dot(ref edges[num12][num5], ref y[xmIdx]);
					num12 = ((edgeLengthSq[num5][xmIdx] < edgeLengthSq[num9][xmIdx]) ? num5 : num9);
					det[num11][xmIdx] = det[num6 | num10][num9] * Dot(ref edges[num12][xmIdx], ref y[num9]) +
										det[num6 | num10][num5] * Dot(ref edges[num12][xmIdx], ref y[num5]);
					num8 >>= 3;
				}
				num3 >>= 3;
				num4++;
			}
			if ((simplexBits | num) == 15)
			{
				int num13 = (edgeLengthSq[1][0] < edgeLengthSq[2][0])
								? ((edgeLengthSq[1][0] < edgeLengthSq[3][0]) ? 1 : 3)
								: ((edgeLengthSq[2][0] < edgeLengthSq[3][0]) ? 2 : 3);
				det[15][0] = det[14][1] * Dot(ref edges[num13][0], ref y[1]) + det[14][2] * Dot(ref edges[num13][0], ref y[2]) +
							 det[14][3] * Dot(ref edges[num13][0], ref y[3]);
				num13 = ((edgeLengthSq[0][1] < edgeLengthSq[2][1])
							? ((edgeLengthSq[0][1] < edgeLengthSq[3][1]) ? 0 : 3)
							: ((edgeLengthSq[2][1] < edgeLengthSq[3][1]) ? 2 : 3));
				det[15][1] = det[13][0] * Dot(ref edges[num13][1], ref y[0]) + det[13][2] * Dot(ref edges[num13][1], ref y[2]) +
							 det[13][3] * Dot(ref edges[num13][1], ref y[3]);
				num13 = ((edgeLengthSq[0][2] < edgeLengthSq[1][2])
							? ((edgeLengthSq[0][2] < edgeLengthSq[3][2]) ? 0 : 3)
							: ((edgeLengthSq[1][2] < edgeLengthSq[3][2]) ? 1 : 3));
				det[15][2] = det[11][0] * Dot(ref edges[num13][2], ref y[0]) + det[11][1] * Dot(ref edges[num13][2], ref y[1]) +
							 det[11][3] * Dot(ref edges[num13][2], ref y[3]);
				num13 = ((edgeLengthSq[0][3] < edgeLengthSq[1][3])
							? ((edgeLengthSq[0][3] < edgeLengthSq[2][3]) ? 0 : 2)
							: ((edgeLengthSq[1][3] < edgeLengthSq[2][3]) ? 1 : 2));
				det[15][3] = det[7][0] * Dot(ref edges[num13][3], ref y[0]) + det[7][1] * Dot(ref edges[num13][3], ref y[1]) +
							 det[7][2] * Dot(ref edges[num13][3], ref y[2]);
			}
		}

		private bool UpdateSimplex(int newIndex)
		{
			int num = simplexBits | 1 << (newIndex & 31);
			int num2 = 1 << (newIndex & 31);
			for (int num3 = simplexBits; num3 != 0; num3--)
			{
				if ((num3 & num) == num3 && IsSatisfiedRule(num3 | num2, num))
				{
					simplexBits = (num3 | num2);
					closestPoint = ComputeClosestPoint();
					return true;
				}
			}
			bool result = false;
			if (IsSatisfiedRule(num2, num))
			{
				simplexBits = num2;
				closestPoint = y[newIndex];
				maxLengthSq = yLengthSq[newIndex];
				result = true;
			}
			return result;
		}

		private Vector3 ComputeClosestPoint()
		{
			float num = 0f;
			Vector3 vector = Vector3.Zero;
			maxLengthSq = 0f;
			for (int num2 = BitsToIndices[simplexBits]; num2 != 0; num2 >>= 3)
			{
				int num3 = (num2 & 7) - 1;
				float num4 = det[simplexBits][num3];
				num += num4;
				vector += y[num3] * num4;
				maxLengthSq = MathHelper.Max(maxLengthSq, yLengthSq[num3]);
			}
			return vector / num;
		}

		private bool IsSatisfiedRule(int xBits, int yBits)
		{
			bool result = true;
			for (int num = BitsToIndices[yBits]; num != 0; num >>= 3)
			{
				int num2 = (num & 7) - 1;
				int num3 = 1 << (num2 & 31);
				if ((num3 & xBits) != 0)
				{
					if (det[xBits][num2] <= 0f)
					{
						result = false;
						break;
					}
				}
				else
				{
					if (det[xBits | num3][num2] > 0f)
					{
						result = false;
						break;
					}
				}
			}
			return result;
		}
	}
}