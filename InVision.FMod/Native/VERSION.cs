/* ========================================================================================== */
/*                                                                                            */
/* FMOD Ex - C# Wrapper . Copyright (c), Firelight Technologies Pty, Ltd. 2004-2011.          */
/*                                                                                            */
/* ========================================================================================== */

namespace InVision.FMod.Native
{
    /*
        FMOD version number.  Check this against FMOD::System::getVersion / System_GetVersion
        0xaaaabbcc -> aaaa = major version number.  bb = minor version number.  cc = development version number.
    */
    public class VERSION
    {
        public const int    number = 0x00043404;
#if WIN64
        public const string dll    = "fmodex64";
#else
        public const string dll    = "fmodex";
#endif
    }

    /*
        FMOD types 
    */
    /*
    [STRUCTURE] 
    [
        [DESCRIPTION]   
        Structure describing a point in 3D space.

        [REMARKS]
        FMOD uses a left handed co-ordinate system by default.
        To use a right handed co-ordinate system specify FMOD_INIT_3D_RIGHTHANDED from FMOD_INITFLAGS in System::init.

        [PLATFORMS]
        Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation 2, PlayStation Portable, PlayStation 3, Wii

        [SEE_ALSO]      
        System::set3DListenerAttributes
        System::get3DListenerAttributes
        Channel::set3DAttributes
        Channel::get3DAttributes
        Geometry::addPolygon
        Geometry::setPolygonVertex
        Geometry::getPolygonVertex
        Geometry::setRotation
        Geometry::getRotation
        Geometry::setPosition
        Geometry::getPosition
        Geometry::setScale
        Geometry::getScale
        FMOD_INITFLAGS
    ]
    */


	/*
    [STRUCTURE] 
    [
        [DESCRIPTION]   
        Structure describing a globally unique identifier.

        [REMARKS]

        [PLATFORMS]
        Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation 2, PlayStation Portable, PlayStation 3, Wii

        [SEE_ALSO]      
        System::getDriverInfo
    ]
    */

	/*
    [STRUCTURE] 
    [
        [DESCRIPTION]   

        [REMARKS]

        [PLATFORMS]
        Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation 2, PlayStation Portable, PlayStation 3, Wii, iPhone

        [SEE_ALSO]      
    ]
    */

	/*
    [ENUM]
    [
        [DESCRIPTION]   
        error codes.  Returned from every function.

        [REMARKS]

        [PLATFORMS]
        Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation 2, PlayStation Portable, PlayStation 3, Wii

        [SEE_ALSO]      
    ]
    */


	/*
    [ENUM]
    [
        [DESCRIPTION]   
        These output types are used with System::setOutput/System::getOutput, to choose which output method to use.
  
        [REMARKS]
        To drive the output synchronously, and to disable FMOD's timing thread, use the FMOD_INIT_NONREALTIME flag.
        
        To pass information to the driver when initializing fmod use the extradriverdata parameter for the following reasons.
        <li>FMOD_OUTPUTTYPE_WAVWRITER - extradriverdata is a pointer to a char * filename that the wav writer will output to.
        <li>FMOD_OUTPUTTYPE_WAVWRITER_NRT - extradriverdata is a pointer to a char * filename that the wav writer will output to.
        <li>FMOD_OUTPUTTYPE_DSOUND - extradriverdata is a pointer to a HWND so that FMOD can set the focus on the audio for a particular window.
        <li>FMOD_OUTPUTTYPE_GC - extradriverdata is a pointer to a FMOD_ARAMBLOCK_INFO struct. This can be found in fmodgc.h.
        Currently these are the only FMOD drivers that take extra information.  Other unknown plugins may have different requirements.

        [PLATFORMS]
        Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation 2, PlayStation Portable, PlayStation 3, Wii

        [SEE_ALSO]      
        System::setOutput
        System::getOutput
        System::setSoftwareFormat
        System::getSoftwareFormat
        System::init
    ]
    */


	/*
    [ENUM] 
    [
        [DESCRIPTION]   

        [REMARKS]

        [PLATFORMS]
        Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation 2, PlayStation Portable, PlayStation 3, Wii

        [SEE_ALSO]
    ]
    */

