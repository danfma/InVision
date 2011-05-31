using System;
using InVision.FMod;
using InVision.FMod.Native;
using Channel = InVision.FMod.Native.Channel;
using Sound = InVision.FMod.Native.Sound;

namespace FModTest
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			var audioSystem = new AudioSystem();
			audioSystem.Init(1, INITFLAGS.NORMAL);
			audioSystem.SetStreamBufferSize(64 * 1024, TIMEUNIT.RAWBYTES);

			var sound = audioSystem.CreateSound("Someday.mp3", (MODE.HARDWARE | MODE._2D | MODE.CREATESTREAM | MODE.OPENONLY));
			var channel = sound.PlaySound(CHANNELINDEX.FREE, false);

			Console.ReadLine();
		}

		private static void PlayFMOD()
		{
			RESULT result;
			InVision.FMod.Native.System system = null;

			result = Factory.System_Create(ref system);
			ERRCHECK(result);

			uint version = 0;

			result = system.getVersion(ref version);
			ERRCHECK(result);

			result = system.init(1, INITFLAGS.NORMAL, (IntPtr)null);
			ERRCHECK(result);

			result = system.setStreamBufferSize(64 * 1024, TIMEUNIT.RAWBYTES);
			ERRCHECK(result);

			Sound sound = null;
			Channel channel = null;

			result = system.createSound("Someday.mp3", (MODE.HARDWARE | MODE._2D | MODE.CREATESTREAM | MODE.OPENONLY), ref sound);
			ERRCHECK(result);

			result = system.playSound(CHANNELINDEX.FREE, sound, false, ref channel);
			ERRCHECK(result);
		}

		private static void ERRCHECK(RESULT result)
		{
			if (result != RESULT.OK)
			{
			}
		}
	}
}