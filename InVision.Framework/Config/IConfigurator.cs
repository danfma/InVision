namespace InVision.Framework.Config
{
	public interface IConfigurator
	{
		/// <summary>
		/// Configures the specified config.
		/// </summary>
		/// <param name="config">The config.</param>
		void Configure(FxConfiguration config);
	}
}