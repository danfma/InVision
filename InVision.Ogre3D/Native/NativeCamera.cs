using System;
using System.Runtime.InteropServices;
using OpenTK;

namespace InVision.Ogre3D.Native
{
	internal sealed class NativeCamera : PlatformInvoke
	{
		[DllImport(Library, EntryPoint = "CamDelete")]
		public static extern void Delete(IntPtr pCamera);

		[DllImport(Library, EntryPoint = "CamGetAspectRatio")]
		public static extern float GetAspectRatio(IntPtr pCamera);

		[DllImport(Library, EntryPoint = "CamSetAspectRatio")]
		public static extern void SetAspectRatio(IntPtr pCamera, float aspectRatio);

		[DllImport(Library, EntryPoint = "CamGetFOVy")]
		public static extern float GetFOVy(IntPtr pCamera);

		[DllImport(Library, EntryPoint = "CamSetFOVy")]
		public static extern void SetFOVy(IntPtr pCamera, float aspectRatio);

		[DllImport(Library, EntryPoint = "CamGetNearClipDistance")]
		public static extern float GetNearClipDistance(IntPtr pCamera);

		[DllImport(Library, EntryPoint = "CamSetNearClipDistance")]
		public static extern void SetNearClipDistance(IntPtr pCamera, float radians);

		[DllImport(Library, EntryPoint = "CamGetFarClipDistance")]
		public static extern float GetFarClipDistance(IntPtr pCamera);

		[DllImport(Library, EntryPoint = "CamSetFarClipDistance")]
		public static extern void SetFarClipDistance(IntPtr pCamera, float radians);

		[DllImport(Library, EntryPoint = "CamGetPolygonMode")]
		[return: MarshalAs(UnmanagedType.U4)]
		public static extern PolygonMode GetPolygonMode(IntPtr pCamera);

		[DllImport(Library, EntryPoint = "CamSetPolygonMode")]
		public static extern void SetPolygonMode(IntPtr pCamera, [MarshalAs(UnmanagedType.U4)] PolygonMode mode);

		[DllImport(Library, EntryPoint = "CamGetPosition")]
		public static extern Vector3 GetPosition(IntPtr pCamera);

		[DllImport(Library, EntryPoint = "CamSetPosition")]
		public static extern void SetPosition(IntPtr pCamera, Vector3 mode);
	}
}