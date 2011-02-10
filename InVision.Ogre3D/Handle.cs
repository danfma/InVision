using System;
using System.Runtime.InteropServices;

namespace InVision.Ogre3D
{
	public abstract class Handle : SafeHandle
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
		}

		/// <summary>
		/// 	Initializes a new instance of the <see cref = "Handle" /> class.
		/// </summary>
		/// <param name = "ownsHandle">if set to <c>true</c> [owns handle].</param>
		protected Handle(bool ownsHandle = true)
			: base(IntPtr.Zero, ownsHandle)
		{
		}

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

			return Release(handle);
		}

		/// <summary>
		/// 	Releases the specified pointer to the unmanaged object.
		/// </summary>
		/// <param name = "pSelf">The pointer to the unmanaged object.</param>
		/// <returns></returns>
		protected abstract bool Release(IntPtr pSelf);
	}
}