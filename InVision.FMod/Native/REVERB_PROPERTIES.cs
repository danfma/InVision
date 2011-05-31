using System.Runtime.InteropServices;

namespace InVision.FMod.Native
{
	[StructLayout(LayoutKind.Sequential)]
	public struct REVERB_PROPERTIES
	{                                   /*          MIN     MAX    DEFAULT   DESCRIPTION */
		public int   Instance;          /* [in]     0     , 3     , 0      , EAX4 only. Environment Instance. 3 seperate reverbs simultaneously are possible. This specifies which one to set. (win32 only) */
		public int   Environment;       /* [in/out] -1    , 25    , -1     , sets all listener properties (win32/ps2) */
		public float EnvSize;           /* [in/out] 1.0   , 100.0 , 7.5    , environment size in meters (win32 only) */
		public float EnvDiffusion;      /* [in/out] 0.0   , 1.0   , 1.0    , environment diffusion (win32/xbox) */
		public int   Room;              /* [in/out] -10000, 0     , -1000  , room effect level (at mid frequencies) (win32/xbox) */
		public int   RoomHF;            /* [in/out] -10000, 0     , -100   , relative room effect level at high frequencies (win32/xbox) */
		public int   RoomLF;            /* [in/out] -10000, 0     , 0      , relative room effect level at low frequencies (win32 only) */
		public float DecayTime;         /* [in/out] 0.1   , 20.0  , 1.49   , reverberation decay time at mid frequencies (win32/xbox) */
		public float DecayHFRatio;      /* [in/out] 0.1   , 2.0   , 0.83   , high-frequency to mid-frequency decay time ratio (win32/xbox) */
		public float DecayLFRatio;      /* [in/out] 0.1   , 2.0   , 1.0    , low-frequency to mid-frequency decay time ratio (win32 only) */
		public int   Reflections;       /* [in/out] -10000, 1000  , -2602  , early reflections level relative to room effect (win32/xbox) */
		public float ReflectionsDelay;  /* [in/out] 0.0   , 0.3   , 0.007  , initial reflection delay time (win32/xbox) */
		[MarshalAs(UnmanagedType.ByValArray,SizeConst=3)]
		public float[] ReflectionsPan;  /* [in/out]       ,       , [0,0,0], early reflections panning vector (win32 only) */
		public int   Reverb;            /* [in/out] -10000, 2000  , 200    , late reverberation level relative to room effect (win32/xbox) */
		public float ReverbDelay;       /* [in/out] 0.0   , 0.1   , 0.011  , late reverberation delay time relative to initial reflection (win32/xbox) */
		[MarshalAs(UnmanagedType.ByValArray,SizeConst=3)]
		public float[] ReverbPan;       /* [in/out]       ,       , [0,0,0], late reverberation panning vector (win32 only) */
		public float EchoTime;          /* [in/out] .075  , 0.25  , 0.25   , echo time (win32 only) */
		public float EchoDepth;         /* [in/out] 0.0   , 1.0   , 0.0    , echo depth (win32 only) */
		public float ModulationTime;    /* [in/out] 0.04  , 4.0   , 0.25   , modulation time (win32 only) */
		public float ModulationDepth;   /* [in/out] 0.0   , 1.0   , 0.0    , modulation depth (win32 only) */
		public float AirAbsorptionHF;   /* [in/out] -100  , 0.0   , -5.0   , change in level per meter at high frequencies (win32 only) */
		public float HFReference;       /* [in/out] 1000.0, 20000 , 5000.0 , reference high frequency (hz) (win32/xbox) */
		public float LFReference;       /* [in/out] 20.0  , 1000.0, 250.0  , reference low frequency (hz) (win32 only) */
		public float RoomRolloffFactor; /* [in/out] 0.0   , 10.0  , 0.0    , like rolloffscale in System::set3DSettings but for reverb room size effect (win32) */
		public float Diffusion;         /* [in/out] 0.0   , 100.0 , 100.0  , Value that controls the echo density in the late reverberation decay. (xbox only) */
		public float Density;           /* [in/out] 0.0   , 100.0 , 100.0  , Value that controls the modal density in the late reverberation decay (xbox only) */
		public uint  Flags;             /* [in/out] REVERB_FLAGS - modifies the behavior of above properties (win32/ps2) */

		#region wrapperinternal
		public REVERB_PROPERTIES(int instance, int environment, float envSize, float envDiffusion, int room, int roomHF, int roomLF,
		                         float decayTime, float decayHFRatio, float decayLFRatio, int reflections, float reflectionsDelay,
		                         float reflectionsPanx, float reflectionsPany, float reflectionsPanz, int reverb, float reverbDelay,
		                         float reverbPanx, float reverbPany, float reverbPanz, float echoTime, float echoDepth, float modulationTime,
		                         float modulationDepth, float airAbsorptionHF, float hfReference, float lfReference, float roomRolloffFactor,
		                         float diffusion, float density, uint flags)
		{
			ReflectionsPan      = new float[3];
			ReverbPan           = new float[3];

			Instance            = instance;
			Environment         = environment;
			EnvSize             = envSize;
			EnvDiffusion        = envDiffusion;
			Room                = room;
			RoomHF              = roomHF;
			RoomLF              = roomLF;
			DecayTime           = decayTime;
			DecayHFRatio        = decayHFRatio;
			DecayLFRatio        = decayLFRatio;
			Reflections         = reflections;
			ReflectionsDelay    = reflectionsDelay;
			ReflectionsPan[0]   = reflectionsPanx;
			ReflectionsPan[1]   = reflectionsPany;
			ReflectionsPan[2]   = reflectionsPanz;
			Reverb              = reverb;
			ReverbDelay          = reverbDelay;
			ReverbPan[0]        = reverbPanx;
			ReverbPan[1]        = reverbPany;
			ReverbPan[2]        = reverbPanz;
			EchoTime            = echoTime;
			EchoDepth           = echoDepth;
			ModulationTime      = modulationTime;
			ModulationDepth     = modulationDepth;
			AirAbsorptionHF     = airAbsorptionHF;
			HFReference         = hfReference;
			LFReference         = lfReference;
			RoomRolloffFactor   = roomRolloffFactor;
			Diffusion           = diffusion;
			Density             = density;
			Flags               = flags;
		}
		#endregion
	}
}