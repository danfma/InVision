using System;
using System.Text;
using InVision.FMod.Native;

namespace InVision.FMod
{
	public class AudioSystem
	{
		private readonly Native.System _system;
		private readonly uint _version;
		private RESULT _result;

		public AudioSystem()
		{
			Factory.System_Create(ref _system).Check();
			_system.getVersion(ref _version).Check();
		}

		internal Native.System System
		{
			get { return _system; }
		}

		public void Init(int maxChannels, INITFLAGS initFlags)
		{
			_system.init(maxChannels, initFlags, IntPtr.Zero).Check();
		}

		public void SetStreamBufferSize(uint bufferSize, TIMEUNIT bufferSizeType)
		{
			_system.setStreamBufferSize(bufferSize, bufferSizeType).Check();
		}

		public Sound CreateSound(string nameOrData, MODE mode)
		{
			return new Sound(this, nameOrData, mode);
		}
	}
}