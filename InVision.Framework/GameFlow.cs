namespace InVision.Framework
{
	public abstract class GameFlow : IGameFlow
	{
		/// <summary>
		/// Runs the specified app.
		/// </summary>
		/// <param name="app">The app.</param>
		public abstract void Run(GameApplication app);
	}
}