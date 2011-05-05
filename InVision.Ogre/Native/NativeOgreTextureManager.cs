using System;
using System.Runtime.InteropServices;

namespace InVision.Ogre.Native
{
	internal sealed class NativeOgreTextureManager : PlatformInvoke
	{
		[DllImport(Library, EntryPoint = "texmanager_get_instance")]
		public static extern IntPtr _GetInstance();



		[DllImport(Library, EntryPoint = "texmanager_get_default_num_mipmaps")]
		public static extern int GetDefaultNumMipmaps(IntPtr handle);

		[DllImport(Library, EntryPoint = "texmanager_set_default_num_mipmaps")]
		public static extern void SetDefaultNumMipmaps(IntPtr handle, int numMipmaps);

		[DllImport(Library, EntryPoint = "texmanager_reload_all")]
		public static extern void ReloadAll(IntPtr handle, bool reloadableOnly);


		#region Helpers

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <returns></returns>
		public static TextureManager GetInstance()
		{
			return _GetInstance().AsHandle(ptr => new TextureManager(ptr, false));
		}

		#endregion
	}
}