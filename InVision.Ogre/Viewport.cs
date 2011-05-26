using InVision.Native;
using InVision.Ogre.Native;

namespace InVision.Ogre
{
	public class Viewport : CppWrapper<IViewport>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Viewport"/> class.
		/// </summary>
		/// <param name="nativeInstance">The native instance.</param>
		public Viewport(IViewport nativeInstance)
			: base(nativeInstance)
		{
		}
	}
}