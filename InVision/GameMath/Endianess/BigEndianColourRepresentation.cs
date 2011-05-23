namespace InVision.GameMath.Endianess
{
	public class BigEndianColourRepresentation : LittleEndianColourRepresentation
	{
		public override uint ToInt32(float c0, float c1, float c2, float c3)
		{
			return base.ToInt32(c3, c2, c1, c0);
		}

		public override void FromInt32(uint value, out float c0, out float c1, out float c2, out float c3)
		{
			base.FromInt32(value, out c3, out c2, out c1, out c0);
		}
	}
}