/*
 * GENERATED CODE
 * DO NOT EDIT THIS
 */

using System;
using System.Runtime.InteropServices;
using InVision.FMod;
using InVision.FMod.Native;
using InVision.Native;

namespace InVision.FMod.Native
{
	internal sealed unsafe class NativeFModSystem : InVision.Native.PlatformInvoke
	{
		public const string Library = "InVisionNative.dll";
		
		static NativeFModSystem()
		{
			Init();
		}
		
		
		[DllImport(Library, EntryPoint = "fmodsystem_init")]
		public static extern Result Init(
			Handle self, 
			int maxChannels, 
			InitFlags flags, 
			IntPtr extraDriverData);
		
		[DllImport(Library, EntryPoint = "fmodsystem_set_speaker_mode")]
		public static extern Result SetSpeakerMode(
			Handle self, 
			SpeakerMode speakerMode);
		
		[DllImport(Library, EntryPoint = "fmodsystem_set_software_channels")]
		public static extern Result SetSoftwareChannels(
			Handle self, 
			int numSoftwareChannels);
		
		[DllImport(Library, EntryPoint = "fmodsystem_set_hardware_channels")]
		public static extern Result SetHardwareChannels(
			Handle self, 
			int min2d, 
			int max2d, 
			int min3d, 
			int max3d);
		
		[DllImport(Library, EntryPoint = "fmodsystem_create_sound")]
		public static extern Result CreateSound(
			Handle self, 
			[MarshalAs(UnmanagedType.LPStr)] String nameOrData, 
			Mode mode, 
			IntPtr extInfo, 
			ref ISound sound);
		
		[DllImport(Library, EntryPoint = "fmodsystem_create_stream")]
		public static extern Result CreateStream(
			Handle self, 
			[MarshalAs(UnmanagedType.LPStr)] String nameOrData, 
			Mode mode, 
			IntPtr extInfo, 
			ref ISound sound);
		
		[DllImport(Library, EntryPoint = "fmodsystem_play_sound")]
		public static extern Result PlaySound(
			Handle self, 
			ChannelIndex channelIndex, 
			ISound sound, 
			[MarshalAs(UnmanagedType.I1)] bool paused, 
			ref IChannel channel);
	}
	
	internal sealed unsafe class NativeSystemCreator : InVision.Native.PlatformInvoke
	{
		public const string Library = "InVisionNative.dll";
		
		static NativeSystemCreator()
		{
			Init();
		}
		
		
		[DllImport(Library, EntryPoint = "systemcreator_create")]
		public static extern Result Create(IFModSystem system);
	}
	
	internal sealed unsafe class NativeSound : InVision.Native.PlatformInvoke
	{
		public const string Library = "InVisionNative.dll";
		
		static NativeSound()
		{
			Init();
		}
		
	}
	
	internal sealed unsafe class NativeChannel : InVision.Native.PlatformInvoke
	{
		public const string Library = "InVisionNative.dll";
		
		static NativeChannel()
		{
			Init();
		}
		
		
		[DllImport(Library, EntryPoint = "channel_set_volume")]
		public static extern Result SetVolume(
			Handle self, 
			float volume);
		
		[DllImport(Library, EntryPoint = "channel_set_pause")]
		public static extern Result SetPause(
			Handle self, 
			[MarshalAs(UnmanagedType.I1)] bool paused);
	}
	
	internal sealed unsafe class NativeChannelCreator : InVision.Native.PlatformInvoke
	{
		public const string Library = "InVisionNative.dll";
		
		static NativeChannelCreator()
		{
			Init();
		}
		
		
		[DllImport(Library, EntryPoint = "channelcreator_create")]
		public static extern Result Create(IChannel channel);
	}
	
}
