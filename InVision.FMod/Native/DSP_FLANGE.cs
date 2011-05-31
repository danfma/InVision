namespace InVision.FMod.Native
{
	public enum DSP_FLANGE
	{
		DRYMIX,      /* Volume of original signal to pass to output.  0.0 to 1.0. Default = 0.45. */
		WETMIX,      /* Volume of flange signal to pass to output.  0.0 to 1.0. Default = 0.55. */
		DEPTH,       /* Flange depth.  0.01 to 1.0.  Default = 1.0. */
		RATE         /* Flange speed in hz.  0.0 to 20.0.  Default = 0.1. */
	}
}