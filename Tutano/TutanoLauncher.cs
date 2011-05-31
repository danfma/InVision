namespace Tutano
{
	public class TutanoLauncher
	{
		/// <summary>
		/// Runs this instance.
		/// </summary>
		public void Run()
		{
			using (var tutano = new Core.Tutano()) {
				tutano.Run();
			}
		}
	}
}