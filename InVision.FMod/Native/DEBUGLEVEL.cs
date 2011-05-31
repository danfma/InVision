namespace InVision.FMod.Native
{
	public enum DEBUGLEVEL
	{
		LEVEL_NONE           = 0x00000000,
		LEVEL_LOG            = 0x00000001,
		LEVEL_ERROR          = 0x00000002,
		LEVEL_WARNING        = 0x00000004,
		LEVEL_HINT           = 0x00000008,
		LEVEL_ALL            = 0x000000FF,   
		TYPE_MEMORY          = 0x00000100,
		TYPE_THREAD          = 0x00000200,
		TYPE_FILE            = 0x00000400,
		TYPE_NET             = 0x00000800,
		TYPE_EVENT           = 0x00001000,
		TYPE_ALL             = 0x0000FFFF,                     
		DISPLAY_TIMESTAMPS   = 0x01000000,
		DISPLAY_LINENUMBERS  = 0x02000000,
		DISPLAY_COMPRESS     = 0x04000000,
		DISPLAY_THREAD       = 0x08000000,
		DISPLAY_ALL          = 0x0F000000,   
		ALL                  = unchecked((int)0xffffffff)
	}
}