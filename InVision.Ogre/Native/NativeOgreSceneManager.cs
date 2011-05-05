using System;
using System.Runtime.InteropServices;

namespace InVision.Ogre.Native
{
	internal sealed class NativeOgreSceneManager : PlatformInvoke
	{
		[DllImport(Library, EntryPoint = "scenemanager_delete")]
		public static extern void Delete(IntPtr pSceneManager);

		[DllImport(Library, EntryPoint = "scenemanager_create_camera")]
		public static extern IntPtr _CreateCamera(IntPtr pSceneManager, string name);

		/// <summary>
		/// 	Creates the camera.
		/// </summary>
		/// <param name = "pSceneManager">The p scene manager.</param>
		/// <param name = "name">The name.</param>
		/// <returns></returns>
		public static Camera CreateCamera(IntPtr pSceneManager, string name)
		{
			return _CreateCamera(pSceneManager, name).
				AsHandle(pCamera => new Camera(pCamera));
		}
	}
}