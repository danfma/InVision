using System;
using System.Runtime.InteropServices;

namespace InVision.FMod.Native
{
	[StructLayout(LayoutKind.Sequential)]
	public struct REVERB_CHANNELPROPERTIES  
	{                                      /*          MIN     MAX    DEFAULT  DESCRIPTION */
		public int       Direct;               /* [in/out] -10000, 1000,  0,       direct path level (at low and mid frequencies) (win32/xbox) */
		public int       DirectHF;             /* [in/out] -10000, 0,     0,       relative direct path level at high frequencies (win32/xbox) */
		public int       Room;                 /* [in/out] -10000, 1000,  0,       room effect level (at low and mid frequencies) (win32/xbox) */
		public int       RoomHF;               /* [in/out] -10000, 0,     0,       relative room effect level at high frequencies (win32/xbox) */
		public int       Obstruction;          /* [in/out] -10000, 0,     0,       main obstruction control (attenuation at high frequencies)  (win32/xbox) */
		public float     ObstructionLFRatio;   /* [in/out] 0.0,    1.0,   0.0,     obstruction low-frequency level re. main control (win32/xbox) */
		public int       Occlusion;            /* [in/out] -10000, 0,     0,       main occlusion control (attenuation at high frequencies) (win32/xbox) */
		public float     OcclusionLFRatio;     /* [in/out] 0.0,    1.0,   0.25,    occlusion low-frequency level re. main control (win32/xbox) */
		public float     OcclusionRoomRatio;   /* [in/out] 0.0,    10.0,  1.5,     relative occlusion control for room effect (win32) */
		public float     OcclusionDirectRatio; /* [in/out] 0.0,    10.0,  1.0,     relative occlusion control for direct path (win32) */
		public int       Exclusion;            /* [in/out] -10000, 0,     0,       main exlusion control (attenuation at high frequencies) (win32) */
		public float     ExclusionLFRatio;     /* [in/out] 0.0,    1.0,   1.0,     exclusion low-frequency level re. main control (win32) */
		public int       OutsideVolumeHF;      /* [in/out] -10000, 0,     0,       outside sound cone level at high frequencies (win32) */
		public float     DopplerFactor;        /* [in/out] 0.0,    10.0,  0.0,     like DS3D flDopplerFactor but per source (win32) */
		public float     RolloffFactor;        /* [in/out] 0.0,    10.0,  0.0,     like DS3D flRolloffFactor but per source (win32) */
		public float     RoomRolloffFactor;    /* [in/out] 0.0,    10.0,  0.0,     like DS3D flRolloffFactor but for room effect (win32/xbox) */
		public float     AirAbsorptionFactor;  /* [in/out] 0.0,    10.0,  1.0,     multiplies AirAbsorptionHF member of REVERB_PROPERTIES (win32) */
		public uint      Flags;                /* [in/out] REVERB_CHANNELFLAGS - modifies the behavior of properties (win32) */
		public IntPtr    ConnectionPoint;      /* [in/out] See remarks.            DSP network location to connect reverb for this channel.    (SUPPORTED:SFX only).*/
	}
}