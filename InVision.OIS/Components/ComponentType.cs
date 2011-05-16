using InVision.Native.Ext;

namespace InVision.OIS.Components
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