namespace VectorTests.Vectors
{
	public struct ArrayVector3
	{
		private readonly float[] data;

		/// <summary>
		/// Initializes a new instance of the <see cref="ArrayVector3"/> struct.
		/// </summary>
		/// <param name="x">The x.</param>
		/// <param name="y">The y.</param>
		/// <param name="z">The z.</param>
		public ArrayVector3(float x, float y, float z)
		{
			data = new[] {x, y, z};
		}

		/// <summary>
		/// Gets or sets the X.
		/// </summary>
		/// <value>The X.</value>
		public float X
		{
			get { return data[0]; }
			set { data[0] = value; }
		}

		/// <summary>
		/// Gets or sets the Y.
		/// </summary>
		/// <value>The Y.</value>
		public float Y
		{
			get { return data[1]; }
			set { data[1] = value; }
		}

		/// <summary>
		/// Gets or sets the Z.
		/// </summary>
		/// <value>The Z.</value>
		public float Z
		{
			get { return data[2]; }
			set { data[2] = value; }
		}

		/// <summary>
		/// Implements the operator +.
		/// </summary>
		/// <param name="a">A.</param>
		/// <param name="b">The b.</param>
		/// <returns>The result of the operator.</returns>
		public static ArrayVector3 operator +(ArrayVector3 a, ArrayVector3 b)
		{
			return new ArrayVector3(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
		}
	}
}