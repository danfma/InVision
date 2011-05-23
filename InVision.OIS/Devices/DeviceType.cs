using InVision.OIS.Attributes;

namespace InVision.OIS.Devices
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