using InVision.Native;
using InVision.Ogre.Native;

namespace InVision.Ogre
{
	public class SceneManagerFactory : CppWrapper<ISceneManagerFactory>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="SceneManagerFactory"/> class.
		/// </summary>
		/// <param name="nativeInstance">The native instance.</param>
		public SceneManagerFactory(ISceneManagerFactory nativeInstance)
			: base(nativeInstance)
		{
		}
	}
}