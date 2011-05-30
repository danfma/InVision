using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
