namespace InVision.FMod.Native
{
	public enum DSP_SFXREVERB
	{
		DRYLEVEL,            /* Dry Level      : Mix level of dry signal in output in mB.  Ranges from -10000.0 to 0.0.  Default is 0.0. */
		ROOM,                /* Room           : Room effect level at low frequencies in mB.  Ranges from -10000.0 to 0.0.  Default is 0.0. */
		ROOMHF,              /* Room HF        : Room effect high-frequency level re. low frequency level in mB.  Ranges from -10000.0 to 0.0.  Default is 0.0. */
		ROOMROLLOFFFACTOR,   /* Room Rolloff   : Like DS3D flRolloffFactor but for room effect.  Ranges from 0.0 to 10.0. Default is 10.0 */
		DECAYTIME,           /* Decay Time     : Reverberation decay time at low-frequencies in seconds.  Ranges from 0.1 to 20.0. Default is 1.0. */
		DECAYHFRATIO,        /* Decay HF Ratio : High-frequency to low-frequency decay time ratio.  Ranges from 0.1 to 2.0. Default is 0.5. */
		REFLECTIONSLEVEL,    /* Reflections    : Early reflections level relative to room effect in mB.  Ranges from -10000.0 to 1000.0.  Default is -10000.0. */
		REFLECTIONSDELAY,    /* Reflect Delay  : Delay time of first reflection in seconds.  Ranges from 0.0 to 0.3.  Default is 0.02. */
		REVERBLEVEL,         /* Reverb         : Late reverberation level relative to room effect in mB.  Ranges from -10000.0 to 2000.0.  Default is 0.0. */
		REVERBDELAY,         /* Reverb Delay   : Late reverberation delay time relative to first reflection in seconds.  Ranges from 0.0 to 0.1.  Default is 0.04. */
		DIFFUSION,           /* Diffusion      : Reverberation diffusion (echo density) in percent.  Ranges from 0.0 to 100.0.  Default is 100.0. */
		DENSITY,             /* Density        : Reverberation density (modal density) in percent.  Ranges from 0.0 to 100.0.  Default is 100.0. */
		HFREFERENCE,         /* HF Reference   : Reference high frequency in Hz.  Ranges from 20.0 to 20000.0. Default is 5000.0. */
		ROOMLF,              /* Room LF        : Room effect low-frequency level in mB.  Ranges from -10000.0 to 0.0.  Default is 0.0. */
		LFREFERENCE          /* LF Reference   : Reference low-frequency in Hz.  Ranges from 20.0 to 1000.0. Default is 250.0. */
	}
}