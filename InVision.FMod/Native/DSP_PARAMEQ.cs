namespace InVision.FMod.Native
{
	public enum DSP_PARAMEQ
	{
		CENTER,     /* Frequency center.  20.0 to 22000.0.  Default = 8000.0. */
		BANDWIDTH,  /* Octave range around the center frequency to filter.  0.2 to 5.0.  Default = 1.0. */
		GAIN        /* Frequency Gain.  0.05 to 3.0.  Default = 1.0.  */
	}
}