using InVision.Native;
using InVision.Ogre.Native;

namespace InVision.Ogre
{
	public class OverlayManager : Singleton<OverlayManager, IOverlayManager>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="OverlayManager"/> class.
		/// </summary>
		/// <param name="nativeInstance">The native instance.</param>
		public OverlayManager(ICppInstance nativeInstance)
			: base(nativeInstance)
		{
		}

		/// <summary>
		/// Gets the overlay element.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <param name="isTemplate">if set to <c>true</c> [is template].</param>
		/// <returns></returns>
		public OverlayElement GetOverlayElement(string name, bool isTemplate = false)
		{
			return GetOrCreateOwner(
				Native.GetOverlayElement(name, isTemplate),
				native => new OverlayElement(native));
		}

		/// <summary>
		/// Gets the name of the by.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <returns></returns>
		public Overlay GetByName(string name)
		{
			return GetOrCreateOwner(
				Native.GetByName(name),
				native => new Overlay(native));
		}
	}
}