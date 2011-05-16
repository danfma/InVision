using System;
using System.Runtime.InteropServices;
using InVision.Native.Ext;

namespace InVision.OIS.Native
{
    [CppType("KeyEventDescriptor"), ValueObject]
    [StructLayout(LayoutKind.Sequential)]
    internal unsafe struct KeyEventDescriptor
    {
        private readonly EventArgDescriptor _base;
        private readonly KeyCode* _key;
        private readonly uint* _text;

        /// <summary>
        /// Gets the base.
        /// </summary>
        /// <value>The base.</value>
        public EventArgDescriptor Base
        {
            get { return _base; }
        }

        /// <summary>
        /// Gets the key.
        /// </summary>
        /// <value>The key.</value>
        public KeyCode Key
        {
            get { return *_key; }
        }

        /// <summary>
        /// Gets the text.
        /// </summary>
        /// <value>The text.</value>
        public char Char
        {
            get { return Convert.ToChar(*_text); }
        }
    }
}