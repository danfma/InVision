using InVision.Native;
using InVision.Ogre.Native;

namespace InVision.Ogre
{
	public class EdgeData : CppWrapper<Native.IEdgeData>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="EdgeData"/> class.
		/// </summary>
		/// <param name="nativeInstance">The native instance.</param>
		public EdgeData(IEdgeData nativeInstance)
			: base(nativeInstance)
		{
		}
	}
}