namespace InVision.FMod.Native
{
	public enum DSP_COMPRESSOR
	{
		THRESHOLD,  /* Threshold level (dB)in the range from -60 through 0. The default value is 50. */ 
		ATTACK,     /* Gain reduction attack time (milliseconds), in the range from 10 through 200. The default value is 50. */    
		RELEASE,    /* Gain reduction release time (milliseconds), in the range from 20 through 1000. The default value is 50. */     
		GAINMAKEUP /* Make-up gain applied after limiting, in the range from 0.0 through 100.0. The default value is 50. */   
	}
}