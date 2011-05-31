namespace InVision.FMod.Native
{
	public enum MEMORY_TYPE
	{
		NORMAL           = 0x00000000,       /* Standard memory. */
		STREAM_FILE      = 0x00000001,       /* Stream file buffer, size controllable with System::setStreamBufferSize. */
		STREAM_DECODE    = 0x00000002,       /* Stream decode buffer, size controllable with FMOD_CREATESOUNDEXINFO::decodebuffersize. */
		SAMPLEDATA       = 0x00000004,       /* Sample data buffer.  Raw audio data, usually PCM/MPEG/ADPCM/XMA data. */
		DSP_OUTPUTBUFFER = 0x00000008,       /* DSP memory block allocated when more than 1 output exists on a DSP node. */
		XBOX360_PHYSICAL = 0x00100000,       /* Requires XPhysicalAlloc / XPhysicalFree. */
		PERSISTENT       = 0x00200000,       /* Persistent memory. Memory will be freed when System::release is called. */
		SECONDARY        = 0x00400000        /* Secondary memory. Allocation should be in secondary memory. For example RSX on the PS3. */
	}
}