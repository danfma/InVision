using InVision.Native;

namespace InVision.FMod.Attributes
{
	public class FModClassAttribute : CppClassAttribute
	{
		public FModClassAttribute(string name)
			: base(name)
		{
			Namespace = "FMOD";

		}
	}
}