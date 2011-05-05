// 
// BoundingFrustum.cs
//  
// Author:
//       Michael Hutchinson <mhutchinson@novell.com>
// 
// Copyright (c) 2010 Novell, Inc.
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;

namespace InVision.GameMath
{
	[Serializable]
	public class BoundingFrustum : IEquatable<BoundingFrustum>
	{
		public const int CornerCount = 8;
		private const int NearPlaneIndex = 0;
		private const int FarPlaneIndex = 1;
		private const int LeftPlaneIndex = 2;
		private const int RightPlaneIndex = 3;
		private const int TopPlaneIndex = 4;
		private const int BottomPlaneIndex = 5;
		private const int NumPlanes = 6;
		private readonly Plane[] planes = new Plane[6];
		internal Vector3[] cornerArray = new Vector3[8];
		private Gjk gjk;
		private Matrix matrix;

		private BoundingFrustum()
		{
		}

		public BoundingFrustum(Matrix value)
		{
			SetMatrix(ref value);
		}

		public Plane Near
		{
			get { return planes[0]; }
		}

		public Plane Far
		{
			get { return planes[1]; }
		}

		public Plane Left
		{
			get { return planes[2]; }
		}

		public Plane Right
		{
			get { return planes[3]; }
		}

		public Plane Top
		{
			get { return planes[4]; }
		}

		public Plane Bottom
		{
			get { return planes[5]; }
		}

		public Matrix Matrix
		{
			get { return matrix; }
			set { SetMatrix(ref value); }
		}

		#region IEquatable<BoundingFrustum> Members

		public bool Equals(BoundingFrustum other)
		{
			return !(other == null) && matrix == other.matrix;
		}

		#endregion

		public Vector3[] GetCorners()
		{
			return (Vector3[]) cornerArray.Clone();
		}

		public void GetCorners(Vector3[] corners)
		{
			if (corners == null)
			{
				throw new ArgumentNullException("corners");
			}
			if (corners.Length < 8)
			{
				throw new ArgumentOutOfRangeException("corners");
			}
			cornerArray.CopyTo(corners, 0);
		}

		public override bool Equals(object obj)
		{
			bool result = false;
			var boundingFrustum = obj as BoundingFrustum;
			if (boundingFrustum != null)
			{
				result = (matrix == boundingFrustum.matrix);
			}
			return result;
		}

		public override int GetHashCode()
		{
			return matrix.GetHashCode();
		}

		public override string ToString()
		{
			return string.Format("{{Near:{0} Far:{1} Left:{2} Right:{3} Top:{4} Bottom:{5}}}",
			                     Near, Far, Left, Right, Top, Bottom);
		}

		private void SetMatrix(ref Matrix value)
		{
			matrix = value;
			planes[2].Normal.X = -value.M14 - value.M11;
			planes[2].Normal.Y = -value.M24 - value.M21;
			planes[2].Normal.Z = -value.M34 - value.M31;
			planes[2].D = -value.M44 - value.M41;
			planes[3].Normal.X = -value.M14 + value.M11;
			planes[3].Normal.Y = -value.M24 + value.M21;
			planes[3].Normal.Z = -value.M34 + value.M31;
			planes[3].D = -value.M44 + value.M41;
			planes[4].Normal.X = -value.M14 + value.M12;
			planes[4].Normal.Y = -value.M24 + value.M22;
			planes[4].Normal.Z = -value.M34 + value.M32;
			planes[4].D = -value.M44 + value.M42;
			planes[5].Normal.X = -value.M14 - value.M12;
			planes[5].Normal.Y = -value.M24 - value.M22;
			planes[5].Normal.Z = -value.M34 - value.M32;
			planes[5].D = -value.M44 - value.M42;
			planes[0].Normal.X = -value.M13;
			planes[0].Normal.Y = -value.M23;
			planes[0].Normal.Z = -value.M33;
			planes[0].D = -value.M43;
			planes[1].Normal.X = -value.M14 + value.M13;
			planes[1].Normal.Y = -value.M24 + value.M23;
			planes[1].Normal.Z = -value.M34 + value.M33;
			planes[1].D = -value.M44 + value.M43;

			for (int i = 0; i < 6; i++)
			{
				float num = planes[i].Normal.Length();
				planes[i].Normal = planes[i].Normal/num;
				planes[i].D = planes[i].D/num;
			}

			Ray ray = ComputeIntersectionLine(ref planes[0], ref planes[2]);
			cornerArray[0] = ComputeIntersection(ref planes[4], ref ray);
			cornerArray[3] = ComputeIntersection(ref planes[5], ref ray);
			ray = ComputeIntersectionLine(ref planes[3], ref planes[0]);
			cornerArray[1] = ComputeIntersection(ref planes[4], ref ray);
			cornerArray[2] = ComputeIntersection(ref planes[5], ref ray);
			ray = ComputeIntersectionLine(ref planes[2], ref planes[1]);
			cornerArray[4] = ComputeIntersection(ref planes[4], ref ray);
			cornerArray[7] = ComputeIntersection(ref planes[5], ref ray);
			ray = ComputeIntersectionLine(ref planes[1], ref planes[3]);
			cornerArray[5] = ComputeIntersection(ref planes[4], ref ray);
			cornerArray[6] = ComputeIntersection(ref planes[5], ref ray);
		}

