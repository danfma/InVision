using InVision.Native;
using InVision.Ogre.Native;

namespace InVision.Ogre
{
	public class Node : CppWrapper<INode>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Node"/> class.
		/// </summary>
		/// <param name="nativeInstance">The native instance.</param>
		public Node(INode nativeInstance)
			: base(nativeInstance)
		{
		}
	}
}