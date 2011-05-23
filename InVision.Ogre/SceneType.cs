using System;
using InVision.Ogre.Native;

namespace InVision.Ogre
{
	[OgreEnumeration("SceneTypeMask")]
	[Flags]
	public enum SceneType : uint
	{
		Generic = 1,
		ExteriorClose = 2,
		ExteriorFar = 4,
		ExteriorRealFar = 8,
		Interior = 16
	}
}