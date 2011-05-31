namespace InVision.FMod.Native
{
	public enum DSP_CHORUS
	{
		DRYMIX,   /* Volume of original signal to pass to output.  0.0 to 1.0. Default = 0.5. */
		WETMIX1,  /* Volume of 1st chorus tap.  0.0 to 1.0.  Default = 0.5. */
		WETMIX2,  /* Volume of 2nd chorus tap. This tap is 90 degrees out of phase of the first tap.  0.0 to 1.0.  Default = 0.5. */
		WETMIX3,  /* Volume of 3rd chorus tap. This tap is 90 degrees out of phase of the second tap.  0.0 to 1.0.  Default = 0.5. */
		DELAY,    /* Chorus delay in ms.  0.1 to 100.0.  Default = 40.0 ms. */
		RATE,     /* Chorus modulation rate in hz.  0.0 to 20.0.  Default = 0.8 hz. */
		DEPTH,    /* Chorus modulation depth.  0.0 to 1.0.  Default = 0.03. */
		FEEDBACK  /* Chorus feedback.  Controls how much of the wet signal gets fed back into the chorus buffer.  0.0 to 1.0.  Default = 0.0. */
	}
}