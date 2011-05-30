using InVision.Native;

namespace InVision.Ogre.Native
{
	[OgreClass("TextureManager")]
	public interface ITextureManager : IResourceManager, ISingleton<ITextureManager>
	{
		[Method(Implemented = true)]
		void SetDefaultNumMipmaps(int num);

		[Method(Implemented = true)]
		int GetDefaultNumMipmaps();

		[Method(Implemented = true)]
		void ReloadAll(bool reloadableOnly = true);
	}
}