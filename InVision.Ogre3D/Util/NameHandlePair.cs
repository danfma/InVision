using System;
using System.Runtime.InteropServices;

namespace InVision.Ogre3D.Util
{
	[StructLayout(LayoutKind.Explicit)]
	public struct NameHandlePair
	{
		[FieldOffset(0)]
		[MarshalAs(UnmanagedType.LPStr)]
		private readonly string key;

		[FieldOffset(4)]
		private readonly IntPtr value;

		/// <summary>
		/// Initializes a new instance of the <see cref="NameHandlePair"/> struct.
		/// </summary>
		/// <param name="key">The key.</param>
		/// <param name="value">The value.</param>
		public NameHandlePair(string key, IntPtr value) : this()
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
		public IntPtr Value
		{
			get { return value; }
		}
	}
}