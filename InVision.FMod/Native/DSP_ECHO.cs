namespace InVision.FMod.Native
{
	public enum DSP_ECHO
	{
		DELAY,       /* Echo delay in ms.  10  to 5000.  Default = 500. */
		DECAYRATIO,  /* Echo decay per delay.  0 to 1.  1.0 = No decay, 0.0 = total decay.  Default = 0.5. */
		MAXCHANNELS, /* Maximum channels supported.  0 to 16.  0 = same as fmod's default output polyphony, 1 = mono, 2 = stereo etc.  See remarks for more.  Default = 0.  It is suggested to leave at 0! */
		DRYMIX,      /* Volume of original signal to pass to output.  0.0 to 1.0. Default = 1.0. */
		WETMIX       /* Volume of echo signal to pass to output.  0.0 to 1.0. Default = 1.0. */
	}
}