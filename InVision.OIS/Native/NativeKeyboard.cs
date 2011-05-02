using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace InVision.OIS.Native
{
	internal class NativeKeyboard : NativeOIS
	{
		private static sbyte[] _buffer = new sbyte[256];

		/// <summary>
		/// Initializes the <see cref="NativeKeyboard"/> class.
		/// </summary>
		static NativeKeyboard()
		{
			Init();
		}

		[DllImport(OISLibrary, EntryPoint = "ois_keyboard_is_key_down")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool IsKeyDown(IntPtr self, KeyCode keyCode);

		[DllImport(OISLibrary, EntryPoint = "ois_keyboard_set_event_callback")]
		public static extern void SetEventCallback(IntPtr self, IntPtr keyListener);

		[DllImport(OISLibrary, EntryPoint = "ois_keyboard_get_text_translation")]
		public static extern TextTranslationMode GetTextTranslationMode(IntPtr self);

		[DllImport(OISLibrary, EntryPoint = "ois_keyboard_set_text_translation")]
		public static extern void SetTextTranslationMode(IntPtr self, TextTranslationMode value);

		[DllImport(OISLibrary, EntryPoint = "ois_keyboard_get_as_string")]
		public static extern string GetAsString(IntPtr self, KeyCode keyCode);

		[DllImport(OISLibrary, EntryPoint = "ois_keyboard_is_modifier_down")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool IsModifierDown(IntPtr self, Modifier modifier);

		[DllImport(OISLibrary, EntryPoint = "ois_keyboard_copy_key_states")]
		public static extern void CopyKeyStates(IntPtr self, ref sbyte[] keys);

		[MethodImpl(MethodImplOptions.Synchronized)]
		public static void CopyKeyStates(IntPtr self, bool[] keys)
		{
			CopyKeyStates(self, ref _buffer);

			Parallel.For(0, _buffer.Length, i => { keys[i] = _buffer[i] != 0; });
		}
	}
}