	/*
    [DEFINE] 
    [
        [NAME]
        FMOD_DEBUGLEVEL

        [DESCRIPTION]   
        Bit fields to use with FMOD::Debug_SetLevel / FMOD::Debug_GetLevel to control the level of tty debug output with logging versions of FMOD (fmodL).

        [REMARKS]

        [PLATFORMS]
        Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation 2, PlayStation Portable, PlayStation 3, Wii

        [SEE_ALSO]
        Debug_SetLevel 
        Debug_GetLevel
    ]
    */


	/*
    [DEFINE] 
    [
        [NAME]
        FMOD_MEMORY_TYPE

        [DESCRIPTION]   
        Bit fields for memory allocation type being passed into FMOD memory callbacks.

        [REMARKS]

        [PLATFORMS]
        Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation 2, PlayStation Portable, PlayStation 3, Wii

        [SEE_ALSO]
        FMOD_MEMORY_ALLOCCALLBACK
        FMOD_MEMORY_REALLOCCALLBACK
        FMOD_MEMORY_FREECALLBACK
        Memory_Initialize
    
    ]
    */


	/*
    [ENUM]
    [
        [DESCRIPTION]   
        These are speaker types defined for use with the System::setSpeakerMode or System::getSpeakerMode command.

        [REMARKS]
        These are important notes on speaker modes in regards to sounds created with FMOD_SOFTWARE.<br>
        Note below the phrase 'sound channels' is used.  These are the subchannels inside a sound, they are not related and 
        have nothing to do with the FMOD class "Channel".<br>
        For example a mono sound has 1 sound channel, a stereo sound has 2 sound channels, and an AC3 or 6 channel wav file have 6 "sound channels".<br>
        <br>
        FMOD_SPEAKERMODE_RAW<br>
        ---------------------<br>
        This mode is for output devices that are not specifically mono/stereo/quad/surround/5.1 or 7.1, but are multichannel.<br>
        Sound channels map to speakers sequentially, so a mono sound maps to output speaker 0, stereo sound maps to output speaker 0 & 1.<br>
        The user assumes knowledge of the speaker order.  FMOD_SPEAKER enumerations may not apply, so raw channel indicies should be used.<br>
        Multichannel sounds map input channels to output channels 1:1. <br>
        Channel::setPan and Channel::setSpeakerMix do not work.<br>
        Speaker levels must be manually set with Channel::setSpeakerLevels.<br>
        <br>
        FMOD_SPEAKERMODE_MONO<br>
        ---------------------<br>
        This mode is for a 1 speaker arrangement.<br>
        Panning does not work in this speaker mode.<br>
        Mono, stereo and multichannel sounds have each sound channel played on the one speaker unity.<br>
        Mix behaviour for multichannel sounds can be set with Channel::setSpeakerLevels.<br>
        Channel::setSpeakerMix does not work.<br>
        <br>
        FMOD_SPEAKERMODE_STEREO<br>
        -----------------------<br>
        This mode is for 2 speaker arrangements that have a left and right speaker.<br>
        <li>Mono sounds default to an even distribution between left and right.  They can be panned with Channel::setPan.<br>
        <li>Stereo sounds default to the middle, or full left in the left speaker and full right in the right speaker.  
        <li>They can be cross faded with Channel::setPan.<br>
        <li>Multichannel sounds have each sound channel played on each speaker at unity.<br>
        <li>Mix behaviour for multichannel sounds can be set with Channel::setSpeakerLevels.<br>
        <li>Channel::setSpeakerMix works but only front left and right parameters are used, the rest are ignored.<br>
        <br>
        FMOD_SPEAKERMODE_QUAD<br>
        ------------------------<br>
        This mode is for 4 speaker arrangements that have a front left, front right, rear left and a rear right speaker.<br>
        <li>Mono sounds default to an even distribution between front left and front right.  They can be panned with Channel::setPan.<br>
        <li>Stereo sounds default to the left sound channel played on the front left, and the right sound channel played on the front right.<br>
        <li>They can be cross faded with Channel::setPan.<br>
        <li>Multichannel sounds default to all of their sound channels being played on each speaker in order of input.<br>
        <li>Mix behaviour for multichannel sounds can be set with Channel::setSpeakerLevels.<br>
        <li>Channel::setSpeakerMix works but side left, side right, center and lfe are ignored.<br>
        <br>
        FMOD_SPEAKERMODE_SURROUND<br>
        ------------------------<br>
        This mode is for 4 speaker arrangements that have a front left, front right, front center and a rear center.<br>
        <li>Mono sounds default to the center speaker.  They can be panned with Channel::setPan.<br>
        <li>Stereo sounds default to the left sound channel played on the front left, and the right sound channel played on the front right.  
        <li>They can be cross faded with Channel::setPan.<br>
        <li>Multichannel sounds default to all of their sound channels being played on each speaker in order of input.<br>
        <li>Mix behaviour for multichannel sounds can be set with Channel::setSpeakerLevels.<br>
        <li>Channel::setSpeakerMix works but side left, side right and lfe are ignored, and rear left / rear right are averaged into the rear speaker.<br>
        <br>
        FMOD_SPEAKERMODE_5POINT1<br>
        ------------------------<br>
        This mode is for 5.1 speaker arrangements that have a left/right/center/rear left/rear right and a subwoofer speaker.<br>
        <li>Mono sounds default to the center speaker.  They can be panned with Channel::setPan.<br>
        <li>Stereo sounds default to the left sound channel played on the front left, and the right sound channel played on the front right.  
        <li>They can be cross faded with Channel::setPan.<br>
        <li>Multichannel sounds default to all of their sound channels being played on each speaker in order of input.  
        <li>Mix behaviour for multichannel sounds can be set with Channel::setSpeakerLevels.<br>
        <li>Channel::setSpeakerMix works but side left / side right are ignored.<br>
        <br>
        FMOD_SPEAKERMODE_7POINT1<br>
        ------------------------<br>
        This mode is for 7.1 speaker arrangements that have a left/right/center/rear left/rear right/side left/side right 
        and a subwoofer speaker.<br>
        <li>Mono sounds default to the center speaker.  They can be panned with Channel::setPan.<br>
        <li>Stereo sounds default to the left sound channel played on the front left, and the right sound channel played on the front right.  
        <li>They can be cross faded with Channel::setPan.<br>
        <li>Multichannel sounds default to all of their sound channels being played on each speaker in order of input.  
        <li>Mix behaviour for multichannel sounds can be set with Channel::setSpeakerLevels.<br>
        <li>Channel::setSpeakerMix works and every parameter is used to set the balance of a sound in any speaker.<br>
        <br>
        FMOD_SPEAKERMODE_PROLOGIC<br>
        ------------------------------------------------------<br>
        This mode is for mono, stereo, 5.1 and 7.1 speaker arrangements, as it is backwards and forwards compatible with stereo, 
        but to get a surround effect a Dolby Prologic or Prologic 2 hardware decoder / amplifier is needed.<br>
        Pan behaviour is the same as FMOD_SPEAKERMODE_5POINT1.<br>
        <br>
        If this function is called the numoutputchannels setting in System::setSoftwareFormat is overwritten.<br>
        <br>
        For 3D sounds, panning is determined at runtime by the 3D subsystem based on the speaker mode to determine which speaker the 
        sound should be placed in.<br>

        [PLATFORMS]
        Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation 2, PlayStation Portable, PlayStation 3, Wii

        [SEE_ALSO]
        System::setSpeakerMode
        System::getSpeakerMode
        System::getDriverCaps
        Channel::setSpeakerLevels
    ]
    */


