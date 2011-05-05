using System;
using InVision.Native;
using InVision.Ogre.Native;

namespace InVision.Ogre
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
		/// <returns></returns>
		protected override void ReleaseValidHandle()
		{
			NativeOgreSceneManager.Delete(handle);
		}

		/// <summary>
		/// Creates the camera.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <returns></returns>
		public Camera CreateCamera(string name)
		{
			return NativeOgreSceneManager.CreateCamera(handle, name);
		}
	}
}