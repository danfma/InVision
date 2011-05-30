// 
// BoundingBox.cs
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
using System.Collections.Generic;
using System.Runtime.InteropServices;
using InVision.Native;

namespace InVision.GameMath
{
	[Serializable]
	[StructLayout(LayoutKind.Sequential)]
	[CppValueObject(DefinitionFile = "invisionnative.h")]
	public struct BoundingBox : IEquatable<BoundingBox>
	{
		public const int CornerCount = 8;
		public Vector3 Max;
		public Vector3 Min;

		public BoundingBox(Vector3 min, Vector3 max)
		{
			Min = min;
			Max = max;
		}

		#region Contains

		public ContainmentType Contains(BoundingBox box)
		{
			ContainmentType result;
			Contains(ref box, out result);
			return result;
		}

		public void Contains(ref BoundingBox box, out ContainmentType result)
		{
			if ((Max.X < box.Min.X || Min.X > box.Max.X) ||
				(Max.Y < box.Min.Y || Min.Y > box.Max.Y) ||
				(Max.Z < box.Min.Z || Min.Z > box.Max.Z)) {
				result = ContainmentType.Disjoint;
				return;
			}

			if ((Min.X <= box.Min.X && Max.X >= box.Max.X) &&
				(Min.Y <= box.Min.Y && Max.Y >= box.Max.Y) &&
				(Min.Z <= box.Min.Z && Max.Z >= box.Max.Z)) {
				result = ContainmentType.Contains;
				return;
			}

			result = ContainmentType.Intersects;
		}

		public ContainmentType Contains(BoundingFrustum frustum)
		{
			if (frustum == null)
				throw new ArgumentNullException("frustum");

			if (!frustum.Intersects(this)) {
				return ContainmentType.Disjoint;
			}

			Vector3[] cornerArray = frustum.cornerArray;

			for (int i = 0; i < cornerArray.Length; i++) {
				Vector3 point = cornerArray[i];

				if (Contains(point) == ContainmentType.Disjoint) {
					return ContainmentType.Intersects;
				}
			}

			return ContainmentType.Contains;
		}

		public ContainmentType Contains(BoundingSphere sphere)
		{
			ContainmentType result;
			Contains(ref sphere, out result);
			return result;
		}

		public void Contains(ref BoundingSphere sphere, out ContainmentType result)
		{
			Vector3 center = sphere.Center;

			Vector3 point;
			Vector3.Clamp(ref center, ref Min, ref Max, out point);

			float dist;
			Vector3.DistanceSquared(ref center, ref point, out dist);

			float radius = sphere.Radius;

			if (dist > radius) {
				result = ContainmentType.Disjoint;
				return;
			}

			if (Min.X + radius <= center.X && Max.X - radius >= center.X && Max.X - Min.X > radius &&
				Min.Y + radius <= center.Y && Max.Y - radius >= center.Y && Max.Y - Min.Y > radius &&
				Min.Z + radius <= center.Z && Max.Z - radius >= center.Z && Max.X - Min.X > radius) {
				result = ContainmentType.Contains;
				return;
			}

			result = ContainmentType.Intersects;
		}

		public ContainmentType Contains(Vector3 point)
		{
			ContainmentType result;
			Contains(ref point, out result);
			return result;
		}

		public void Contains(ref Vector3 point, out ContainmentType result)
		{
			if ((Min.X <= point.X && Max.X >= point.X) &&
				(Min.Y <= point.Y && Max.Y >= point.Y) &&
				(Min.Z <= point.Z && Max.Z >= point.Z)) {
				result = ContainmentType.Contains;
				return;
			}

			result = ContainmentType.Disjoint;
		}

		#endregion

		#region Creation

		public static BoundingBox CreateFromPoints(IEnumerable<Vector3> points)
		{
			if (points == null)
				throw new ArgumentNullException("points");

			bool hasPoints = false;
			var min = new Vector3(float.MaxValue);
			var max = new Vector3(float.MinValue);

			foreach (Vector3 point in points) {
				Vector3 pt = point;

				Vector3.Min(ref min, ref pt, out min);
				Vector3.Max(ref max, ref pt, out max);

				hasPoints = true;
			}

			if (!hasPoints)
				throw new ArgumentException("No points were given.", "points");

			return new BoundingBox(min, max);
		}

