using System;
using System.Collections.Generic;
using InVision.OIS.Native;

namespace InVision.OIS
{
	public class Keyboard : DeviceObject
	{
		private KeyListenerDispatcher dispatcher;

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
		public TextTranslationMode TextTranslation
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
			get { return dispatcher.Listeners; }
		}

		/// <summary>
		/// Initializes this instance.
		/// </summary>
		private void Initialize()
		{
			dispatcher = new KeyListenerDispatcher();
			NativeKeyboard.SetEventCallback(handle, dispatcher.DangerousGetHandle());
		}

		/// <summary>
		/// Releases the valid handle.
		/// </summary>
		protected override void ReleaseValidHandle()
		{
			NativeKeyboard.SetEventCallback(handle, IntPtr.Zero); 
			dispatcher.Dispose();

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
		/// Occurs when [key pressed].
		/// </summary>
		public event KeyEventHandler KeyPressed
		{
			add { dispatcher.KeyPressed += value; }
			remove { dispatcher.KeyPressed -= value; }
		}

		/// <summary>
		/// Occurs when [key released].
		/// </summary>
		public event KeyEventHandler KeyReleased
		{
			add { dispatcher.KeyReleased += value; }
			remove { dispatcher.KeyReleased -= value; }
		}
	}
}