using InVision.Native;
using InVision.Ogre.Native;

namespace InVision.Ogre
{
	public class StringInterface : CppWrapper<IStringInterface>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="StringInterface"/> class.
		/// </summary>
		/// <param name="nativeInstance">The native instance.</param>
		public StringInterface(IStringInterface nativeInstance) : base(nativeInstance)
		{
		}
	}
}