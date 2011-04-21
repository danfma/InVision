using System;
using InVision.OIS.Native;

namespace InVision.OIS
{
	/// <summary>
	/// 
	/// </summary>
	public class Vector3Component : Component, IVector3Component
	{
		private Vector3Extended nativeRef;

		/// <summary>
		/// Initializes a new instance of the <see cref="Vector3Component"/> class.
		/// </summary>
		public Vector3Component(float x, float y, float z)
			: this(NativeVector3.New(x, y, z), true)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Vector3Component"/> class.
		/// </summary>
		/// <param name="nativeRef">The native ref.</param>
		/// <param name="ownsHandle">if set to <c>true</c> [owns handle].</param>
		internal Vector3Component(Vector3Extended nativeRef, bool ownsHandle = false)
			: base(nativeRef.BaseInfo, ownsHandle)
		{
			this.nativeRef = nativeRef;
		}

		#region IVector3Component Members

		/// <summary>
		/// Gets the X.
		/// </summary>
		/// <value>The X.</value>
		public float X
		{
			get { return nativeRef.X; }
		}

		/// <summary>
		/// Gets the Y.
		/// </summary>
		/// <value>The Y.</value>
		public float Y
		{
			get { return nativeRef.Y; }
		}

		/// <summary>
		/// Gets the Z.
		/// </summary>
		/// <value>The Z.</value>
		public float Z
		{
			get { return nativeRef.Z; }
		}

		#endregion

		/// <summary>
		/// Releases the valid handle.
		/// </summary>
		protected override void ReleaseValidHandle()
		{
			NativeVector3.Delete(handle);
			nativeRef = default(Vector3Extended);
		}
	}

	public class Vector3Proxy : ComponentProxy
	{
		private Vector3ProxyInfo proxyInfo;
		private Vector3ProxyInfo.VTable oldVTable;
		private Vector3ClearMethod clearMethod;

		/// <summary>
		/// Initializes a new instance of the <see cref="Vector3Proxy"/> class.
		/// </summary>
		/// <param name="x">The x.</param>
		/// <param name="y">The y.</param>
		/// <param name="z">The z.</param>
		public Vector3Proxy(float x, float y, float z)
			: base(true)
		{
			proxyInfo = NativeVector3.NewProxy(x, y, z);
			oldVTable = proxyInfo.CreateVTable();

			UpdateVTable(proxyInfo);
			SetHandle(proxyInfo.Base.Handle);
		}

		/// <summary>
		/// Updates the VTable.
		/// </summary>
		/// <param name="proxyInfo">The proxy info.</param>
		internal void UpdateVTable(Vector3ProxyInfo proxyInfo)
		{
			// holding local instances (preventing gc to collect them)
			clearMethod = self => Clear();

			// setting the new methods on the native side
			proxyInfo.ClearMethod = clearMethod; // updating vtable clearMethod
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Vector3Proxy"/> class.
		/// </summary>
		/// <param name="pSelf">The p self.</param>
		/// <param name="ownsHandle">if set to <c>true</c> [owns handle].</param>
		protected Vector3Proxy(IntPtr pSelf, bool ownsHandle)
			: base(pSelf, ownsHandle)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Vector3Proxy"/> class.
		/// </summary>
		/// <param name="ownsHandle">if set to <c>true</c> [owns handle].</param>
		protected Vector3Proxy(bool ownsHandle)
			: base(ownsHandle)
		{
		}

		/// <summary>
		/// Gets the X.
		/// </summary>
		/// <value>The X.</value>
		public float X
		{
			get { return proxyInfo.X; }
		}

		/// <summary>
		/// Gets the Y.
		/// </summary>
		/// <value>The Y.</value>
		public float Y
		{
			get { return proxyInfo.Y; }
		}

		/// <summary>
		/// Gets the Z.
		/// </summary>
		/// <value>The Z.</value>
		public float Z
		{
			get { return proxyInfo.Z; }
		}

		/// <summary>
		/// Clears this instance.
		/// </summary>
		public virtual void Clear()
		{
			oldVTable.ClearMethod(handle);
		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);

			if (disposing)
			{
				proxyInfo = default(Vector3ProxyInfo);
				oldVTable = default(Vector3ProxyInfo.VTable);
				clearMethod = null;
			}
		}

		/// <summary>
		/// Returns a <see cref="System.String"/> that represents this instance.
		/// </summary>
		/// <returns>
		/// A <see cref="System.String"/> that represents this instance.
		/// </returns>
		public override string ToString()
		{
			return string.Format("X: {0} Y: {1} Z: {2}", X, Y, Z);
		}
	}
}