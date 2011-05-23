using InVision.OIS.Attributes;

namespace InVision.OIS.Devices
{
    [OISEnumeration("ComponentType")]
    public enum ComponentType
    {
        Unknown = 0,
        Button,
        Axis,
        Slider,
        POV,
        Vector3
    }
}