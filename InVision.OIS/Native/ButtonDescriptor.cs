using System.Runtime.InteropServices;

namespace InVision.OIS.Native
{
	[StructLayout(LayoutKind.Sequential)]
	internal unsafe struct ButtonDescriptor
	{
		private readonly ComponentDescriptor _baseDescriptor;
		private readonly sbyte* _pushed;

		/// <summary>
		/// Gets the base info.
		/// </summary>
		/// <value>The base info.</value>
		public ComponentDescriptor BaseDescriptor
		{
			get { return _baseDescriptor; }
		}

		/// <summary>
		/// Gets a value indicating whether this <see cref="ButtonDescriptor"/> is pushed.
		/// </summary>
		/// <value><c>true</c> if pushed; otherwise, <c>false</c>.</value>
		public bool Pushed
		{
			get { return *_pushed != 0; }
		}
	}
}