namespace InVision.FMod.Native
{
	public enum SPEAKERMAPTYPE
	{
		DEFAULT,     /* This is the default, and just means FMOD decides which speakers it puts the source channels. */
		ALLMONO,     /* This means the sound is made up of all mono sounds.  All voices will be panned to the front center by default in this case.  */
		ALLSTEREO,   /* This means the sound is made up of all stereo sounds.  All voices will be panned to front left and front right alternating every second channel.  */
		_51_PROTOOLS /* Map a 5.1 sound to use protools L C R Ls Rs LFE mapping.  Will return an error if not a 6 channel sound. */
	}
}