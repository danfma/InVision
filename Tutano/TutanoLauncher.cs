namespace Tutano
{
	public static class TutanoLauncher
	{
		public static void Run()
		{
			using (var tutano = new TutanoApplication())
			{
				tutano.Run();
			}
		}
	}
}