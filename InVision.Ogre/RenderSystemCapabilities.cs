using InVision.Native;
using InVision.Ogre.Native;

namespace InVision.Ogre
{
	public class RenderSystemCapabilities : CppWrapper<IRenderSystemCapabilities>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="RenderSystemCapabilities"/> class.
		/// </summary>
		/// <param name="nativeInstance">The native instance.</param>
		public RenderSystemCapabilities(IRenderSystemCapabilities nativeInstance)
			: base(nativeInstance)
		{
		}
	}
}