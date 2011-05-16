using InVision.Native.Ext;

namespace InVision.GenOIS
{
	[CppEnumerationAttribute(Namespace = "OIS")]
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