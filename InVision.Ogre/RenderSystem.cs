using InVision.Native;
using InVision.Ogre.Native;

namespace InVision.Ogre
{
	public class RenderSystem : CppWrapper<IRenderSystem>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="RenderSystem"/> class.
		/// </summary>
		/// <param name="nativeInstance">The native instance.</param>
		public RenderSystem(IRenderSystem nativeInstance)
			: base(nativeInstance)
		{
		}
	}
}