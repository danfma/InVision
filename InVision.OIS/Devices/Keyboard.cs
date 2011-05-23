using System;
using System.Collections.Generic;
using InVision.Native;
using InVision.OIS.Native;

namespace InVision.OIS.Devices
{
	public class Keyboard : DeviceObject
	{
		private readonly KeyListenerDispatcher _dispatcher;

		/// <summary>
		/// Initializes a new instance of the <see cref="Keyboard"/> class.
		/// </summary>
		/// <param name="nativeInstance">The native instance.</param>
		protected Keyboard(ICppInterface nativeInstance)
			: base(nativeInstance)
		{
			_dispatcher = new KeyListenerDispatcher();
		}

		/// <summary>
		/// Gets or sets the native instance.
		/// </summary>
		/// <value>The native instance.</value>
		protected new IKeyboard Native
		{
			get { return (IKeyboard)base.Native; }
		}

		/// <summary>
		/// Gets or sets the text translation.
		/// </summary>
		/// <value>The text translation.</value>
		public TextTranslationMode TextTranslation
		{
			get { return Native.GetTextTranslation(); }
			private set { Native.SetTextTranslation(value); }
		}

		/// <summary>
		/// Gets the listeners.
		/// </summary>
		/// <value>The listeners.</value>
		public IList<IKeyListener> Listeners
		{
			get { return _dispatcher.Listeners; }
		}

		/// <summary>
		/// Initializes this instance.
		/// </summary>
		protected override void Initialize()
		{
			base.Initialize();

			TextTranslation = TextTranslationMode.Unicode;
			Native.SetEventCallback(_dispatcher.Native);
		}

		/// <summary>
		/// Releases unmanaged and - optionally - managed resources
		/// </summary>
		/// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
		protected override void Dispose(bool disposing)
		{
			if (Native != null)
				Native.SetEventCallback(null);

			if (_dispatcher != null && !_dispatcher.IsDisposed)
				_dispatcher.Dispose();

			base.Dispose(disposing);
		}

		/// <summary>
		/// Determines whether [is key down] [the specified key code].
		/// </summary>
		/// <param name="keyCode">The key code.</param>
		/// <returns>
		/// 	<c>true</c> if [is key down] [the specified key code]; otherwise, <c>false</c>.
		/// </returns>
		public bool IsKeyDown(KeyCode keyCode)
		{
			return Native.IsKeyDown(keyCode);
		}

		/// <summary>
		/// Determines whether [is modifier down] [the specified modifier].
		/// </summary>
		/// <param name="modifier">The modifier.</param>
		/// <returns>
		/// 	<c>true</c> if [is modifier down] [the specified modifier]; otherwise, <c>false</c>.
		/// </returns>
		public bool IsModifierDown(Modifier modifier)
		{
			return Native.IsModifierDown(modifier);
		}

		/// <summary>
		/// Copies the key states.
		/// </summary>
		/// <returns></returns>
		public bool[] CopyKeyStates()
		{
			var keys = new bool[256];
			CopyKeyStates(keys);

			return keys;
		}

		/// <summary>
		/// Copies the key states.
		/// </summary>
		/// <param name="states">The states (must be one array with 256 of length).</param>
		public void CopyKeyStates(bool[] states)
		{
			Native.CopyKeyStates(states);
		}

		/// <summary>
		/// Gets as string.
		/// </summary>
		/// <param name="keyCode">The key code.</param>
		/// <returns></returns>
		public string GetAsString(KeyCode keyCode)
		{
			return Native.GetAsString(keyCode);
		}

		/// <summary>
		/// Occurs when [key pressed].
		/// </summary>
		public event KeyEventHandler KeyPressed
		{
			add { _dispatcher.KeyPressed += value; }
			remove { _dispatcher.KeyPressed -= value; }
		}

		/// <summary>
		/// Occurs when [key released].
		/// </summary>
		public event KeyEventHandler KeyReleased
		{
			add { _dispatcher.KeyReleased += value; }
			remove { _dispatcher.KeyReleased -= value; }
		}
	}
}