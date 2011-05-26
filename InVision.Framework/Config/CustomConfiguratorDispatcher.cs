using System.Collections.Generic;
using System.Linq;

namespace InVision.Framework.Config
{
	public sealed class CustomConfiguratorDispatcher : ICustomConfigurator
	{
		private readonly ICustomConfigurator[] _customConfigurators;

		/// <summary>
		/// Initializes a new instance of the <see cref="CustomConfiguratorDispatcher"/> class.
		/// </summary>
		/// <param name="configurators">The configurators.</param>
		public CustomConfiguratorDispatcher(IEnumerable<ICustomConfigurator> configurators)
		{
			_customConfigurators = configurators.ToArray();
		}

		/// <summary>
		/// Configures the specified config.
		/// </summary>
		/// <param name="config">The config.</param>
		public void Configure(Configuration config)
		{
			foreach (var configurator in _customConfigurators)
			{
				configurator.Configure(config);
			}
		}
	}
}