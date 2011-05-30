using InVision.FMod.Attributes;

namespace InVision.FMod
{
	[FModEnumeration("FMOD_TAGTYPE")]
	public enum TagType
	{
		Unknown,
		Id3V1,
		Id3V2,
		VorbisComment,
		Shoutcast,
		Icecast,
		Asf,
		Midi,
		Playlist,
		Fmod,
		User,
		Max
	}
}