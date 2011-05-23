using System;
using InVision.Native;

namespace InVision.Ogre.Native
{
	[AttributeUsage(AttributeTargets.Interface)]
	public class OgreInterfaceAttribute : CppInterfaceAttribute
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="OgreInterfaceAttribute"/> class.
		/// </summary>
		public OgreInterfaceAttribute()
		{
			Initialize();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="OgreInterfaceAttribute"/> class.
		/// </summary>
		/// <param name="typename">The typename.</param>
		public OgreInterfaceAttribute(string typename)
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