using System;
using InVision.Native;

namespace InVision.Ogre.Native
{
	[AttributeUsage(AttributeTargets.Enum)]
	public class OgreEnumerationAttribute : CppEnumerationAttribute
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="OgreEnumerationAttribute"/> class.
		/// </summary>
		/// <param name="typename">The typename.</param>
		public OgreEnumerationAttribute(string typename)
			: base(typename)
		{
			Namespace = "Ogre";
			DefinitionFile = "Ogre.h";
		}
	}
}