using InVision.OIS.Native;

namespace InVision.OIS
{
	public class KeyEventArgs : EventArgs
	{
		private readonly KeyEventExtended keyEventExtended;

		/// <summary>
		/// Initializes a new instance of the <see cref="KeyEventArgs"/> class.
		/// </summary>
		/// <param name="keyEventExtended">The key event extended.</param>
		internal KeyEventArgs(KeyEventExtended keyEventExtended)
			: base(keyEventExtended.Base)
		{
			this.keyEventExtended = keyEventExtended;
		}

		/// <summary>
		/// Gets the key code.
		/// </summary>
		/// <value>The key code.</value>
		public KeyCode KeyCode
		{
			get { return keyEventExtended.Key; }
		}

		/// <summary>
		/// Gets the text value.
		/// </summary>
		/// <value>The text value.</value>
		public uint TextValue
		{
			get { return keyEventExtended.Text; }
		}
	}
}