	/*
    [ENUM]
    [
        [DESCRIPTION]   
        These are speaker types defined for use with the Channel::setSpeakerLevels command.
        It can also be used for speaker placement in the System::setSpeakerPosition command.

        [REMARKS]
        If you are using FMOD_SPEAKERMODE_RAW and speaker assignments are meaningless, just cast a raw integer value to this type.<br>
        For example (FMOD_SPEAKER)7 would use the 7th speaker (also the same as FMOD_SPEAKER_SIDE_RIGHT).<br>
        Values higher than this can be used if an output system has more than 8 speaker types / output channels.  15 is the current maximum.

        [PLATFORMS]
        Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation 2, PlayStation Portable, PlayStation 3, Wii

        [SEE_ALSO]
        FMOD_SPEAKERMODE
        Channel::setSpeakerLevels
        Channel::getSpeakerLevels
        System::setSpeakerPosition
        System::getSpeakerPosition
    ]
    */


	/*
    [ENUM]
    [
        [DESCRIPTION]   
        These are plugin types defined for use with the System::getNumPlugins / System_GetNumPlugins, 
        System::getPluginInfo / System_GetPluginInfo and System::unloadPlugin / System_UnloadPlugin functions.

        [REMARKS]

        [PLATFORMS]
        Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation 2, PlayStation Portable, PlayStation 3, Wii

        [SEE_ALSO]
        System::getNumPlugins
        System::getPluginInfo
        System::unloadPlugin
    ]
    */


