using System.Runtime.InteropServices;
using InVision.GameMath;
using InVision.Native;

namespace InVision.Ogre.Native
{
	[OgreInterface("SceneManager")]
	public interface ISceneManager : ICppInterface
	{
		[Method]
		void ClearScene();

		[Method]
		void SetAmbientLight(Color color);

		[Method]
		Color GetAmbientLight();

		[Method]
		ICamera CreateCamera([MarshalAs(UnmanagedType.LPStr)] string name);
	}
}