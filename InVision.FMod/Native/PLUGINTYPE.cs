namespace InVision.FMod.Native
{
	public enum PLUGINTYPE :int
	{
		OUTPUT,     /* The plugin type is an output module.  FMOD mixed audio will play through one of these devices */
		CODEC,      /* The plugin type is a file format codec.  FMOD will use these codecs to load file formats for playback. */
		DSP         /* The plugin type is a DSP unit.  FMOD will use these plugins as part of its DSP network to apply effects to output or generate sound in realtime. */
	}
}