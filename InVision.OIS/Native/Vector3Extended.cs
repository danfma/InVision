using System.Runtime.InteropServices;

namespace InVision.OIS.Native
{
	[StructLayout(LayoutKind.Sequential)]
	internal unsafe struct Vector3Extended
	{
		private ComponentExtended baseInfo;
		private float* x;
		private float* y;
		private float* z;

		/// <summary>
		/// Gets the base info.
		/// </summary>
		/// <value>The base info.</value>
		public ComponentExtended BaseInfo
		{
			get { return baseInfo; }
		}

		/// <summary>
		/// Gets the X.
		/// </summary>
		/// <value>The X.</value>
		public float X
		{
			get { return *x; }
		}

		/// <summary>
		/// Gets the Y.
		/// </summary>
		/// <value>The Y.</value>
		public float Y
		{
			get { return *y; }
		}

		/// <summary>
		/// Gets the Z.
		/// </summary>
		/// <value>The Z.</value>
		public float Z
		{
			get { return *z; }
		}
	}
}