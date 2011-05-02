using System.Runtime.InteropServices;

namespace InVision.Native
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

		/// <summary>
		/// Gets the key.
		/// </summary>
		/// <value>The key.</value>
		public string Key
		{
			get { return key; }
		}

		/// <summary>
		/// Gets the value.
		/// </summary>
		/// <value>The value.</value>
		public string Value
		{
			get { return value; }
		}
	}
}