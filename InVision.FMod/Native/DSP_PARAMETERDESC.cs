/*$ preserve start $*/
/* ========================================================================================== */
/* FMOD Ex - DSP header file. Copyright (c), Firelight Technologies Pty, Ltd. 2004-2011.      */
/*                                                                                            */
/* Use this header if you are interested in delving deeper into the FMOD software mixing /    */
/* DSP engine.  In this header you can find parameter structures for FMOD system reigstered   */
/* DSP effects and generators.                                                                */
/*                                                                                            */
/* ========================================================================================== */

using System.Runtime.InteropServices;

namespace InVision.FMod.Native
{
/*$ preserve end $*/

    /* 
        DSP callbacks
    */


	/*
    [ENUM]
    [
        [DESCRIPTION]   
        These definitions can be used for creating FMOD defined special effects or DSP units.

        [REMARKS]
        To get them to be active, first create the unit, then add it somewhere into the DSP network, either at the front of the network near the soundcard unit to affect the global output (by using System::getDSPHead), or on a single channel (using Channel::getDSPHead).

        [PLATFORMS]
        Win32, Win64, Linux, Linux64, Macintosh, Xbox, Xbox360, PlayStation 2, GameCube, PlayStation Portable, PlayStation 3, Wii

        [SEE_ALSO]
        System::createDSPByType
    ]
    */


	/*
    [STRUCTURE]
    [
        [DESCRIPTION]   

        [REMARKS]
        Members marked with [in] mean the user sets the value before passing it to the function.<br>
        Members marked with [out] mean FMOD sets the value to be used after the function exits.<br>
        <br>
        The step parameter tells the gui or application that the parameter has a certain granularity.<br>
        For example in the example of cutoff frequency with a range from 100.0 to 22050.0 you might only want the selection to be in 10hz increments.  For this you would simply use 10.0 as the step value.<br>
        For a boolean, you can use min = 0.0, max = 1.0, step = 1.0.  This way the only possible values are 0.0 and 1.0.<br>
        Some applications may detect min = 0.0, max = 1.0, step = 1.0 and replace a graphical slider bar with a checkbox instead.<br>
        A step value of 1.0 would simulate integer values only.<br>
        A step value of 0.0 would mean the full floating point range is accessable.<br>

        [PLATFORMS]
        Win32, Win64, Linux, Linux64, Macintosh, Xbox, Xbox360, PlayStation 2, GameCube, PlayStation Portable, PlayStation 3, Wii

        [SEE_ALSO]    
        System::createDSP
        System::getDSP
    ]
    */
    public struct DSP_PARAMETERDESC
    {
        public float         min;             /* [in] Minimum value of the parameter (ie 100.0). */
        public float         max;             /* [in] Maximum value of the parameter (ie 22050.0). */
        public float         defaultval;      /* [in] Default value of parameter. */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public char[]        name;            /* [in] Name of the parameter to be displayed (ie "Cutoff frequency"). */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public char[]        label;           /* [in] Short string to be put next to value to denote the unit type (ie "hz"). */
        public string        description;     /* [in] Description of the parameter to be displayed as a help item / tooltip for this parameter. */
    }


    /*
    [STRUCTURE] 
    [
        [DESCRIPTION]
        Strcture to define the parameters for a DSP unit.

        [REMARKS]
        Members marked with [in] mean the user sets the value before passing it to the function.<br>
        Members marked with [out] mean FMOD sets the value to be used after the function exits.<br>
        <br>
        There are 2 different ways to change a parameter in this architecture.<br>
        One is to use DSP::setParameter / DSP::getParameter.  This is platform independant and is dynamic, so new unknown plugins can have their parameters enumerated and used.<br>
        The other is to use DSP::showConfigDialog.  This is platform specific and requires a GUI, and will display a dialog box to configure the plugin.<br>
        
        [PLATFORMS]
        Win32, Win64, Linux, Linux64, Macintosh, Xbox, Xbox360, PlayStation 2, GameCube, PlayStation Portable, PlayStation 3, Wii

        [SEE_ALSO]
        System::createDSP
        System::getDSP
    ]
    */


	/*
    [STRUCTURE] 
    [
        [DESCRIPTION]
        DSP plugin structure that is passed into each callback.

        [REMARKS]
        Members marked with [in] mean the variable can be written to.  The user can set the value.<br>
        Members marked with [out] mean the variable is modified by FMOD and is for reading purposes only.  Do not change this value.<br>

        [PLATFORMS]
        Win32, Win64, Linux, Linux64, Macintosh, Xbox, Xbox360, PlayStation 2, GameCube, PlayStation Portable, PlayStation 3

        [SEE_ALSO]
        FMOD_DSP_DESCRIPTION
    ]
    */


