using System;
using InVision.Ogre3D.Native;
using OpenTK;

namespace InVision.Ogre3D
{
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
		/// Gets or sets the position.
		/// </summary>
		/// <value>The position.</value>
		public Vector3 Position
		{
			get { return NativeCamera.GetPosition(handle); }
			set { NativeCamera.SetPosition(handle, value); }
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
	}
}