		private static Ray ComputeIntersectionLine(ref Plane p1, ref Plane p2)
		{
			Ray result = default(Ray);
			result.Direction = Vector3.Cross(p1.Normal, p2.Normal);
			float divider = result.Direction.LengthSquared();
			result.Position = Vector3.Cross(-p1.D*p2.Normal + p2.D*p1.Normal, result.Direction)/divider;
			return result;
		}

		private static Vector3 ComputeIntersection(ref Plane plane, ref Ray ray)
		{
			float scaleFactor = (-plane.D - Vector3.Dot(plane.Normal, ray.Position))/Vector3.Dot(plane.Normal, ray.Direction);
			return ray.Position + ray.Direction*scaleFactor;
		}

		public bool Intersects(BoundingBox box)
		{
			bool result;
			Intersects(ref box, out result);
			return result;
		}

		public void Intersects(ref BoundingBox box, out bool result)
		{
			if (gjk == null)
			{
				gjk = new Gjk();
			}
			gjk.Reset();
			Vector3 closestPoint;
			Vector3.Subtract(ref cornerArray[0], ref box.Min, out closestPoint);
			if (closestPoint.LengthSquared() < 1E-05f)
			{
				Vector3.Subtract(ref cornerArray[0], ref box.Max, out closestPoint);
			}
			float num = 3.40282347E+38f;
			result = false;
			while (true)
			{
				Vector3 vector = default(Vector3);
				vector.X = -closestPoint.X;
				vector.Y = -closestPoint.Y;
				vector.Z = -closestPoint.Z;
				Vector3 vector2;
				SupportMapping(ref vector, out vector2);
				Vector3 vector3;
				box.SupportMapping(ref closestPoint, out vector3);
				Vector3 vector4;
				Vector3.Subtract(ref vector2, ref vector3, out vector4);
				float num2 = closestPoint.X*vector4.X + closestPoint.Y*vector4.Y + closestPoint.Z*vector4.Z;
				if (num2 > 0f)
				{
					break;
				}
				gjk.AddSupportPoint(ref vector4);
				closestPoint = gjk.ClosestPoint;
				float num3 = num;
				num = closestPoint.LengthSquared();
				if (num3 - num <= 1E-05f*num3)
				{
					return;
				}
				float num4 = 4E-05f*gjk.MaxLengthSquared;
				if (gjk.FullSimplex || num < num4)
				{
					result = true;
					return;
				}
			}

			return;
		}

		public bool Intersects(BoundingFrustum frustum)
		{
			if (frustum == null)
			{
				throw new ArgumentNullException("frustum");
			}
			if (gjk == null)
			{
				gjk = new Gjk();
			}
			gjk.Reset();
			Vector3 closestPoint;
			Vector3.Subtract(ref cornerArray[0], ref frustum.cornerArray[0], out closestPoint);
			if (closestPoint.LengthSquared() < 1E-05f)
			{
				Vector3.Subtract(ref cornerArray[0], ref frustum.cornerArray[1], out closestPoint);
			}
			float num = 3.40282347E+38f;
			while (true)
			{
				Vector3 vector = default(Vector3);
				vector.X = -closestPoint.X;
				vector.Y = -closestPoint.Y;
				vector.Z = -closestPoint.Z;
				Vector3 vector2;
				SupportMapping(ref vector, out vector2);
				Vector3 vector3;
				frustum.SupportMapping(ref closestPoint, out vector3);
				Vector3 vector4;
				Vector3.Subtract(ref vector2, ref vector3, out vector4);
				float num2 = closestPoint.X*vector4.X + closestPoint.Y*vector4.Y + closestPoint.Z*vector4.Z;
				if (num2 > 0f)
				{
					break;
				}
				gjk.AddSupportPoint(ref vector4);
				closestPoint = gjk.ClosestPoint;
				float num3 = num;
				num = closestPoint.LengthSquared();
				float num4 = 4E-05f*gjk.MaxLengthSquared;
				if (num3 - num <= 1E-05f*num3)
				{
					return false;
				}
				if (gjk.FullSimplex || num < num4)
				{
					return true;
				}
			}
			return false;
		}

