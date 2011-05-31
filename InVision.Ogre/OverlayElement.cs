using System.Runtime.InteropServices;
using InVision.Ogre.Native;

namespace InVision.Ogre
{
	public class OverlayElement : StringInterface
	{
		public static readonly IOverlayElement NativeStatic = CreateCppInstance<IOverlayElement>();

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
			get
			{
				unsafe {
					char* pdata = Native.GetCaption();

					try {
						return new string(pdata);

					} finally {
						NativeStatic.DeleteWideString(pdata);
					}
				}
			}
			set
			{
				Native.SetCaption(value);
			}
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