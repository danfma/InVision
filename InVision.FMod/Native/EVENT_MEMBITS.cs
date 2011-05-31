namespace InVision.FMod.Native
{
	public enum EVENT_MEMBITS :uint
	{
		EVENTSYSTEM           = 0x00000001, /* EventSystem and various internals */
		MUSICSYSTEM           = 0x00000002, /* MusicSystem and various internals */
		FEV                   = 0x00000004, /* Definition of objects contained in all loaded projects e.g. events, groups, categories */
		MEMORYFSB             = 0x00000008, /* Data loaded with registerMemoryFSB */
		EVENTPROJECT          = 0x00000010, /* EventProject objects and internals */
		EVENTGROUPI           = 0x00000020, /* EventGroup objects and internals */
		SOUNDBANKCLASS        = 0x00000040, /* Objects used to manage wave banks */
		SOUNDBANKLIST         = 0x00000080, /* Data used to manage lists of wave bank usage */
		STREAMINSTANCE        = 0x00000100, /* Stream objects and internals */
		SOUNDDEFCLASS         = 0x00000200, /* Sound definition objects */
		SOUNDDEFDEFCLASS      = 0x00000400, /* Sound definition static data objects */
		SOUNDDEFPOOL          = 0x00000800, /* Sound definition pool data */
		REVERBDEF             = 0x00001000, /* Reverb definition objects */
		EVENTREVERB           = 0x00002000, /* Reverb objects */
		USERPROPERTY          = 0x00004000, /* User property objects */
		EVENTINSTANCE         = 0x00008000, /* Event instance base objects */
		EVENTINSTANCE_COMPLEX = 0x00010000, /* Complex event instance objects */
		EVENTINSTANCE_SIMPLE  = 0x00020000, /* Simple event instance objects */
		EVENTINSTANCE_LAYER   = 0x00040000, /* Event layer instance objects */
		EVENTINSTANCE_SOUND   = 0x00080000, /* Event sound instance objects */
		EVENTENVELOPE         = 0x00100000, /* Event envelope objects */
		EVENTENVELOPEDEF      = 0x00200000, /* Event envelope definition objects */
		EVENTPARAMETER        = 0x00400000, /* Event parameter objects */
		EVENTCATEGORY         = 0x00800000, /* Event category objects */
		EVENTENVELOPEPOINT    = 0x01000000, /* Event envelope point objects */
		EVENTINSTANCEPOOL     = 0x02000000, /* Event instance pool data */
		ALL                   = 0xffffffff, /* All memory used by FMOD Event System */

		/* All event instance memory */
		EVENTINSTANCE_GROUP   = (EVENTINSTANCE | EVENTINSTANCE_COMPLEX | EVENTINSTANCE_SIMPLE | EVENTINSTANCE_LAYER | EVENTINSTANCE_SOUND),

		/* All sound definition memory */
		SOUNDDEF_GROUP        = (SOUNDDEFCLASS | SOUNDDEFDEFCLASS | SOUNDDEFPOOL)
	}
}