	/*
        ==============================================================================================================

        FMOD built in effect parameters.  
        Use DSP::setParameter with these enums for the 'index' parameter.

        ==============================================================================================================
    */

    /*
    [ENUM]
    [  
        [DESCRIPTION]   
        Parameter types for the FMOD_DSP_TYPE_OSCILLATOR filter.

        [REMARKS]

        [PLATFORMS]
        Win32, Win64, Linux, Linux64, Macintosh, Xbox, Xbox360, PlayStation 2, GameCube, PlayStation Portable, PlayStation 3, Wii

        [SEE_ALSO]
        DSP::setParameter
        DSP::getParameter
        FMOD_DSP_TYPE   
    ]
    */


	/*
    [ENUM]
    [  
        [DESCRIPTION]   
        Parameter types for the FMOD_DSP_TYPE_LOWPASS filter.

        [REMARKS]

        [PLATFORMS]
        Win32, Win64, Linux, Linux64, Macintosh, Xbox, Xbox360, PlayStation 2, GameCube, PlayStation Portable, PlayStation 3, Wii

        [SEE_ALSO]      
        DSP::setParameter
        DSP::getParameter
        FMOD_DSP_TYPE
    ]
    */


	/*
    [ENUM]
    [  
        [DESCRIPTION]   
        Parameter types for the FMOD_DSP_TYPE_ITLOWPASS filter.
        This is different to the default FMOD_DSP_TYPE_ITLOWPASS filter in that it uses a different quality algorithm and is 
        the filter used to produce the correct sounding playback in .IT files.<br> 
        FMOD Ex's .IT playback uses this filter.<br>

        [REMARKS]
        Note! This filter actually has a limited cutoff frequency below the specified maximum, due to its limited design, 
        so for a more  open range filter use FMOD_DSP_LOWPASS or if you don't mind not having resonance, 
        FMOD_DSP_LOWPASS_SIMPLE.<br>
        The effective maximum cutoff is about 8060hz.

        [PLATFORMS]
        Win32, Win64, Linux, Linux64, Macintosh, Xbox, Xbox360, PlayStation 2, GameCube, PlayStation Portable, PlayStation 3, Wii

        [SEE_ALSO]      
        DSP::setParameter
        DSP::getParameter
        FMOD_DSP_TYPE
    ]
    */


	/*
    [ENUM]
    [  
        [DESCRIPTION]   
        Parameter types for the FMOD_DSP_TYPE_HIGHPASS filter.

        [REMARKS]

        [PLATFORMS]
        Win32, Win64, Linux, Linux64, Macintosh, Xbox, Xbox360, PlayStation 2, GameCube, PlayStation Portable, PlayStation 3, Wii

        [SEE_ALSO]      
        DSP::setParameter
        DSP::getParameter
        FMOD_DSP_TYPE
    ]
    */


	/*
    [ENUM]
    [  
        [DESCRIPTION]   
        Parameter types for the FMOD_DSP_TYPE_ECHO filter.

        [REMARKS]
        Note.  Every time the delay is changed, the plugin re-allocates the echo buffer.  This means the echo will dissapear at that time while it refills its new buffer.<br>
        Larger echo delays result in larger amounts of memory allocated.<br>
        <br>
        '<i>maxchannels</i>' also dictates the amount of memory allocated.  By default, the maxchannels value is 0.  If FMOD is set to stereo, the echo unit will allocate enough memory for 2 channels.  If it is 5.1, it will allocate enough memory for a 6 channel echo, etc.<br>
        If the echo effect is only ever applied to the global mix (ie it was added with System::addDSP), then 0 is the value to set as it will be enough to handle all speaker modes.<br>
        When the echo is added to a channel (ie Channel::addDSP) then the channel count that comes in could be anything from 1 to 8 possibly.  It is only in this case where you might want to increase the channel count above the output's channel count.<br>
        If a channel echo is set to a lower number than the sound's channel count that is coming in, it will not echo the sound.<br>

        [PLATFORMS]
        Win32, Win64, Linux, Linux64, Macintosh, Xbox, Xbox360, PlayStation 2, GameCube, PlayStation Portable, PlayStation 3, Wii

        [SEE_ALSO]      
        DSP::setParameter
        DSP::getParameter
        FMOD_DSP_TYPE
    ]
    */


