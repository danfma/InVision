using System;
using System.Runtime.InteropServices;
using InVision.GameMath;
using InVision.Ogre.Util;

namespace InVision.Ogre
{
	[StructLayout(LayoutKind.Sequential)]
	public struct Degree : IEquatable<Degree>, IComparable<Degree>
	{
		private readonly float degrees;

		/// <summary>
		/// 	Initializes a new instance of the <see cref = "Radian" /> struct.
		/// </summary>
		/// <param name = "degrees">The radians.</param>
		public Degree(float degrees)
			: this()
		{
			this.degrees = degrees;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Degree"/> struct.
		/// </summary>
		/// <param name="radian">The radian.</param>
		public Degree(Radian radian)
			: this(radian.ValueDegrees)
		{
		}

		/// <summary>
		/// 	Gets the value degrees.
		/// </summary>
		/// <value>The value degrees.</value>
		public float ValueDegrees
		{
			get { return degrees; }
		}

		/// <summary>
		/// 	Gets the value radians.
		/// </summary>
		/// <value>The value radians.</value>
		public float ValueRadians
		{
			get { return degrees.ToRadian(); }
		}

		/// <summary>
		/// 	Gets the value angle units.
		/// </summary>
		/// <value>The value angle units.</value>
		public float ValueAngleUnits
		{
			get { return MathUtility.DegreeToAngleUnit(degrees); }
		}

		/// <summary>
		/// Compares the current object with another object of the same type.
		/// </summary>
		/// <returns>
		/// A 32-bit signed integer that indicates the relative order of the objects being compared. The return value has the following meanings: Value Meaning Less than zero This object is less than the other parameter.Zero This object is equal to other. Greater than zero This object is greater than other. 
		/// </returns>
		/// <param name="other">An object to compare with this object.</param>
		public int CompareTo(Degree other)
		{
			return (int)Math.Ceiling(degrees - other.degrees);
		}

		/// <summary>
		/// Returns a <see cref="System.String"/> that represents this instance.
		/// </summary>
		/// <returns>
		/// A <see cref="System.String"/> that represents this instance.
		/// </returns>
		public override string ToString()
		{
			return string.Format("Degree({0})", degrees);
		}

		/// <summary>
		/// 	Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		/// <returns>
		/// 	true if the current object is equal to the other parameter; otherwise, false.
		/// </returns>
		/// <param name = "other">An object to compare with this object.</param>
		public bool Equals(Degree other)
		{
			return other.degrees.Equals(degrees);
		}

		/// <summary>
		/// Determines whether the specified <see cref="System.Object"/> is equal to this instance.
		/// </summary>
		/// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
		/// <returns>
		/// 	<c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.
		/// </returns>
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
			return degrees.GetHashCode();
		}

		/// <summary>
		/// Adds this instance.
		/// </summary>
		/// <returns></returns>
		public Degree Add()
		{
			return Add(ref this);
		}

		/// <summary>
		/// Adds the specified r.
		/// </summary>
		/// <param name="d">The r.</param>
		/// <returns></returns>
		public Degree Add(Degree d)
		{
			return Add(ref this, ref d);
		}

		/// <summary>
		/// Adds the specified d.
		/// </summary>
		/// <param name="r">The d.</param>
		/// <returns></returns>
		public Degree Add(Radian r)
		{
			return Add(ref this, ref r);
		}

		/// <summary>
		/// Subtracts this instance.
		/// </summary>
		/// <returns></returns>
		public Degree Subtract()
		{
			return Subtract(ref this);
		}

		/// <summary>
		/// Subtracts the specified r.
		/// </summary>
		/// <param name="d">The r.</param>
		/// <returns></returns>
		public Degree Subtract(Degree d)
		{
			return Subtract(ref this, ref d);
		}

		/// <summary>
		/// Subtracts the specified d.
		/// </summary>
		/// <param name="r">The d.</param>
		/// <returns></returns>
		public Degree Subtract(Radian r)
		{
			return Subtract(ref this, ref r);
		}

		/// <summary>
		/// Multiplies the specified d.
		/// </summary>
		/// <param name="d">The d.</param>
		/// <returns></returns>
		public Degree Multiply(Degree d)
		{
			return Multiply(ref this, ref d);
		}

