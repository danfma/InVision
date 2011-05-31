namespace InVision.FMod.Native
{
	public enum SPEAKER :int
	{
		FRONT_LEFT,
		FRONT_RIGHT,
		FRONT_CENTER,
		LOW_FREQUENCY,
		BACK_LEFT,
		BACK_RIGHT,
		SIDE_LEFT,
		SIDE_RIGHT,
    
		MAX,                               /* Maximum number of speaker types supported. */
		MONO        = FRONT_LEFT,    /* For use with FMOD_SPEAKERMODE_MONO and Channel::SetSpeakerLevels.  Mapped to same value as FMOD_SPEAKER_FRONT_LEFT. */
		NULL        = MAX,           /* A non speaker.  Use this to send. */
		SBL         = SIDE_LEFT,     /* For use with FMOD_SPEAKERMODE_7POINT1 on PS3 where the extra speakers are surround back inside of side speakers. */
		SBR         = SIDE_RIGHT,    /* For use with FMOD_SPEAKERMODE_7POINT1 on PS3 where the extra speakers are surround back inside of side speakers. */
	}
}