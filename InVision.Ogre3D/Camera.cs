using System;
using InVision.GameMath;
using InVision.Ogre3D.Native;

namespace InVision.Ogre3D
{
	/// <summary>
	/// </summary>
	public class Camera : Handle
	{
		/// <summary>
		/// 	Initializes a new instance of the <see cref = "Camera" /> class.
		/// </summary>
		/// <param name = "pSelf">The p self.</param>
		/// <param name = "ownsHandle">if set to <c>true</c> [owns handle].</param>
		public Camera(IntPtr pSelf, bool ownsHandle = false)
			: base(pSelf, ownsHandle)
		{
		}

		/// <summary>
		/// 	Initializes a new instance of the <see cref = "Camera" /> class.
		/// </summary>
		/// <param name = "ownsHandle">if set to <c>true</c> [owns handle].</param>
		public Camera(bool ownsHandle = true)
			: base(ownsHandle)
		{
		}

		/// <summary>
		/// 	Gets or sets the aspect ratio.
		/// </summary>
		/// <value>The aspect ratio.</value>
		public float AspectRatio
		{
			get { return NativeCamera.GetAspectRatio(handle); }
			set { NativeCamera.SetAspectRatio(handle, value); }
		}

		/// <summary>
		/// 	Gets or sets the Field of view y.
		/// </summary>
		/// <value>The FO vy.</value>
		public Radian FOVy
		{
			get { return (Radian)NativeCamera.GetFOVy(handle); }
			set { NativeCamera.SetFOVy(handle, value.ValueRadians); }
		}

		/// <summary>
		/// 	Gets or sets the near clip distance.
		/// </summary>
		/// <value>The near clip distance.</value>
		public float NearClipDistance
		{
			get { return NativeCamera.GetNearClipDistance(handle); }
			set { NativeCamera.SetNearClipDistance(handle, value); }
		}

		/// <summary>
		/// 	Gets or sets the far clip distance.
		/// </summary>
		/// <value>The far clip distance.</value>
		public float FarClipDistance
		{
			get { return NativeCamera.GetFarClipDistance(handle); }
			set { NativeCamera.SetFarClipDistance(handle, value); }
		}

		/// <summary>
		/// 	Gets or sets the polygon mode.
		/// </summary>
		/// <value>The polygon mode.</value>
		public PolygonMode PolygonMode
		{
			get { return NativeCamera.GetPolygonMode(handle); }
			set { NativeCamera.SetPolygonMode(handle, value); }
		}

		/// <summary>
		/// 	Gets or sets the position.
		/// </summary>
		/// <value>The position.</value>
		public Vector3 Position
		{
			get { return NativeCamera.GetPosition(handle); }
			set { NativeCamera.SetPosition(handle, value); }
		}

		/// <summary>
		/// 	Gets or sets the direction.
		/// </summary>
		/// <value>The direction.</value>
		public Vector3 Direction
		{
			get { return NativeCamera.GetDirection(handle); }
			set { NativeCamera.SetDirection(handle, value); }
		}

		/// <summary>
		/// 	Gets up.
		/// </summary>
		/// <value>Up.</value>
		public Vector3 Up
		{
			get { return NativeCamera.GetUp(handle); }
		}

		/// <summary>
		/// 	Gets the right.
		/// </summary>
		/// <value>The right.</value>
		public Vector3 Right
		{
			get { return NativeCamera.GetRight(handle); }
		}

		/// <summary>
		/// 	Gets or sets the orientation.
		/// </summary>
		/// <value>The orientation.</value>
		public Quaternion Orientation
		{
			get { return NativeCamera.GetOrientation(handle); }
			set { NativeCamera.SetOrientation(handle, value); }
		}

		/// <summary>
		/// 	Releases the specified pointer to the unmanaged object.
		/// </summary>
		/// <param name = "pSelf">The pointer to the unmanaged object.</param>
		/// <returns></returns>
		protected override bool Release(IntPtr pSelf)
		{
			NativeCamera.Delete(pSelf);
			return true;
		}

		/// <summary>
		/// 	Moves the specified distance.
		/// </summary>
		/// <param name = "distance">The distance.</param>
		public void Move(Vector3 distance)
		{
			NativeCamera.Move(handle, distance);
		}

		/// <summary>
		/// 	Moves the specified x.
		/// </summary>
		/// <param name = "x">The x.</param>
		/// <param name = "y">The y.</param>
		/// <param name = "z">The z.</param>
		public void Move(float x, float y, float z)
		{
			Move(new Vector3(x, y, z));
		}

		/// <summary>
		/// 	Moves the relative.
		/// </summary>
		/// <param name = "distance">The distance.</param>
		public void MoveRelative(Vector3 distance)
		{
			NativeCamera.MoveRelative(handle, distance);
		}

		/// <summary>
		/// 	Moves the relative.
		/// </summary>
		/// <param name = "x">The x.</param>
		/// <param name = "y">The y.</param>
		/// <param name = "z">The z.</param>
		public void MoveRelative(float x, float y, float z)
		{
			MoveRelative(new Vector3(x, y, z));
		}

