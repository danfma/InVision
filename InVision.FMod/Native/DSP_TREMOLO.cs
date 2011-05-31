namespace InVision.FMod.Native
{
	public enum DSP_TREMOLO
	{
		FREQUENCY,     /* LFO frequency in Hz.  0.1 to 20.  Default = 4. */
		DEPTH,         /* Tremolo depth.  0 to 1.  Default = 0. */
		SHAPE,         /* LFO shape morph between triangle and sine.  0 to 1.  Default = 0. */
		SKEW,          /* Time-skewing of LFO cycle.  -1 to 1.  Default = 0. */
		DUTY,          /* LFO on-time.  0 to 1.  Default = 0.5. */
		SQUARE,        /* Flatness of the LFO shape.  0 to 1.  Default = 0. */
		PHASE,         /* Instantaneous LFO phase.  0 to 1.  Default = 0. */
		SPREAD         /* Rotation / auto-pan effect.  -1 to 1.  Default = 0. */
	}
}