	/*
    [ENUM] 
    [
        [DESCRIPTION]   
        Initialization flags.  Use them with System::init in the flags parameter to change various behaviour.  

        [REMARKS]

        [PLATFORMS]
        Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation 2, PlayStation Portable, PlayStation 3, Wii

        [SEE_ALSO]
        System::init
    ]
    */


	/*
    [ENUM]
    [
        [DESCRIPTION]   
        These definitions describe the type of song being played.

        [REMARKS]

        [PLATFORMS]
        Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation 2, PlayStation Portable, PlayStation 3, Wii

        [SEE_ALSO]      
        Sound::getFormat
    ]
    */


	/*
    [ENUM]
    [
        [DESCRIPTION]   
        These definitions describe the native format of the hardware or software buffer that will be used.

        [REMARKS]
        This is the format the native hardware or software buffer will be or is created in.

        [PLATFORMS]
        Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation 2, PlayStation Portable, PlayStation 3, Wii

        [SEE_ALSO]
        System::createSoundEx
        Sound::getFormat
    ]
    */


	/*
    [DEFINE]
    [
        [NAME] 
        FMOD_MODE

        [DESCRIPTION]   
        Sound description bitfields, bitwise OR them together for loading and describing sounds.

        [REMARKS]
        By default a sound will open as a static sound that is decompressed fully into memory.<br>
        To have a sound stream instead, use FMOD_CREATESTREAM.<br>
        Some opening modes (ie FMOD_OPENUSER, FMOD_OPENMEMORY, FMOD_OPENRAW) will need extra information.<br>
        This can be provided using the FMOD_CREATESOUNDEXINFO structure.

        [PLATFORMS]
        Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation 2, PlayStation Portable, PlayStation 3, Wii

        [SEE_ALSO]
        System::createSound
        System::createStream
        Sound::setMode
        Sound::getMode
        Channel::setMode
        Channel::getMode
        Sound::set3DCustomRolloff
        Channel::set3DCustomRolloff
    ]
    */


	/*
    [ENUM]
    [
        [DESCRIPTION]   
        These values describe what state a sound is in after NONBLOCKING has been used to open it.

        [REMARKS]    

        [PLATFORMS]
        Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation 2, PlayStation Portable, PlayStation 3, Wii

        [SEE_ALSO]
        Sound::getOpenState
        MODE
    ]
    */


	/*
    [ENUM]
    [
        [DESCRIPTION]   
        These flags are used with SoundGroup::setMaxAudibleBehavior to determine what happens when more sounds 
        are played than are specified with SoundGroup::setMaxAudible.

        [REMARKS]
        When using FMOD_SOUNDGROUP_BEHAVIOR_MUTE, SoundGroup::setMuteFadeSpeed can be used to stop a sudden transition.  
        Instead, the time specified will be used to cross fade between the sounds that go silent and the ones that become audible.

        [PLATFORMS]
        Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation 2, PlayStation Portable, PlayStation 3, Wii

        [SEE_ALSO]      
        SoundGroup::setMaxAudibleBehavior
        SoundGroup::getMaxAudibleBehavior
        SoundGroup::setMaxAudible
        SoundGroup::getMaxAudible
        SoundGroup::setMuteFadeSpeed
        SoundGroup::getMuteFadeSpeed
    ]
    */

	/*
    [ENUM]
    [
        [DESCRIPTION]   
        These callback types are used with System::setCallback.

        [REMARKS]
        Each callback has commanddata parameters passed as int unique to the type of callback.<br>
        See reference to FMOD_SYSTEM_CALLBACK to determine what they might mean for each type of callback.<br>
        <br>
        <b>Note!</b>  Currently the user must call System::update for these callbacks to trigger!

        [PLATFORMS]
        Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation 2, PlayStation Portable, PlayStation 3, Wii

        [SEE_ALSO]      
        System::setCallback
        FMOD_SYSTEM_CALLBACK
        System::update
    ]
    */

