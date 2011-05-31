namespace InVision.FMod.Native
{
	public enum SPEAKERMODE :int
	{
		RAW,              /* There is no specific speakermode.  Sound channels are mapped in order of input to output.  See remarks for more information. */
		MONO,             /* The speakers are monaural. */
		STEREO,           /* The speakers are stereo (DEFAULT). */
		QUAD,             /* 4 speaker setup.  This includes front left, front right, rear left, rear right.  */
		SURROUND,         /* 4 speaker setup.  This includes front left, front right, center, rear center (rear left/rear right are averaged). */
		_5POINT1,         /* 5.1 speaker setup.  This includes front left, front right, center, rear left, rear right and a subwoofer. */
		_7POINT1,         /* 7.1 speaker setup.  This includes front left, front right, center, rear left, rear right, side left, side right and a subwoofer. */
		PROLOGIC,         /* Stereo output, but data is encoded in a way that is picked up by a Prologic/Prologic2 decoder and split into a 5.1 speaker setup. */

		MAX,              /* Maximum number of speaker modes supported. */
	}
}