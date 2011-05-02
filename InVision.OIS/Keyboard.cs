using System;
using System.Collections.Generic;
using InVision.OIS.Native;

namespace InVision.OIS
{
	public class Keyboard : DeviceObject
	{
		private KeyListenerDispatcher _dispatcher;

		/// <summary>
		/// Initializes a new instance of the <see cref="Keyboard"/> class.
		/// </summary>
		/// <param name="pSelf">The p self.</param>
		public Keyboard(IntPtr pSelf)
			: base(pSelf, true)
		{
			Initialize();
		}

		/// <summary>
		/// Gets or sets the text translation.
		/// </summary>
		/// <value>The text translation.</value>
		private TextTranslationMode TextTranslation
		{
			get { return NativeKeyboard.GetTextTranslationMode(handle); }
			set { NativeKeyboard.SetTextTranslationMode(handle, value); }
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
		private void Initialize()
		{
			TextTranslation = TextTranslationMode.Unicode;
			_dispatcher = new KeyListenerDispatcher();
			NativeKeyboard.SetEventCallback(handle, _dispatcher.DangerousGetHandle());
		}

		/// <summary>
		/// Releases the valid handle.
		/// </summary>
		protected override void ReleaseValidHandle()
		{
			NativeKeyboard.SetEventCallback(handle, IntPtr.Zero);
			_dispatcher.Dispose();

			base.ReleaseValidHandle();
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
			return NativeKeyboard.IsKeyDown(handle, keyCode);
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
			return NativeKeyboard.IsModifierDown(handle, modifier);
		}

		/// <summary>
		/// Copies the key states.
		/// </summary>
		/// <returns></returns>
		public bool[] CopyKeyStates()
		{
			var keys = new bool[256];

			NativeKeyboard.CopyKeyStates(handle, keys);

			return keys;
		}

		/// <summary>
		/// Copies the key states.
		/// </summary>
		/// <param name="states">The states (must be one array with 256 of length).</param>
		public void CopyKeyStates(bool[] states)
		{
			NativeKeyboard.CopyKeyStates(handle, states);
		}

		/// <summary>
		/// Gets as string.
		/// </summary>
		/// <param name="keyCode">The key code.</param>
		/// <returns></returns>
		public string GetAsString(KeyCode keyCode)
		{
			return NativeKeyboard.GetAsString(handle, keyCode);
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