using System.Runtime.InteropServices;

namespace InVision.OIS.Native
{
	[StructLayout(LayoutKind.Sequential)]
	internal unsafe struct KeyEventExtended
	{
		private EventArgExtended @base;
		private KeyCode* key;
		private uint* text;

		/// <summary>
		/// Gets the base.
		/// </summary>
		/// <value>The base.</value>
		public EventArgExtended Base
		{
			get { return @base; }
		}

		/// <summary>
		/// Gets the key.
		/// </summary>
		/// <value>The key.</value>
		public KeyCode Key
		{
			get { return *key; }
		}

		/// <summary>
		/// Gets the text.
		/// </summary>
		/// <value>The text.</value>
		public uint Text
		{
			get { return *text; }
		}
	}
}