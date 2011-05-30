using InVision.Ogre.Native;

namespace InVision.Ogre
{
	public class ResourceManager : ScriptLoader
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ResourceManager"/> class.
		/// </summary>
		/// <param name="nativeInstance">The native instance.</param>
		public ResourceManager(IScriptLoader nativeInstance)
			: base(nativeInstance)
		{
		}

		/// <summary>
		/// Gets the native.
		/// </summary>
		/// <value>The native.</value>
		public new IResourceManager Native
		{
			get { return (IResourceManager)base.Native; }
		}
	}
}