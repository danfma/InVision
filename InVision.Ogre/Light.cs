using InVision.GameMath;
using InVision.Ogre.Native;

namespace InVision.Ogre
{
	public class Light : MovableObject
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Light"/> class.
		/// </summary>
		/// <param name="nativeInstance">The native instance.</param>
		public Light(IMovableObject nativeInstance)
			: base(nativeInstance)
		{
		}

		/// <summary>
		/// Gets the native.
		/// </summary>
		/// <value>The native.</value>
		public new ILight Native
		{
			get { return (ILight)base.Native; }
		}

		/// <summary>
		/// Gets or sets the position.
		/// </summary>
		/// <value>The position.</value>
		public Vector3 Position
		{
			get { return Native.GetPosition(); }
			set { Native.SetPosition(value); }
		}

		/// <summary>
		/// Sets the position.
		/// </summary>
		/// <param name="x">The x.</param>
		/// <param name="y">The y.</param>
		/// <param name="z">The z.</param>
		public void SetPosition(float x, float y, float z)
		{
			Native.SetPosition(x, y, z);
		}
	}
}