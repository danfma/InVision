using System;
using System.Runtime.InteropServices;
using InVision.Native.Ext;
using InVision.OIS.Attributes;

namespace InVision.OIS.Native
{
    [OISInterface("MouseListener")]
    public interface IMouseListener : ICppInterface
    {
        [Constructor]
        IMouseListener MouseListener(
            MouseMovedHandler mouseMoved, 
            MouseClickHandler mousePressed,
            MouseClickHandler mouseReleased);

        [Destructor]
        void Dispose();
    }

    [return: MarshalAs(UnmanagedType.I1)]
    public delegate bool MouseMovedHandler(MouseEventDescriptor e);

    [return: MarshalAs(UnmanagedType.I1)]
    public delegate bool MouseClickHandler(MouseEventDescriptor e, MouseButton button);
}