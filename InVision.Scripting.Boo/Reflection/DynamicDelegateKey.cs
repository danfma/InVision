using System;
using Mono.Simd;

namespace InVision.Scripting.Boo.Reflection
{
	public struct DynamicDelegateKey : IEquatable<DynamicDelegateKey>
	{
		private readonly Vector4i _bits128;
		private readonly int _bits32;

		/// <summary>
		/// Initializes a new instance of the <see cref="DynamicDelegateKey"/> struct.
		/// </summary>
		/// <param name="bytes">The bytes.</param>
		public DynamicDelegateKey(byte[] bytes)
		{
			_bits128 = new Vector4i(
				BitConverter.ToInt32(bytes, 0),
				BitConverter.ToInt32(bytes, 4),
				BitConverter.ToInt32(bytes, 8),
				BitConverter.ToInt32(bytes, 12));

			_bits32 = BitConverter.ToInt32(bytes, 16);
		}

		#region IEquatable<DynamicDelegateKey> Members

		/// <summary>
		/// Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		/// <returns>
		/// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
		/// </returns>
		/// <param name="other">An object to compare with this object.</param>
		public bool Equals(DynamicDelegateKey other)
		{
			return other._bits128.Equals(_bits128) && other._bits32 == _bits32;
		}

		#endregion

		/// <summary>
		/// Indicates whether this instance and a specified object are equal.
		/// </summary>
		/// <returns>
		/// true if <paramref name="obj"/> and this instance are the same type and represent the same value; otherwise, false.
		/// </returns>
		/// <param name="obj">Another object to compare to. </param><filterpriority>2</filterpriority>
		public override bool Equals(object obj)
		{
			return Equals((DynamicDelegateKey)obj);
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
			unchecked
			{
				return (_bits128.GetHashCode() * 397) ^ _bits32;
			}
		}

		/// <summary>
		/// Implements the operator ==.
		/// </summary>
		/// <param name="left">The left.</param>
		/// <param name="right">The right.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(DynamicDelegateKey left, DynamicDelegateKey right)
		{
			return left.Equals(right);
		}

		/// <summary>
		/// Implements the operator !=.
		/// </summary>
		/// <param name="left">The left.</param>
		/// <param name="right">The right.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(DynamicDelegateKey left, DynamicDelegateKey right)
		{
			return !left.Equals(right);
		}
	}
}