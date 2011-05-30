using InVision.Ogre.Native;

namespace InVision.Ogre
{
	public class Frustum : MovableObject
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Frustum"/> class.
		/// </summary>
		/// <param name="native">The native.</param>
		protected Frustum(IFrustum native)
			: base(native)
		{

		}

		/// <summary>
		/// Gets the native.
		/// </summary>
		/// <value>The native.</value>
		public new IFrustum Native
		{
			get { return (IFrustum) base.Native; }
		}
	}
}