using InVision.FMod.Native;

namespace InVision.FMod
{
	public class Channel : DisposableObject
	{
		private readonly AudioSystem _audioSystem;
		private readonly Native.Channel _channel;
		private readonly Sound _sound;

		public Channel(AudioSystem audioSystem, CHANNELINDEX channelIndex, Sound sound, bool paused)
		{
			_audioSystem = audioSystem;
			_sound = sound;
			_audioSystem.System.playSound(channelIndex, _sound.SoundInstance, paused, ref _channel).Check();
		}

		public bool Paused
		{
			get
			{
				bool value = false;

				_channel.getPaused(ref value).Check();

				return value;
			}
			set
			{
				_channel.setPaused(value).Check();
			}
		}

		protected override void Dispose(bool disposing)
		{
		}

		public void Stop()
		{
			_channel.stop().Check();
		}
	}
}