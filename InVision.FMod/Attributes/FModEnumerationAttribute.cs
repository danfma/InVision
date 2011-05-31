using System;
using InVision.Native;

namespace InVision.FMod.Attributes
{
	public class FModEnumerationAttribute : CppEnumerationAttribute
	{
		public FModEnumerationAttribute(string name)
			: base(name)
		{
		}
	}
}