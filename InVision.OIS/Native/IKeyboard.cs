using System;
using System.Runtime.InteropServices;
using InVision.Native.Ext;
using InVision.OIS.Attributes;

namespace InVision.OIS.Native
{
    [OISInterface("Keyboard", BaseType = typeof(IObject))]
    public interface IKeyboard : IObject
    {
        [Method]
        bool IsKeyDown(KeyCode keyCode);

        [Method]
        void SetEventCallback(ICustomKeyListener keyListener);

        [Method]
        ICustomKeyListener GetEventCallback();

        [Method]
        void SetTextTranslation(TextTranslationMode translationMode);

        [Method]
        TextTranslationMode GetTextTranslation();

        [Method]
        [return: MarshalAs(UnmanagedType.LPStr)]
        string GetAsString(KeyCode keyCode);

        [Method]
        bool IsModifierDown(Modifier modifier);

        [Method]
        void CopyKeyStates(
            [MarshalAs(UnmanagedType.LPArray, SizeConst = 256, ArraySubType = UnmanagedType.I1)] bool[] keys);
    }
}