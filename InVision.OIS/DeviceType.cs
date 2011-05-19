using System;
using InVision.OIS.Attributes;

namespace InVision.OIS
{
    /// <summary>
    /// The OIS::Type enum
    /// </summary>
    [OISEnumeration("Type")]
    public enum DeviceType
    {
        Unknown = 0,
        Keyboard,
        Mouse,
        Joystick,
        Tablet
    }
}