using System;
using System.Runtime.InteropServices;

namespace InVision.GameMath
{
	[StructLayout(LayoutKind.Sequential)]
	public struct Matrix3
	{
		private readonly Vector3 row0;
		private readonly Vector3 row1;
		private readonly Vector3 row2;

		/// <summary>
		/// Initializes a new instance of the <see cref="Matrix3"/> class.
		/// </summary>
		/// <param name="rows">The rows.</param>
		public Matrix3(Vector3[] rows)
		{
			row0 = rows[0];
			row1 = rows[1];
			row2 = rows[2];
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Matrix3"/> struct.
		/// </summary>
		/// <param name="a1">The a1.</param>
		/// <param name="a2">The a2.</param>
		/// <param name="a3">The a3.</param>
		/// <param name="b1">The b1.</param>
		/// <param name="b2">The b2.</param>
		/// <param name="b3">The b3.</param>
		/// <param name="c1">The c1.</param>
		/// <param name="c2">The c2.</param>
		/// <param name="c3">The c3.</param>
		public Matrix3(
			float a1, float a2, float a3,
			float b1, float b2, float b3,
			float c1, float c2, float c3)
			: this()
		{
			A1 = a1;
			A2 = a2;
			A3 = a3;

			B1 = b1;
			B2 = b2;
			B3 = b3;

			C1 = c1;
			C2 = c2;
			C3 = c3;
		}

		/// <summary>
		/// Gets or sets the <see cref="System.Single"/> with the specified row.
		/// </summary>
		/// <value></value>
		public float this[int row, int col]
		{
			get
			{
				unsafe
				{
					int rowSpace = sizeof(Vector3) * row;

					fixed (void* pself = &this)
					{
						float* data = (float*)pself;
						data += rowSpace + col * sizeof(float);

						return *data;
					}
				}
			}
			set
			{
				unsafe
				{
					int rowSpace = sizeof(Vector3) * row;

					fixed (void* pself = &this)
					{
						var data = (float*)pself;
						data += rowSpace + col * sizeof(float);

						*data = value;
					}
				}
			}
		}

		public float A1 { get { return this[0, 0]; } set { this[0, 0] = value; } }
		public float A2 { get { return this[0, 1]; } set { this[0, 1] = value; } }
		public float A3 { get { return this[0, 2]; } set { this[0, 2] = value; } }

		public float B1 { get { return this[1, 0]; } set { this[1, 0] = value; } }
		public float B2 { get { return this[1, 1]; } set { this[1, 1] = value; } }
		public float B3 { get { return this[1, 2]; } set { this[1, 2] = value; } }

		public float C1 { get { return this[2, 0]; } set { this[2, 0] = value; } }
		public float C2 { get { return this[2, 1]; } set { this[2, 1] = value; } }
		public float C3 { get { return this[2, 2]; } set { this[2, 2] = value; } }
	}
}