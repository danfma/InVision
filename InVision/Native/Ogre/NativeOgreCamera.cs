using System;
using System.Runtime.InteropServices;
using InVision.Rendering;
using InVision.GameMath;

namespace InVision.Native.Ogre
{
	internal sealed class NativeOgreCamera : PlatformInvoke
	{
		[DllImport(Library, EntryPoint = "camera_delete")]
		public static extern void Delete(IntPtr pCamera);

		[DllImport(Library, EntryPoint = "camera_get_aspect_ratio")]
		public static extern float GetAspectRatio(IntPtr pCamera);

		[DllImport(Library, EntryPoint = "camera_set_aspect_ratio")]
		public static extern void SetAspectRatio(IntPtr pCamera, float aspectRatio);

		[DllImport(Library, EntryPoint = "camera_get_fovy")]
		public static extern float GetFOVy(IntPtr pCamera);

		[DllImport(Library, EntryPoint = "camera_set_fovy")]
		public static extern void SetFOVy(IntPtr pCamera, float aspectRatio);

		[DllImport(Library, EntryPoint = "camera_get_near_clip_distance")]
		public static extern float GetNearClipDistance(IntPtr pCamera);

		[DllImport(Library, EntryPoint = "camera_set_near_clip_distance")]
		public static extern void SetNearClipDistance(IntPtr pCamera, float radians);

		[DllImport(Library, EntryPoint = "camera_get_far_clip_distance")]
		public static extern float GetFarClipDistance(IntPtr pCamera);

		[DllImport(Library, EntryPoint = "camera_set_far_clip_distance")]
		public static extern void SetFarClipDistance(IntPtr pCamera, float radians);

		[DllImport(Library, EntryPoint = "camera_get_polyon_mode")]
		[return: MarshalAs(UnmanagedType.U4)]
		public static extern PolygonMode GetPolygonMode(IntPtr pCamera);

		[DllImport(Library, EntryPoint = "camera_set_polygon_mode")]
		public static extern void SetPolygonMode(IntPtr pCamera, [MarshalAs(UnmanagedType.U4)] PolygonMode mode);

		[DllImport(Library, EntryPoint = "camera_get_position")]
		public static extern Vector3 GetPosition(IntPtr pCamera);

		[DllImport(Library, EntryPoint = "camera_set_position")]
		public static extern void SetPosition(IntPtr pCamera, Vector3 mode);

		[DllImport(Library, EntryPoint = "camera_move")]
		public static extern void Move(IntPtr pCamera, Vector3 distance);

		[DllImport(Library, EntryPoint = "camera_move_relative")]
		public static extern void MoveRelative(IntPtr pCamera, Vector3 distance);

		[DllImport(Library, EntryPoint = "camera_set_auto_aspect_ratio")]
		public static extern void SetAutoAspectRatio(IntPtr pCamera, [MarshalAs(UnmanagedType.Bool)] bool autoRatio);

		[DllImport(Library, EntryPoint = "camera_get_direction")]
		public static extern Vector3 GetDirection(IntPtr pCamera);

		[DllImport(Library, EntryPoint = "camera_set_direction")]
		public static extern void SetDirection(IntPtr pCamera, Vector3 direction);

		[DllImport(Library, EntryPoint = "camera_get_up")]
		public static extern Vector3 GetUp(IntPtr pCamera);

		[DllImport(Library, EntryPoint = "camera_set_right")]
		public static extern Vector3 GetRight(IntPtr pCamera);

		[DllImport(Library, EntryPoint = "camera_look_at")]
		public static extern void LookAt(IntPtr pCamera, Vector3 target);

		[DllImport(Library, EntryPoint = "camera_look_at_3f")]
		public static extern void LookAt(IntPtr pCamera, float x, float y, float z);

		[DllImport(Library, EntryPoint = "camera_roll")]
		public static extern void Roll(IntPtr pCamera, float radians);

		[DllImport(Library, EntryPoint = "camera_yaw")]
		public static extern void Yaw(IntPtr pCamera, float radians);

		[DllImport(Library, EntryPoint = "camera_pitch")]
		public static extern void Pitch(IntPtr pCamera, float radians);

		[DllImport(Library, EntryPoint = "camera_rotate")]
		public static extern void Rotate(IntPtr pCamera, Vector3 axis, float radians);

		[DllImport(Library, EntryPoint = "camera_rotate_by_quaternion")]
		public static extern void Rotate(IntPtr pCamera, Quaternion quaternion);

		[DllImport(Library, EntryPoint = "camera_set_fixed_yaw_axis2")]
		public static extern void SetFixedYawAxis(IntPtr pCamera, bool useFixed);

		[DllImport(Library, EntryPoint = "camera_set_fixed_yaw_axis")]
		public static extern void SetFixedYawAxis(IntPtr pCamera, bool useFixed, Vector3 fixedAxis);

		[DllImport(Library, EntryPoint = "camera_get_orientation")]
		public static extern Quaternion GetOrientation(IntPtr pCamera);

		[DllImport(Library, EntryPoint = "camera_set_direction")]
		public static extern void SetOrientation(IntPtr pCamera, Quaternion orientation);

		[DllImport(Library, EntryPoint = "camera_set_auto_tracking3")]
		public static extern void SetAutoTracking(IntPtr pCamera, bool enabled);

		[DllImport(Library, EntryPoint = "camera_set_auto_tracking2")]
		public static extern void SetAutoTracking(IntPtr pCamera, bool enabled, IntPtr target);

		[DllImport(Library, EntryPoint = "camera_set_auto_tracking")]
		public static extern void SetAutoTracking(IntPtr pCamera, bool enabled, IntPtr target, Vector3 offset);
	}
}