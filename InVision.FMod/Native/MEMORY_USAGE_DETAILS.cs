/* ============================================================================================= */
/* FMOD Ex - Memory info header file. Copyright (c), Firelight Technologies Pty, Ltd. 2009-2011. */
/*                                                                                               */
/* Use this header if you are interested in getting detailed information on FMOD's memory        */
/* usage. See the documentation for more details.                                                */
/*                                                                                               */
/* ============================================================================================= */

using System.Runtime.InteropServices;

namespace InVision.FMod.Native
{
    /*
    [STRUCTURE]
    [
        [DESCRIPTION]
        Structure to be filled with detailed memory usage information of an FMOD object

        [REMARKS]
        Every public FMOD class has a getMemoryInfo function which can be used to get detailed information on what memory resources are associated with the object in question. 
        On return from getMemoryInfo, each member of this structure will hold the amount of memory used for its type in bytes.<br>
        <br>
        Members marked with [in] mean the user sets the value before passing it to the function.<br>
        Members marked with [out] mean FMOD sets the value to be used after the function exits.<br>


        [PLATFORMS]
        Win32, Win64, Linux, Linux64, Macintosh, Xbox, Xbox360, PlayStation 2, GameCube, PlayStation Portable, PlayStation 3

        [SEE_ALSO]
        System::getMemoryInfo
        EventSystem::getMemoryInfo
        FMOD_MEMBITS    
        FMOD_EVENT_MEMBITS
    ]
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct MEMORY_USAGE_DETAILS
    {
        public uint other;                          /* [out] Memory not accounted for by other types */
        public uint stringdata;                     /* [out] String data */
        public uint system;                         /* [out] System object and various internals */
        public uint plugins;                        /* [out] Plugin objects and internals */
        public uint output;                         /* [out] Output module object and internals */
        public uint channel;                        /* [out] Channel related memory */
        public uint channelgroup;                   /* [out] ChannelGroup objects and internals */
        public uint codec;                          /* [out] Codecs allocated for streaming */
        public uint file;                           /* [out] File buffers and structures */
        public uint sound;                          /* [out] Sound objects and internals */
        public uint secondaryram;                   /* [out] Sound data stored in secondary RAM */
        public uint soundgroup;                     /* [out] SoundGroup objects and internals */
        public uint streambuffer;                   /* [out] Stream buffer memory */
        public uint dspconnection;                  /* [out] DSPConnection objects and internals */
        public uint dsp;                            /* [out] DSP implementation objects */
        public uint dspcodec;                       /* [out] Realtime file format decoding DSP objects */
        public uint profile;                        /* [out] Profiler memory footprint. */
        public uint recordbuffer;                   /* [out] Buffer used to store recorded data from microphone */
        public uint reverb;                         /* [out] Reverb implementation objects */
        public uint reverbchannelprops;             /* [out] Reverb channel properties structs */
        public uint geometry;                       /* [out] Geometry objects and internals */
        public uint syncpoint;                      /* [out] Sync point memory. */
        public uint eventsystem;                    /* [out] EventSystem and various internals */
        public uint musicsystem;                    /* [out] MusicSystem and various internals */
        public uint fev;                            /* [out] Definition of objects contained in all loaded projects e.g. events, groups, categories */
        public uint memoryfsb;                      /* [out] Data loaded with registerMemoryFSB */
        public uint eventproject;                   /* [out] EventProject objects and internals */
        public uint eventgroupi;                    /* [out] EventGroup objects and internals */
        public uint soundbankclass;                 /* [out] Objects used to manage wave banks */
        public uint soundbanklist;                  /* [out] Data used to manage lists of wave bank usage */
        public uint streaminstance;                 /* [out] Stream objects and internals */
        public uint sounddefclass;                  /* [out] Sound definition objects */
        public uint sounddefdefclass;               /* [out] Sound definition static data objects */
        public uint sounddefpool;                   /* [out] Sound definition pool data */
        public uint reverbdef;                      /* [out] Reverb definition objects */
        public uint eventreverb;                    /* [out] Reverb objects */
        public uint userproperty;                   /* [out] User property objects */
        public uint eventinstance;                  /* [out] Event instance base objects */
        public uint eventinstance_complex;          /* [out] Complex event instance objects */
        public uint eventinstance_simple;           /* [out] Simple event instance objects */
        public uint eventinstance_layer;            /* [out] Event layer instance objects */
        public uint eventinstance_sound;            /* [out] Event sound instance objects */
        public uint eventenvelope;                  /* [out] Event envelope objects */
        public uint eventenvelopedef;               /* [out] Event envelope definition objects */
        public uint eventparameter;                 /* [out] Event parameter objects */
        public uint eventcategory;                  /* [out] Event category objects */
        public uint eventenvelopepoint;             /* [out] Event envelope point objects */
        public uint eventinstancepool;              /* [out] Event instance pool memory */
    }


    /*
    [DEFINE]
    [
        [NAME]
        FMOD_MEMBITS

        [DESCRIPTION]
        Bitfield used to request specific memory usage information from the getMemoryInfo function of every public FMOD Ex class.<br>
        Use with the "memorybits" parameter of getMemoryInfo to get information on FMOD Ex memory usage.

        [REMARKS]
        Every public FMOD class has a getMemoryInfo function which can be used to get detailed information on what memory resources are associated with the object in question. 
        The FMOD_MEMBITS defines can be OR'd together to specify precisely what memory usage you'd like to get information on. See System::getMemoryInfo for an example.

        [PLATFORMS]
        Win32, Win64, Linux, Linux64, Macintosh, Xbox, Xbox360, PlayStation 2, GameCube, PlayStation Portable, PlayStation 3, Wii, Solaris

        [SEE_ALSO]
        FMOD_EVENT_MEMBITS
        EventSystem::getMemoryInfo
    ]
    */

	/*
    [DEFINE]
    [
        [NAME]
        FMOD_EVENT_MEMBITS

        [DESCRIPTION]   
        Bitfield used to request specific memory usage information from the getMemoryInfo function of every public FMOD Event System class.<br>
        Use with the "event_memorybits" parameter of getMemoryInfo to get information on FMOD Event System memory usage.

        [REMARKS]
        Every public FMOD Event System class has a getMemoryInfo function which can be used to get detailed information on what memory resources are associated with the object in question. 
        The FMOD_EVENT_MEMBITS defines can be OR'd together to specify precisely what memory usage you'd like to get information on. See EventSystem::getMemoryInfo for an example.

        [PLATFORMS]
        Win32, Win64, Linux, Linux64, Macintosh, Xbox, Xbox360, PlayStation 2, GameCube, PlayStation Portable, PlayStation 3, Wii, Solaris

        [SEE_ALSO]
        FMOD_MEMBITS
        System::getMemoryInfo
    ]
    */
}
