using InVision.GameMath;
using InVision.Native;
using InVision.Ogre.Native;

namespace InVision.Ogre
{
	public class Viewport : CppWrapper<IViewport>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Viewport"/> class.
		/// </summary>
		/// <param name="nativeInstance">The native instance.</param>
		public Viewport(IViewport nativeInstance)
			: base(nativeInstance)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Viewport"/> class.
		/// </summary>
		/// <param name="camera">The camera.</param>
		/// <param name="renderTarget">The render target.</param>
		/// <param name="left">The left.</param>
		/// <param name="top">The top.</param>
		/// <param name="width">The width.</param>
		/// <param name="height">The height.</param>
		/// <param name="zOrder">The z order.</param>
		public Viewport(Camera camera, RenderTarget renderTarget,
			float left, float top,
			float width, float height,
			int zOrder)
			: this(CreateCppInstance<IViewport>())
		{
			Native.Construct(
				camera.Native,
				renderTarget.Native,
				left, top,
				width, height,
				zOrder).SetOwner(this);
		}

		/// <summary>
		/// Releases unmanaged and - optionally - managed resources
		/// </summary>
		/// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
		protected override void Dispose(bool disposing)
		{
			if (Native != null)
				Native.Destruct();

			base.Dispose(disposing);
		}

		/// <summary>
		/// Gets or sets the color of the background.
		/// </summary>
		/// <value>The color of the background.</value>
		public Color BackgroundColor
		{
			get { return Native.GetBackgroundColor(); }
			set { Native.SetBackgroundColor(value); }
		}

		/// <summary>
		/// Gets or sets the camera.
		/// </summary>
		/// <value>The camera.</value>
		public Camera Camera
		{
			get { return GetOrCreateOwner(Native.GetCamera(), native => new Camera(native)); }
			set { Native.SetCamera(value != null ? value.Native : null); }
		}

		/// <summary>
		/// Gets the left.
		/// </summary>
		/// <value>The left.</value>
		public float Left
		{
			get { return Native.GetLeft(); }
		}

		/// <summary>
		/// Gets the top.
		/// </summary>
		/// <value>The top.</value>
		public float Top
		{
			get { return Native.GetTop(); }
		}

		/// <summary>
		/// Gets the width.
		/// </summary>
		/// <value>The width.</value>
		public float Width
		{
			get { return Native.GetWidth(); }
		}

		/// <summary>
		/// Gets the height.
		/// </summary>
		/// <value>The height.</value>
		public float Height
		{
			get { return Native.GetHeight(); }
		}

		/// <summary>
		/// Gets the actual left.
		/// </summary>
		/// <value>The actual left.</value>
		public int ActualLeft
		{
			get { return Native.GetActualLeft(); }
		}

		/// <summary>
		/// Gets the actual top.
		/// </summary>
		/// <value>The actual top.</value>
		public int ActualTop
		{
			get { return Native.GetActualTop(); }
		}

		/// <summary>
		/// Gets the actual width.
		/// </summary>
		/// <value>The actual width.</value>
		public int ActualWidth
		{
			get { return Native.GetActualWidth(); }
		}

		/// <summary>
		/// Gets the actual height.
		/// </summary>
		/// <value>The actual height.</value>
		public int ActualHeight
		{
			get { return Native.GetActualHeight(); }
		}

		/// <summary>
		/// Updates this instance.
		/// </summary>
		public void Update()
		{
			Native.Update();
		}

		/// <summary>
		/// Clears this instance.
		/// </summary>
		public void Clear()
		{
			Native.Clear();
		}
	}
}