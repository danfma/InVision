using System.Runtime.InteropServices;

namespace InVision.FMod.Native
{
	[StructLayout(LayoutKind.Sequential)]
	public struct REVERB_FLAGS
	{
		public const uint DECAYTIMESCALE        = 0x00000001;   /* 'EnvSize' affects reverberation decay time */
		public const uint REFLECTIONSSCALE      = 0x00000002;   /* 'EnvSize' affects reflection level */
		public const uint REFLECTIONSDELAYSCALE = 0x00000004;   /* 'EnvSize' affects initial reflection delay time */
		public const uint REVERBSCALE           = 0x00000008;   /* 'EnvSize' affects reflections level */
		public const uint REVERBDELAYSCALE      = 0x00000010;   /* 'EnvSize' affects late reverberation delay time */
		public const uint DECAYHFLIMIT          = 0x00000020;   /* AirAbsorptionHF affects DecayHFRatio */
		public const uint ECHOTIMESCALE         = 0x00000040;   /* 'EnvSize' affects echo time */
		public const uint MODULATIONTIMESCALE   = 0x00000080;   /* 'EnvSize' affects modulation time */
		public const uint DEFAULT               = (DECAYTIMESCALE | 
		                                           REFLECTIONSSCALE | 
		                                           REFLECTIONSDELAYSCALE | 
		                                           REVERBSCALE | 
		                                           REVERBDELAYSCALE | 
		                                           DECAYHFLIMIT);
	}
}