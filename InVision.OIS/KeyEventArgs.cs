using System;
using InVision.OIS.Native;

namespace InVision.OIS
{
	public class KeyEventArgs : EventArgs
	{
		private readonly KeyEventDescriptor _descriptor;

		/// <summary>
		/// Initializes a new instance of the <see cref="KeyEventArgs"/> class.
		/// </summary>
		/// <param name="descriptor">The key event extended.</param>
		internal KeyEventArgs(KeyEventDescriptor descriptor)
			: base(descriptor.Base)
		{
			_descriptor = descriptor;
		}

		/// <summary>
		/// Gets the key code.
		/// </summary>
		/// <value>The key code.</value>
		public KeyCode KeyCode
		{
			get { throw new NotImplementedException(); }
		}

		/// <summary>
		/// Gets the char.
		/// </summary>
		/// <value>The char.</value>
		public char Char
		{
			get { throw new NotImplementedException(); }
		}
	}
}