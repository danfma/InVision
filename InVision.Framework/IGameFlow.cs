using System;

namespace InVision.Framework
{
	public interface IGameFlow
	{
		/// <summary>
		/// Runs the specified app.
		/// </summary>
		/// <param name="app">The app.</param>
		void Run(GameApplication app);
	}
}