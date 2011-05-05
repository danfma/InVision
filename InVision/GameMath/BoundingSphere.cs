// 
// BoundingSphere.cs
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

namespace InVision.GameMath
{
	[Serializable]
	public struct BoundingSphere : IEquatable<BoundingSphere>
	{
		public Vector3 Center;
		public float Radius;

		public BoundingSphere(Vector3 center, float radius)
		{
			if (radius < 0)
				throw new ArgumentException("Radius cannot be less than zero", "radius");

			Center = center;
			Radius = radius;
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
			if (!box.Intersects(this))
			{
				result = ContainmentType.Disjoint;
				return;
			}

			float radiusSq = Radius * Radius;
			float cx = Center.X;
			float cy = Center.Y;
			float cz = Center.Z;

			if (new Vector3(cx - box.Min.X, cy - box.Max.Y, cz - box.Max.Z).LengthSquared() > radiusSq ||
				new Vector3(cx - box.Max.X, cy - box.Max.Y, cz - box.Max.Z).LengthSquared() > radiusSq ||
				new Vector3(cx - box.Max.X, cy - box.Min.Y, cz - box.Max.Z).LengthSquared() > radiusSq ||
				new Vector3(cx - box.Min.X, cy - box.Min.Y, cz - box.Max.Z).LengthSquared() > radiusSq ||
				new Vector3(cx - box.Min.X, cy - box.Max.Y, cz - box.Min.Z).LengthSquared() > radiusSq ||
				new Vector3(cx - box.Max.X, cy - box.Max.Y, cz - box.Min.Z).LengthSquared() > radiusSq ||
				new Vector3(cx - box.Max.X, cy - box.Min.Y, cz - box.Min.Z).LengthSquared() > radiusSq ||
				new Vector3(cx - box.Min.X, cy - box.Min.Y, cz - box.Min.Z).LengthSquared() > radiusSq)
			{
				result = ContainmentType.Intersects;
				return;
			}

			result = ContainmentType.Contains;
		}

