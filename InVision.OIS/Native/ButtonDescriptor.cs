using System.Runtime.InteropServices;
using InVision.Native.Ext;

namespace InVision.OIS.Native
{
	[StructLayout(LayoutKind.Sequential)]
	internal unsafe struct ButtonDescriptor
	{
		private readonly ComponentDescriptor _base;
		private readonly bool* _pushed;

		/// <summary>
		/// Gets the base info.
		/// </summary>
		/// <value>The base info.</value>
		public ComponentDescriptor Base
		{
			get { return _base; }
		}

		/// <summary>
		/// Gets a value indicating whether this <see cref="ButtonDescriptor"/> is pushed.
		/// </summary>
		/// <value><c>true</c> if pushed; otherwise, <c>false</c>.</value>
		public bool Pushed
		{
			get { return *_pushed; }
		}
	}
}