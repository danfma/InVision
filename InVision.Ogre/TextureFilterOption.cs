using InVision.Ogre.Native;

namespace InVision.Ogre
{
	[OgreEnumeration("TextureFilterOptions")]
	public enum TextureFilterOption : uint
	{
		None,
		Bilinear,
		Trilinear,
		Anisotropic
	}
}