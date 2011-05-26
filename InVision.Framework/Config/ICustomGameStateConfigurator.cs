namespace InVision.Framework.Config
{
	public interface ICustomGameStateConfigurator
	{
		/// <summary>
		/// Configures the specified states.
		/// </summary>
		/// <param name="states">The states.</param>
		void Configure(GameStateMachine states);
	}
}