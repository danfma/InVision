namespace InVision.FMod.Native
{
	public enum DSP_NORMALIZE
	{
		FADETIME,    /* Time to ramp the silence to full in ms.  0.0 to 20000.0. Default = 5000.0. */
		THRESHHOLD,  /* Lower volume range threshold to ignore.  0.0 to 1.0.  Default = 0.1.  Raise higher to stop amplification of very quiet signals. */
		MAXAMP       /* Maximum amplification allowed.  1.0 to 100000.0.  Default = 20.0.  1.0 = no amplifaction, higher values allow more boost. */
	}
}