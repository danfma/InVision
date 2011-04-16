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
}