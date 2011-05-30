using System.Runtime.InteropServices;
using InVision.Native;

namespace InVision.Ogre.Native
{
	[OgreClass("ResourceGroupManager")]
	public interface IResourceGroupManager : ICppInstance, ISingleton<IResourceGroupManager>
	{
		[Method(Implemented = true)]
		void AddResourceLocation(
			[MarshalAs(UnmanagedType.LPStr)] string name,
			[MarshalAs(UnmanagedType.LPStr)] string locType);

		[Method(Implemented = true)]
		void AddResourceLocation(
			[MarshalAs(UnmanagedType.LPStr)] string name,
			[MarshalAs(UnmanagedType.LPStr)] string locType,
			[MarshalAs(UnmanagedType.LPStr)] string resGroup);

		[Method(Implemented = true)]
		void AddResourceLocation(
			[MarshalAs(UnmanagedType.LPStr)] string name,
			[MarshalAs(UnmanagedType.LPStr)] string locType,
			[MarshalAs(UnmanagedType.LPStr)] string resGroup,
			[MarshalAs(UnmanagedType.I1)] bool recursive);

		[Method(Implemented = true)]
		void InitializeAllResourceGroups();
	}
}