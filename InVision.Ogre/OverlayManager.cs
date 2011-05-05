using System;
using InVision.Native;
using InVision.Ogre.Native;

namespace InVision.Ogre
{
	public class OverlayManager : Handle
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="OverlayManager"/> class.
		/// </summary>
		/// <param name="pSelf">The p self.</param>
		/// <param name="ownsHandle">if set to <c>true</c> [owns handle].</param>
		internal OverlayManager(IntPtr pSelf, bool ownsHandle)
			: base(pSelf, ownsHandle)
		{
		}

		/// <summary>
		/// 	Releases the specified pointer to the unmanaged object.
		/// </summary>
		/// <returns></returns>
		protected override void ReleaseValidHandle()
		{
			NativeOverlayManager.Delete(handle);
		}

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>The instance.</value>
		public static OverlayManager Instance
		{
			get { return NativeOverlayManager.GetSingleton(); }
		}

		/// <summary>
		/// Creates the specified name.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <returns></returns>
		public Overlay Create(string name)
		{
			return NativeOverlayManager.Create(handle, name);
		}

		/// <summary>
		/// Gets the name of the by.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <returns></returns>
		public Overlay GetByName(string name)
		{
			return NativeOverlayManager.GetByName(handle, name);
		}

		/// <summary>
		/// Gets the overlay element.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <param name="isTemplate">if set to <c>true</c> [is template].</param>
		/// <returns></returns>
		public OverlayElement GetOverlayElement(string name, bool isTemplate = false)
		{
			return NativeOverlayManager.GetOverlayElement(handle, name, isTemplate);
		}
	}
}