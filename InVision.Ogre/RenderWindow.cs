using System;
using InVision.Native;
using InVision.Ogre.Native;

namespace InVision.Ogre
{
	public class RenderWindow : CppWrapper<IRenderWindow>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="RenderWindow"/> class.
		/// </summary>
		/// <param name="nativeInstance">The native instance.</param>
		public RenderWindow(IRenderWindow nativeInstance)
			: base(nativeInstance)
		{
		}

		/// <summary>
		/// Determines whether this instance is closed.
		/// </summary>
		/// <value>
		/// 	&lt;c&gt;true&lt;/c&gt; if this instance is closed; otherwise, &lt;c&gt;false&lt;/c&gt;.
		/// </value>
		public bool IsClosed
		{
			get { return Native.IsClosed(); }
		}

		/// <summary>
		/// Gets the custom attribute.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <param name="data">The data.</param>
		public void GetCustomAttribute(string name, out IntPtr data)
		{
			Native.GetCustomAttribute(name, out data);
		}

		/// <summary>
		/// Adds the viewport.
		/// </summary>
		/// <param name="camera">The camera.</param>
		/// <param name="zOrder">The z order.</param>
		/// <param name="left">The left.</param>
		/// <param name="top">The top.</param>
		/// <param name="width">The width.</param>
		/// <param name="height">The height.</param>
		/// <returns></returns>
		public Viewport AddViewport(ICamera camera, int zOrder, float left, float top, float width, float height)
		{
			return GetOrCreateOwner(
				Native.AddViewport(camera, zOrder, left, top, width, height),
				native => new Viewport(native));
		}
	}
}