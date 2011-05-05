using System;
using System.Runtime.InteropServices;
using InVision.Ogre.Util;
using InVision.GameMath;

namespace InVision.Ogre
{
	[StructLayout(LayoutKind.Sequential)]
	public struct Radian : IEquatable<Radian>, IComparable<Radian>
	{
		private readonly float radians;

		/// <summary>
		/// 	Initializes a new instance of the <see cref = "Radian" /> struct.
		/// </summary>
		/// <param name = "radians">The radians.</param>
		public Radian(float radians)
			: this()
		{
			this.radians = radians;
		}

		/// <summary>
		/// 	Initializes a new instance of the <see cref = "Radian" /> struct.
		/// </summary>
		/// <param name = "degree">The degree.</param>
		public Radian(Degree degree)
			: this(degree.ValueRadians)
		{
		}

		/// <summary>
		/// 	Gets the value degrees.
		/// </summary>
		/// <value>The value degrees.</value>
		public float ValueDegrees
		{
			get { return radians.ToDegree(); }
		}

		/// <summary>
		/// 	Gets the value radians.
		/// </summary>
		/// <value>The value radians.</value>
		public float ValueRadians
		{
			get { return radians; }
		}

		/// <summary>
		/// 	Gets the value angle units.
		/// </summary>
		/// <value>The value angle units.</value>
		public float ValueAngleUnits
		{
			get { return MathUtility.RadianToAngleUnit(radians); }
		}

		/// <summary>
		/// Compares the current object with another object of the same type.
		/// </summary>
		/// <returns>
		/// A 32-bit signed integer that indicates the relative order of the objects being compared. The return value has the following meanings: Value Meaning Less than zero This object is less than the other parameter.Zero This object is equal to other. Greater than zero This object is greater than other. 
		/// </returns>
		/// <param name="other">An object to compare with this object.</param>
		public int CompareTo(Radian other)
		{
			return (int)Math.Ceiling(radians - other.radians);
		}

		/// <summary>
		/// 	Returns a <see cref = "System.String" /> that represents this instance.
		/// </summary>
		/// <returns>
		/// 	A <see cref = "System.String" /> that represents this instance.
		/// </returns>
		public override string ToString()
		{
			return string.Format("Radian({0})", radians);
		}

		/// <summary>
		/// 	Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		/// <returns>
		/// 	true if the current object is equal to the other parameter; otherwise, false.
		/// </returns>
		/// <param name = "other">An object to compare with this object.</param>
		public bool Equals(Radian other)
		{
			return other.radians.Equals(radians);
		}

		/// <summary>
		/// 	Indicates whether this instance and a specified object are equal.
		/// </summary>
		/// <returns>
		/// 	true if obj and this instance are the same type and represent the same value; otherwise, false.
		/// </returns>
		/// <param name = "obj">Another object to compare to. </param>
		/// <filterpriority>2</filterpriority>
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (obj.GetType() != typeof(Radian)) return false;
			return Equals((Radian)obj);
		}

		/// <summary>
		/// 	Returns the hash code for this instance.
		/// </summary>
		/// <returns>
		/// 	A 32-bit signed integer that is the hash code for this instance.
		/// </returns>
		/// <filterpriority>2</filterpriority>
		public override int GetHashCode()
		{
			return radians.GetHashCode();
		}

		/// <summary>
		/// Adds this instance.
		/// </summary>
		/// <returns></returns>
		public Radian Add()
		{
			return Add(ref this);
		}

		/// <summary>
		/// Adds the specified r.
		/// </summary>
		/// <param name="r">The r.</param>
		/// <returns></returns>
		public Radian Add(Radian r)
		{
			return Add(ref this, ref r);
		}

		/// <summary>
		/// Adds the specified d.
		/// </summary>
		/// <param name="d">The d.</param>
		/// <returns></returns>
		public Radian Add(Degree d)
		{
			return Add(ref this, ref d);
		}

		/// <summary>
		/// Subtracts this instance.
		/// </summary>
		/// <returns></returns>
		public Radian Subtract()
		{
			return Subtract(ref this);
		}

		/// <summary>
		/// Subtracts the specified r.
		/// </summary>
		/// <param name="r">The r.</param>
		/// <returns></returns>
		public Radian Subtract(Radian r)
		{
			return Subtract(ref this, ref r);
		}

		/// <summary>
		/// Subtracts the specified d.
		/// </summary>
		/// <param name="d">The d.</param>
		/// <returns></returns>
		public Radian Subtract(Degree d)
		{
			return Subtract(ref this, ref d);
		}