	/*
    [ENUM]
    [
        [DESCRIPTION]   
        These callback types are used with Channel::setCallback.

        [REMARKS]
        Each callback has commanddata parameters passed int unique to the type of callback.
        See reference to FMOD_CHANNEL_CALLBACK to determine what they might mean for each type of callback.

        [PLATFORMS]
        Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation 2, PlayStation Portable, PlayStation 3, Wii

        [SEE_ALSO]      
        Channel::setCallback
        FMOD_CHANNEL_CALLBACK
    ]
    */


	/* 
        FMOD Callbacks
    */

	/*
    [ENUM]
    [
        [DESCRIPTION]   
        List of windowing methods used in spectrum analysis to reduce leakage / transient signals intefering with the analysis.
        This is a problem with analysis of continuous signals that only have a small portion of the signal sample (the fft window size).
        Windowing the signal with a curve or triangle tapers the sides of the fft window to help alleviate this problem.

        [REMARKS]
        Cyclic signals such as a sine wave that repeat their cycle in a multiple of the window size do not need windowing.
        I.e. If the sine wave repeats every 1024, 512, 256 etc samples and the FMOD fft window is 1024, then the signal would not need windowing.
        Not windowing is the same as FMOD_DSP_FFT_WINDOW_RECT, which is the default.
        If the cycle of the signal (ie the sine wave) is not a multiple of the window size, it will cause frequency abnormalities, so a different windowing method is needed.
        <exclude>
        
        FMOD_DSP_FFT_WINDOW_RECT.
        <img src = "rectangle.gif"></img>
        
        FMOD_DSP_FFT_WINDOW_TRIANGLE.
        <img src = "triangle.gif"></img>
        
        FMOD_DSP_FFT_WINDOW_HAMMING.
        <img src = "hamming.gif"></img>
        
        FMOD_DSP_FFT_WINDOW_HANNING.
        <img src = "hanning.gif"></img>
        
        FMOD_DSP_FFT_WINDOW_BLACKMAN.
        <img src = "blackman.gif"></img>
        
        FMOD_DSP_FFT_WINDOW_BLACKMANHARRIS.
        <img src = "blackmanharris.gif"></img>
        </exclude>

        [PLATFORMS]
        Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation 2, PlayStation Portable, PlayStation 3, Wii

        [SEE_ALSO]      
        System::getSpectrum
        Channel::getSpectrum
    ]
    */


	/*
    [ENUM]
    [
        [DESCRIPTION]   
        List of interpolation types that the FMOD Ex software mixer supports.  

        [REMARKS]
        The default resampler type is FMOD_DSP_RESAMPLER_LINEAR.<br>
        Use System::setSoftwareFormat to tell FMOD the resampling quality you require for FMOD_SOFTWARE based sounds.

        [PLATFORMS]
        Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation 2, PlayStation Portable, PlayStation 3, Wii

        [SEE_ALSO]      
        System::setSoftwareFormat
        System::getSoftwareFormat
    ]
    */


	/*
    [ENUM]
    [
        [DESCRIPTION]   
        List of tag types that could be stored within a sound.  These include id3 tags, metadata from netstreams and vorbis/asf data.

        [REMARKS]

        [PLATFORMS]
        Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation 2, PlayStation Portable, PlayStation 3, Wii

        [SEE_ALSO]      
        Sound::getTag
    ]
    */


	/*
    [ENUM]
    [
        [DESCRIPTION]   
        List of data types that can be returned by Sound::getTag

        [REMARKS]

        [PLATFORMS]
        Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation 2, PlayStation Portable, PlayStation 3, Wii

        [SEE_ALSO]      
        Sound::getTag
    ]
    */

	/*
    [ENUM]
    [
        [DESCRIPTION]   
        Types of delay that can be used with Channel::setDelay / Channel::getDelay.

        [REMARKS]
        If you haven't called Channel::setDelay yet, if you call Channel::getDelay with FMOD_DELAYTYPE_DSPCLOCK_START it will return the 
        equivalent global DSP clock value to determine when a channel started, so that you can use it for other channels to sync against.<br>
        <br>
        Use System::getDSPClock to also get the current dspclock time, a base for future calls to Channel::setDelay.<br>
        <br>
        Use FMOD_64BIT_ADD or FMOD_64BIT_SUB to add a hi/lo combination together and cope with wraparound.
        <br>
        If FMOD_DELAYTYPE_END_MS is specified, the value is not treated as a 64 bit number, just the delayhi value is used and it is treated as milliseconds.

        [PLATFORMS]
        Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation 2, PlayStation Portable, PlayStation 3, Wii

        [SEE_ALSO]      
        Channel::setDelay
        Channel::getDelay
        System::getDSPClock
    ]
    */


