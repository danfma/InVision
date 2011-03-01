using System;
using System.Runtime.InteropServices;

namespace VectorTests.Vectors
{
	public unsafe struct PArrayVector3 : IDisposable
	{
		private readonly float* data;

		/// <summary>
		/// 	Initializes a new instance of the <see cref = "PArrayVector3" /> struct.
		/// </summary>
		/// <param name = "x">The x.</param>
		/// <param name = "y">The y.</param>
		/// <param name = "z">The z.</param>
		public PArrayVector3(float x, float y, float z)
		{
			data = (float*)Marshal.AllocHGlobal(3 * sizeof(float)).ToPointer();
			data[0] = x;
			data[1] = y;
			data[2] = z;
		}

		/// <summary>
		/// 	Gets or sets the X.
		/// </summary>
		/// <value>The X.</value>
		public float X
		{
			get { return data[0]; }
			set { data[0] = value; }
		}

		/// <summary>
		/// 	Gets or sets the Y.
		/// </summary>
		/// <value>The Y.</value>
		public float Y
		{
			get { return data[1]; }
			set { data[1] = value; }
		}

		/// <summary>
		/// 	Gets or sets the Z.
		/// </summary>
		/// <value>The Z.</value>
		public float Z
		{
			get { return data[2]; }
			set { data[2] = value; }
		}

		#region IDisposable Members

		/// <summary>
		/// 	Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		/// <filterpriority>2</filterpriority>
		public void Dispose()
		{
			var pData = new IntPtr(data);
			Marshal.FreeHGlobal(pData);
		}

		#endregion

		/// <summary>
		/// 	Implements the operator +.
		/// </summary>
		/// <param name = "a">A.</param>
		/// <param name = "b">The b.</param>
		/// <returns>The result of the operator.</returns>
		public static PArrayVector3 operator +(PArrayVector3 a, PArrayVector3 b)
		{
			float* p1 = a.data;
			float* p2 = b.data;

			return new PArrayVector3(p1[0] + p2[0], p1[1] + p2[1], p1[2] + p2[2]);
		}
	}
}