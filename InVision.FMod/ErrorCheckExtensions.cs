using InVision.FMod.Native;

namespace InVision.FMod
{
	public static class ErrorCheckExtensions
	{
		public static void Check(this RESULT result)
		{
			if (result != RESULT.OK)
				throw new FModException(result);
		}
	}
}