	/*
    [STRUCTURE] 
    [
        [DESCRIPTION]   
        Structure describing a piece of tag data.

        [REMARKS]
        Members marked with [in] mean the user sets the value before passing it to the function.
        Members marked with [out] mean FMOD sets the value to be used after the function exits.

        [PLATFORMS]
        Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation 2, PlayStation Portable, PlayStation 3, Wii

        [SEE_ALSO]      
        Sound::getTag
        TAGTYPE
        TAGDATATYPE
    ]
    */


	/*
    [STRUCTURE] 
    [
        [DESCRIPTION]   
        Structure describing a CD/DVD table of contents

        [REMARKS]
        Members marked with [in] mean the user sets the value before passing it to the function.
        Members marked with [out] mean FMOD sets the value to be used after the function exits.

        [PLATFORMS]
        Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation 2, PlayStation Portable, PlayStation 3, Wii

        [SEE_ALSO]      
        Sound::getTag
    ]
    */


	/*
    [ENUM]
    [
        [DESCRIPTION]   
        List of time types that can be returned by Sound::getLength and used with Channel::setPosition or Channel::getPosition.

        [REMARKS]

        [PLATFORMS]
        Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation 2, PlayStation Portable, PlayStation 3, Wii

        [SEE_ALSO]      
        Sound::getLength
        Channel::setPosition
        Channel::getPosition
    ]
    */


	/*
    [ENUM]
    [
        [DESCRIPTION]
        When creating a multichannel sound, FMOD will pan them to their default speaker locations, for example a 6 channel sound will default to one channel per 5.1 output speaker.<br>
        Another example is a stereo sound.  It will default to left = front left, right = front right.<br>
        <br>
        This is for sounds that are not 'default'.  For example you might have a sound that is 6 channels but actually made up of 3 stereo pairs, that should all be located in front left, front right only.

        [REMARKS]
        For full flexibility of speaker assignments, use Channel::setSpeakerLevels.  This functionality is cheaper, uses less memory and easier to use.

        [PLATFORMS]
        Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation 2, PlayStation Portable, PlayStation 3, Wii

        [SEE_ALSO]
        FMOD_CREATESOUNDEXINFO
        Channel::setSpeakerLevels
    ]
    */


	/*
    [STRUCTURE] 
    [
        [DESCRIPTION]
        Use this structure with System::createSound when more control is needed over loading.
        The possible reasons to use this with System::createSound are:
        <li>Loading a file from memory.
        <li>Loading a file from within another larger (possibly wad/pak) file, by giving the loader an offset and length.
        <li>To create a user created / non file based sound.
        <li>To specify a starting subsound to seek to within a multi-sample sounds (ie FSB/DLS/SF2) when created as a stream.
        <li>To specify which subsounds to load for multi-sample sounds (ie FSB/DLS/SF2) so that memory is saved and only a subset is actually loaded/read from disk.
        <li>To specify 'piggyback' read and seek callbacks for capture of sound data as fmod reads and decodes it.  Useful for ripping decoded PCM data from sounds as they are loaded / played.
        <li>To specify a MIDI DLS/SF2 sample set file to load when opening a MIDI file.
        See below on what members to fill for each of the above types of sound you want to create.

        [REMARKS]
        This structure is optional!  Specify 0 or NULL in System::createSound if you don't need it!
        
        Members marked with [in] mean the user sets the value before passing it to the function.
        Members marked with [out] mean FMOD sets the value to be used after the function exits.
        
        <u>Loading a file from memory.</u>
        <li>Create the sound using the FMOD_OPENMEMORY flag.
        <li>Mandantory.  Specify 'length' for the size of the memory block in bytes.
        <li>Other flags are optional.
        
        
        <u>Loading a file from within another larger (possibly wad/pak) file, by giving the loader an offset and length.</u>
        <li>Mandantory.  Specify 'fileoffset' and 'length'.
        <li>Other flags are optional.
        
        
        <u>To create a user created / non file based sound.</u>
        <li>Create the sound using the FMOD_OPENUSER flag.
        <li>Mandantory.  Specify 'defaultfrequency, 'numchannels' and 'format'.
        <li>Other flags are optional.
        
        
        <u>To specify a starting subsound to seek to and flush with, within a multi-sample stream (ie FSB/DLS/SF2).</u>
        
        <li>Mandantory.  Specify 'initialsubsound'.
        
        
        <u>To specify which subsounds to load for multi-sample sounds (ie FSB/DLS/SF2) so that memory is saved and only a subset is actually loaded/read from disk.</u>
        
        <li>Mandantory.  Specify 'inclusionlist' and 'inclusionlistnum'.
        
        
        <u>To specify 'piggyback' read and seek callbacks for capture of sound data as fmod reads and decodes it.  Useful for ripping decoded PCM data from sounds as they are loaded / played.</u>
        
        <li>Mandantory.  Specify 'pcmreadcallback' and 'pcmseekcallback'.
        
        
        <u>To specify a MIDI DLS/SF2 sample set file to load when opening a MIDI file.</u>
        
        <li>Mandantory.  Specify 'dlsname'.
        
        
        Setting the 'decodebuffersize' is for cpu intensive codecs that may be causing stuttering, not file intensive codecs (ie those from CD or netstreams) which are normally altered with System::setStreamBufferSize.  As an example of cpu intensive codecs, an mp3 file will take more cpu to decode than a PCM wav file.
        If you have a stuttering effect, then it is using more cpu than the decode buffer playback rate can keep up with.  Increasing the decode buffersize will most likely solve this problem.

        [PLATFORMS]
        Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation 2, PlayStation Portable, PlayStation 3, Wii

        [SEE_ALSO]
        System::createSound
        System::setStreamBufferSize
        FMOD_MODE
    ]
    */


