using InVision.Native;

namespace InVision.Ogre.Native
{
	public class OgreValueObjectAttribute : CppValueObjectAttribute
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="OgreValueObjectAttribute"/> class.
		/// </summary>
		public OgreValueObjectAttribute()
		{
			Initialize();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="OgreValueObjectAttribute"/> class.
		/// </summary>
		/// <param name="typename">The typename.</param>
		public OgreValueObjectAttribute(string typename)
			: base(typename)
		{
			Initialize();
		}

		/// <summary>
		/// Initializes this instance.
		/// </summary>
		private void Initialize()
		{
			Namespace = "Ogre";
			DefinitionFile = "Ogre.h";
		}
	}
}