using System;

namespace InVision.Framework.Config
{
	public interface ICustomConfigurator
	{
		/// <summary>
		/// Configures the specified config.
		/// </summary>
		/// <param name="config">The config.</param>
		void Configure(Configuration config);
	}
}