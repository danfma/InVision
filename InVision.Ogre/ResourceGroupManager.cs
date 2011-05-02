using System;
using InVision.Native;
using InVision.Native.Ogre;

namespace InVision.Rendering
{
	public class ResourceGroupManager : Handle
	{
		public const string DefaultResourceGroupName = "General";

		/// <summary>
		/// 	Initializes a new instance of the <see cref = "ResourceGroupManager" /> class.
		/// </summary>
		/// <param name = "pSelf">The p self.</param>
		/// <param name = "ownsHandle">if set to <c>true</c> [owns handle].</param>
		protected internal ResourceGroupManager(IntPtr pSelf, bool ownsHandle)
			: base(pSelf, ownsHandle)
		{
		}

		/// <summary>
		/// 	Initializes a new instance of the <see cref = "ResourceGroupManager" /> class.
		/// </summary>
		/// <param name = "ownsHandle">if set to <c>true</c> [owns handle].</param>
		protected internal ResourceGroupManager(bool ownsHandle)
			: base(ownsHandle)
		{
		}

		/// <summary>
		/// 	Gets the instance.
		/// </summary>
		/// <value>The instance.</value>
		public static ResourceGroupManager Instance
		{
			get { return NativeOgreResourceGroupManager.GetSingleton(); }
		}

		/// <summary>
		/// 	Releases the specified pointer to the unmanaged object.
		/// </summary>
		/// <returns></returns>
		protected override void ReleaseValidHandle()
		{
		}

		/// <summary>
		/// 	Initialises all resource groups.
		/// </summary>
		public void InitialiseAllResourceGroups()
		{
			NativeOgreResourceGroupManager.InitialiseAllResourceGroups(handle);
		}

		/// <summary>
		/// Method to add a resource location to for a given resource group. 
		/// </summary>
		/// <remarks>
		/// Resource locations are places which are searched to load resource files. When you choose to load a file, or to search for valid files to load, the resource locations are used. 
		/// </remarks>
		/// <param name="name">The name of the resource location; probably a directory, zip file, URL etc. </param>
		/// <param name="locationType">The codename for the resource type, which must correspond to the Archive factory which is providing the implementation. </param>
		/// <param name="resourceGroup">The name of the resource group for which this location is to apply. ResourceGroupManager::DEFAULT_RESOURCE_GROUP_NAME is the default group which always exists, and can be used for resources which are unlikely to be unloaded until application shutdown. Otherwise it must be the name of a group; if it has not already been created with createResourceGroup then it is created automatically.</param>
		/// <param name="recursive">Whether subdirectories will be searched for files when using a pattern match (such as *.material), and whether subdirectories will be indexed. This can slow down initial loading of the archive and searches. When opening a resource you still need to use the fully qualified name, this allows duplicate names in alternate paths.</param>
		public void AddResourceLocation(string name, string locationType, string resourceGroup = DefaultResourceGroupName, bool recursive = false)
		{
			NativeOgreResourceGroupManager.AddResourceLocation(handle, name, locationType, resourceGroup, recursive);
		}
	}
}