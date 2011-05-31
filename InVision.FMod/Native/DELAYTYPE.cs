namespace InVision.FMod.Native
{
	public enum DELAYTYPE :int
	{
		END_MS,              /* Delay at the end of the sound in milliseconds.  Use delayhi only.   Channel::isPlaying will remain true until this delay has passed even though the sound itself has stopped playing.*/
		DSPCLOCK_START,      /* Time the sound started if Channel::getDelay is used, or if Channel::setDelay is used, the sound will delay playing until this exact tick. */
		DSPCLOCK_END,        /* Time the sound should end. If this is non-zero, the channel will go silent at this exact tick. */
		DSPCLOCK_PAUSE,      /* Time the sound should pause. If this is non-zero, the channel will pause at this exact tick. */

		MAX                  /* Maximum number of tag datatypes supported. */
	}
}