using System;

namespace InVision.Rendering.Util
{
	public abstract class ColourRepresentation
	{
		/// <summary>
		/// 	Initializes the <see cref = "ColourRepresentation" /> class.
		/// </summary>
		static ColourRepresentation()
		{
			Instance = BitConverter.IsLittleEndian ? new LittleEndianColourRepresentation() : new BigEndianColourRepresentation();
		}

		/// <summary>
		/// Gets or sets the instance.
		/// </summary>
		/// <value>The instance.</value>
		public static ColourRepresentation Instance { get; private set; }

		/// <summary>
		/// Converts the four color components into a Int32 value.
		/// </summary>
		/// <param name="c0">The c0.</param>
		/// <param name="c1">The c1.</param>
		/// <param name="c2">The c2.</param>
		/// <param name="c3">The c3.</param>
		/// <returns></returns>
		public abstract uint ToInt32(float c0, float c1, float c2, float c3);

		/// <summary>
		/// Extracts the four color components values from a Int32 value.
		/// </summary>
		/// <param name="value"></param>
		/// <param name="c0"></param>
		/// <param name="c1"></param>
		/// <param name="c2"></param>
		/// <param name="c3"></param>
		public abstract void FromInt32(uint value, out float c0, out float c1, out float c2, out float c3);
	}
}