	/*
    [STRUCTURE] 
    [
        [DESCRIPTION]
        Structure defining a reverb environment.<br>
        <br>
        For more indepth descriptions of the reverb properties under win32, please see the EAX2 and EAX3
        documentation at http://developer.creative.com/ under the 'downloads' section.<br>
        If they do not have the EAX3 documentation, then most information can be attained from
        the EAX2 documentation, as EAX3 only adds some more parameters and functionality on top of 
        EAX2.

        [REMARKS]
        Note the default reverb properties are the same as the FMOD_PRESET_GENERIC preset.<br>
        Note that integer values that typically range from -10,000 to 1000 are represented in 
        decibels, and are of a logarithmic scale, not linear, wheras float values are always linear.<br>
        <br>
        The numerical values listed below are the maximum, minimum and default values for each variable respectively.<br>
        <br>
        <b>SUPPORTED</b> next to each parameter means the platform the parameter can be set on.  Some platforms support all parameters and some don't.<br>
        EAX   means hardware reverb on FMOD_OUTPUTTYPE_DSOUND on windows only (must use FMOD_HARDWARE), on soundcards that support EAX 1 to 4.<br>
        EAX4  means hardware reverb on FMOD_OUTPUTTYPE_DSOUND on windows only (must use FMOD_HARDWARE), on soundcards that support EAX 4.<br>
        I3DL2 means hardware reverb on FMOD_OUTPUTTYPE_DSOUND on windows only (must use FMOD_HARDWARE), on soundcards that support I3DL2 non EAX native reverb.<br>
        GC    means Nintendo Gamecube hardware reverb (must use FMOD_HARDWARE).<br>
        WII   means Nintendo Wii hardware reverb (must use FMOD_HARDWARE).<br>
        PS2   means Playstation 2 hardware reverb (must use FMOD_HARDWARE).<br>
        SFX   means FMOD SFX software reverb.  This works on any platform that uses FMOD_SOFTWARE for loading sounds.<br>
        <br>
        Members marked with [in] mean the user sets the value before passing it to the function.<br>
        Members marked with [out] mean FMOD sets the value to be used after the function exits.<br>

        [PLATFORMS]
        Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation 2, PlayStation Portable, PlayStation 3, Wii

        [SEE_ALSO]
        System::setReverbProperties
        System::getReverbProperties
        FMOD_REVERB_PRESETS
        FMOD_REVERB_FLAGS
    ]
    */


	/*
    [DEFINE] 
    [
        [NAME] 
        REVERB_FLAGS

        [DESCRIPTION]
        Values for the Flags member of the REVERB_PROPERTIES structure.

        [PLATFORMS]
        Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation 2, PlayStation Portable, PlayStation 3, Wii

        [SEE_ALSO]
        REVERB_PROPERTIES
    ]
    */


