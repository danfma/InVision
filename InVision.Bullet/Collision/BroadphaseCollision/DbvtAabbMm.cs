using System.Collections.Generic;
using InVision.Bullet.LinearMath;
using InVision.GameMath;

namespace InVision.Bullet.Collision.BroadphaseCollision
{
	public struct DbvtAabbMm
	{
		public Vector3 Center() { return (_max + _min) / 2f; }
		public Vector3 Extent() { return (_max - _min) / 2f; }
		public Vector3 Mins() { return _min; }    // should be ref?
		public Vector3 Maxs() { return _max; }    // should be ref?
		public Vector3 Lengths() { return new Vector3(); }

		public static float Proximity(ref DbvtAabbMm a, ref DbvtAabbMm b)
		{
			Vector3 d = (a._min + a._max) - (b._min + b._max);
			return (System.Math.Abs(d.X) + System.Math.Abs(d.Y) + System.Math.Abs(d.Z));
		}


		public static DbvtAabbMm Merge(ref DbvtAabbMm a, ref DbvtAabbMm b)
		{
			DbvtAabbMm res = new DbvtAabbMm();
			Merge(ref a, ref b, ref res);
			return (res);
		}

		public static void Merge(ref DbvtAabbMm a, ref DbvtAabbMm b, ref DbvtAabbMm r)
		{
			//r = a;
			//SetMin(ref r._min, ref b._min);
			//SetMax(ref r._max, ref b._max);
			MathUtil.VectorMin(ref a._min, ref b._min, ref r._min);
			MathUtil.VectorMax(ref a._max, ref b._max, ref r._max);

		}

		public static bool NotEqual(ref DbvtAabbMm a, ref DbvtAabbMm b)
		{
			return ((a._min.X != b._min.X) ||
			        (a._min.Y != b._min.Y) ||
			        (a._min.Z != b._min.Z) ||
			        (a._max.X != b._max.X) ||
			        (a._max.Y != b._max.Y) ||
			        (a._max.Z != b._max.Z));

		}


		public static DbvtAabbMm FromCE(ref Vector3 c, ref Vector3 e)
		{
			DbvtAabbMm box;
			box._min = c - e; box._max = c + e;
			return (box);
		}
		public static DbvtAabbMm FromCR(ref Vector3 c, float r)
		{
			Vector3 temp = new Vector3(r, r, r);
			return (FromCE(ref c, ref temp));
		}
		public static DbvtAabbMm FromMM(ref Vector3 mi, ref Vector3 mx)
		{
			DbvtAabbMm box;
			box._min = mi; box._max = mx;
			return (box);
		}

		public static DbvtAabbMm FromPoints(List<Vector3> points)
		{
			DbvtAabbMm box;
			box._min = box._max = points[0];
			for (int i = 1; i < points.Count; ++i)
			{
				Vector3 temp = points[i];
				//SetMin(ref box._min, ref temp);
				//SetMax(ref box._max, ref temp);
				MathUtil.VectorMin(ref temp, ref box._min);
				MathUtil.VectorMax(ref temp, ref box._max);


			}
			return (box);
		}

		public static DbvtAabbMm FromPoints(List<List<Vector3>> points)
		{
			return new DbvtAabbMm();
		}

		public void Expand(Vector3 e)
		{
			_min -= e; _max += e;
		}

		public void SignedExpand(Vector3 e)
		{
			if (e.X > 0) _max.X = _max.X + e.X; else _min.X = _min.X + e.X;
			if (e.Y > 0) _max.Y = _max.Y + e.Y; else _min.Y = _min.Y + e.Y;
			if (e.Z > 0) _max.Z = _max.Z + e.Z; else _min.Z = _min.Z + e.Z;
		}
		public bool Contain(ref DbvtAabbMm a)
		{
			return ((_min.X <= a._min.X) &&
			        (_min.Y <= a._min.Y) &&
			        (_min.Z <= a._min.Z) &&
			        (_max.X >= a._max.X) &&
			        (_max.Y >= a._max.Y) &&
			        (_max.Z >= a._max.Z));
		}

		public static bool Intersect(ref DbvtAabbMm a, ref DbvtAabbMm b)
		{
			return ((a._min.X <= b._max.X) &&
			        (a._max.X >= b._min.X) &&
			        (a._min.Y <= b._max.Y) &&
			        (a._max.Y >= b._min.Y) &&
			        (a._min.Z <= b._max.Z) &&
			        (a._max.Z >= b._min.Z));
		}

		public static bool Intersect(DbvtAabbMm a, ref Vector3 b)
		{
			return ((b.X >= a._min.X) &&
			        (b.Y >= a._min.Y) &&
			        (b.Z >= a._min.Z) &&
			        (b.X <= a._max.X) &&
			        (b.Y <= a._max.Y) &&
			        (b.Z <= a._max.Z));
		}



		public int Classify(ref Vector3 n, float o, int s)
		{
			Vector3 pi, px;
			switch (s)
			{
				case (0 + 0 + 0):
					{
						px = new Vector3(_min.X, _min.Y, _min.Z);
						pi = new Vector3(_max.X, _max.Y, _max.Z);
						break;
					}
				case (1 + 0 + 0):
					{
						px = new Vector3(_max.X, _min.Y, _min.Z);
						pi = new Vector3(_min.X, _max.Y, _max.Z); break;
					}
				case (0 + 2 + 0):
					{
						px = new Vector3(_min.X, _max.Y, _min.Z);
						pi = new Vector3(_max.X, _min.Y, _max.Z); break;
					}
				case (1 + 2 + 0):
					{
						px = new Vector3(_max.X, _max.Y, _min.Z);
						pi = new Vector3(_min.X, _min.Y, _max.Z); break;
					}
				case (0 + 0 + 4):
					{
						px = new Vector3(_min.X, _min.Y, _max.Z);
						pi = new Vector3(_max.X, _max.Y, _min.Z); break;
					}
				case (1 + 0 + 4):
					{
						px = new Vector3(_max.X, _min.Y, _max.Z);
						pi = new Vector3(_min.X, _max.Y, _min.Z); break;
					}
				case (0 + 2 + 4):
					{
						px = new Vector3(_min.X, _max.Y, _max.Z);
						pi = new Vector3(_max.X, _min.Y, _min.Z); break;
					}
				case (1 + 2 + 4):
					{
						px = new Vector3(_max.X, _max.Y, _max.Z);
						pi = new Vector3(_min.X, _min.Y, _min.Z); break;
					}
				default:
					{
						px = new Vector3();
						pi = new Vector3();
						break;
					}
			}
			if ((Vector3.Dot(n, px) + o) < 0) return (-1);
			if ((Vector3.Dot(n, pi) + o) >= 0) return (+1);
			return (0);
		}

		public float ProjectMinimum(ref Vector3 v, uint signs)
		{
			Vector3[] b = { _max, _min };
			Vector3 p = new Vector3(b[(signs >> 0) & 1].X,
			                        b[(signs >> 1) & 1].Y,
			                        b[(signs >> 2) & 1].Z);
			return (Vector3.Dot(p, v));
		}


		public Vector3 _min;
		public Vector3 _max;
	}
}