		/// <summary>
		/// 	Sets the auto aspect ratio.
		/// </summary>
		/// <param name = "autoRatio">if set to <c>true</c> [auto ratio].</param>
		public void SetAutoAspectRatio(bool autoRatio)
		{
			NativeCamera.SetAutoAspectRatio(handle, autoRatio);
		}

		/// <summary>
		/// 	Looks at.
		/// </summary>
		/// <param name = "target">The target.</param>
		public void LookAt(Vector3 target)
		{
			NativeCamera.LookAt(handle, target);
		}

		/// <summary>
		/// 	Looks at.
		/// </summary>
		/// <param name = "x">The x.</param>
		/// <param name = "y">The y.</param>
		/// <param name = "z">The z.</param>
		public void LookAt(float x, float y, float z)
		{
			NativeCamera.LookAt(handle, x, y, z);
		}

		/// <summary>
		/// 	Rolls the specified radians.
		/// </summary>
		/// <param name = "radians">The radians.</param>
		public void Roll(Radian radians)
		{
			NativeCamera.Roll(handle, radians.ValueRadians);
		}

		/// <summary>
		/// 	Rolls the specified radians.
		/// </summary>
		/// <param name = "radians">The radians.</param>
		public void Roll(float radians)
		{
			NativeCamera.Roll(handle, radians);
		}

		/// <summary>
		/// 	Yaws the specified radians.
		/// </summary>
		/// <param name = "radians">The radians.</param>
		public void Yaw(Radian radians)
		{
			NativeCamera.Yaw(handle, radians.ValueRadians);
		}

		/// <summary>
		/// 	Yaws the specified radians.
		/// </summary>
		/// <param name = "radians">The radians.</param>
		public void Yaw(float radians)
		{
			NativeCamera.Yaw(handle, radians);
		}

		/// <summary>
		/// 	Pitches the specified radians.
		/// </summary>
		/// <param name = "radians">The radians.</param>
		public void Pitch(Radian radians)
		{
			NativeCamera.Pitch(handle, radians.ValueRadians);
		}

		/// <summary>
		/// 	Pitches the specified radians.
		/// </summary>
		/// <param name = "radians">The radians.</param>
		public void Pitch(float radians)
		{
			NativeCamera.Pitch(handle, radians);
		}

		/// <summary>
		/// 	Rotates the specified axis.
		/// </summary>
		/// <param name = "axis">The axis.</param>
		/// <param name = "radian">The radian.</param>
		public void Rotate(Vector3 axis, Radian radian)
		{
			Rotate(axis, radian.ValueRadians);
		}

		/// <summary>
		/// 	Rotates the specified axis.
		/// </summary>
		/// <param name = "axis">The axis.</param>
		/// <param name = "radians">The radians.</param>
		public void Rotate(Vector3 axis, float radians)
		{
			NativeCamera.Rotate(handle, axis, radians);
		}

		/// <summary>
		/// 	Rotates the specified rotation.
		/// </summary>
		/// <param name = "rotation">The rotation.</param>
		public void Rotate(Quaternion rotation)
		{
			NativeCamera.Rotate(handle, rotation);
		}

		/// <summary>
		/// 	Sets the fixed yaw axis.
		/// </summary>
		/// <param name = "useFixed">if set to <c>true</c> [use fixed].</param>
		public void SetFixedYawAxis(bool useFixed)
		{
			NativeCamera.SetFixedYawAxis(handle, useFixed);
		}

		/// <summary>
		/// 	Sets the fixed yaw axis.
		/// </summary>
		/// <param name = "useFixed">if set to <c>true</c> [use fixed].</param>
		/// <param name = "fixedAxis">The fixed axis.</param>
		public void SetFixedYawAxis(bool useFixed, Vector3 fixedAxis)
		{
			NativeCamera.SetFixedYawAxis(handle, useFixed, fixedAxis);
		}

		/// <summary>
		/// 	Sets the auto tracking.
		/// </summary>
		/// <param name = "enabled">if set to <c>true</c> [enabled].</param>
		public void SetAutoTracking(bool enabled)
		{
			NativeCamera.SetAutoTracking(handle, enabled);
		}

		/// <summary>
		/// 	Sets the auto tracking.
		/// </summary>
		/// <param name = "enabled">if set to <c>true</c> [enabled].</param>
		/// <param name = "target">The target.</param>
		public void SetAutoTracking(bool enabled, SceneNode target)
		{
			NativeCamera.SetAutoTracking(handle, enabled, target.DangerousGetHandle());
		}

		/// <summary>
		/// 	Sets the auto tracking.
		/// </summary>
		/// <param name = "enabled">if set to <c>true</c> [enabled].</param>
		/// <param name = "target">The target.</param>
		/// <param name = "offset">The offset.</param>
		public void SetAutoTracking(bool enabled, SceneNode target, Vector3 offset)
		{
			NativeCamera.SetAutoTracking(handle, enabled, target.DangerousGetHandle(), offset);
		}
	}
}