		public ContainmentType Contains(BoundingFrustum frustum)
		{
			if (frustum == null)
				throw new ArgumentNullException("frustum");

			if (!frustum.Intersects(this))
				return ContainmentType.Disjoint;

			float num = Radius * Radius;
			Vector3[] cornerArray = frustum.cornerArray;

			for (int i = 0; i < cornerArray.Length; i++)
			{
				Vector3 vector = cornerArray[i];
				var vector2 = new Vector3(
					vector.X - Center.X,
					vector.Y - Center.Y,
					vector.Z - Center.Z);

				if (vector2.LengthSquared() > num)
				{
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
			float dist;
			Vector3.Distance(ref Center, ref sphere.Center, out dist);
			float sphereRadius = sphere.Radius;

			if (Radius + sphereRadius < dist)
			{
				result = ContainmentType.Disjoint;
				return;
			}

			if (Radius - sphereRadius < dist)
			{
				result = ContainmentType.Intersects;
				return;
			}

			result = ContainmentType.Contains;
		}

		public ContainmentType Contains(Vector3 point)
		{
			ContainmentType result;
			Contains(ref point, out result);
			return result;
		}

		public void Contains(ref Vector3 point, out ContainmentType result)
		{
			if (Vector3.DistanceSquared(point, Center) >= Radius * Radius)
			{
				result = ContainmentType.Disjoint;
				return;
			}

			result = ContainmentType.Contains;
		}

		#endregion

		#region Creation

		public static BoundingSphere CreateFromBoundingBox(BoundingBox box)
		{
			BoundingSphere result;
			CreateFromBoundingBox(ref box, out result);
			return result;
		}

		public static void CreateFromBoundingBox(ref BoundingBox box, out BoundingSphere result)
		{
			Vector3.Lerp(ref box.Min, ref box.Max, 0.5f, out result.Center);

			float distance;
			Vector3.Distance(ref box.Min, ref box.Max, out distance);
			result.Radius = distance * 0.5f;
		}

		public static BoundingSphere CreateFromFrustum(BoundingFrustum frustum)
		{
			if (frustum == null)
				throw new ArgumentNullException("frustum");

			return CreateFromPoints(frustum.GetCorners());
		}

		public static BoundingSphere CreateFromPoints(IEnumerable<Vector3> points)
		{
			if (points == null)
				throw new ArgumentNullException("points");

			IEnumerator<Vector3> enumerator = points.GetEnumerator();

			if (!enumerator.MoveNext())
				throw new ArgumentException("no points in enumeration");

			Vector3 vector6;
			Vector3 vector5;
			Vector3 vector4;
			Vector3 vector3;
			Vector3 vector2;
			Vector3 vector = vector2 = (vector3 = (vector4 = (vector5 = (vector6 = enumerator.Current))));

			foreach (Vector3 current in points)
			{
				if (current.X < vector2.X)
				{
					vector2 = current;
				}
				if (current.X > vector.X)
				{
					vector = current;
				}
				if (current.Y < vector3.Y)
				{
					vector3 = current;
				}
				if (current.Y > vector4.Y)
				{
					vector4 = current;
				}
				if (current.Z < vector5.Z)
				{
					vector5 = current;
				}
				if (current.Z > vector6.Z)
				{
					vector6 = current;
				}
			}
			float num;
			Vector3.Distance(ref vector, ref vector2, out num);
			float num2;
			Vector3.Distance(ref vector4, ref vector3, out num2);
			float num3;
			Vector3.Distance(ref vector6, ref vector5, out num3);
			Vector3 vector7;
			float num4;
			if (num > num2)
			{
				if (num > num3)
				{
					Vector3.Lerp(ref vector, ref vector2, 0.5f, out vector7);
					num4 = num * 0.5f;
				}
				else
				{
					Vector3.Lerp(ref vector6, ref vector5, 0.5f, out vector7);
					num4 = num3 * 0.5f;
				}
			}
			else
			{
				if (num2 > num3)
				{
					Vector3.Lerp(ref vector4, ref vector3, 0.5f, out vector7);
					num4 = num2 * 0.5f;
				}
				else
				{
					Vector3.Lerp(ref vector6, ref vector5, 0.5f, out vector7);
					num4 = num3 * 0.5f;
				}
			}
			foreach (Vector3 current2 in points)
			{
				Vector3 value = default(Vector3);
				value.X = current2.X - vector7.X;
				value.Y = current2.Y - vector7.Y;
				value.Z = current2.Z - vector7.Z;
				float num5 = value.Length();
				if (num5 > num4)
				{
					num4 = (num4 + num5) * 0.5f;
					vector7 += (1f - num4 / num5) * value;
				}
			}
			BoundingSphere result;
			result.Center = vector7;
			result.Radius = num4;
			return result;
		}

		public static BoundingSphere CreateMerged(BoundingSphere original, BoundingSphere additional)
		{
			BoundingSphere result;
			CreateMerged(ref original, ref additional, out result);
			return result;
		}

		public static void CreateMerged(ref BoundingSphere original, ref BoundingSphere additional, out BoundingSphere result)
		{
			Vector3 value;
			Vector3.Subtract(ref additional.Center, ref original.Center, out value);
			float num = value.Length();
			float radius = original.Radius;
			float radius2 = additional.Radius;
			if (radius + radius2 >= num)
			{
				if (radius - radius2 >= num)
				{
					result = original;
					return;
				}
				if (radius2 - radius >= num)
				{
					result = additional;
					return;
				}
			}
			Vector3 value2 = value * (1f / num);
			float num2 = MathHelper.Min(-radius, num - radius2);
			float num3 = MathHelper.Max(radius, num + radius2);
			float num4 = (num3 - num2) * 0.5f;
			result.Center = original.Center + value2 * (num4 + num2);
			result.Radius = num4;
		}

		#endregion

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
			float distance;
			Vector3.Dot(ref plane.Normal, ref Center, out distance);
			distance += plane.D;

			if (distance > Radius)
			{
				result = PlaneIntersectionType.Front;
				return;
			}

			if (distance < -Radius)
			{
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
			ray.Intersects(ref this, out result);
		}

		#endregion

		public BoundingSphere Transform(Matrix matrix)
		{
			BoundingSphere result;
			Transform(ref matrix, out result);
			return result;
		}

		public void Transform(ref Matrix matrix, out BoundingSphere result)
		{
			result.Center = Vector3.Transform(this.Center, matrix);
			float val = matrix.M11 * matrix.M11 + matrix.M12 * matrix.M12 + matrix.M13 * matrix.M13;
			float val2 = matrix.M21 * matrix.M21 + matrix.M22 * matrix.M22 + matrix.M23 * matrix.M23;
			float val3 = matrix.M31 * matrix.M31 + matrix.M32 * matrix.M32 + matrix.M33 * matrix.M33;
			float num = Math.Max(val, Math.Max(val2, val3));
			result.Radius = this.Radius * (float)Math.Sqrt((double)num);
		}

		internal void SupportMapping(ref Vector3 v, out Vector3 result)
		{
			float num = v.Length();
			float num2 = Radius / num;

			result = default(Vector3);
			result.X = Center.X + v.X * num2;
			result.Y = Center.Y + v.Y * num2;
			result.Z = Center.Z + v.Z * num2;
		}

		public override string ToString()
		{
			return string.Format("{{Center:{0} Radius:{1}}}", Center, Radius);
		}

		#region Equality

		public bool Equals(BoundingSphere other)
		{
			return other == this;
		}

		public override bool Equals(object obj)
		{
			return obj is BoundingSphere && ((BoundingSphere)obj) == this;
		}

		public override int GetHashCode()
		{
			return Radius.GetHashCode() ^ Center.GetHashCode();
		}

		public static bool operator ==(BoundingSphere a, BoundingSphere b)
		{
			return a.Radius == b.Radius && a.Center == b.Center;
		}

		public static bool operator !=(BoundingSphere a, BoundingSphere b)
		{
			return a.Radius != b.Radius || a.Center != b.Center;
		}

		#endregion
	}
}