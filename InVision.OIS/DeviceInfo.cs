using System.Runtime.InteropServices;

namespace InVision.OIS
{
	[StructLayout(LayoutKind.Sequential)]
	public struct DeviceInfo
	{
		[MarshalAs(UnmanagedType.I4)]
		private readonly DeviceType type;

		[MarshalAs(UnmanagedType.LPStr)]
		private readonly string name;

		/// <summary>
		/// Initializes a new instance of the <see cref="DeviceInfo"/> struct.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <param name="name">The name.</param>
		public DeviceInfo(DeviceType type, string name)
		{
			this.type = type;
			this.name = name;
		}

		/// <summary>
		/// Gets the type.
		/// </summary>
		/// <value>The type.</value>
		public DeviceType Type
		{
			get { return type; }
		}

		/// <summary>
		/// Gets the name.
		/// </summary>
		/// <value>The name.</value>
		public string Name
		{
			get { return name; }
		}
	}
}