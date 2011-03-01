using System;
using System.Runtime.InteropServices;
using InVision.Rendering;

namespace InVision.Native.Ogre
{
	internal sealed class NativeOverlayManager : PlatformInvoke
	{
		/// <summary>
		/// 	Natives the ogre material manager.
		/// </summary>
		static NativeOverlayManager()
		{
			Init();
		}

		[DllImport(Library, EntryPoint = "ogre_delete_overlaymanager")]
		public static extern void Delete(IntPtr self);

		[DllImport(Library, EntryPoint = "ogre_overlaymanager_get_singleton")]
		public static extern IntPtr _GetSingleton();

		[DllImport(Library, EntryPoint = "ogre_overlaymanager_create")]
		public static extern IntPtr _Create(
			IntPtr pOverlayManager,
			[MarshalAs(UnmanagedType.LPStr)] string name);

		[DllImport(Library, EntryPoint = "ogre_overlaymanager_get_by_name")]
		public static extern IntPtr _GetByName(
			IntPtr pOverlayManager,
			[MarshalAs(UnmanagedType.LPStr)] string name);

		[DllImport(Library, EntryPoint = "ogre_overlaymanager_get_overlayelement")]
		public static extern IntPtr _GetOverlayElement(
			IntPtr pOverlayManager,
			[MarshalAs(UnmanagedType.LPStr)] string name,
			[MarshalAs(UnmanagedType.Bool)] bool isTemplate);

		#region Helpers

		public static OverlayManager GetSingleton()
		{
			return _GetSingleton().AsHandle(ptr => new OverlayManager(ptr, false));
		}

		public static Overlay Create(IntPtr pOverlayManager, string name)
		{
			return _Create(pOverlayManager, name).AsHandle(ptr => new Overlay(ptr, false));
		}

		public static Overlay GetByName(IntPtr pOverlayManager, string name)
		{
			return _GetByName(pOverlayManager, name).AsHandle(ptr => new Overlay(ptr, false));
		}

		public static OverlayElement GetOverlayElement(IntPtr handle, string name, bool isTemplate)
		{
			return _GetOverlayElement(handle, name, isTemplate).AsHandle(ptr => new OverlayElement(ptr, false));
		}

		#endregion
	}
}