		public static BoundingBox CreateFromSphere(BoundingSphere sphere)
		{
			BoundingBox result;
			CreateFromSphere(ref sphere, out result);
			return result;
		}

		public static void CreateFromSphere(ref BoundingSphere sphere, out BoundingBox result)
		{
			var min = new Vector3(sphere.Center.X - sphere.Radius, sphere.Center.Y - sphere.Radius,
								  sphere.Center.Z - sphere.Radius);
			var max = new Vector3(sphere.Center.X + sphere.Radius, sphere.Center.Y + sphere.Radius,
								  sphere.Center.Z + sphere.Radius);

			result = new BoundingBox(min, max);
		}

		public static BoundingBox CreateMerged(BoundingBox original, BoundingBox additional)
		{
			BoundingBox result;
			CreateMerged(ref original, ref additional, out result);
			return result;
		}

		public static void CreateMerged(ref BoundingBox original, ref BoundingBox additional, out BoundingBox result)
		{
			Vector3 min, max;

			Vector3.Min(ref original.Min, ref additional.Min, out min);
			Vector3.Max(ref original.Max, ref additional.Max, out max);

			result = new BoundingBox(min, max);
		}

		#endregion

		public Vector3[] GetCorners()
		{
			var arr = new Vector3[CornerCount];
			GetCorners(arr);
			return arr;
		}

		public void GetCorners(Vector3[] corners)
		{
			if (corners == null)
				throw new ArgumentNullException("corners");

			if (corners.Length != CornerCount)
				throw new ArgumentOutOfRangeException("You must have at least 8 elements to copy corners.", "corners");

			corners[0] = new Vector3(Min.X, Max.Y, Max.Z);
			corners[1] = new Vector3(Max.X, Max.Y, Max.Z);
			corners[2] = new Vector3(Max.X, Min.Y, Max.Z);
			corners[3] = new Vector3(Min.X, Min.Y, Max.Z);
			corners[4] = new Vector3(Min.X, Max.Y, Min.Z);
			corners[5] = new Vector3(Max.X, Max.Y, Min.Z);
			corners[6] = new Vector3(Max.X, Min.Y, Min.Z);
			corners[7] = new Vector3(Min.X, Min.Y, Min.Z);
		}

		internal void SupportMapping(ref Vector3 v, out Vector3 result)
		{
			result = default(Vector3);
			result.X = ((v.X >= 0f) ? Max.X : Min.X);
			result.Y = ((v.Y >= 0f) ? Max.Y : Min.Y);
			result.Z = ((v.Z >= 0f) ? Max.Z : Min.Z);
		}

		public override string ToString()
		{
			return string.Format("{{Min:{0} Max:{1}}}", Min, Max);
		}

		#region Equality

		public bool Equals(BoundingBox other)
		{
			return other == this;
		}

		public override bool Equals(object obj)
		{
			return obj is BoundingBox && ((BoundingBox)obj) == this;
		}

		public override int GetHashCode()
		{
			return Min.GetHashCode() ^ Max.GetHashCode();
		}

		public static bool operator ==(BoundingBox a, BoundingBox b)
		{
			return a.Min == b.Min && a.Max == b.Max;
		}

		public static bool operator !=(BoundingBox a, BoundingBox b)
		{
			return a.Min != b.Min || a.Max != b.Max;
		}

		# endregion

		#region Intersects

		public bool Intersects(BoundingBox box)
		{
			bool result;
			Intersects(ref box, out result);
			return result;
		}

		public void Intersects(ref BoundingBox box, out bool result)
		{
			ContainmentType containment;
			Contains(ref box, out containment);
			result = containment == ContainmentType.Intersects;
		}

		public bool Intersects(BoundingFrustum frustum)
		{
			return (Contains(frustum) == ContainmentType.Intersects);
		}

