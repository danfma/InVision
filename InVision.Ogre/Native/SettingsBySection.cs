using System;
using System.Runtime.InteropServices;
using InVision.Native;

namespace InVision.Ogre.Native
{
	[CppValueObject]
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct SettingsBySection
	{
		public IntPtr Section;
		public Setting* Settings;
		public SettingsBySection* Next;

		/// <summary>
		/// Gets the name of the section.
		/// </summary>
		/// <value>The name of the section.</value>
		public string SectionName
		{
			get { return Marshal.PtrToStringAnsi(Section); }
		}
	}
}