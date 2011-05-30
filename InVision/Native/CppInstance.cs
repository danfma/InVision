using System;
using System.Diagnostics;

namespace InVision.Native
{
	public abstract class CppInstance : IEquatable<CppInstance>, ICppInstance
	{
		/// <summary>
		/// Gets or sets the self.
		/// </summary>
		/// <value>The self.</value>
		public Handle Self { get; set; }

		/// <summary>
		/// Sets the owner.
		/// </summary>
		/// <param name="owner">The owner.</param>
		public void SetOwner(object owner)
		{
			CppWrapper.RegisterOwnership(this, owner);
		}

		/// <summary>
		/// Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns>
		/// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
		/// </returns>
		public bool Equals(CppInstance other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return other.Self.Equals(Self);
		}

		/// <summary>
		/// Determines whether the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>.
		/// </summary>
		/// <returns>
		/// true if the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>; otherwise, false.
		/// </returns>
		/// <param name="obj">The <see cref="T:System.Object"/> to compare with the current <see cref="T:System.Object"/>. </param><filterpriority>2</filterpriority>
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (!(obj is CppInstance)) return false;

			return Equals((CppInstance)obj);
		}

		/// <summary>
		/// Serves as a hash function for a particular type. 
		/// </summary>
		/// <returns>
		/// A hash code for the current <see cref="T:System.Object"/>.
		/// </returns>
		/// <filterpriority>2</filterpriority>
		public override int GetHashCode()
		{
			return Self.GetHashCode();
		}

		/// <summary>
		/// Implements the operator ==.
		/// </summary>
		/// <param name="left">The left.</param>
		/// <param name="right">The right.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(CppInstance left, CppInstance right)
		{
			return Equals(left, right);
		}

		/// <summary>
		/// Implements the operator !=.
		/// </summary>
		/// <param name="left">The left.</param>
		/// <param name="right">The right.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(CppInstance left, CppInstance right)
		{
			return !Equals(left, right);
		}

		/// <summary>
		/// Checks the static only call.
		/// </summary>
		protected void CheckStaticOnlyCall()
		{
#if DEBUG
			Debug.Assert(!Self.IsValid, "Can not call a static method");
#endif
		}

		/// <summary>
		/// Checks the member only call.
		/// </summary>
		protected void CheckMemberOnlyCall()
		{
#if DEBUG
			Debug.Assert(Self.IsValid, "Can not call a member method");
#endif
		}
	}
}