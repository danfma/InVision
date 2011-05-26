using System;
using InVision.Framework.Config;
using InVision.GameMath;

namespace InVision.Framework
{
	public class DefaultGameFlow : IGameFlow
	{
		#region IGameFlow Members

		/// <summary>
		/// Runs the specified app.
		/// </summary>
		/// <param name="app">The app.</param>
		public void Run(GameApplication app)
		{
			var config = new Configuration {
				Screen = {
					Width = 800,
					Height = 600,
					BackgroundColor = Color.Black
				}
			};

			app.Configure(config);

			while (app.IsRunning)
			{
				var state = app.StateMachine.Current;

				if (state == null)
					break;

				app.BeginScene();
				{
					var gameTime = app.Timer;
					state.Update(gameTime);
				}
				app.EndScene();
			}
		}

		#endregion
	}
}