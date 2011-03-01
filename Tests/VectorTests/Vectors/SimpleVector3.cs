using System.Runtime.InteropServices;

namespace VectorTests.Vectors
{
	[StructLayout(LayoutKind.Explicit)]
	public struct SimpleVector3
	{
		[FieldOffset(0 * sizeof(float))]
		private float x;

		[FieldOffset(1 * sizeof(float))]
		private float y;

		[FieldOffset(2 * sizeof(float))]
		private float z;

		/// <summary>
		/// 	Initializes a new instance of the <see cref = "SimpleVector3" /> struct.
		/// </summary>
		/// <param name = "x">The x.</param>
		/// <param name = "y">The y.</param>
		/// <param name = "z">The z.</param>
		public SimpleVector3(float x, float y, float z)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}

		/// <summary>
		/// 	Gets or sets the X.
		/// </summary>
		/// <value>The X.</value>
		public float X
		{
			get { return x; }
			set { x = value; }
		}

		/// <summary>
		/// 	Gets or sets the Y.
		/// </summary>
		/// <value>The Y.</value>
		public float Y
		{
			get { return y; }
			set { y = value; }
		}

		/// <summary>
		/// 	Gets or sets the Z.
		/// </summary>
		/// <value>The Z.</value>
		public float Z
		{
			get { return z; }
			set { z = value; }
		}

		/// <summary>
		/// 	Implements the operator +.
		/// </summary>
		/// <param name = "a">A.</param>
		/// <param name = "b">The b.</param>
		/// <returns>The result of the operator.</returns>
		public static SimpleVector3 operator +(SimpleVector3 a, SimpleVector3 b)
		{
			return new SimpleVector3(a.x + b.x, a.y + b.y, a.z + b.z);
		}
	}
}