using InVision.Native;
using InVision.Ogre.Native;

namespace InVision.Ogre
{
	public class Overlay : CppWrapper<IOverlay>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Overlay"/> class.
		/// </summary>
		/// <param name="nativeInstance">The native instance.</param>
		public Overlay(IOverlay nativeInstance)
			: base(nativeInstance)
		{
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