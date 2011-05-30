using InVision.Ogre.Native;

namespace InVision.Ogre
{
	public class OverlayElement : StringInterface
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="OverlayElement"/> class.
		/// </summary>
		/// <param name="nativeInstance">The native instance.</param>
		public OverlayElement(IStringInterface nativeInstance)
			: base(nativeInstance)
		{
		}

		/// <summary>
		/// Gets the native.
		/// </summary>
		/// <value>The native.</value>
		public new IOverlayElement Native
		{
			get { return (IOverlayElement)base.Native; }
		}

		/// <summary>
		/// Gets or sets the caption.
		/// </summary>
		/// <value>The caption.</value>
		public string Caption
		{
			get { return Native.GetCaption(); }
			set { Native.SetCaption(value); }
		}

		/// <summary>
		/// Shows this instance.
		/// </summary>
		public void Show()
		{
			Native.Show();
		}
	}
}