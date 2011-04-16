using System;
using System.Runtime.InteropServices;

namespace InVision.OIS.Native
{
	[StructLayout(LayoutKind.Sequential)]
	internal unsafe struct ButtonExtended
	{
		private ComponentExtended baseInfo;
		private bool* pushed;

		/// <summary>
		/// Gets the base info.
		/// </summary>
		/// <value>The base info.</value>
		public ComponentExtended BaseInfo
		{
			get { return baseInfo; }
		}

		/// <summary>
		/// Gets a value indicating whether this <see cref="ButtonExtended"/> is pushed.
		/// </summary>
		/// <value><c>true</c> if pushed; otherwise, <c>false</c>.</value>
		public bool Pushed
		{
			get { return *pushed; }
		}
	}
}