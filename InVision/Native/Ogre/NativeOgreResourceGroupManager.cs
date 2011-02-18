using System;
using System.Runtime.InteropServices;
using InVision.Rendering;

namespace InVision.Native.Ogre
{
	internal sealed class NativeOgreResourceGroupManager : PlatformInvoke
	{
		[DllImport(Library, EntryPoint = "resgroupmng_get_singleton")]
		public static extern IntPtr _GetSingleton();

		[DllImport(Library, EntryPoint = "resgroupmng_initialise_all_resource_groups")]
		public static extern void InitialiseAllResourceGroups(IntPtr pSelf);

		[DllImport(Library, EntryPoint = "resgroupmng_add_resource_location")]
		public static extern void AddResourceLocation(
			IntPtr pSelf,
			[MarshalAs(UnmanagedType.LPStr)] string name,
			[MarshalAs(UnmanagedType.LPStr)] string locationType,
			[MarshalAs(UnmanagedType.LPStr)] string resourceGroup,
			[MarshalAs(UnmanagedType.Bool)] bool recursive);

		#region Helpers

		/// <summary>
		/// Gets the singleton.
		/// </summary>
		/// <returns></returns>
		public static ResourceGroupManager GetSingleton()
		{
			return _GetSingleton().AsHandle(ptr => new ResourceGroupManager(ptr, false));
		}

		#endregion
	}
}