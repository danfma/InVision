using System;
using InVision.Native;
using InVision.Ogre.Native;

namespace InVision.Ogre
{
	public class TextureManager : Handle, ITextureManager
	{
		/// <summary>
		/// 	Initializes a new instance of the <see cref = "TextureManager" /> class.
		/// </summary>
		/// <param name = "pSelf">The p self.</param>
		/// <param name = "ownsHandle">if set to <c>true</c> [owns handle].</param>
		internal TextureManager(IntPtr pSelf, bool ownsHandle)
			: base(pSelf, ownsHandle)
		{
		}

		/// <summary>
		/// 	Initializes a new instance of the <see cref = "TextureManager" /> class.
		/// </summary>
		/// <param name = "ownsHandle">if set to <c>true</c> [owns handle].</param>
		internal TextureManager(bool ownsHandle)
			: base(ownsHandle)
		{
		}

		/// <summary>
		/// 	Gets or sets the default num mipmaps.
		/// </summary>
		/// <value>The default num mipmaps.</value>
		public int DefaultNumMipmaps
		{
			get { return NativeOgreTextureManager.GetDefaultNumMipmaps(handle); }
			set { NativeOgreTextureManager.SetDefaultNumMipmaps(handle, value); }
		}

		/// <summary>
		/// 	Gets the singleton.
		/// </summary>
		/// <value>The singleton.</value>
		public static TextureManager Instance
		{
			get { return NativeOgreTextureManager.GetInstance(); }
		}

		/// <summary>
		/// 	Releases the specified pointer to the unmanaged object.
		/// </summary>
		/// <returns></returns>
		protected override void ReleaseValidHandle()
		{
			
		}

		/// <summary>
		/// 	Reloads all.
		/// </summary>
		/// <param name = "reloadableOnly">if set to <c>true</c> [reloadable only].</param>
		public void ReloadAll(bool reloadableOnly = true)
		{
			NativeOgreTextureManager.ReloadAll(handle, reloadableOnly);
		}
	}
}