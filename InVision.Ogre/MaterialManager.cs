using System;
using InVision.Native;
using InVision.Ogre.Native;

namespace InVision.Ogre
{
	public class MaterialManager : Singleton<MaterialManager, IMaterialManager>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="MaterialManager"/> class.
		/// </summary>
		/// <param name="nativeInstance">The native instance.</param>
		public MaterialManager(ICppInstance nativeInstance)
			: base(nativeInstance)
		{
		}

		/// <summary>
		/// Gets or sets the default anisotropy.
		/// </summary>
		/// <value>The default anisotropy.</value>
		public uint DefaultAnisotropy
		{
			set { Native.SetDefaultAnisotropy(value); }
			get { return Native.GetDefaultAnisotropy(); }
		}

		/// <summary>
		/// Sets the default texture filtering.
		/// </summary>
		/// <param name="option">The option.</param>
		public void SetDefaultTextureFiltering(TextureFilterOption option)
		{
			Native.SetDefaultTextureFiltering(option);
		}
	}
}