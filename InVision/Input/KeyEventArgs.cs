namespace InVision.Input
{
	public sealed class KeyEventArgs : EventArgs
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="KeyEventArgs"/> class.
		/// </summary>
		/// <param name="data">The <see cref="UKeyEventArgs"/> instance containing the event data.</param>
		internal KeyEventArgs(ref UKeyEventArgs data)
			: base(data.Device)
		{
			Key = data.Key;
			TextCode = data.TextCode;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="KeyEventArgs"/> class.
		/// </summary>
		/// <param name="device">The device.</param>
		/// <param name="key">The key.</param>
		/// <param name="text">The text.</param>
		public KeyEventArgs(InputObject device, KeyCode key, uint text) : base(device)
		{
			Key = key;
			TextCode = text;
		}

		/// <summary>
		/// Gets or sets the key.
		/// </summary>
		/// <value>The key.</value>
		public KeyCode Key { get; private set; }

		/// <summary>
		/// Gets or sets the text code.
		/// </summary>
		/// <value>The text code.</value>
		public uint TextCode { get; private set; }
	}
}