using System.Runtime.InteropServices;

namespace InVision.Ogre.Native
{
	[StructLayout(LayoutKind.Sequential)]
	[OgreValueObject]
	public struct NameValuePair
	{
		[MarshalAs(UnmanagedType.LPStr)]
		public string Name;

		[MarshalAs(UnmanagedType.LPStr)]
		public string Value;

		/// <summary>
		/// Initializes a new instance of the <see cref="NameValuePair"/> struct.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <param name="value">The value.</param>
		public NameValuePair(string name, string value)
		{
			Name = name;
			Value = value;
		}
	}
}