		public PlaneIntersectionType Intersects(Plane plane)
		{
			int num = 0;
			for (int i = 0; i < 8; i++)
			{
				float num2;
				Vector3.Dot(ref cornerArray[i], ref plane.Normal, out num2);
				if (num2 + plane.D > 0f)
				{
					num |= 1;
				}
				else
				{
					num |= 2;
				}
				if (num == 3)
				{
					return PlaneIntersectionType.Intersecting;
				}
			}
			if (num != 1)
			{
				return PlaneIntersectionType.Back;
			}
			return PlaneIntersectionType.Front;
		}

		public void Intersects(ref Plane plane, out PlaneIntersectionType result)
		{
			int num = 0;
			for (int i = 0; i < 8; i++)
			{
				float num2;
				Vector3.Dot(ref cornerArray[i], ref plane.Normal, out num2);
				if (num2 + plane.D > 0f)
				{
					num |= 1;
				}
				else
				{
					num |= 2;
				}
				if (num == 3)
				{
					result = PlaneIntersectionType.Intersecting;
					return;
				}
			}
			result = ((num == 1) ? PlaneIntersectionType.Front : PlaneIntersectionType.Back);
		}

		public float? Intersects(Ray ray)
		{
			float? result;
			Intersects(ref ray, out result);
			return result;
		}

		public void Intersects(ref Ray ray, out float? result)
		{
			ContainmentType containmentType;
			Contains(ref ray.Position, out containmentType);
			if (containmentType == ContainmentType.Contains)
			{
				result = 0f;
				return;
			}
			float num = -3.40282347E+38f;
			float num2 = 3.40282347E+38f;
			result = null;
			Plane[] array = planes;
			int i = 0;
			while (i < array.Length)
			{
				Plane plane = array[i];
				Vector3 normal = plane.Normal;
				float num3;
				Vector3.Dot(ref ray.Direction, ref normal, out num3);
				float num4;
				Vector3.Dot(ref ray.Position, ref normal, out num4);
				num4 += plane.D;
				if (Math.Abs(num3) < 1E-05f)
				{
					if (num4 > 0f)
					{
						return;
					}
				}
				else
				{
					float num5 = -num4/num3;
					if (num3 < 0f)
					{
						if (num5 > num2)
						{
							return;
						}
						if (num5 > num)
						{
							num = num5;
						}
					}
					else
					{
						if (num5 < num)
						{
							return;
						}
						if (num5 < num2)
						{
							num2 = num5;
						}
					}
				}
				i++;
				continue;
			}
			float num6 = (num >= 0f) ? num : num2;
			if (num6 >= 0f)
			{
				result = num6;
				return;
			}
		}

		public bool Intersects(BoundingSphere sphere)
		{
			bool result;
			Intersects(ref sphere, out result);
			return result;
		}

		public void Intersects(ref BoundingSphere sphere, out bool result)
		{
			if (gjk == null)
			{
				gjk = new Gjk();
			}
			gjk.Reset();
			Vector3 vector;
			Vector3.Subtract(ref cornerArray[0], ref sphere.Center, out vector);
			if (vector.LengthSquared() < 1E-05f)
			{
				vector = Vector3.UnitX;
			}
			float num = 3.40282347E+38f;
			result = false;
			while (true)
			{
				Vector3 vector2 = default(Vector3);
				vector2.X = -vector.X;
				vector2.Y = -vector.Y;
				vector2.Z = -vector.Z;
				Vector3 vector3;
				SupportMapping(ref vector2, out vector3);
				Vector3 vector4;
				sphere.SupportMapping(ref vector, out vector4);
				Vector3 vector5;
				Vector3.Subtract(ref vector3, ref vector4, out vector5);
				float num2 = vector.X*vector5.X + vector.Y*vector5.Y + vector.Z*vector5.Z;
				if (num2 > 0f)
				{
					break;
				}
				gjk.AddSupportPoint(ref vector5);
				vector = gjk.ClosestPoint;
				float num3 = num;
				num = vector.LengthSquared();
				if (num3 - num <= 1E-05f*num3)
				{
					return;
				}
				float num4 = 4E-05f*gjk.MaxLengthSquared;
				if (gjk.FullSimplex || num < num4)
				{
					result = true;
					return;
				}
			}
		}

