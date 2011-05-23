namespace Tutano
{
	public static class TutanoLauncher
	{
		public static void Run()
		{
			using (var tutano = new Tutano())
			{
				tutano.Initialize();
				tutano.Run();
			}
		}
	}
}