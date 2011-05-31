/*
 * GENERATED CODE
 * DO NOT EDIT THIS
 */

using System;
using InVision.FMod;
using InVision.FMod.Native;
using InVision.Native;

namespace InVision.FMod.Native
{
	[CppImplementation(typeof(IFModSystem))]
	internal unsafe class FModSystemImpl
		: CppInstance, IFModSystem
	{
		Result IFModSystem.Init(int maxChannels, InitFlags flags, IntPtr extraDriverData)
		{
			CheckMemberOnlyCall();
			
			var result = NativeFModSystem.Init(Self, maxChannels, flags, extraDriverData);
			
			return result;
		}
		
		Result IFModSystem.SetSpeakerMode(SpeakerMode speakerMode)
		{
			CheckMemberOnlyCall();
			
			var result = NativeFModSystem.SetSpeakerMode(Self, speakerMode);
			
			return result;
		}
		
		Result IFModSystem.SetSoftwareChannels(int numSoftwareChannels)
		{
			CheckMemberOnlyCall();
			
			var result = NativeFModSystem.SetSoftwareChannels(Self, numSoftwareChannels);
			
			return result;
		}
		
		Result IFModSystem.SetHardwareChannels(int min2d, int max2d, int min3d, int max3d)
		{
			CheckMemberOnlyCall();
			
			var result = NativeFModSystem.SetHardwareChannels(Self, min2d, max2d, min3d, max3d);
			
			return result;
		}
		
		Result IFModSystem.CreateSound(String nameOrData, Mode mode, IntPtr extInfo, ref ISound sound)
		{
			CheckMemberOnlyCall();
			
			var result = NativeFModSystem.CreateSound(Self, nameOrData, mode, extInfo, ref sound);
			
			return result;
		}
		
		Result IFModSystem.CreateStream(String nameOrData, Mode mode, IntPtr extInfo, ref ISound sound)
		{
			CheckMemberOnlyCall();
			
			var result = NativeFModSystem.CreateStream(Self, nameOrData, mode, extInfo, ref sound);
			
			return result;
		}
		
		Result IFModSystem.PlaySound(ChannelIndex channelIndex, ISound sound, bool paused, ref IChannel channel)
		{
			CheckMemberOnlyCall();
			
			var result = NativeFModSystem.PlaySound(Self, channelIndex, sound, paused, ref channel);
			
			return result;
		}
		
	}
	
	[CppImplementation(typeof(ISystemCreator))]
	internal unsafe class SystemCreatorImpl
		: CppInstance, ISystemCreator
	{
		Result ISystemCreator.Create(IFModSystem system)
		{
			CheckStaticOnlyCall();
			
			var result = NativeSystemCreator.Create(system);
			
			return result;
		}
		
	}
	
	[CppImplementation(typeof(ISound))]
	internal unsafe class SoundImpl
		: CppInstance, ISound
	{
	}
	
	[CppImplementation(typeof(IChannel))]
	internal unsafe class ChannelImpl
		: CppInstance, IChannel
	{
		Result IChannel.SetVolume(float volume)
		{
			CheckMemberOnlyCall();
			
			var result = NativeChannel.SetVolume(Self, volume);
			
			return result;
		}
		
		Result IChannel.SetPause(bool paused)
		{
			CheckMemberOnlyCall();
			
			var result = NativeChannel.SetPause(Self, paused);
			
			return result;
		}
		
	}
	
	[CppImplementation(typeof(IChannelCreator))]
	internal unsafe class ChannelCreatorImpl
		: CppInstance, IChannelCreator
	{
		Result IChannelCreator.Create(IChannel channel)
		{
			CheckStaticOnlyCall();
			
			var result = NativeChannelCreator.Create(channel);
			
			return result;
		}
		
	}
	
}
