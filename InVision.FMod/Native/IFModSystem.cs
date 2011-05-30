using System;
using System.Runtime.InteropServices;
using InVision.Native;

namespace InVision.FMod.Native
{
	public interface ISystemCreator
	{
		[Method(Static = true)]
		Result Create(IFModSystem system);


	}

	public interface IFModSystem
	{
		[Method]
		Result Init(int maxChannels, InitFlags flags, IntPtr extraDriverData);

		[Method]
		Result SetSpeakerMode(SpeakerMode speakerMode);

		[Method]
		Result SetSoftwareChannels(int numSoftwareChannels);

		[Method]
		Result SetHardwareChannels(int min2d, int max2d, int min3d, int max3d);

		[Method]
		Result CreateSound([MarshalAs(UnmanagedType.LPStr)] string nameOrData, Mode mode, IntPtr extInfo, ref ISound sound);

		[Method]
		Result CreateStream([MarshalAs(UnmanagedType.LPStr)] string nameOrData, Mode mode, IntPtr extInfo, ref ISound sound);

		[Method]
		Result PlaySound(ChannelIndex channelIndex, ISound sound, [MarshalAs(UnmanagedType.I1)]bool paused, ref IChannel channel);

	}

	public interface ISound
	{
		
	}

	public interface IChannel
	{
		
	}



}