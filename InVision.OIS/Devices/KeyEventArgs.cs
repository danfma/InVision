using System;
using InVision.OIS.Native;

namespace InVision.OIS.Devices
{
	public unsafe class KeyEventArgs : EventArgs
	{
		private KeyCode* _key;
		private uint* _text;

		/// <summary>
		/// Initializes a new instance of the <see cref="KeyEventArgs"/> class.
		/// </summary>
		/// <param name="descriptor">The key event extended.</param>
		internal KeyEventArgs(KeyEventDescriptor descriptor)
			: base(descriptor.Base, CreateCppInstance<IKeyEvent>())
		{
			Initialize(descriptor);
		}

		/// <summary>
		/// Initializes the specified descriptor.
		/// </summary>
		/// <param name="descriptor">The descriptor.</param>
		protected void Initialize(KeyEventDescriptor descriptor)
		{
			Initialize(descriptor.Base);

			_key = descriptor.Key;
			_text = descriptor.Text;
		}

		/// <summary>
		/// Gets the key code.
		/// </summary>
		/// <value>The key code.</value>
		public KeyCode KeyCode
		{
			get { return *_key; }
		}

		/// <summary>
		/// Gets the char.
		/// </summary>
		/// <value>The char.</value>
		public char Char
		{
			get
			{
				var value = *_text;

				return Convert.ToChar(value);
			}
		}
	}
}