		public ContainmentType Contains(BoundingBox box)
		{
			bool flag = false;
			Plane[] array = planes;
			for (int i = 0; i < array.Length; i++)
			{
				Plane plane = array[i];
				PlaneIntersectionType planeIntersectionType = box.Intersects(plane);
				if (planeIntersectionType == PlaneIntersectionType.Front)
				{
					return ContainmentType.Disjoint;
				}
				if (planeIntersectionType == PlaneIntersectionType.Intersecting)
				{
					flag = true;
				}
			}
			if (!flag)
			{
				return ContainmentType.Contains;
			}
			return ContainmentType.Intersects;
		}

		public void Contains(ref BoundingBox box, out ContainmentType result)
		{
			bool flag = false;
			Plane[] array = planes;
			for (int i = 0; i < array.Length; i++)
			{
				Plane plane = array[i];
				PlaneIntersectionType planeIntersectionType = box.Intersects(plane);
				if (planeIntersectionType == PlaneIntersectionType.Front)
				{
					result = ContainmentType.Disjoint;
					return;
				}
				if (planeIntersectionType == PlaneIntersectionType.Intersecting)
				{
					flag = true;
				}
			}
			result = (flag ? ContainmentType.Intersects : ContainmentType.Contains);
		}

		public ContainmentType Contains(BoundingFrustum frustum)
		{
			if (frustum == null)
			{
				throw new ArgumentNullException("frustum");
			}
			ContainmentType result = ContainmentType.Disjoint;
			if (Intersects(frustum))
			{
				result = ContainmentType.Contains;
				for (int i = 0; i < cornerArray.Length; i++)
				{
					if (Contains(frustum.cornerArray[i]) == ContainmentType.Disjoint)
					{
						result = ContainmentType.Intersects;
						break;
					}
				}
			}
			return result;
		}

		public ContainmentType Contains(Vector3 point)
		{
			Plane[] array = planes;
			for (int i = 0; i < array.Length; i++)
			{
				Plane plane = array[i];
				float num = plane.Normal.X*point.X + plane.Normal.Y*point.Y + plane.Normal.Z*point.Z + plane.D;
				if (num > 1E-05f)
				{
					return ContainmentType.Disjoint;
				}
			}
			return ContainmentType.Contains;
		}

		public void Contains(ref Vector3 point, out ContainmentType result)
		{
			Plane[] array = planes;
			for (int i = 0; i < array.Length; i++)
			{
				Plane plane = array[i];
				float num = plane.Normal.X*point.X + plane.Normal.Y*point.Y + plane.Normal.Z*point.Z + plane.D;
				if (num > 1E-05f)
				{
					result = ContainmentType.Disjoint;
					return;
				}
			}
			result = ContainmentType.Contains;
		}

		public ContainmentType Contains(BoundingSphere sphere)
		{
			Vector3 center = sphere.Center;
			float radius = sphere.Radius;
			int num = 0;
			Plane[] array = planes;
			for (int i = 0; i < array.Length; i++)
			{
				Plane plane = array[i];
				float num2 = plane.Normal.X*center.X + plane.Normal.Y*center.Y + plane.Normal.Z*center.Z;
				float num3 = num2 + plane.D;
				if (num3 > radius)
				{
					return ContainmentType.Disjoint;
				}
				if (num3 < -radius)
				{
					num++;
				}
			}
			if (num != 6)
			{
				return ContainmentType.Intersects;
			}
			return ContainmentType.Contains;
		}

		public void Contains(ref BoundingSphere sphere, out ContainmentType result)
		{
			Vector3 center = sphere.Center;
			float radius = sphere.Radius;
			int num = 0;
			Plane[] array = planes;
			for (int i = 0; i < array.Length; i++)
			{
				Plane plane = array[i];
				float num2 = plane.Normal.X*center.X + plane.Normal.Y*center.Y + plane.Normal.Z*center.Z;
				float num3 = num2 + plane.D;
				if (num3 > radius)
				{
					result = ContainmentType.Disjoint;
					return;
				}
				if (num3 < -radius)
				{
					num++;
				}
			}
			result = ((num == 6) ? ContainmentType.Contains : ContainmentType.Intersects);
		}

		internal void SupportMapping(ref Vector3 v, out Vector3 result)
		{
			int num = 0;
			float num2;
			Vector3.Dot(ref cornerArray[0], ref v, out num2);
			for (int i = 1; i < cornerArray.Length; i++)
			{
				float num3;
				Vector3.Dot(ref cornerArray[i], ref v, out num3);
				if (num3 > num2)
				{
					num = i;
					num2 = num3;
				}
			}
			result = cornerArray[num];
		}

		public static bool operator ==(BoundingFrustum a, BoundingFrustum b)
		{
			return Equals(a, b);
		}

		public static bool operator !=(BoundingFrustum a, BoundingFrustum b)
		{
			return !Equals(a, b);
		}
	}
}