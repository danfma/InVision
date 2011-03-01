using System;
using System.Runtime.InteropServices;
using InVision.Input;

namespace InVision.Native.OIS
{
	internal sealed class NativeKeyboard : PlatformInvoke
	{
		[DllImport(Library, EntryPoint = "ois_keyboard_set_event_callback")]
		public static extern void SetEventCallback(IntPtr self, IntPtr dispatcherHandler);

		[DllImport(Library, EntryPoint = "ois_keyboard_is_key_down")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool IsKeyDown(
			IntPtr self,
			[MarshalAs(UnmanagedType.I4)] KeyCode key);

		[DllImport(Library, EntryPoint = "ois_keyboard_get_text_translation_mode")]
		public static extern TextTranslationMode GetTextTranslationMode(IntPtr self);

		[DllImport(Library, EntryPoint = "ois_keyboard_set_text_translation_mode")]
		public static extern void SetTextTranslationMode(IntPtr self, TextTranslationMode mode);

		[DllImport(Library, EntryPoint = "ois_keyboard_get_as_string")]
		[return: MarshalAs(UnmanagedType.LPStr)]
		public static extern string GetAsString(IntPtr self, KeyCode key);

		[DllImport(Library, EntryPoint = "ois_keyboard_is_modifier_down")]
		public static extern bool IsModifierDown(IntPtr self, Modifier modifier);

		[DllImport(Library, EntryPoint = "ois_keyboard_copy_key_states")]
		public static extern void CopyKeyStates(
			IntPtr self,
			[MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.I1)] ref bool[] states);
	}
}