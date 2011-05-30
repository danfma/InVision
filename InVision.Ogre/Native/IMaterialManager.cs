using InVision.Native;

namespace InVision.Ogre.Native
{
	[OgreClass("MaterialManager")]
	public interface IMaterialManager : IResourceManager, ISingleton<IMaterialManager>
	{
		[Method(Implemented = true)]
		void SetDefaultTextureFiltering(TextureFilterOption option);

		[Method(Implemented = true)]
		void SetDefaultAnisotropy(uint max);

		[Method(Implemented = true)]
		uint GetDefaultAnisotropy();
	}
}