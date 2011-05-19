using System;
using System.Runtime.InteropServices;
using InVision.OIS.Attributes;

namespace InVision.OIS.Native
{
    [OISDescriptor]
    [StructLayout(LayoutKind.Sequential)]
    public struct MouseEventDescriptor
    {
        public EventArgDescriptor Base;
        public MouseStateDescriptor MouseState;
    }
}