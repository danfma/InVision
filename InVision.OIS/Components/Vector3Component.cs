using InVision.OIS.Native;

namespace InVision.OIS.Components
{
	/// <summary>
	/// 
	/// </summary>
	public class Vector3Component : Component
	{
		private Vector3Descriptor _descriptor;

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
		/// <param name="descriptor">The native ref.</param>
		/// <param name="ownsHandle">if set to <c>true</c> [owns handle].</param>
		internal Vector3Component(Vector3Descriptor descriptor, bool ownsHandle = false)
			: base(descriptor.Base, ownsHandle)
		{
			_descriptor = descriptor;
		}

		/// <summary>
		/// Gets the X.
		/// </summary>
		/// <value>The X.</value>
		public float X
		{
			get { return _descriptor.X; }
		}

		/// <summary>
		/// Gets the Y.
		/// </summary>
		/// <value>The Y.</value>
		public float Y
		{
			get { return _descriptor.Y; }
		}

		/// <summary>
		/// Gets the Z.
		/// </summary>
		/// <value>The Z.</value>
		public float Z
		{
			get { return _descriptor.Z; }
		}

		/// <summary>
		/// Releases the valid handle.
		/// </summary>
		protected override void DeleteHandle()
		{
			NativeVector3.Delete(SelfHandle);
			_descriptor = default(Vector3Descriptor);
		}
	}
}