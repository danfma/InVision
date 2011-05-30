using System;
using System.Runtime.InteropServices;
using InVision.Native;

namespace InVision.Ogre.Native
{
	[OgreClass("ConfigFile")]
	public unsafe interface IConfigFile : ICppInstance
	{
		[Constructor(Implemented = true)]
		IConfigFile Construct();

		[Destructor(Implemented = true)]
		void Destruct();

		[Method(Implemented = true)]
		void Load(
			[MarshalAs(UnmanagedType.LPStr)] string filename,
			[MarshalAs(UnmanagedType.LPStr)] string separators,
			[MarshalAs(UnmanagedType.I1)] bool trimWhitespace);

		[Method(Implemented = true)]
		void GetSections(out SettingsBySection* settingsBySection);

		[Method(Static = true, Implemented = true)]
		void DeleteSettingsBySection(SettingsBySection* settingsBySection);
	}
}