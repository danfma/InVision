using System.Resources;
using InVision.GameMath;
using InVision.Ogre.Native;

namespace InVision.Ogre
{
	public class Camera : Frustum
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Camera"/> class.
		/// </summary>
		/// <param name="camera">The camera.</param>
		public Camera(ICamera camera)
			: base(camera)
		{

		}

		/// <summary>
		/// Gets the native.
		/// </summary>
		/// <value>The native.</value>
		public new ICamera Native
		{
			get { return (ICamera)base.Native; }
		}

		/// <summary>
		/// Gets or sets the position.
		/// </summary>
		/// <value>The position.</value>
		public Vector3 Position
		{
			get { return Native.GetPosition(); }
			set { Native.SetPosition(value); }
		}

		/// <summary>
		/// Gets the direction.
		/// </summary>
		/// <value>The direction.</value>
		public Vector3 Direction
		{
			get { return Native.GetDirection(); }
		}

		/// <summary>
		/// Gets the right.
		/// </summary>
		/// <value>The right.</value>
		public Vector3 Right
		{
			get { return Native.GetRight(); }
		}

		/// <summary>
		/// Gets up.
		/// </summary>
		/// <value>Up.</value>
		public Vector3 Up
		{
			get { return Native.GetUp(); }
		}

		/// <summary>
		/// Gets or sets the near clip distance.
		/// </summary>
		/// <value>The near clip distance.</value>
		public float NearClipDistance
		{
			get { return Native.GetNearClipDistance(); }
			set { Native.SetNearClipDistance(value); }
		}

		/// <summary>
		/// Gets or sets the far clip distance.
		/// </summary>
		/// <value>The far clip distance.</value>
		public float FarClipDistance
		{
			get { return Native.GetFarClipDistance(); }
			set { Native.SetFarClipDistance(value); }
		}

		/// <summary>
		/// Gets or sets the aspect ratio.
		/// </summary>
		/// <value>The aspect ratio.</value>
		public float AspectRatio
		{
			get { return Native.GetAspectRatio(); }
			set { Native.SetAspectRatio(value); }
		}

		/// <summary>
		/// Gets or sets the polygon mode.
		/// </summary>
		/// <value>The polygon mode.</value>
		public PolygonMode PolygonMode
		{
			get { return Native.GetPolygonMode(); }
			set { Native.SetPolygonMode(value); }
		}

		/// <summary>
		/// Looks at.
		/// </summary>
		/// <param name="target">The target.</param>
		public void LookAt(Vector3 target)
		{
			Native.LookAt(target);
		}

		/// <summary>
		/// Sets the auto aspect ratio.
		/// </summary>
		/// <param name="value">if set to <c>true</c> [value].</param>
		public void SetAutoAspectRatio(bool value)
		{
			Native.SetAutoAspectRatio(value);
		}

		/// <summary>
		/// Moves the specified distance.
		/// </summary>
		/// <param name="distance">The distance.</param>
		public void Move(Vector3 distance)
		{
			Native.Move(distance);
		}

		/// <summary>
		/// Yaws the specified radians.
		/// </summary>
		/// <param name="radians">The radians.</param>
		public void Yaw(Radian radians)
		{
			Native.Yaw(radians.ValueRadians);
		}

		/// <summary>
		/// Yaws the specified radians.
		/// </summary>
		/// <param name="radians">The radians.</param>
		public void Yaw(float radians)
		{
			Native.Yaw(radians);
		}

		/// <summary>
		/// Pitches the specified radians.
		/// </summary>
		/// <param name="radians">The radians.</param>
		public void Pitch(Radian radians)
		{
			Native.Pitch(radians.ValueRadians);
		}

		/// <summary>
		/// Pitches the specified radians.
		/// </summary>
		/// <param name="radians">The radians.</param>
		public void Pitch(float radians)
		{
			Native.Pitch(radians);
		}
	}
}