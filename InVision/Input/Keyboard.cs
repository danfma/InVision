using System;
using InVision.Native.OIS;

namespace InVision.Input
{
	public class Keyboard : InputObject
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Keyboard"/> class.
		/// </summary>
		/// <param name="pSelf">The p self.</param>
		/// <param name="ownsHandle">if set to <c>true</c> [owns handle].</param>
		protected internal Keyboard(IntPtr pSelf, bool ownsHandle)
			: base(pSelf, ownsHandle)
		{
			EventDispatcher = new KeyEventDispatcher();
		}

		/// <summary>
		/// Gets or sets the event dispatcher.
		/// </summary>
		/// <value>The event dispatcher.</value>
		private KeyEventDispatcher EventDispatcher { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this instance has events enabled.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if this instance has events enabled; otherwise, <c>false</c>.
		/// </value>
		public bool HasEventsEnabled { get; private set; }

		/// <summary>
		/// Occurs when [key released].
		/// </summary>
		public event KeyEventHandler KeyReleased
		{
			add
			{
				EventDispatcher.KeyReleased += value;
				EnableEvents();
			}
			remove
			{
				EventDispatcher.KeyReleased -= value;
				DisableEvents();
			}
		}

		/// <summary>
		/// Occurs when [key pressed].
		/// </summary>
		public event KeyEventHandler KeyPressed
		{
			add
			{
				EventDispatcher.KeyPressed += value;
				EnableEvents();
			}
			remove
			{
				EventDispatcher.KeyPressed -= value;
				DisableEvents();
			}
		}

		/// <summary>
		/// Adds the specified item.
		/// </summary>
		/// <param name="item">The item.</param>
		public void Add(IKeyEventListener item)
		{
			EventDispatcher.Add(item);
			EnableEvents();
		}

		/// <summary>
		/// Removes the specified item.
		/// </summary>
		/// <param name="item">The item.</param>
		/// <returns></returns>
		public void Remove(IKeyEventListener item)
		{
			EventDispatcher.Remove(item);
			DisableEvents();
		}

		/// <summary>
		/// Releases the unmanaged resources used by the <see cref="T:System.Runtime.InteropServices.SafeHandle"/> class specifying whether to perform a normal dispose operation.
		/// </summary>
		/// <param name="disposing">true for a normal dispose operation; false to finalize the handle.</param>
		protected override void Dispose(bool disposing)
		{
			if (EventDispatcher != null)
				DisableEvents(true);

			base.Dispose(disposing);

			if (disposing)
				EventDispatcher = null;
		}

		/// <summary>
		/// Enables the events.
		/// </summary>
		private void EnableEvents()
		{
			if (HasEventsEnabled)
				return;

			NativeKeyboard.SetEventCallback(handle, EventDispatcher.DangerousGetHandle());
			HasEventsEnabled = true;
		}

		/// <summary>
		/// Disables the events.
		/// </summary>
		/// <param name="force">if set to <c>true</c> [force].</param>
		private void DisableEvents(bool force = false)
		{
			if (!HasEventsEnabled)
				return;

			if (EventDispatcher.HasListeners && !force)
				return;

			NativeKeyboard.SetEventCallback(handle, IntPtr.Zero);
			HasEventsEnabled = false;
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
		/// Gets or sets the translation mode.
		/// </summary>
		/// <value>The translation mode.</value>
		public TextTranslationMode TranslationMode
		{
			get { return NativeKeyboard.GetTextTranslationMode(handle); }
			set { NativeKeyboard.SetTextTranslationMode(handle, value); }
		}

		/// <summary>
		/// Gets as string.
		/// </summary>
		/// <param name="key">The key.</param>
		/// <returns></returns>
		public string GetAsString(KeyCode key)
		{
			return NativeKeyboard.GetAsString(handle, key);
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
		/// <param name="keys">The keys.</param>
		public void CopyKeyStates(bool[] keys)
		{
			if (keys.Length < 256)
				throw new InvalidOperationException("The key array length must be at least 256");

			NativeKeyboard.CopyKeyStates(handle, ref keys);
		}
	}
}