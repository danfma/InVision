using System.Runtime.InteropServices;

namespace InVision.OIS.Native
{
	[StructLayout(LayoutKind.Sequential)]
	internal unsafe struct Vector3Descriptor
	{
		private readonly ComponentDescriptor _baseDescriptor;
		private readonly float* _x;
		private readonly float* _y;
		private readonly float* _z;

		/// <summary>
		/// Gets the base info.
		/// </summary>
		/// <value>The base info.</value>
		public ComponentDescriptor BaseDescriptor
		{
			get { return _baseDescriptor; }
		}

		/// <summary>
		/// Gets the X.
		/// </summary>
		/// <value>The X.</value>
		public float X
		{
			get { return *_x; }
		}

		/// <summary>
		/// Gets the Y.
		/// </summary>
		/// <value>The Y.</value>
		public float Y
		{
			get { return *_y; }
		}

		/// <summary>
		/// Gets the Z.
		/// </summary>
		/// <value>The Z.</value>
		public float Z
		{
			get { return *_z; }
		}
	}
}