	/*
    [DEFINE] 
    [
    [NAME] 
    FMOD_REVERB_PRESETS

    [DESCRIPTION]   
    A set of predefined environment PARAMETERS, created by Creative Labs
    These are used to initialize an FMOD_REVERB_PROPERTIES structure statically.
    ie 
    FMOD_REVERB_PROPERTIES prop = FMOD_PRESET_GENERIC;

    [PLATFORMS]
    Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation 2, PlayStation Portable, PlayStation 3, Wii

    [SEE_ALSO]
    System::setReverbProperties
    ]
    */

	/*
    [STRUCTURE] 
    [
        [DESCRIPTION]
        Structure defining the properties for a reverb source, related to a FMOD channel.

        For more indepth descriptions of the reverb properties under win32, please see the EAX3
        documentation at http://developer.creative.com/ under the 'downloads' section.
        If they do not have the EAX3 documentation, then most information can be attained from
        the EAX2 documentation, as EAX3 only adds some more parameters and functionality on top of 
        EAX2.

        Note the default reverb properties are the same as the PRESET_GENERIC preset.
        Note that integer values that typically range from -10,000 to 1000 are represented in 
        decibels, and are of a logarithmic scale, not linear, wheras FLOAT values are typically linear.
        PORTABILITY: Each member has the platform it supports in braces ie (win32/xbox).  
        Some reverb parameters are only supported in win32 and some only on xbox. If all parameters are set then
        the reverb should product a similar effect on either platform.
        Linux and FMODCE do not support the reverb api.

        The numerical values listed below are the maximum, minimum and default values for each variable respectively.

        [REMARKS]
        For EAX4 support with multiple reverb environments, set FMOD_REVERB_CHANNELFLAGS_ENVIRONMENT0,
        FMOD_REVERB_CHANNELFLAGS_ENVIRONMENT1 or/and FMOD_REVERB_CHANNELFLAGS_ENVIRONMENT2 in the flags member 
        of FMOD_REVERB_CHANNELPROPERTIES to specify which environment instance(s) to target. 
        Only up to 2 environments to target can be specified at once. Specifying three will result in an error.
        If the sound card does not support EAX4, the environment flag is ignored.

        [PLATFORMS]
        Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation 2, PlayStation Portable, PlayStation 3, Wii

        [SEE_ALSO]
        Channel::setReverbProperties
        Channel::getReverbProperties
        REVERB_CHANNELFLAGS
    ]
    */


	/*
    [DEFINE] 
    [
        [NAME] 
        REVERB_CHANNELFLAGS

        [DESCRIPTION]
        Values for the Flags member of the REVERB_CHANNELPROPERTIES structure.

        [PLATFORMS]
        Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation 2, PlayStation Portable, PlayStation 3, Wii

        [SEE_ALSO]
        REVERB_CHANNELPROPERTIES
    ]
    */


	/*
    [STRUCTURE] 
    [
        [DESCRIPTION]
        Settings for advanced features like configuring memory and cpu usage for the FMOD_CREATECOMPRESSEDSAMPLE feature.
   
        [REMARKS]
        maxMPEGcodecs / maxADPCMcodecs / maxXMAcodecs will determine the maximum cpu usage of playing realtime samples.  Use this to lower potential excess cpu usage and also control memory usage.<br>
   
        [PLATFORMS]
        Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation 2, PlayStation Portable, PlayStation 3
   
        [SEE_ALSO]
        System::setAdvancedSettings
        System::getAdvancedSettings
    ]
    */


	/*
    [ENUM] 
    [
        [NAME] 
        FMOD_MISC_VALUES

        [DESCRIPTION]
        Miscellaneous values for FMOD functions.

        [PLATFORMS]
        Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation 2, PlayStation Portable, PlayStation 3, Wii

        [SEE_ALSO]
        System::playSound
        System::playDSP
        System::getChannel
    ]
    */


	/*
        FMOD System factory functions.  Use this to create an FMOD System Instance.  below you will see System_Init/Close to get started.
    */


	/*
        'System' API
    */


	/*
        'Sound' API
    */


	/*
        'Channel' API
    */


	/*
        'ChannelGroup' API
    */


	/*
        'SoundGroup' API
    */


	/*
        'DSP' API
    */


	/*
        'DSPConnection' API
    */

	/*
        'Geometry' API
    */

	/*
        'Reverb' API
    */
}
