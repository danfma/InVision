using System;
using InVision.FMod.Native;

namespace InVision.FMod
{
	public class FModException : Exception
	{
		public FModException(RESULT result)
		{
			Result = result;
		}

		public RESULT Result { get; private set; }
	}
}