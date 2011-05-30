using System.Runtime.InteropServices;
using InVision.GameMath;
using InVision.Native;

namespace InVision.Ogre.Native
{
	[OgreClass("SceneManager")]
	public interface ISceneManager : ICppInstance
	{
		[Method(Implemented = true)]
		void ClearScene();

		[Method(Implemented = true)]
		void SetAmbientLight(Color color);

		[Method(Implemented = true)]
		Color GetAmbientLight();

		[Method(Implemented = true)]
		ICamera CreateCamera([MarshalAs(UnmanagedType.LPStr)] string name);

		[Method(Implemented = true)]
		IEntity CreateEntity([MarshalAs(UnmanagedType.LPStr)] string meshName);

		[Method(Implemented = true)]
		IEntity CreateEntity([MarshalAs(UnmanagedType.LPStr)] string entityName, [MarshalAs(UnmanagedType.LPStr)] string meshName);

		[Method(Implemented = true)]
		ISceneNode GetRootSceneNode();

		[Method(Implemented = true)]
		ILight CreateLight();

		[Method(Implemented = true)]
		ILight CreateLight([MarshalAs(UnmanagedType.LPStr)] string name);
	}
}