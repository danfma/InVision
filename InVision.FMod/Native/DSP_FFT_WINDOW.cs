namespace InVision.FMod.Native
{
	public enum DSP_FFT_WINDOW :int
	{
		RECT,           /* w[n] = 1.0                                                                                            */
		TRIANGLE,       /* w[n] = TRI(2n/N)                                                                                      */
		HAMMING,        /* w[n] = 0.54 - (0.46 * COS(n/N) )                                                                      */
		HANNING,        /* w[n] = 0.5 *  (1.0  - COS(n/N) )                                                                      */
		BLACKMAN,       /* w[n] = 0.42 - (0.5  * COS(n/N) ) + (0.08 * COS(2.0 * n/N) )                                           */
		BLACKMANHARRIS, /* w[n] = 0.35875 - (0.48829 * COS(1.0 * n/N)) + (0.14128 * COS(2.0 * n/N)) - (0.01168 * COS(3.0 * n/N)) */

		MAX
	}
}