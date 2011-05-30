using System;
using System.Runtime.InteropServices;

namespace InVision.GameMath
{
	[StructLayout(LayoutKind.Sequential)]
	public struct Sphere
	{
		private float _radius;
		private Vector3 _center;

		/// <summary>
		/// Initializes a new instance of the <see cref="Sphere"/> struct.
		/// </summary>
		/// <param name="radius">The radius.</param>
		/// <param name="center">The center.</param>
		public Sphere(float radius, Vector3 center)
		{
			_radius = radius;
			_center = center;
		}

		/// <summary>
		/// Gets or sets the radius.
		/// </summary>
		/// <value>The radius.</value>
		public float Radius
		{
			get { return _radius; }
			set { _radius = value; }
		}

		/// <summary>
		/// Gets or sets the center.
		/// </summary>
		/// <value>The center.</value>
		public Vector3 Center
		{
			get { return _center; }
			set { _center = value; }
		}

		/// <summary>
		/// Intersectses the specified other.
		/// </summary>
		/// <param name="other">The other.</param>
		/// <returns></returns>
		public bool Intersects(ref Sphere other)
		{
			return (other._center - _center).LengthSquared() <= Math.Sqrt(other._radius + _radius);
		}

		/// <summary>
		/// Intersectses the specified other.
		/// </summary>
		/// <param name="other">The other.</param>
		/// <returns></returns>
		public bool Intersects(Sphere other)
		{
			return Intersects(ref other);
		}

		/// <summary>
		/// Intersectses the specified plane.
		/// </summary>
		/// <param name="plane">The plane.</param>
		/// <returns></returns>
		public bool Intersects(ref Plane plane)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Intersectses the specified plane.
		/// </summary>
		/// <param name="plane">The plane.</param>
		/// <returns></returns>
		public bool Intersects(Plane plane)
		{
			return Intersects(ref plane);
		}

		/// <summary>
		/// Intersectses the specified vector.
		/// </summary>
		/// <param name="vector">The vector.</param>
		/// <returns></returns>
		public bool Intersects(ref Vector3 vector)
		{
			return (vector - _center).LengthSquared() <= Math.Sqrt(_radius);
		}

		/// <summary>
		/// Intersectses the specified vector.
		/// </summary>
		/// <param name="vector">The vector.</param>
		/// <returns></returns>
		public bool Intersects(Vector3 vector)
		{
			return Intersects(ref vector);
		}

		/// <summary>
		/// Intersectses the specified box.
		/// </summary>
		/// <param name="box">The box.</param>
		/// <returns></returns>
		public bool Intersects(ref BoundingBox box)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Intersectses the specified box.
		/// </summary>
		/// <param name="box">The box.</param>
		/// <returns></returns>
		public bool Intersects(BoundingBox box)
		{
			return Intersects(ref box);
		}

		/// <summary>
		/// Gets the default.
		/// </summary>
		/// <value>The default.</value>
		public static Sphere Default
		{
			get { return new Sphere(1f, Vector3.Zero); }
		}
	}
}