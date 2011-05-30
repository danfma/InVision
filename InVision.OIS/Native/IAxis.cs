using InVision.Native;

namespace InVision.OIS.Native
{
	[CppClass("Axis", Namespace = "OIS", DefinitionFile = "OIS.h", BaseType = typeof(IComponent))]
	public interface IAxis : IComponent
	{
		[Constructor(Implemented = true)]
		IAxis Construct(ref AxisDescriptor descriptor);
	}
}