using System;
using System.Runtime.InteropServices;
using InVision.Native;
using InVision.OIS.Attributes;
using InVision.OIS.Devices;

namespace InVision.OIS.Native
{
	[OISClass("Keyboard", BaseType = typeof(IObject))]
	public interface IKeyboard : IObject
	{
		[Method(Implemented = true)]
		bool IsKeyDown(KeyCode keyCode);

		[Method(Implemented = true)]
		void SetEventCallback(ICustomKeyListener keyListener);

		[Method(Implemented = true)]
		ICustomKeyListener GetEventCallback();

		[Method(Implemented = true)]
		void SetTextTranslation(TextTranslationMode translationMode);

		[Method(Implemented = true)]
		TextTranslationMode GetTextTranslation();

		[Method(Implemented = true)]
		[return: MarshalAs(UnmanagedType.LPStr)]
		string GetAsString(KeyCode keyCode);

		[Method(Implemented = true)]
		bool IsModifierDown(Modifier modifier);

		[Method(Implemented = true)]
		void CopyKeyStates(
			[MarshalAs(UnmanagedType.LPArray, SizeConst = 256, ArraySubType = UnmanagedType.I1)] bool[] keys);
	}
}