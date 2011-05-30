using InVision.Native;
using InVision.Ogre.Native;

namespace InVision.Ogre
{
	public class RenderTarget : CppWrapper<IRenderTarget>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="RenderTarget"/> class.
		/// </summary>
		/// <param name="nativeInstance">The native instance.</param>
		public RenderTarget(IRenderTarget nativeInstance) : base(nativeInstance)
		{
		}
	}
}