		/// <summary>
		/// Multiplies the specified r.
		/// </summary>
		/// <param name="r">The r.</param>
		/// <returns></returns>
		public Radian Multiply(Radian r)
		{
			return Multiply(ref this, ref r);
		}

		/// <summary>
		/// Multiplies the specified d.
		/// </summary>
		/// <param name="d">The d.</param>
		/// <returns></returns>
		public Radian Multiply(Degree d)
		{
			return Multiply(ref this, ref d);
		}

		/// <summary>
		/// Divides the specified r.
		/// </summary>
		/// <param name="r">The r.</param>
		/// <returns></returns>
		public Radian Divide(Radian r)
		{
			return Divide(ref this, ref r);
		}

		/// <summary>
		/// Divides the specified d.
		/// </summary>
		/// <param name="d">The d.</param>
		/// <returns></returns>
		public Radian Divide(Degree d)
		{
			return Divide(ref this, ref d);
		}

		#region Static helpers

		public static Radian FromValue(float v)
		{
			return new Radian(v);
		}

		public static Radian FromDegrees(ref Degree d)
		{
			return new Radian(d.ValueRadians);
		}

		public static Radian FromDegrees(float degrees)
		{
			return new Radian(MathUtility.DegreeToRadian(degrees));
		}

		public static Radian Add(ref Radian r)
		{
			return r;
		}

		public static Radian Add(ref Radian r1, ref Radian r2)
		{
			return new Radian(r1.radians + r2.radians);
		}

		public static Radian Add(ref Radian r, ref Degree d)
		{
			return new Radian(r.radians + d.ValueRadians);
		}

		public static Radian Subtract(ref Radian r)
		{
			return new Radian(-r.radians);
		}

		public static Radian Subtract(ref Radian r1, ref Radian r2)
		{
			return new Radian(r1.radians - r2.radians);
		}

		public static Radian Subtract(ref Radian r, ref Degree d)
		{
			return new Radian(r.radians - d.ValueRadians);
		}

		public static Radian Multiply(ref Radian r1, ref Radian r2)
		{
			return new Radian(r1.radians * r2.radians);
		}

		public static Radian Multiply(ref Radian r, ref Degree d)
		{
			return new Radian(r.radians * d.ValueRadians);
		}

		public static Radian Divide(ref Radian r1, ref Radian r2)
		{
			return new Radian(r1.radians / r2.radians);
		}

		public static Radian Divide(ref Radian r, ref Degree d)
		{
			return new Radian(r.radians / d.ValueRadians);
		}

		public static bool LessThan(ref Radian r1, ref Radian r2)
		{
			return r1.radians < r2.radians;
		}

		public static bool LessOrEqualThan(ref Radian r1, ref Radian r2)
		{
			return r1.radians <= r2.radians;
		}

		public static bool GreaterThan(ref Radian r1, ref Radian r2)
		{
			return r1.radians > r2.radians;
		}

		public static bool GreaterOrEqualThan(ref Radian r1, ref Radian r2)
		{
			return r1.radians >= r2.radians;
		}

		#endregion

		#region Operators

		public static bool operator ==(Radian left, Radian right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(Radian left, Radian right)
		{
			return !left.Equals(right);
		}

		public static Radian operator +(Radian r)
		{
			return Add(ref r);
		}

		public static Radian operator +(Radian r1, Radian r2)
		{
			return Add(ref r1, ref r2);
		}

		public static Radian operator +(Radian r, Degree d)
		{
			return Add(ref r, ref d);
		}

		public static Radian operator -(Radian r)
		{
			return Subtract(ref r);
		}

		public static Radian operator -(Radian r1, Radian r2)
		{
			return Subtract(ref r1, ref r2);
		}

		public static Radian operator -(Radian r, Degree d)
		{
			return Subtract(ref r, ref d);
		}

		public static Radian operator *(Radian r1, Radian r2)
		{
			return Multiply(ref r1, ref r2);
		}

		public static Radian operator *(Radian r, Degree d)
		{
			return Multiply(ref r, ref d);
		}

		public static Radian operator /(Radian r1, Radian r2)
		{
			return Divide(ref r1, ref r2);
		}

		public static Radian operator /(Radian r, Degree d)
		{
			return Divide(ref r, ref d);
		}

		public static explicit operator Radian(float value)
		{
			return new Radian(value);
		}

		#endregion
	}
}