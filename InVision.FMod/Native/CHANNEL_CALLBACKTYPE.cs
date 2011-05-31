namespace InVision.FMod.Native
{
	public enum CHANNEL_CALLBACKTYPE :int
	{
		END,                  /* Called when a sound ends. */
		VIRTUALVOICE,         /* Called when a voice is swapped out or swapped in. */
		SYNCPOINT,            /* Called when a syncpoint is encountered.  Can be from wav file markers. */
		OCCLUSION,            /* Called when the channel has its geometry occlusion value calculated.  Can be used to clamp or change the value. */

		MAX
	}
}