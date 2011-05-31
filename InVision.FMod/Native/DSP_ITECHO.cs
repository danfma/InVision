namespace InVision.FMod.Native
{
	public enum DSP_ITECHO
	{
		WETDRYMIX,      /* Ratio of wet (processed) signal to dry (unprocessed) signal. Must be in the range from 0.0 through 100.0 (all wet). The default value is 50. */
		FEEDBACK,       /* Percentage of output fed back into input, in the range from 0.0 through 100.0. The default value is 50. */
		LEFTDELAY,      /* Delay for left channel, in milliseconds, in the range from 1.0 through 2000.0. The default value is 500 ms. */
		RIGHTDELAY,     /* Delay for right channel, in milliseconds, in the range from 1.0 through 2000.0. The default value is 500 ms. */
		PANDELAY        /* Value that specifies whether to swap left and right delays with each successive echo. The default value is zero, meaning no swap. Possible values are defined as 0.0 (equivalent to FALSE) and 1.0 (equivalent to TRUE). */
	}
}