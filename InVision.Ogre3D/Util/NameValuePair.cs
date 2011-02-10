using System.Runtime.InteropServices;

namespace InVision.Ogre3D.Util
{
	[StructLayout(LayoutKind.Sequential)]
	public struct NameValuePair
	{
		[MarshalAs(UnmanagedType.LPStr)]
		private readonly string key;
		
		[MarshalAs(UnmanagedType.LPStr)]
		private readonly string value;

		/// <summary>
		/// Initializes a new instance of the <see cref="NameValuePair"/> struct.
		/// </summary>
		/// <param name="key">The key.</param>
		/// <param name="value">The value.</param>
		public NameValuePair(string key, string value)
			: this()
		{
			this.key = key;
			this.value = value;
		}

		public string Key
		{
			get { return key; }
		}

		public string Value
		{
			get { return value; }
		}
	}
}