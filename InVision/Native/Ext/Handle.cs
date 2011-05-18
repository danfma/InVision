using System;
using System.Runtime.InteropServices;

namespace InVision.Native.Ext
{
    [StructLayout(LayoutKind.Explicit, Size = sizeof(uint))]
    public struct Handle
    {
        [FieldOffset(0)]
        private readonly uint _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="Handle"/> struct.
        /// </summary>
        /// <param name="value">The value.</param>
        public Handle(uint value)
        {
            _value = value;
        }

        /// <summary>
        /// Gets the handle.
        /// </summary>
        /// <value>The handle.</value>
        public uint Value
        {
            get { return _value; }
        }

        /// <summary>
        /// The type's id of this handle on the native side.
        /// </summary>
        public ushort TypeCode
        {
            get { return (ushort)_value; }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is valid.
        /// </summary>
        /// <value><c>true</c> if this instance is valid; otherwise, <c>false</c>.</value>
        public bool IsValid
        {
            get { return _value > 0; }
        }
    }
}