	/*
    [ENUM]
    [  
        [DESCRIPTION]   
        Parameter types for the FMOD_DSP_TYPE_DELAY filter.

        [REMARKS]
        Note.  Every time MaxDelay is changed, the plugin re-allocates the delay buffer.  This means the delay will dissapear at that time while it refills its new buffer.<br>
        A larger MaxDelay results in larger amounts of memory allocated.<br>
        Channel delays above MaxDelay will be clipped to MaxDelay and the delay buffer will not be resized.<br>
        <br>

        [PLATFORMS]
        Win32, Win64, Linux, Linux64, Macintosh, Xbox, Xbox360, PlayStation 2, GameCube, PlayStation Portable, PlayStation 3, Wii

        [SEE_ALSO]      
        DSP::setParameter
        DSP::getParameter
        FMOD_DSP_TYPE
    ]
    */


	/*
    [ENUM]
    [  
        [DESCRIPTION]   
        Parameter types for the FMOD_DSP_TYPE_FLANGE filter.

        [REMARKS]
        Flange is an effect where the signal is played twice at the same time, and one copy slides back and forth creating a whooshing or flanging effect.<br>
        As there are 2 copies of the same signal, by default each signal is given 50% mix, so that the total is not louder than the original unaffected signal.<br>
        <br>
        Flange depth is a percentage of a 10ms shift from the original signal.  Anything above 10ms is not considered flange because to the ear it begins to 'echo' so 10ms is the highest value possible.<br>

        [PLATFORMS]
        Win32, Win64, Linux, Linux64, Macintosh, Xbox, Xbox360, PlayStation 2, GameCube, PlayStation Portable, PlayStation 3, Wii

        [SEE_ALSO]      
        DSP::setParameter
        DSP::getParameter
        FMOD_DSP_TYPE
    ]
    */


	/*
    [ENUM]
    [  
        [DESCRIPTION]   
        Parameter types for the FMOD_DSP_TYPE_TREMOLO filter.

        [REMARKS]
        The tremolo effect varies the amplitude of a sound. Depending on the settings, this unit can produce a tremolo, chopper or auto-pan effect.<br>
        <br>
        The shape of the LFO (low freq. oscillator) can morphed between sine, triangle and sawtooth waves using the FMOD_DSP_TREMOLO_SHAPE and FMOD_DSP_TREMOLO_SKEW parameters.<br>
        FMOD_DSP_TREMOLO_DUTY and FMOD_DSP_TREMOLO_SQUARE are useful for a chopper-type effect where the first controls the on-time duration and second controls the flatness of the envelope.<br>
        FMOD_DSP_TREMOLO_SPREAD varies the LFO phase between channels to get an auto-pan effect. This works best with a sine shape LFO.<br>
        The LFO can be synchronized using the FMOD_DSP_TREMOLO_PHASE parameter which sets its instantaneous phase.<br>

        [PLATFORMS]
        Win32, Win64, Linux, Linux64, Macintosh, Xbox, Xbox360, PlayStation 2, GameCube, PlayStation Portable, PlayStation 3, Wii

        [SEE_ALSO]      
        DSP::setParameter
        DSP::getParameter
        FMOD_DSP_TYPE
    ]
    */


	/*
    [ENUM]
    [  
        [DESCRIPTION]   
        Parameter types for the FMOD_DSP_TYPE_DISTORTION filter.

        [REMARKS]

        [PLATFORMS]
        Win32, Win64, Linux, Linux64, Macintosh, Xbox, Xbox360, PlayStation 2, GameCube, PlayStation Portable, PlayStation 3, Wii

        [SEE_ALSO]      
        DSP::setParameter
        DSP::getParameter
        FMOD_DSP_TYPE
    ]
    */


	/*
    [ENUM]
    [  
        [DESCRIPTION]   
        Parameter types for the FMOD_DSP_TYPE_NORMALIZE filter.

        [REMARKS]
        Normalize amplifies the sound based on the maximum peaks within the signal.<br>
        For example if the maximum peaks in the signal were 50% of the bandwidth, it would scale the whole sound by 2.<br>
        The lower threshold value makes the normalizer ignores peaks below a certain point, to avoid over-amplification if a loud signal suddenly came in, and also to avoid amplifying to maximum things like background hiss.<br>
        <br>
        Because FMOD is a realtime audio processor, it doesn't have the luxury of knowing the peak for the whole sound (ie it can't see into the future), so it has to process data as it comes in.<br>
        To avoid very sudden changes in volume level based on small samples of new data, fmod fades towards the desired amplification which makes for smooth gain control.  The fadetime parameter can control this.<br>

        [PLATFORMS]
        Win32, Win64, Linux, Linux64, Macintosh, Xbox, Xbox360, PlayStation 2, GameCube, PlayStation Portable, PlayStation 3, Wii

        [SEE_ALSO]      
        DSP::setParameter
        DSP::getParameter
        FMOD_DSP_TYPE
    ]
    */


