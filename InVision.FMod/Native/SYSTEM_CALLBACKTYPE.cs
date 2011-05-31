namespace InVision.FMod.Native
{
	public enum SYSTEM_CALLBACKTYPE :int
	{
		DEVICELISTCHANGED,      /* Called when the enumerated list of devices has changed. */
		DEVICELOST,             /* Called from System::update when an output device has been lost due to control panel parameter changes and FMOD cannot automatically recover. */
		MEMORYALLOCATIONFAILED, /* Called directly when a memory allocation fails somewhere in FMOD. */
		THREADCREATED,          /* Called directly when a thread is created. */
		BADDSPCONNECTION,       /* Called when a bad connection was made with DSP::addInput. Usually called from mixer thread because that is where the connections are made.  */
		BADDSPLEVEL,            /* Called when too many effects were added exceeding the maximum tree depth of 128.  This is most likely caused by accidentally adding too many DSP effects. Usually called from mixer thread because that is where the connections are made.  */

		MAX                     /* Maximum number of callback types supported. */
	}
}