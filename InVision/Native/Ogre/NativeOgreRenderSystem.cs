using System;
using System.Runtime.InteropServices;

namespace InVision.Native.Ogre
{
	internal sealed class NativeOgreRenderSystem : PlatformInvoke
	{
		[DllImport(Library, EntryPoint = "rendersystem_get_name")]
		public static extern IntPtr _GetName(IntPtr pRenderSystem);

		/// <summary>
		/// 	Gets the name.
		/// </summary>
		/// <param name = "pRenderSystem">The p render system.</param>
		/// <returns></returns>
		public static string GetName(IntPtr pRenderSystem)
		{
			return _GetName(pRenderSystem).AsConstString();
		}
	}
}