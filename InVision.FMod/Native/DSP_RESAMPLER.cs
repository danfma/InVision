namespace InVision.FMod.Native
{
	public enum DSP_RESAMPLER :int
	{
		NOINTERP,        /* No interpolation.  High frequency aliasing hiss will be audible depending on the sample rate of the sound. */
		LINEAR,          /* Linear interpolation (default method).  Fast and good quality, causes very slight lowpass effect on low frequency sounds. */
		CUBIC,           /* Cubic interpolation.  Slower than linear interpolation but better quality. */
		SPLINE,          /* 5 point spline interpolation.  Slowest resampling method but best quality. */

		MAX,             /* Maximum number of resample methods supported. */
	}
}