using InVision.Native;
using InVision.Ogre.Native;

namespace InVision.Ogre
{
	public class ResourceGroupManager : CppWrapper<IResourceGroupManager>
	{
		public static readonly IResourceGroupManager NativeStatic = CreateCppInstance<IResourceGroupManager>();

		/// <summary>
		/// Initializes a new instance of the <see cref="ResourceGroupManager"/> class.
		/// </summary>
		/// <param name="nativeInstance">The native instance.</param>
		public ResourceGroupManager(IResourceGroupManager nativeInstance)
			: base(nativeInstance)
		{
		}

		/// <summary>
		/// Adds the resource location.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <param name="locType">Type of the loc.</param>
		public void AddResourceLocation(string name, string locType)
		{
			Native.AddResourceLocation(name, locType);
		}

		/// <summary>
		/// Adds the resource location.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <param name="locType">Type of the loc.</param>
		/// <param name="resGroup">The res group.</param>
		public void AddResourceLocation(string name, string locType, string resGroup)
		{
			Native.AddResourceLocation(name, locType, resGroup);
		}

		/// <summary>
		/// Adds the resource location.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <param name="locType">Type of the loc.</param>
		/// <param name="resGroup">The res group.</param>
		/// <param name="recursive">if set to <c>true</c> [recursive].</param>
		public void AddResourceLocation(string name, string locType, string resGroup, bool recursive)
		{
			Native.AddResourceLocation(name, locType, resGroup, recursive);
		}

		/// <summary>
		/// Initializes all resource groups.
		/// </summary>
		public void InitializeAllResourceGroups()
		{
			Native.InitializeAllResourceGroups();
		}

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>The instance.</value>
		public static ResourceGroupManager Instance
		{
			get
			{
				return GetOrCreateOwner(
					NativeStatic.GetSingleton(),
					native => new ResourceGroupManager(native));
			}
		}
	}
}