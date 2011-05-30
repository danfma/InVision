using System;
using InVision.Native;

namespace InVision.Ogre.Native
{
	[AttributeUsage(AttributeTargets.Interface)]
	public class OgreClassAttribute : CppClassAttribute
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="OgreClassAttribute"/> class.
		/// </summary>
		public OgreClassAttribute()
		{
			Initialize();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="OgreClassAttribute"/> class.
		/// </summary>
		/// <param name="typename">The typename.</param>
		public OgreClassAttribute(string typename)
			: base(typename)
		{
			Initialize();
		}

		private void Initialize()
		{
			Namespace = "Ogre";
			DefinitionFile = "Ogre.h";
		}
	}
}