using System;
using InVision.FMod.Native;

namespace InVision.FMod
{
	public class Sound : DisposableObject
	{
		private readonly AudioSystem _audioSystem;
		private readonly Native.Sound _sound;

		public Sound(AudioSystem audioSystem, string nameOrdata, MODE mode)
		{
			_audioSystem = audioSystem;
			audioSystem.System.createSound(nameOrdata, mode, ref _sound).Check();
		}

		internal Native.Sound SoundInstance
		{
			get { return _sound; }
		}

		protected override void Dispose(bool disposing)
		{
			_sound.release().Check();
		}

		public Channel PlaySound(CHANNELINDEX channelIndex, bool paused)
		{
			return new Channel(_audioSystem, channelIndex, this, paused);
		}
	}
}