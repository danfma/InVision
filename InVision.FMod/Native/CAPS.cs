namespace InVision.FMod.Native
{
	public enum CAPS
	{
		NONE                   = 0x00000000,    /* Device has no special capabilities. */
		HARDWARE               = 0x00000001,    /* Device supports hardware mixing. */
		HARDWARE_EMULATED      = 0x00000002,    /* User has device set to 'Hardware acceleration = off' in control panel, and now extra 200ms latency is incurred. */
		OUTPUT_MULTICHANNEL    = 0x00000004,    /* Device can do multichannel output, ie greater than 2 channels. */
		OUTPUT_FORMAT_PCM8     = 0x00000008,    /* Device can output to 8bit integer PCM. */
		OUTPUT_FORMAT_PCM16    = 0x00000010,    /* Device can output to 16bit integer PCM. */
		OUTPUT_FORMAT_PCM24    = 0x00000020,    /* Device can output to 24bit integer PCM. */
		OUTPUT_FORMAT_PCM32    = 0x00000040,    /* Device can output to 32bit integer PCM. */
		OUTPUT_FORMAT_PCMFLOAT = 0x00000080,    /* Device can output to 32bit floating point PCM. */
		REVERB_EAX2            = 0x00000100,    /* Device supports EAX2 reverb. */
		REVERB_EAX3            = 0x00000200,    /* Device supports EAX3 reverb. */
		REVERB_EAX4            = 0x00000400,    /* Device supports EAX4 reverb  */
		REVERB_EAX5            = 0x00000800,    /* Device supports EAX5 reverb  */
		REVERB_I3DL2           = 0x00001000,    /* Device supports I3DL2 reverb. */
		REVERB_LIMITED         = 0x00002000     /* Device supports some form of limited hardware reverb, maybe parameterless and only selectable by environment. */
	}
}