		public bool Intersects(BoundingSphere sphere)
		{
			bool result;
			Intersects(ref sphere, out result);
			return result;
		}

		public void Intersects(ref BoundingSphere sphere, out bool result)
		{
			ContainmentType containment;
			Contains(ref sphere, out containment);
			result = containment == ContainmentType.Intersects;
		}

		public PlaneIntersectionType Intersects(Plane plane)
		{
			PlaneIntersectionType result;
			Intersects(ref plane, out result);
			return result;
		}

		public void Intersects(ref Plane plane, out PlaneIntersectionType result)
		{
			Vector3 vector = default(Vector3);
			vector.X = ((plane.Normal.X >= 0f) ? Min.X : Max.X);
			vector.Y = ((plane.Normal.Y >= 0f) ? Min.Y : Max.Y);
			vector.Z = ((plane.Normal.Z >= 0f) ? Min.Z : Max.Z);

			Vector3 vector2 = default(Vector3);
			vector2.X = ((plane.Normal.X >= 0f) ? Max.X : Min.X);
			vector2.Y = ((plane.Normal.Y >= 0f) ? Max.Y : Min.Y);
			vector2.Z = ((plane.Normal.Z >= 0f) ? Max.Z : Min.Z);

			float num = plane.Normal.X * vector.X + plane.Normal.Y * vector.Y + plane.Normal.Z * vector.Z;

			if (num + plane.D > 0f) {
				result = PlaneIntersectionType.Front;
				return;
			}

			num = plane.Normal.X * vector2.X + plane.Normal.Y * vector2.Y + plane.Normal.Z * vector2.Z;

			if (num + plane.D < 0f) {
				result = PlaneIntersectionType.Back;
				return;
			}

			result = PlaneIntersectionType.Intersecting;
		}

		public float? Intersects(Ray ray)
		{
			float? result;
			Intersects(ref ray, out result);
			return result;
		}

		public void Intersects(ref Ray ray, out float? result)
		{
			result = null;
			float num = 0f;
			float num2 = 3.40282347E+38f;

			if (Math.Abs(ray.Direction.X) < 1E-06f) {
				if (ray.Position.X < Min.X || ray.Position.X > Max.X) {
					return;
				}
			} else {
				float num3 = 1f / ray.Direction.X;
				float num4 = (Min.X - ray.Position.X) * num3;
				float num5 = (Max.X - ray.Position.X) * num3;
				if (num4 > num5) {
					float num6 = num4;
					num4 = num5;
					num5 = num6;
				}
				num = MathHelper.Max(num4, num);
				num2 = MathHelper.Min(num5, num2);
				if (num > num2) {
					return;
				}
			}
			if (Math.Abs(ray.Direction.Y) < 1E-06f) {
				if (ray.Position.Y < Min.Y || ray.Position.Y > Max.Y) {
					return;
				}
			} else {
				float num7 = 1f / ray.Direction.Y;
				float num8 = (Min.Y - ray.Position.Y) * num7;
				float num9 = (Max.Y - ray.Position.Y) * num7;
				if (num8 > num9) {
					float num10 = num8;
					num8 = num9;
					num9 = num10;
				}
				num = MathHelper.Max(num8, num);
				num2 = MathHelper.Min(num9, num2);
				if (num > num2) {
					return;
				}
			}
			if (Math.Abs(ray.Direction.Z) < 1E-06f) {
				if (ray.Position.Z < Min.Z || ray.Position.Z > Max.Z) {
					return;
				}
			} else {
				float num11 = 1f / ray.Direction.Z;
				float num12 = (Min.Z - ray.Position.Z) * num11;
				float num13 = (Max.Z - ray.Position.Z) * num11;
				if (num12 > num13) {
					float num14 = num12;
					num12 = num13;
					num13 = num14;
				}
				num = MathHelper.Max(num12, num);
				num2 = MathHelper.Min(num13, num2);
				if (num > num2) {
					return;
				}
			}
			result = num;
		}

		#endregion
	}
}