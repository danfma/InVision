using System.Collections.Generic;
using System.Linq;

namespace InVision.Framework.Config
{
	public sealed class ConfiguratorDispatcher : IConfigurator
	{
		private readonly IConfigurator[] _configurators;

		/// <summary>
		/// Initializes a new instance of the <see cref="ConfiguratorDispatcher"/> class.
		/// </summary>
		/// <param name="configurators">The configurators.</param>
		public ConfiguratorDispatcher(IEnumerable<IConfigurator> configurators)
		{
			_configurators = configurators.ToArray();
		}

		/// <summary>
		/// Configures the specified config.
		/// </summary>
		/// <param name="config">The config.</param>
		public void Configure(FxConfiguration config)
		{
			foreach (var configurator in _configurators)
			{
				configurator.Configure(config);
			}
		}
	}
}