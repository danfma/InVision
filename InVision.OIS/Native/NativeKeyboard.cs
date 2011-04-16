using System;
using System.Runtime.InteropServices;

namespace InVision.OIS.Native
{
	internal class NativeKeyboard : NativeOIS
	{
		/// <summary>
		/// Initializes the <see cref="NativeKeyboard"/> class.
		/// </summary>
		static NativeKeyboard()
		{
			Init();
		}

		[DllImport(OISLibrary, EntryPoint = "ois_keyboard_is_key_down")]
		public static extern bool IsKeyDown(IntPtr self, KeyCode keyCode);

		[DllImport(OISLibrary, EntryPoint = "ois_keyboard_set_event_callback")]
		public static extern void SetEventCallback(IntPtr self, IntPtr keyListener);

		[DllImport(OISLibrary, EntryPoint = "ois_keyboard_get_text_translation_mode")]
		public static extern TextTranslationMode GetTextTranslationMode(IntPtr self);

		[DllImport(OISLibrary, EntryPoint = "ois_keyboard_set_text_translation_mode")]
		public static extern void SetTextTranslationMode(IntPtr self, TextTranslationMode value);

		[DllImport(OISLibrary, EntryPoint = "ois_keyboard_get_as_string")]
		public static extern string GetAsString(IntPtr self, KeyCode keyCode);

		[DllImport(OISLibrary, EntryPoint = "ois_keyboard_is_modifier_down")]
		public static extern bool IsModifierDown(IntPtr self, Modifier modifier);

		[DllImport(OISLibrary, EntryPoint = "ois_keyboard_copy_key_states")]
		public static extern void CopyKeyStates(IntPtr self, ref byte[] keys);

		public static void CopyKeyStates(IntPtr self, ref bool[] keys)
		{
			var buffer = new byte[256];

			CopyKeyStates(self, ref buffer);

			for (int i = 0; i < buffer.Length; i++)
			{
				keys[i] = buffer[i] != 0;
			}
		}
	}
}