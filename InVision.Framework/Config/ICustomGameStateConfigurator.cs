using InVision.Framework.States;

namespace InVision.Framework.Config
{
	public interface ICustomGameStateConfigurator
	{
		/// <summary>
		/// Configures the specified app.
		/// </summary>
		/// <param name="app">The app.</param>
		/// <param name="states">The states.</param>
		void Configure(GameApplication app, GameStateMachine states);
	}
}