	/*
    [ENUM]
    [  
        [DESCRIPTION]   
        Parameter types for the FMOD_DSP_TYPE_PARAMEQ filter.

        [REMARKS]
        Parametric EQ is a bandpass filter that attenuates or amplifies a selected frequency and its neighbouring frequencies.<br>
        <br>
        To create a multi-band EQ create multiple FMOD_DSP_TYPE_PARAMEQ units and set each unit to different frequencies, for example 1000hz, 2000hz, 4000hz, 8000hz, 16000hz with a range of 1 octave each.<br>
        <br>
        When a frequency has its gain set to 1.0, the sound will be unaffected and represents the original signal exactly.<br>

        [PLATFORMS]
        Win32, Win64, Linux, Linux64, Macintosh, Xbox, Xbox360, PlayStation 2, GameCube, PlayStation Portable, PlayStation 3, Wii

        [SEE_ALSO]      
        DSP::setParameter
        DSP::getParameter
        FMOD_DSP_TYPE
    ]
    */


	/*
    [ENUM]
    [  
        [DESCRIPTION]   
        Parameter types for the FMOD_DSP_TYPE_PITCHSHIFT filter.

        [REMARKS]
        This pitch shifting unit can be used to change the pitch of a sound without speeding it up or slowing it down.<br>
        It can also be used for time stretching or scaling, for example if the pitch was doubled, and the frequency of the sound was halved, the pitch of the sound would sound correct but it would be twice as slow.<br>
        <br>
        <b>Warning!</b> This filter is very computationally expensive!  Similar to a vocoder, it requires several overlapping FFT and IFFT's to produce smooth output, and can require around 440mhz for 1 stereo 48khz signal using the default settings.<br>
        Reducing the signal to mono will half the cpu usage, as will the overlap count.<br>
        Reducing this will lower audio quality, but what settings to use are largely dependant on the sound being played.  A noisy polyphonic signal will need higher overlap and fft size compared to a speaking voice for example.<br>
        <br>
        This pitch shifter is based on the pitch shifter code at http://www.dspdimension.com, written by Stephan M. Bernsee.<br>
        The original code is COPYRIGHT 1999-2003 Stephan M. Bernsee <smb@dspdimension.com>.<br>
        <br>
        '<i>maxchannels</i>' dictates the amount of memory allocated.  By default, the maxchannels value is 0.  If FMOD is set to stereo, the pitch shift unit will allocate enough memory for 2 channels.  If it is 5.1, it will allocate enough memory for a 6 channel pitch shift, etc.<br>
        If the pitch shift effect is only ever applied to the global mix (ie it was added with System::addDSP), then 0 is the value to set as it will be enough to handle all speaker modes.<br>
        When the pitch shift is added to a channel (ie Channel::addDSP) then the channel count that comes in could be anything from 1 to 8 possibly.  It is only in this case where you might want to increase the channel count above the output's channel count.<br>
        If a channel pitch shift is set to a lower number than the sound's channel count that is coming in, it will not pitch shift the sound.<br>

        [PLATFORMS]
        Win32, Win64, Linux, Linux64, Macintosh, Xbox, Xbox360, PlayStation 2, GameCube, PlayStation Portable, PlayStation 3, Wii

        [SEE_ALSO]      
        DSP::setParameter
        DSP::getParameter
        FMOD_DSP_TYPE
    ]
    */


	/*
    [ENUM]
    [  
        [DESCRIPTION]   
        Parameter types for the FMOD_DSP_TYPE_CHORUS filter.

        [REMARKS]
        Chrous is an effect where the sound is more 'spacious' due to 1 to 3 versions of the sound being played along side the original signal but with the pitch of each copy modulating on a sine wave.<br>
        This is a highly configurable chorus unit.  It supports 3 taps, small and large delay times and also feedback.<br>
        This unit also could be used to do a simple echo, or a flange effect. 

        [PLATFORMS]
        Win32, Win64, Linux, Linux64, Macintosh, Xbox, Xbox360, PlayStation 2, GameCube, PlayStation Portable, PlayStation 3, Wii

        [SEE_ALSO]      
        DSP::setParameter
        DSP::getParameter
        FMOD_DSP_TYPE
    ]
    */


