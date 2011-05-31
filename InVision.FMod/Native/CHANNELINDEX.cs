namespace InVision.FMod.Native
{
	public enum CHANNELINDEX
	{
		FREE   = -1,     /* For a channel index, FMOD chooses a free voice using the priority system. */
		REUSE  = -2      /* For a channel index, re-use the channel handle that was passed in. */
	}
}