		/// <summary>
		/// Multiplies the specified r.
		/// </summary>
		/// <param name="r">The r.</param>
		/// <returns></returns>
		public Degree Multiply(Radian r)
		{
			return Multiply(ref this, ref r);
		}

		/// <summary>
		/// Divides the specified r.
		/// </summary>
		/// <param name="r">The r.</param>
		/// <returns></returns>
		public Degree Divide(Radian r)
		{
			return Divide(ref this, ref r);
		}

		/// <summary>
		/// Divides the specified d.
		/// </summary>
		/// <param name="d">The d.</param>
		/// <returns></returns>
		public Degree Divide(Degree d)
		{
			return Divide(ref this, ref d);
		}

		#region Static helpers

		public static Degree FromValue(float v)
		{
			return new Degree(v);
		}

		public static Degree FromRadians(ref Radian r)
		{
			return new Degree(r.ValueDegrees);
		}

		/// <summary>
		/// Froms the radians.
		/// </summary>
		/// <param name="radians">The radians.</param>
		/// <returns></returns>
		public static Degree FromRadians(float radians)
		{
			return new Degree(radians.ToDegree());
		}

		public static Degree Add(ref Degree right)
		{
			return right;
		}

		public static Degree Add(ref Degree left, ref Degree right)
		{
			return new Degree(left.degrees + right.degrees);
		}

		public static Degree Add(ref Degree left, ref Radian right)
		{
			return new Degree(left.degrees + right.ValueDegrees);
		}

		public static Degree Subtract(ref Degree right)
		{
			return new Degree(-right.degrees);
		}

		public static Degree Subtract(ref Degree left, ref Degree right)
		{
			return new Degree(left.degrees - right.degrees);
		}

		public static Degree Subtract(ref Degree left, ref Radian right)
		{
			return new Degree(left.degrees - right.ValueDegrees);
		}

		public static Degree Multiply(ref Degree left, ref Degree right)
		{
			return new Degree(left.degrees * right.degrees);
		}

		public static Degree Multiply(ref Degree left, ref Radian right)
		{
			return new Degree(left.degrees * right.ValueDegrees);
		}

		public static Degree Divide(ref Degree left, ref Degree right)
		{
			return new Degree(left.degrees / right.degrees);
		}

		public static Degree Divide(ref Degree left, ref Radian right)
		{
			return new Degree(left.degrees / right.ValueDegrees);
		}

		public static bool LessThan(ref Degree left, ref Degree right)
		{
			return left.degrees < right.degrees;
		}

		public static bool LessOrEqualThan(ref Degree left, ref Degree right)
		{
			return left.degrees <= right.degrees;
		}

		public static bool GreaterThan(ref Degree left, ref Degree right)
		{
			return left.degrees > right.degrees;
		}

		public static bool GreaterOrEqualThan(ref Degree left, ref Degree right)
		{
			return left.degrees >= right.degrees;
		}

		#endregion

		#region Operators

		public static bool operator ==(Degree left, Degree right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(Degree left, Degree right)
		{
			return !left.Equals(right);
		}

		public static Degree operator +(Degree right)
		{
			return Add(ref right);
		}

		public static Degree operator +(Degree left, Degree right)
		{
			return Add(ref left, ref right);
		}

		public static Degree operator +(Degree left, Radian right)
		{
			return Add(ref left, ref right);
		}

		public static Degree operator -(Degree right)
		{
			return Subtract(ref right);
		}

		public static Degree operator -(Degree left, Degree right)
		{
			return Subtract(ref left, ref right);
		}

		public static Degree operator -(Degree left, Radian right)
		{
			return Subtract(ref left, ref right);
		}

		public static Degree operator *(Degree left, Degree right)
		{
			return Multiply(ref left, ref right);
		}

		public static Degree operator *(Degree left, Radian right)
		{
			return Multiply(ref left, ref right);
		}

		public static Degree operator /(Degree left, Degree right)
		{
			return Divide(ref left, ref right);
		}

		public static Degree operator /(Degree left, Radian right)
		{
			return Divide(ref left, ref right);
		}

		public static explicit operator Degree(float value)
		{
			return new Degree(value);
		}

		#endregion
	}
}