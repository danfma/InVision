using System;
using InVision.OIS.Attributes;

namespace InVision.OIS.Components
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