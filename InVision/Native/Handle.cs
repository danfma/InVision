using System;
using System.Runtime.InteropServices;

namespace InVision.Native
{
	public abstract class Handle : SafeHandle, IEquatable<Handle>
	{
		/// <summary>
		/// 	Initializes a new instance of the <see cref = "Handle" /> class.
		/// </summary>
		/// <param name = "pSelf">The p self.</param>
		/// <param name = "ownsHandle">if set to <c>true</c> [owns handle].</param>
		protected Handle(IntPtr pSelf, bool ownsHandle = false)
			: base(IntPtr.Zero, ownsHandle)
		{
			SetHandle(pSelf);
			OwnsHandle = ownsHandle;

			if (ownsHandle)
				this.RegisterHandle();
		}

		/// <summary>
		/// 	Initializes a new instance of the <see cref = "Handle" /> class.
		/// </summary>
		/// <param name = "ownsHandle">if set to <c>true</c> [owns handle].</param>
		protected Handle(bool ownsHandle = true)
			: base(IntPtr.Zero, ownsHandle)
		{
			OwnsHandle = ownsHandle;
		}

		/// <summary>
		/// 	Gets or sets a value indicating whether [owns handle].
		/// </summary>
		/// <value><c>true</c> if [owns handle]; otherwise, <c>false</c>.</value>
		protected bool OwnsHandle { get; private set; }


		/// <summary>
		/// 	When overridden in a derived class, gets a value indicating whether the handle value is invalid.
		/// </summary>
		/// <value></value>
		/// <returns>true if the handle value is invalid; otherwise, false.</returns>
		/// <PermissionSet>
		/// 	<IPermission class = "System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version = "1" Flags = "UnmanagedCode" />
		/// </PermissionSet>
		public override bool IsInvalid
		{
			get { return handle == IntPtr.Zero; }
		}

		#region IEquatable<Handle> Members

		/// <summary>
		/// 	Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		/// <returns>
		/// 	true if the current object is equal to the <paramref name = "other" /> parameter; otherwise, false.
		/// </returns>
		/// <param name = "other">An object to compare with this object.</param>
		public bool Equals(Handle other)
		{
			return !ReferenceEquals(null, other);
		}

		#endregion

		/// <summary>
		/// 	Gives up handle ownership.
		/// </summary>
		internal void GiveUpHandleOwnership()
		{
			OwnsHandle = false;
		}

		/// <summary>
		/// 	Releases the unmanaged resources used by the <see cref = "T:System.Runtime.InteropServices.SafeHandle" /> class specifying whether to perform a normal dispose operation.
		/// </summary>
		/// <param name = "disposing">true for a normal dispose operation; false to finalize the handle.</param>
		protected override void Dispose(bool disposing)
		{
			if (OwnsHandle)
				this.UnregisterHandle();

			base.Dispose(disposing);
		}

		/// <summary>
		/// 	When overridden in a derived class, executes the code required to free the handle.
		/// </summary>
		/// <returns>
		/// 	true if the handle is released successfully; otherwise, in the event of a catastrophic failure, false. In this case, it generates a releaseHandleFailed MDA Managed Debugging Assistant.
		/// </returns>
		protected override bool ReleaseHandle()
		{
			if (IsInvalid)
				return true;

			if (!OwnsHandle)
				return true;

			try
			{
				ReleaseValidHandle();
				return true;
			}
			catch
			{
				return false;
			}
		}

		/// <summary>
		/// Releases the valid handle.
		/// </summary>
		protected abstract void ReleaseValidHandle();

		/// <summary>
		/// 	Determines whether the specified <see cref = "System.Object" /> is equal to this instance.
		/// </summary>
		/// <param name = "obj">The <see cref = "System.Object" /> to compare with this instance.</param>
		/// <returns>
		/// 	<c>true</c> if the specified <see cref = "System.Object" /> is equal to this instance; otherwise, <c>false</c>.
		/// </returns>
		public override bool Equals(object obj)
		{
			return obj is Handle && handle == ((Handle) obj).handle;
		}

		/// <summary>
		/// 	Serves as a hash function for a particular type.
		/// </summary>
		/// <returns>
		/// 	A hash code for the current <see cref = "T:System.Object" />.
		/// </returns>
		/// <filterpriority>2</filterpriority>
		public override int GetHashCode()
		{
			return handle.GetHashCode();
		}

		/// <summary>
		/// 	Implements the operator ==.
		/// </summary>
		/// <param name = "left">The left.</param>
		/// <param name = "right">The right.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(Handle left, Handle right)
		{
			return Equals(left, right);
		}

		/// <summary>
		/// 	Implements the operator !=.
		/// </summary>
		/// <param name = "left">The left.</param>
		/// <param name = "right">The right.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(Handle left, Handle right)
		{
			return !Equals(left, right);
		}
	}
}