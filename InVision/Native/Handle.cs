using System;
using System.Runtime.InteropServices;

namespace InVision.Native
{
	[StructLayout(LayoutKind.Explicit, Size = sizeof(uint))]
	public struct Handle : IEquatable<Handle>
	{
		[FieldOffset(0)]
		private readonly uint _value;

		/// <summary>
		/// Initializes a new instance of the <see cref="Handle"/> struct.
		/// </summary>
		/// <param name="value">The value.</param>
		public Handle(uint value)
		{
			_value = value;
		}

		/// <summary>
		/// Gets the handle.
		/// </summary>
		/// <value>The handle.</value>
		public uint Value
		{
			get { return _value; }
		}

		/// <summary>
		/// Gets a value indicating whether this instance is valid.
		/// </summary>
		/// <value><c>true</c> if this instance is valid; otherwise, <c>false</c>.</value>
		public bool IsValid
		{
			get { return _value > 0; }
		}

		/// <summary>
		/// Gets the invalid.
		/// </summary>
		/// <value>The invalid.</value>
		public static Handle Invalid
		{
			get { return new Handle(); }
		}

		/// <summary>
		/// Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		/// <returns>
		/// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
		/// </returns>
		/// <param name="other">An object to compare with this object.</param>
		public bool Equals(Handle other)
		{
			return other._value == _value;
		}

		/// <summary>
		/// Indicates whether this instance and a specified object are equal.
		/// </summary>
		/// <returns>
		/// true if <paramref name="obj"/> and this instance are the same type and represent the same value; otherwise, false.
		/// </returns>
		/// <param name="obj">Another object to compare to. </param><filterpriority>2</filterpriority>
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (obj.GetType() != typeof (Handle)) return false;
			return Equals((Handle) obj);
		}

		/// <summary>
		/// Returns the hash code for this instance.
		/// </summary>
		/// <returns>
		/// A 32-bit signed integer that is the hash code for this instance.
		/// </returns>
		/// <filterpriority>2</filterpriority>
		public override int GetHashCode()
		{
			return _value.GetHashCode();
		}

		/// <summary>
		/// Implements the operator ==.
		/// </summary>
		/// <param name="left">The left.</param>
		/// <param name="right">The right.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(Handle left, Handle right)
		{
			return left.Equals(right);
		}

		/// <summary>
		/// Implements the operator !=.
		/// </summary>
		/// <param name="left">The left.</param>
		/// <param name="right">The right.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(Handle left, Handle right)
		{
			return !left.Equals(right);
		}
	}
}