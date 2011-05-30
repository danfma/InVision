using InVision.Ogre.Native;

namespace InVision.Ogre
{
	public class TextureManager : ResourceManager
	{
		private static readonly ITextureManager NativeStatic = CreateCppInstance<ITextureManager>();

		/// <summary>
		/// Initializes a new instance of the <see cref="TextureManager"/> class.
		/// </summary>
		/// <param name="nativeInstance">The native instance.</param>
		public TextureManager(IScriptLoader nativeInstance)
			: base(nativeInstance)
		{
		}

		/// <summary>
		/// Gets the native.
		/// </summary>
		/// <value>The native.</value>
		public new ITextureManager Native
		{
			get { return (ITextureManager)base.Native; }
		}

		/// <summary>
		/// Gets or sets the default num mipmaps.
		/// </summary>
		/// <value>The default num mipmaps.</value>
		public int DefaultNumMipmaps
		{
			get { return Native.GetDefaultNumMipmaps(); }
			set { Native.SetDefaultNumMipmaps(value); }
		}

		/// <summary>
		/// Reloads all.
		/// </summary>
		/// <param name="reloadableOnly">if set to <c>true</c> [reloadable only].</param>
		public void ReloadAll(bool reloadableOnly = true)
		{
			Native.ReloadAll(reloadableOnly);
		}

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>The instance.</value>
		public static TextureManager Instance
		{
			get
			{
				return GetOrCreateOwner(
					NativeStatic.GetSingleton(),
					native => new TextureManager(native));
			}
		}
	}
}