using System;
using System.Runtime.InteropServices;

namespace InVision.Ogre3D.Native
{
	internal sealed class NativeMaterialManager : PlatformInvoke
	{
		[DllImport(Library, EntryPoint = "materialmng_get_singleton")]
		public static extern IntPtr _GetSingleton();

		[DllImport(Library, EntryPoint = "materialmng_set_default_texture_filtering")]
		public static extern void SetDefaultTextureFiltering(
			IntPtr self,
			[MarshalAs(UnmanagedType.U4)] TextureFilterOption option);

		[DllImport(Library, EntryPoint = "materialmng_set_default_anisotropy")]
		public static extern void SetDefaultAnisotropy(IntPtr self, uint value);

		[DllImport(Library, EntryPoint = "materialmng_get_default_anisotropy")]
		public static extern uint GetDefaultAnisotropy(IntPtr self);

		#region Helpers

		/// <summary>
		/// Gets the singleton.
		/// </summary>
		/// <returns></returns>
		public static MaterialManager GetSingleton()
		{
			return _GetSingleton().AsHandle(ptr => new MaterialManager(ptr, false));
		}

		#endregion
	}
}