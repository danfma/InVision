using System;
using InVision.Ogre3D.Native;

namespace InVision.Ogre3D
{
	public class SceneManager : Handle
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="SceneManager"/> class.
		/// </summary>
		/// <param name="pSelf">The p self.</param>
		/// <param name="ownsHandle">if set to <c>true</c> [owns handle].</param>
		public SceneManager(IntPtr pSelf, bool ownsHandle = false)
			: base(pSelf, ownsHandle)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="SceneManager"/> class.
		/// </summary>
		/// <param name="ownsHandle">if set to <c>true</c> [owns handle].</param>
		public SceneManager(bool ownsHandle = true)
			: base(ownsHandle)
		{
		}

		/// <summary>
		/// Releases the specified pointer to the unmanaged object.
		/// </summary>
		/// <param name="pSelf">The pointer to the unmanaged object.</param>
		/// <returns></returns>
		protected override bool Release(IntPtr pSelf)
		{
			NativeSceneManager.Delete(pSelf);
			return true;
		}

		/// <summary>
		/// Creates the camera.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <returns></returns>
		public Camera CreateCamera(string name)
		{
			return NativeSceneManager.CreateCamera(handle, name);
		}
	}
}