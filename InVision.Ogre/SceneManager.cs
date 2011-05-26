using InVision.Native;
using InVision.Ogre.Native;

namespace InVision.Ogre
{
	public class SceneManager : CppWrapper<ISceneManager>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="SceneManager"/> class.
		/// </summary>
		/// <param name="nativeInstance">The native instance.</param>
		public SceneManager(ISceneManager nativeInstance)
			: base(nativeInstance)
		{
		}
	}
}