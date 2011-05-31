namespace InVision.FMod.Native
{
	public enum DSP_TYPE :int
	{
		UNKNOWN,            /* This unit was created via a non FMOD plugin so has an unknown purpose */
		MIXER,              /* This unit does nothing but take inputs and mix them together then feed the result to the soundcard unit. */
		OSCILLATOR,         /* This unit generates sine/square/saw/triangle or noise tones. */
		LOWPASS,            /* This unit filters sound using a high quality, resonant lowpass filter algorithm but consumes more CPU time. */
		ITLOWPASS,          /* This unit filters sound using a resonant lowpass filter algorithm that is used in Impulse Tracker, but with limited cutoff range (0 to 8060hz). */
		HIGHPASS,           /* This unit filters sound using a resonant highpass filter algorithm. */
		ECHO,               /* This unit produces an echo on the sound and fades out at the desired rate. */
		FLANGE,             /* This unit produces a flange effect on the sound. */
		DISTORTION,         /* This unit distorts the sound. */
		NORMALIZE,          /* This unit normalizes or amplifies the sound to a certain level. */
		PARAMEQ,            /* This unit attenuates or amplifies a selected frequency range. */
		PITCHSHIFT,         /* This unit bends the pitch of a sound without changing the speed of playback. */
		CHORUS,             /* This unit produces a chorus effect on the sound. */
		REVERB,             /* This unit produces a reverb effect on the sound. */
		VSTPLUGIN,          /* This unit allows the use of Steinberg VST plugins */
		WINAMPPLUGIN,       /* This unit allows the use of Nullsoft Winamp plugins */
		ITECHO,             /* This unit produces an echo on the sound and fades out at the desired rate as is used in Impulse Tracker. */
		COMPRESSOR,         /* This unit implements dynamic compression (linked multichannel, wideband) */
		SFXREVERB,          /* This unit implements SFX reverb */
		LOWPASS_SIMPLE,     /* This unit filters sound using a simple lowpass with no resonance, but has flexible cutoff and is fast. */
		DELAY,              /* This unit produces different delays on individual channels of the sound. */
		TREMOLO,            /* This unit produces a tremolo / chopper effect on the sound. */
		LADSPAPLUGIN,       /* This unit allows the use of LADSPA standard plugins. */    
	}
}