	/*
    [ENUM]
    [  
        [DESCRIPTION]   
        Parameter types for the FMOD_DSP_TYPE_REVERB filter.

        [REMARKS]

        [PLATFORMS]
        Win32, Win64, Linux, Macintosh, Xbox, Xbox360, PlayStation 2, GameCube, PlayStation Portable

        [SEE_ALSO]      
        DSP::setParameter
        DSP::getParameter
        FMOD_DSP_TYPE
    ]
    */

	/*
    [ENUM]
    [  
        [DESCRIPTION]   
        Parameter types for the FMOD_DSP_TYPE_ITECHO filter.<br>
        This is effectively a software based echo filter that emulates the DirectX DMO echo effect.  Impulse tracker files can support this, and FMOD will produce the effect on ANY platform, not just those that support DirectX effects!<br>

        [REMARKS]
        Note.  Every time the delay is changed, the plugin re-allocates the echo buffer.  This means the echo will dissapear at that time while it refills its new buffer.<br>
        Larger echo delays result in larger amounts of memory allocated.<br>
        <br>
        For stereo signals only!  This will not work on mono or multichannel signals.  This is fine for .IT format purposes, and also if you use System::addDSP with a standard stereo output.<br>

        [PLATFORMS]
        Win32, Win64, Linux, Macintosh, Xbox, Xbox360, PlayStation 2, GameCube, PlayStation Portable

        [SEE_ALSO]      
        DSP::setParameter
        DSP::getParameter
        FMOD_DSP_TYPE
        System::addDSP
    ]
    */


	/*
    [ENUM]
    [  
        [DESCRIPTION]   
        Parameter types for the FMOD_DSP_TYPE_COMPRESSOR unit.<br>
        This is a simple linked multichannel software limiter that is uniform across the whole spectrum.<br>

        [REMARKS]
        The parameters are as follows:
        Threshold: [-60dB to 0dB, default 0dB]
        Attack Time: [10ms to 200ms, default 50ms]
        Release Time: [20ms to 1000ms, default 50ms]
        Gain Make Up: [0dB to +30dB, default 0dB]
        <br>
        The limiter is not guaranteed to catch every peak above the threshold level,
        because it cannot apply gain reduction instantaneously - the time delay is
        determined by the attack time. However setting the attack time too short will
        distort the sound, so it is a compromise. High level peaks can be avoided by
        using a short attack time - but not too short, and setting the threshold a few
        decibels below the critical level.
        <br>

        [PLATFORMS]
        Win32, Win64, Linux, Linux64, Macintosh, Xbox, Xbox360, PlayStation 2, GameCube, PlayStation Portable, PlayStation 3

        [SEE_ALSO]      
        DSP::SetParameter
        DSP::GetParameter
        FMOD_DSP_TYPE
        System::addDSP
    ]
    */


	/*
    [ENUM]
    [  
        [DESCRIPTION]   
        Parameter types for the FMOD_DSP_TYPE_SFXREVERB unit.<br>
    
        [REMARKS]
        This is a high quality I3DL2 based reverb which improves greatly on FMOD_DSP_REVERB.<br>
        On top of the I3DL2 property set, "Dry Level" is also included to allow the dry mix to be changed.<br>
        <br>
        Currently FMOD_DSP_SFXREVERB_REFLECTIONSLEVEL, FMOD_DSP_SFXREVERB_REFLECTIONSDELAY and FMOD_DSP_SFXREVERB_REVERBDELAY are not enabled but will come in future versions.<br>
        <br>
        These properties can be set with presets in FMOD_REVERB_PRESETS.

        [PLATFORMS]
        Win32, Win64, Linux, Linux64, Macintosh, Xbox, Xbox360, PlayStation 2, GameCube, PlayStation Portable, PlayStation 3

        [SEE_ALSO]      
        DSP::SetParameter
        DSP::GetParameter
        FMOD_DSP_TYPE
        System::addDSP
        FMOD_REVERB_PRESETS
    ]
    */

	/*
    [ENUM]
    [  
        [DESCRIPTION]   
        Parameter types for the FMOD_DSP_TYPE_LOWPASS_SIMPLE filter.<br>
        This is a very simple low pass filter, based on two single-pole RC time-constant modules.
        The emphasis is on speed rather than accuracy, so this should not be used for task requiring critical filtering.<br> 

        [REMARKS]

        [PLATFORMS]
        Win32, Win64, Linux, Linux64, Macintosh, Xbox, Xbox360, PlayStation 2, GameCube, PlayStation Portable, PlayStation 3, Wii

        [SEE_ALSO]      
        DSP::setParameter
        DSP::getParameter
        FMOD_DSP_TYPE
    ]
    */
/*$ preserve start $*/
}
/*$ preserve end $*/
