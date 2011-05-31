namespace InVision.FMod.Native
{
	public class DELAYTYPE_UTILITY
	{
		void FMOD_64BIT_ADD(ref uint hi1, ref uint lo1, uint hi2, uint lo2)
		{
			hi1 += (uint)((hi2) + ((((lo1) + (lo2)) < (lo1)) ? 1 : 0));
			lo1 += (lo2);
		}

		void FMOD_64BIT_SUB(ref uint hi1, ref uint lo1, uint hi2, uint lo2)
		{
			hi1 -= (uint)((hi2) + ((((lo1) - (lo2)) > (lo1)) ? 1 : 0));
			lo1 -= (lo2);
		}
	}
}