namespace InVision.GameMath.Endianess
{
	public class LittleEndianColourRepresentation : ColourRepresentation
	{
		public override uint ToInt32(float c0, float c1, float c2, float c3)
		{
		    uint cpValue = (byte)(c0 * 255);
			uint cValue = cpValue << 24;

			cpValue = (byte)(c1 * 255);
			cValue += cpValue << 16;

			cpValue = (byte)(c2 * 255);
			cValue += cpValue << 8;

			cpValue = (byte)(c3 * 255);
			cValue += cpValue;

			return cValue;
		}

		public override void FromInt32(uint value, out float c0, out float c1, out float c2, out float c3)
		{
			c0 = ((value >> 24) & 0xff) / 255f;
			c1 = ((value >> 16) & 0xff) / 255f;
			c2 = ((value >> 8) & 0xff) / 255f;
			c3 = (value & 0xff) / 255f;
		}
	}
}