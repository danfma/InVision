using System;
using InVision.Ogre3D.Native;

namespace InVision.Ogre3D
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
			get { return NativeTextureManager.GetDefaultNumMipmaps(handle); }
			set { NativeTextureManager.SetDefaultNumMipmaps(handle, value); }
		}

		/// <summary>
		/// 	Gets the singleton.
		/// </summary>
		/// <value>The singleton.</value>
		public static TextureManager Singleton
		{
			get { return NativeTextureManager.GetInstance(); }
		}

		/// <summary>
		/// 	Releases the specified pointer to the unmanaged object.
		/// </summary>
		/// <param name = "pSelf">The pointer to the unmanaged object.</param>
		/// <returns></returns>
		protected override bool Release(IntPtr pSelf)
		{
			return true;
		}
	}
}