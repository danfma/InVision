using System;
using InVision.Ogre3D.Native;

namespace InVision.Ogre3D
{
	public class MaterialManager : Handle
	{
		/// <summary>
		/// 	Initializes a new instance of the <see cref = "MaterialManager" /> class.
		/// </summary>
		/// <param name = "pSelf">The p self.</param>
		/// <param name = "ownsHandle">if set to <c>true</c> [owns handle].</param>
		protected internal MaterialManager(IntPtr pSelf, bool ownsHandle)
			: base(pSelf, ownsHandle)
		{
		}

		/// <summary>
		/// 	Initializes a new instance of the <see cref = "MaterialManager" /> class.
		/// </summary>
		/// <param name = "ownsHandle">if set to <c>true</c> [owns handle].</param>
		protected internal MaterialManager(bool ownsHandle)
			: base(ownsHandle)
		{
		}

		/// <summary>
		/// 	Gets the instance.
		/// </summary>
		/// <value>The instance.</value>
		public static MaterialManager Instance
		{
			get { return NativeMaterialManager.GetSingleton(); }
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

		/// <summary>
		/// 	Sets the default texture filtering.Sets the default texture filtering to be used for loaded textures, for when textures are loaded automatically (e.g. by Material class) or when 'load' is called with the default parameters by the application.
		/// </summary>
		/// <param name = "option">The option.</param>
		/// <remarks>
		/// 	The default value is BILINEAR.
		/// </remarks>
		public void SetDefaultTextureFiltering(TextureFilterOption option)
		{
			NativeMaterialManager.SetDefaultTextureFiltering(handle, option);
		}

		/// <summary>
		/// Gets or sets the default anisotropy.
		/// </summary>
		/// <value>The default anisotropy.</value>
		public uint DefaultAnisotropy
		{
			get { return NativeMaterialManager.GetDefaultAnisotropy(handle); }
			set { NativeMaterialManager.SetDefaultAnisotropy(handle, value); }
		}
	}
}